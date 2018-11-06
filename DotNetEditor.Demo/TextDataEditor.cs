using DotNetEditor.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetEditor.Demo
{
	public class TextDataEditor : Editor<TextData>
	{
		public TextDataEditor() : base(new TextData(),"Text Files (*.txt)|*.txt",true,false)
		{
			
		}

		protected override TextData CreateNew()
		{
			return new TextData();
		}

		protected override TextData Open(string filePath)
		{
			string text;
			using (var fileStream=new FileStream(filePath,FileMode.Open))
			{
				try
				{
					byte[] buffer = new byte[fileStream.Length];
					fileStream.Read(buffer, 0, buffer.Length);
					text = Encoding.Default.GetString(buffer);
				}
				catch(IOException e)
				{
					Console.WriteLine(e.StackTrace);
					return null;
				}
			}
			return new TextData(filePath,text);
		}

		protected override bool Save(string savePath)
		{
			if (File.Exists(FileData.FilePath))
			{
				if (MessageBox.Show(null, "Text", "Text", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return false;
				}
			}
			using (var fileStream = new FileStream(savePath, FileMode.Create))
			{
				try
				{
					byte[] text = Encoding.Default.GetBytes(FileData.Text);
					fileStream.Write(text,0,text.Length);
				}
				catch (IOException e)
				{
					Console.WriteLine(e.StackTrace);
					return false;
				}
			}
			return true;
		}

		protected override bool SaveAs(string savePath)
		{
			return Save(savePath);
		}
	}
}
