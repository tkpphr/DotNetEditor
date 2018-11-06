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
