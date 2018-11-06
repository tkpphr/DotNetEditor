﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetEditor.GUI.Forms
{
	internal partial class SaveConfirmationDialog : Form
    {
        public SaveConfirmationDialog()
        {
            InitializeComponent();
			Text = Application.ProductName;
			IconPictureBox.Image = SystemIcons.Question.ToBitmap();
        }

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			IconPictureBox.Image?.Dispose();
		}

		private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void CancelSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
