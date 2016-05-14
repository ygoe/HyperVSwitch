# Hyper-V Switch
A simple GUI to enable or disable Hyper-V without uninstallation, allowing the use of other virtualisation solutions.

Hyper-V is Microsoft’s virtualisation solution that can be installed with Windows. Visual Studio device emulators for Windows 10 Mobile rely on Hyper-V for the guest system. While this may work in most cases, it has the major disadvantage that Hyper-V is running permanently when installed, unlike application hypervisors like VMware or VirtualBox. With the Hyper-V hypervisor already running, these other virtualisation solutions cannot work properly, for example 64-bit support is no longer available and performance is degraded because the VT-x CPU hardware extensions are not available inside a VM guest (which your entire Windows desktop will then be). When using device emulators for Android or other VM solutions for other work, Hyper-V interferes badly with those virtualisation applications.

The only option that Microsoft allows is uninstalling the Hyper-V role from Windows. This takes a short time and then restarts the system. It is also a bit hidden within the classic control panel in a lenghty list of features. When installing it again, you need to know which features to select.

Another solution is to configure the BCD boot configuration file to set a parameter that enables or disables Hyper-V on system startup. This parameter can be set with the command line tool bcdedit.exe and Administrator privileges. Again, this is not an intuitive way to work with multiple virtualisation solutions.

**Hyper-V Switch** automates the second described procedure, reading and writing the BCD file, displaying the current state and offering a one-click action to toggle Hyper-V and restart the computer. The restart is still required because to toggle Hyper-V usage, Windows needs to be booted either without permanent virtualisation or as a virtualised guest from the beginning. Also this information is only available (and can be changed) with Administrator privileges.

To avoid the UAC (Administrator) confirmation for every start of this program, you can create a scheduled task to run this program file, set no trigger, activate the “Highest privileges” option and then create a batch file to run something like `schtasks /run /tn HyperVSwitchTaskName`.
