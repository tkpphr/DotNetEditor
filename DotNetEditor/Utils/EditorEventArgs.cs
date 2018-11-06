using System;

namespace DotNetEditor.Utils
{
	public class EditorEventArgs : EventArgs
	{
		public bool CanUndo { get; set; }
		public bool CanRedo { get; set; }
		public int UndoCount { get; set; }
		public int RedoCount { get; set; }

		public EditorEventArgs(bool canUndo,bool canRedo,int undoCount,int redoCount)
		{
			CanUndo = canUndo;
			CanRedo = canRedo;
			UndoCount = undoCount;
			RedoCount = redoCount;
		}
	}
}
