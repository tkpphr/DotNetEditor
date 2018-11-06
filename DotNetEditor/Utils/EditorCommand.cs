using System;

namespace DotNetEditor.Utils
{
	public class EditorCommand
    {
        public Action Do { get; private set; }
        public Action Undo { get; private set; }
        public Action Redo { get; private set; }

        public EditorCommand(Action doAction, Action undoAction)
        {
            Do = doAction;
            Undo = undoAction;
            Redo = doAction;
        }

        public EditorCommand(Action doAction,Action undoAction,Action redoAction)
        {
            Do = doAction;
            Undo = undoAction;
            Redo = redoAction;
        }

    }
}
