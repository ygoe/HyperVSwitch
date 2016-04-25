namespace HyperVSwitch
{
	partial class MainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusLabel = new System.Windows.Forms.Label();
			this.actionButton = new System.Windows.Forms.Button();
			this.infoLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// statusLabel
			// 
			this.statusLabel.Location = new System.Drawing.Point(12, 9);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(355, 49);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "statusLabel";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.statusLabel.UseMnemonic = false;
			// 
			// actionButton
			// 
			this.actionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.actionButton.Location = new System.Drawing.Point(44, 61);
			this.actionButton.Margin = new System.Windows.Forms.Padding(35, 3, 35, 3);
			this.actionButton.Name = "actionButton";
			this.actionButton.Size = new System.Drawing.Size(291, 31);
			this.actionButton.TabIndex = 1;
			this.actionButton.Text = "actionButton";
			this.actionButton.UseVisualStyleBackColor = true;
			this.actionButton.Click += new System.EventHandler(this.ActionButton_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.infoLabel.Location = new System.Drawing.Point(12, 121);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(56, 15);
			this.infoLabel.TabIndex = 3;
			this.infoLabel.TabStop = true;
			this.infoLabel.Text = "infoLabel";
			this.infoLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InfoLabel_LinkClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(379, 145);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.actionButton);
			this.Controls.Add(this.statusLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Hyper-V Switch";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button actionButton;
		private System.Windows.Forms.LinkLabel infoLabel;
	}
}

