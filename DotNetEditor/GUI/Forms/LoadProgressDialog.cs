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
using DotNetEditor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetEditor.GUI.Forms
{
	internal partial class LoadProgressDialog : Form
	{

		public LoadProgressDialog()
		{
			InitializeComponent();
		}

		private void LoadProgressDialog_Shown(object sender, EventArgs e)
		{
			
		}

		public static T Show<T>(Func<T> loadFunc) where T:FileData
		{
			T fileData=null;
			using (var dialog=new LoadProgressDialog())
			{
				dialog.Shown += async (sender,e) =>
				{
					fileData=await Task.Run(() => loadFunc.Invoke());
					dialog.Close();
				};
				dialog.ShowDialog();
				return fileData;
			}
		}
	}
}
