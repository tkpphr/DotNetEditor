namespace DotNetEditor.GUI.Forms
{
	partial class SaveFailureDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveFailureDialog));
			this.panel1 = new System.Windows.Forms.Panel();
			this.IconPictureBox = new System.Windows.Forms.PictureBox();
			this.LabelMessage = new System.Windows.Forms.Label();
			this.OKButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.IconPictureBox);
			this.panel1.Controls.Add(this.LabelMessage);
			this.panel1.Name = "panel1";
			// 
			// IconPictureBox
			// 
			resources.ApplyResources(this.IconPictureBox, "IconPictureBox");
			this.IconPictureBox.Name = "IconPictureBox";
			this.IconPictureBox.TabStop = false;
			// 
			// LabelMessage
			// 
			resources.ApplyResources(this.LabelMessage, "LabelMessage");
			this.LabelMessage.Name = "LabelMessage";
			// 
			// OKButton
			// 
			resources.ApplyResources(this.OKButton, "OKButton");
			this.OKButton.Name = "OKButton";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// SaveFailureDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.OKButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveFailureDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox IconPictureBox;
		private System.Windows.Forms.Label LabelMessage;
		private System.Windows.Forms.Button OKButton;
	}
}