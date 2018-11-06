namespace DotNetEditor.GUI.Forms
{
	partial class SaveProgressDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveProgressDialog));
			this.IconPictureBox = new System.Windows.Forms.PictureBox();
			this.LabelMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// IconPictureBox
			// 
			resources.ApplyResources(this.IconPictureBox, "IconPictureBox");
			this.IconPictureBox.Image = global::DotNetEditor.Properties.Resources.Progress;
			this.IconPictureBox.Name = "IconPictureBox";
			this.IconPictureBox.TabStop = false;
			// 
			// LabelMessage
			// 
			resources.ApplyResources(this.LabelMessage, "LabelMessage");
			this.LabelMessage.Name = "LabelMessage";
			// 
			// SaveProgressDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ControlBox = false;
			this.Controls.Add(this.IconPictureBox);
			this.Controls.Add(this.LabelMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveProgressDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox IconPictureBox;
		private System.Windows.Forms.Label LabelMessage;
	}
}