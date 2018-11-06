namespace DotNetEditor.GUI.Forms
{
	partial class SaveConfirmationDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveConfirmationDialog));
			this.YesButton = new System.Windows.Forms.Button();
			this.NoButton = new System.Windows.Forms.Button();
			this.CancelSaveButton = new System.Windows.Forms.Button();
			this.LabelMessage = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.IconPictureBox = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// YesButton
			// 
			resources.ApplyResources(this.YesButton, "YesButton");
			this.YesButton.Name = "YesButton";
			this.YesButton.UseVisualStyleBackColor = true;
			this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
			// 
			// NoButton
			// 
			resources.ApplyResources(this.NoButton, "NoButton");
			this.NoButton.Name = "NoButton";
			this.NoButton.UseVisualStyleBackColor = true;
			this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
			// 
			// CancelSaveButton
			// 
			resources.ApplyResources(this.CancelSaveButton, "CancelSaveButton");
			this.CancelSaveButton.Name = "CancelSaveButton";
			this.CancelSaveButton.UseVisualStyleBackColor = true;
			this.CancelSaveButton.Click += new System.EventHandler(this.CancelSaveButton_Click);
			// 
			// LabelMessage
			// 
			resources.ApplyResources(this.LabelMessage, "LabelMessage");
			this.LabelMessage.Name = "LabelMessage";
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel1.Controls.Add(this.NoButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.YesButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.CancelSaveButton, 2, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// IconPictureBox
			// 
			resources.ApplyResources(this.IconPictureBox, "IconPictureBox");
			this.IconPictureBox.Name = "IconPictureBox";
			this.IconPictureBox.TabStop = false;
			// 
			// SaveConfirmationDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ControlBox = false;
			this.Controls.Add(this.IconPictureBox);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.LabelMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SaveConfirmationDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Button CancelSaveButton;
        private System.Windows.Forms.Label LabelMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox IconPictureBox;
    }
}