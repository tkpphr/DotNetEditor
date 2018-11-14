/*
Copyright 2018 tkpphr

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;

namespace DotNetEditor.Utils
{
	public class EditorCommandStack
    {
        private Stack<EditorCommand> _UndoStack;
        private Stack<EditorCommand> _RedoStack;
        public int UndoCount => _UndoStack.Count;
        public int RedoCount => _RedoStack.Count;
        public bool CanUndo => UndoCount > 0;
        public bool CanRedo => RedoCount > 0;
        public event Action<EditorEventArgs> StackCountChanged;

        public EditorCommandStack()
        {
            _UndoStack = new Stack<EditorCommand>();
            _RedoStack = new Stack<EditorCommand>();
        }

        public void Do(EditorCommand command)
        {
            command.Do?.Invoke();
            _UndoStack.Push(command);
            _RedoStack.Clear();
            StackCountChanged?.Invoke(new EditorEventArgs(CanUndo,CanRedo,UndoCount,RedoCount));
        }

        public void Undo()
        {
            if (!CanUndo)
            {
                return;
            }
            EditorCommand command = _UndoStack.Pop();
            command.Undo?.Invoke();
            _RedoStack.Push(command);
			StackCountChanged?.Invoke(new EditorEventArgs(CanUndo, CanRedo, UndoCount, RedoCount));
		}

        public void Redo()
        {
            if (!CanRedo)
            {
                return;
            }
            EditorCommand command = _RedoStack.Pop();
            command.Redo?.Invoke();
            _UndoStack.Push(command);
			StackCountChanged?.Invoke(new EditorEventArgs(CanUndo, CanRedo, UndoCount, RedoCount));
		}

        public void Clear()
        {
            _UndoStack.Clear();
            _RedoStack.Clear();
			StackCountChanged?.Invoke(new EditorEventArgs(CanUndo, CanRedo, UndoCount, RedoCount));
		}
    }
}
