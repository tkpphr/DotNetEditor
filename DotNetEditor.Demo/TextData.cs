using DotNetEditor.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetEditor.Demo
{
	public class TextData : FileData
	{
		public string Text { get; set; }
		private FileStream FileStream { get; set; }

		public TextData() : base()
		{
			Text = "";
		}

		public TextData(string path,string text) : base(path)
		{
			Text = text;
		}

		public override void Lock()
		{
			if (!File.Exists(FilePath))
			{
				return;
			}
			Unlock();
			try
			{
				FileStream = new FileStream(FilePath,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
			}
			catch(IOException e)
			{
				Console.WriteLine(e);
			}
		}

		public override void Unlock()
		{
			FileStream?.Close();
			FileStream = null;
		}
	}
}
