using DotNetEditor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace DotNetEditor.Demo
{
	public static class TextEditorCommand
	{
		public static void SetText(Subject<object> subject,string oldText,string newText)
		{
			if (oldText==newText)
			{
				return;
			}
			var editorCommand = new EditorCommand(
				()=>
				{
					subject.OnNext(newText);
				}
				,
				()=>
				{
					subject.OnNext(oldText);
				}
				,
				()=>
				{
					subject.OnNext(newText);
				});
			subject.OnNext(editorCommand);
		}
	}
}
