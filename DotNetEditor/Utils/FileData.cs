using System.IO;

namespace DotNetEditor.Utils
{
	public abstract class FileData
    {
        public string FilePath { get; set; }
        public string FullFileName => Path.GetFileName(FilePath);
		public string FileName => Path.GetFileNameWithoutExtension(FilePath);
		public string FileExtension => Path.GetExtension(FilePath);

		public FileData()
        {
            FilePath = Properties.Resources.Untitled;
        }

        public FileData(string filePath)
        {
            FilePath = filePath;
        }

		public abstract void Lock();

		public abstract void Unlock();

    }
}
