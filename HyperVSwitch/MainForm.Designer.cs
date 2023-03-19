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
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.refreshButton = new System.Windows.Forms.Button();
			this.toggleButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
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
			this.infoLabel.Location = new System.Drawing.Point(6, 22);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(56, 15);
			this.infoLabel.TabIndex = 3;
			this.infoLabel.TabStop = true;
			this.infoLabel.Text = "infoLabel";
			this.infoLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InfoLabel_LinkClicked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Press F1 for help.";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.infoLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 190);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(379, 44);
			this.panel1.TabIndex = 5;
			// 
			// refreshButton
			// 
			this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.refreshButton.Location = new System.Drawing.Point(44, 135);
			this.refreshButton.Margin = new System.Windows.Forms.Padding(35, 3, 35, 3);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(291, 31);
			this.refreshButton.TabIndex = 6;
			this.refreshButton.Text = "refreshButton";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// toggleButton
			// 
			this.toggleButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.toggleButton.Location = new System.Drawing.Point(44, 98);
			this.toggleButton.Margin = new System.Windows.Forms.Padding(35, 3, 35, 3);
			this.toggleButton.Name = "toggleButton";
			this.toggleButton.Size = new System.Drawing.Size(291, 31);
			this.toggleButton.TabIndex = 7;
			this.toggleButton.Text = "toggleButton";
			this.toggleButton.UseVisualStyleBackColor = true;
			this.toggleButton.Click += new System.EventHandler(this.toggleButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(379, 234);
			this.Controls.Add(this.toggleButton);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.actionButton);
			this.Controls.Add(this.statusLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Hyper-V Switch";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button actionButton;
		private System.Windows.Forms.LinkLabel infoLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Button toggleButton;
	}
}

