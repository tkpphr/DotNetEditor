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
