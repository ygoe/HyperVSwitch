using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HyperVSwitch
{
	public partial class MainForm : Form
	{
		#region Private fields

		private bool? isHyperVActive;
		private bool? isHyperVRunning;
		private bool justRestart;

		#endregion Private fields

		#region Constructors

		public MainForm()
		{
			InitializeComponent();

			isHyperVActive = GetHyperVStatus();
			isHyperVRunning = GetHyperVRunning();

			if (isHyperVActive == true)
			{
				statusLabel.Text = "Hyper-V is ACTIVE.";
				statusLabel.ForeColor = Color.ForestGreen;
				actionButton.Text = "Deactivate Hyper-V and restart computer";
				if (isHyperVRunning == false)
				{
					statusLabel.Text += " However, it is currently NOT running, so a restart may be pending.";
					justRestart = true;
					actionButton.Text = "Restart computer";
				}
			}
			else if (isHyperVActive == false)
			{
				statusLabel.Text = "Hyper-V is DEACTIVATED.";
				statusLabel.ForeColor = Color.Firebrick;
				actionButton.Text = "Activate Hyper-V and restart computer";
				if (isHyperVRunning == true)
				{
					statusLabel.Text += " However, it is currently running, so a restart may be pending.";
					justRestart = true;
					actionButton.Text = "Restart computer";
				}
			}
			else
			{
				statusLabel.Text = "The current state of Hyper-V is UNKNOWN. The Hyper-V role may not be installed on this computer.";
				actionButton.Text = "No action available";
				actionButton.Enabled = false;
			}
			infoLabel.Text = "© 2016 Yves Goergen, GNU GPL v3";
		}

		#endregion Constructors

		#region Window event handlers

		private void MainForm_KeyDown(object sender, KeyEventArgs args)
		{
			if (args.KeyCode == Keys.Escape && args.Modifiers == 0)
			{
				Application.Exit();
			}
		}

		#endregion Window event handlers

		#region Control event handlers

		private void ActionButton_Click(object sender, EventArgs args)
		{
			if (!justRestart)
			{
				if (isHyperVActive == true)
				{
					if (!SetHyperVStatus(false))
					{
						MessageBox.Show("Deactivating Hyper-V failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else if (isHyperVActive == false)
				{
					if (!SetHyperVStatus(true))
					{
						MessageBox.Show("Activating Hyper-V failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else
				{
					return;   // Should not happen
				}
			}

			if (!SafeNativeMethods.ExitWindowsEx(
				ExitWindows.RestartApps,
				ShutdownReason.MajorOperatingSystem | ShutdownReason.MinorReconfig | ShutdownReason.FlagPlanned))
			{
				MessageBox.Show("Restarting the computer failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// System is restarted. Prevent further actions
			Application.Exit();
		}

		private void InfoLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs args)
		{
			Process.Start("http://unclassified.software/");
		}

		#endregion Control event handlers

		#region Hyper-V support methods

		private bool? GetHyperVStatus()
		{
			var startInfo = new ProcessStartInfo
			{
				Arguments = "/enum {default}",
				CreateNoWindow = true,
				FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "bcdedit.exe"),
				RedirectStandardOutput = true,
				UseShellExecute = false
			};
			using (var process = Process.Start(startInfo))
			{
				while (!process.StandardOutput.EndOfStream)
				{
					string line = process.StandardOutput.ReadLine();
					if (line.StartsWith("hypervisorlaunchtype ", StringComparison.OrdinalIgnoreCase))
					{
						return line.IndexOf(" off", StringComparison.OrdinalIgnoreCase) == -1;
					}
				}
			}
			return null;
		}

		private bool SetHyperVStatus(bool active)
		{
			var startInfo = new ProcessStartInfo
			{
				Arguments = "/set {current} hypervisorlaunchtype " + (active ? "auto" : "off"),
				CreateNoWindow = true,
				FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "bcdedit.exe"),
				UseShellExecute = false
			};
			using (var process = Process.Start(startInfo))
			{
				process.WaitForExit();
				return process.ExitCode == 0;
			}
		}

		private bool? GetHyperVRunning()
		{
			// TODO
			return null;
		}

		#endregion Hyper-V support methods
	}
}
