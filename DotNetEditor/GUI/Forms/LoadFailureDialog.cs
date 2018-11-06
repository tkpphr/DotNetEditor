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
	public partial class LoadFailureDialog : Form
	{
		public LoadFailureDialog()
		{
			InitializeComponent();
			IconPictureBox.Image = SystemIcons.Error.ToBitmap();
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			IconPictureBox.Image?.Dispose();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
