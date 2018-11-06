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
	internal partial class SaveProgressDialog : Form
	{

		public SaveProgressDialog()
		{
			InitializeComponent();
		}

		public static bool Show(Func<bool> saveFunc)
		{
			bool isSucceed = false;
			using (var dialog=new SaveProgressDialog())
			{
				dialog.Shown += async (sender, e) =>
				{
					isSucceed = await Task.Run(() => saveFunc.Invoke());
					dialog.Close();
				};
				dialog.ShowDialog();
				return isSucceed;
			}
		}
		
	}
}
