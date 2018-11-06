using DotNetEditor.GUI.Forms;
using DotNetEditor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetEditor.Demo
{
	public partial class MainForm : Form
	{
		private TextDataEditor TextDataEditor { get; set; }
		private Subject<object> Subject { get; set; }

		public MainForm()
		{
			InitializeComponent();
			TextDataEditor = new TextDataEditor();
			TextDataEditor.FileDataChanged += TextDataEditor_FileDataChanged;
			TextDataEditor.SaveFinished += TextDataEditor_SaveFinished;
			TextDataEditor.EditorStackCountChanged += TextDataEditor_EditorStackCountChanged; ;
			Subject = new Subject<object>();
			Subject.Subscribe(obj =>
			{
				if (obj is string)
				{
					string text = (string)obj;
					if (text != TextDataEditor.FileData.Text)
					{
						TextDataEditor.FileData.Text = text;
					}
					if (EditorTextBox.Text != TextDataEditor.FileData.Text)
					{
						EditorTextBox.Text = TextDataEditor.FileData.Text;
					}
				}
				else if (obj is EditorCommand)
				{
					TextDataEditor.Do((EditorCommand)obj);
				}
			});
			RefreshView();

		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			e.Cancel = !TextDataEditor.Exit();
		}

		private void RefreshView()
		{
			Text = string.Format("{0} - {1}", TextDataEditor.Title, Application.ProductName);
			UndoToolStripMenuItem.Enabled = TextDataEditor.CanUndo;
			RedoToolStripMenuItem.Enabled = TextDataEditor.CanRedo;
			SaveToolStripMenuItem.Enabled = TextDataEditor.CanSave;
			if (TextDataEditor.FileData.Text != EditorTextBox.Text)
			{
				EditorTextBox.Text = TextDataEditor.FileData.Text;
			}
		}

		private void TextDataEditor_EditorStackCountChanged(EditorEventArgs obj)
		{
			RefreshView();
		}

		private void TextDataEditor_SaveFinished(TextData arg1, bool arg2)
		{
			RefreshView();
		}

		private void TextDataEditor_FileDataChanged(TextData obj)
		{
			RefreshView();
		}

		private void CreateNewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!TextDataEditor.CreateNewFile())
			{
				using (var dialog = new CancelCreateNewDialog())
				{
					dialog.ShowDialog(this);
				}
			}
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!TextDataEditor.OpenFile())
			{
				using (var dialog = new LoadFailureDialog())
				{
					dialog.ShowDialog(this);
				}
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!TextDataEditor.SaveFile())
			{
				using (var dialog = new SaveFailureDialog())
				{
					dialog.ShowDialog(this);
				}
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(!TextDataEditor.SaveAsFile())
			{
				using (var dialog = new SaveFailureDialog())
				{
					dialog.ShowDialog(this);
				}
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextDataEditor.Undo();
		}

		private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TextDataEditor.Redo();
		}

		private void EditorTextBox_TextChanged(object sender, EventArgs e)
		{
			TextEditorCommand.SetText(Subject, TextDataEditor.FileData.Text, EditorTextBox.Text);
		}

	}
}
