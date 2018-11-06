using DotNetEditor.GUI.Forms;
using DotNetEditor.Properties;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetEditor.Utils
{
	public abstract class Editor<T> where T : FileData
	{
		private T _FileData;
		public T FileData
		{
			get => _FileData;
			private set
			{
				if (value != null)
				{
					if (_FileData != value)
					{
						_FileData?.Unlock();
						_FileData = value;
						_FileData.Lock();
						EditorCommandStack.Clear();
						DataChangedPoint = 0;
						FileDataChanged?.Invoke(FileData);
					}
					
				}
			}
		}
		public int DataChangedPoint { get; private set; }
		public bool IsDataChanged => EditorCommandStack.UndoCount != DataChangedPoint;
		public bool CanSave => FileData != null && File.Exists(FileData.FilePath) && IsDataChanged;
		public bool CanSaveAs => FileData != null;
		public bool CanUndo => EditorCommandStack.CanUndo;
		public bool CanRedo => EditorCommandStack.CanRedo;
		public string Title
		{
			get
			{
				if (FileData == null)
				{
					return Application.ProductName;
				}
				else
				{
					return string.Format("{0}{1}", IsDataChanged ? "*" : "", FileData.FileName);
				}
			}
		}
		public event Action<T> FileDataChanged;
		public event Action<T,bool> SaveFinished;
		public event Action<EditorEventArgs> EditorStackCountChanged;
		private EditorCommandStack EditorCommandStack { get; set; } = new EditorCommandStack();
		private readonly bool _ShowProgress;
		private readonly bool _SaveAfterUndo;
		private readonly string _FileFilter;

		public Editor(string fileFilter,bool saveAfterUndo, bool showProgress=false)
		{
			_FileFilter = fileFilter;
			_SaveAfterUndo = saveAfterUndo;
			_ShowProgress = showProgress;
			DataChangedPoint = 0;			
			EditorCommandStack.StackCountChanged += EditorCommandStack_StackCountChanged;
		}

		public Editor(T fileData,string fileFilter,bool saveAfterUndo, bool showProgress = false) : this(fileFilter,saveAfterUndo,showProgress)
		{
			FileData = fileData;
		}

		public Editor(string filePath, string fileFilter, bool saveAfterUndo, bool showProgress = false) : this(fileFilter,saveAfterUndo,showProgress)
		{
			FileData= _ShowProgress ? LoadProgressDialog.Show(() => Open(filePath)) : Open(filePath);
		}

		public void SetFileData(string filePath)
		{
			if (FileData!=null)
			{
				if (ConfirmSave()==DialogResult.Cancel)
				{
					return;
				}
			}
			var fileData = _ShowProgress ? LoadProgressDialog.Show(() => Open(filePath)) : Open(filePath);
			if (fileData == null)
			{
				using (var dialog = new LoadFailureDialog())
				{
					dialog.ShowDialog();
				}
				FileData?.Lock();
			}
			else
			{
				FileData = fileData;
			}
		}

		public void SetFileData(T fileData)
		{
			if (FileData != null)
			{
				if (ConfirmSave() == DialogResult.Cancel)
				{
					return;
				}
			}
			FileData = fileData;
		}

		public void Do(EditorCommand editorCommand)
		{
			EditorCommandStack.Do(editorCommand);
		}

		public void Undo()
		{
			EditorCommandStack.Undo();
		}

		public void Redo()
		{
			EditorCommandStack.Redo();
		}

		public bool CreateNewFile()
		{
			T fileData;
			if (FileData==null)
			{
				fileData = CreateNew();
			}
			else
			{
				if (ConfirmSave()!=DialogResult.Cancel)
				{
					fileData = CreateNew();
				}
				else
				{
					fileData=null;
				}
			}

			if (fileData==null)
			{
				return false;
			}
			else
			{
				FileData = fileData;
				return true;
			}
		}

		public bool OpenFile()
		{
			DialogResult dialogResult = ConfirmSave();
			if (dialogResult==DialogResult.Cancel)
			{
				return false;
			}
			string filePath;
			using (var dialog = new OpenFileDialog() { Title = Resources.Open, Filter = _FileFilter, Multiselect = false })
			{
				dialog.Title = Resources.Open;
				dialog.Filter = _FileFilter;
				dialog.Multiselect = false;
				if (dialog.ShowDialog()==DialogResult.Cancel)
				{
					return false;
				}
				filePath = dialog.FileName;
			}
			FileData?.Unlock();
			T fileData = _ShowProgress ? LoadProgressDialog.Show(() => Open(filePath)) : Open(filePath);
			if (fileData == null)
			{
				FileData?.Lock();
				return false;
			}
			else
			{
				FileData = fileData;
				return true;
			}
		}

		public bool SaveFile()
		{
			if (FileData == null)
			{
				return false;
			}
			else
			{
				FileData.Unlock();
				bool isSaved;
				if (_ShowProgress)
				{
					isSaved = SaveProgressDialog.Show(() => Save(FileData.FilePath));
				}
				else
				{
					isSaved = Save(FileData.FilePath);
				}

				if (isSaved)
				{
					if (!_SaveAfterUndo)
					{
						EditorCommandStack.Clear();
					}
					DataChangedPoint = EditorCommandStack.UndoCount;
				}
				FileData.Lock();
				SaveFinished?.Invoke(FileData, isSaved);
				return isSaved;
			}
		}

		public bool SaveAsFile()
		{
			if (FileData == null)
			{
				return false;
			}
			else
			{
				var fileName = string.IsNullOrEmpty(FileData.FileName) ? Resources.Untitled : FileData.FileName;
				string filePath;
				using (var dialog=new SaveFileDialog() { Title=Resources.SaveAs,Filter=_FileFilter,FileName=fileName})
				{
					if (dialog.ShowDialog()==DialogResult.Cancel)
					{
						return false;
					}
					filePath = dialog.FileName;
				}
				FileData.Unlock();
				bool isSaved;
				if(_ShowProgress)
				{
					isSaved = SaveProgressDialog.Show(() => File.Exists(filePath) ? Save(filePath) : SaveAs(filePath));
				}
				else
				{
					isSaved = File.Exists(filePath) ? Save(filePath) : SaveAs(filePath);
				}

				if (isSaved)
				{
					FileData.FilePath=filePath;
					if (!_SaveAfterUndo) {
						EditorCommandStack.Clear();
					}
					DataChangedPoint = EditorCommandStack.UndoCount;
				}
				FileData.Lock();
				SaveFinished?.Invoke(FileData, isSaved);
				return isSaved;
			}
		}

		public bool CloseFile()
		{
			if (ConfirmSave()==DialogResult.Cancel)
			{
				return false;
			}
			FileData?.Unlock();
			FileData = null;
			EditorCommandStack.Clear();
			DataChangedPoint = 0;
			return true;
		}

		public bool Exit()
		{
			if (ConfirmSave() != DialogResult.Cancel)
			{
				FileData?.Unlock();
				return true;
			}
			else
			{
				return false;
			}
		}

		private DialogResult ConfirmSave()
		{
			if (!IsDataChanged || FileData == null)
			{
				return DialogResult.No;
			}
			DialogResult dialogResult;
			using (var dialog=new SaveConfirmationDialog())
			{
				dialogResult = dialog.ShowDialog();
				if (dialogResult == DialogResult.Yes)
				{
					if (File.Exists(FileData.FilePath))
					{
						return SaveFile() ? DialogResult.Yes : DialogResult.Cancel;
					}
					else
					{
						return SaveAsFile() ? DialogResult.Yes : DialogResult.Cancel;
					}
				}
				else
				{
					return dialogResult;
				}
			}
		}

		private void EditorCommandStack_StackCountChanged(EditorEventArgs e)
		{
			EditorStackCountChanged?.Invoke(e);
		}

		protected abstract T CreateNew();
		protected abstract T Open(string filePath);
		protected abstract bool Save(string savePath);
		protected abstract bool SaveAs(string savePath);
	}
}
