using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

			statusLabel.Text = "Detecting current state…\nThis may take a few seconds.";
			statusLabel.ForeColor = Color.Gray;
			actionButton.Visible = false;

			toggleButton.Visible = false;
			refreshButton.Visible = false;
			refreshButton.Text = "Refresh current state";

			infoLabel.Text = "© 2016 Yves Goergen, GNU GPL v3";
		}

		#endregion Constructors

		#region Window event handlers

		private async void MainForm_Load(object sender, EventArgs args)
		{
			isHyperVActive = await GetHyperVStatus();
			isHyperVRunning = GetHyperVRunning();

			refreshButton.Visible = true;
			toggleButton.Visible = true;

			actionButton.Visible = true;
			actionButton.Focus();

			if (isHyperVActive == true)
			{
				statusLabel.Text = "Hyper-V is ACTIVE.";
				statusLabel.ForeColor = Color.ForestGreen;
				actionButton.Text = "Deactivate Hyper-V and restart computer";
				toggleButton.Text = "Deactivate only (no restart)";
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
				toggleButton.Text = "Activate only (no restart)";
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
				statusLabel.ForeColor = SystemColors.WindowText;
				actionButton.Text = "No action available";
				actionButton.Enabled = false;
				toggleButton.Visible = false;
				toggleButton.Enabled = false;
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs args)
		{
			if (args.KeyCode == Keys.Escape && args.Modifiers == 0)
			{
				Application.Exit();
			}
			if (args.KeyCode == Keys.F1 && args.Modifiers == 0)
			{
				string message =
					"Hyper-V Switch allows you to enable or disable permanent virtualisation with Hyper-V without uninstalling it so that you can use Hyper-V " +
					"and other virtualisation solutions like VMware or VirtualBox easily. This setting is stored in the boot configuration (bcdedit > hypervisorlaunchtype) " +
					"so that the computer must be restarted to apply the new setting.\n\n" +
					"For more information please click on the link to open the website.\n\n" +
					"Available keyboard shortcuts:\n\n" +
					"Escape: Close program\n" +
					"Shift+Click(" + actionButton.Text + "): Change state but skip restart (you need to restart manually)";
				MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion Window event handlers

		#region Control event handlers

		private async void ActionButton_Click(object sender, EventArgs args)
		{
			bool shiftKeyPressed = ModifierKeys == Keys.Shift;
			actionButton.Enabled = false;
			refreshButton.Enabled = false;
			toggleButton.Enabled = false;
			try
			{
				if (!justRestart)
				{
					if (isHyperVActive == true)
					{
						if (!await SetHyperVStatus(false))
						{
							MessageBox.Show("Deactivating Hyper-V failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					else if (isHyperVActive == false)
					{
						if (!await SetHyperVStatus(true))
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

				if (!shiftKeyPressed)
				{
					if (!SafeNativeMethods.ExitWindowsEx(
						ExitWindows.Reboot,
						ShutdownReason.MajorOperatingSystem | ShutdownReason.MinorReconfig | ShutdownReason.FlagPlanned))
					{
						//int error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
						//string errorMessage = new System.ComponentModel.Win32Exception(error).Message;
						//MessageBox.Show($"Restarting the computer failed. {errorMessage} (Error {error}) Trying another method…", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						// ExitWindowsEx fails on Windows 10.
						// Use the system command, there's no feedback from it.
						Process.Start("shutdown.exe", "-r -t 0");
					}
				}
			}
			finally
			{
				actionButton.Enabled = true;
				refreshButton.Enabled = true;
				toggleButton.Enabled = true;
			}

			// System is restarted. Prevent further actions
			Application.Exit();
		}

		private void InfoLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs args)
		{
			Process.Start("http://unclassified.software/");
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			actionButton.Enabled = false;
			refreshButton.Enabled = false;
			toggleButton.Enabled = false;
			MainForm_Load(sender, e);
			actionButton.Enabled = true;
			refreshButton.Enabled = true;
			toggleButton.Enabled = true;
		}

		private async void toggleButton_Click(object sender, EventArgs e)
		{
			actionButton.Enabled = false;
			refreshButton.Enabled = false;
			toggleButton.Enabled = false;
			try
			{
				if (isHyperVActive == true)
				{
					if (!await SetHyperVStatus(false))
					{
						MessageBox.Show("Deactivating Hyper-V failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else if (isHyperVActive == false)
				{
					if (!await SetHyperVStatus(true))
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
			finally
			{
				MainForm_Load(sender, e);
				actionButton.Enabled = true;
				refreshButton.Enabled = true;
				toggleButton.Enabled = true;
			}
		}

		#endregion Control event handlers

		#region Hyper-V support methods

		private async Task<bool?> GetHyperVStatus()
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
				await process.WaitForExitAsync();
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

		private async Task<bool> SetHyperVStatus(bool active)
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
				await process.WaitForExitAsync();
				return process.ExitCode == 0;
			}
		}

		private bool? GetHyperVRunning()
		{
			return !SafeNativeMethods.IsProcessorFeaturePresent(ProcessorFeature.PF_VIRT_FIRMWARE_ENABLED);
		}

		#endregion Hyper-V support methods

	}
}
