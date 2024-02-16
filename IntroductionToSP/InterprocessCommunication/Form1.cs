using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Management;

namespace InterprocessCommunication
{
	public partial class Form1 : Form
	{
		const uint WM_SETTEXT = 0x0C;
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hwnd, uint uMsg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);
		List<Process> processes = new List<Process>();
		int count = 0;
		string path;
		string Path
		{ 
			get => path; 
			set 
			{
				path = value;
				lbAssemblies.Items.Clear();
				LoadAvaibleAssemblies(path);
			} 
		}
		public Form1()
		{
			InitializeComponent();
			Path = Application.StartupPath;
			btnStart.Enabled = false;
			btnStop.Enabled = false;
			btnRefresh.Enabled = false;
			btnCloseWindow.Enabled = false;
		}

		void LoadAvaibleAssemblies(string path)
		{
			string except = new FileInfo(Application.ExecutablePath).Name;
			except.Substring(0, except.IndexOf("."));
			LoadFilesByPath(path, "*.exe");
			LoadFilesByPath(path, "*.lnk");
		}

		void LoadFilesByPath(string path, string format)
		{
			string[] files = Directory.GetFiles(path, format);
			foreach (string file in files)
			{
				string except = new FileInfo(Application.ExecutablePath).Name;
				string fileName = new FileInfo(file).Name;
				if(format.Equals("*.lnk"))fileName = fileName.Substring(0, fileName.IndexOf("."));
				if (fileName.IndexOf(except) == -1) lbAssemblies.Items.Add(fileName);
			}
		}

		void RunProcess(string assemblyName)
		{
			Process process = Process.Start(assemblyName);
			processes.Add(process);
			if(Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))
			{
				MessageBox.Show(this, process.ProcessName + " дочерний процесс текущего процесса.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				process.EnableRaisingEvents = true;
				process.Exited += Proc_Exited;
				SendMessage(process.MainWindowHandle, WM_SETTEXT, 0, $"Child process #{count++}");
				if(!lbProcesses.Items.Contains(process.ProcessName))
				{
					lbProcesses.Items.Add(process.ProcessName);
					lbAssemblies.Items.Remove(lbAssemblies.SelectedItem);
				}
			}
		}

		void Proc_Exited(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			Process process = sender as Process;
			lbProcesses.Items.Remove(process.ProcessName);
			lbAssemblies.Items.Add(process.ProcessName);
			processes.Remove(process);
			count--;
			int index = 0;
			foreach(Process proc in processes)
			{
				SendMessage(proc.MainWindowHandle, WM_SETTEXT, 0, $"Child process #{++index}");
			}
		}

		int GetParentProcessId(int id)
		{
			int pareintId = 0;
			using (ManagementObject obj = new ManagementObject($"win32_process.handle={id}"))
			{
				obj.Get();
				pareintId = Convert.ToInt32(obj["ParentProcessId"]);
			};
			return pareintId;
		}

		delegate void ProcessDelegate(Process proc);
		void ExecuteOnProcessByName(string processName, ProcessDelegate function)
		{
			Process[] processes = Process.GetProcessesByName(processName);
			foreach(Process proc in processes)
			{
				if(Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
				{
					function(proc);
				}
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			RunProcess(lbAssemblies.SelectedItem.ToString());
		}

		void Kill(Process process)
		{
			process.Kill();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			object selectedItem = lbProcesses.SelectedItem;
			ExecuteOnProcessByName(lbProcesses.SelectedItem.ToString(), Kill);
			lbProcesses.Items.Remove(selectedItem);
		}

		void CloseMainWindow(Process process)
		{
			process.CloseMainWindow();
		}


		private void btnCloseWindow_Click(object sender, EventArgs e)
		{
			ExecuteOnProcessByName(lbProcesses.SelectedItem.ToString(), CloseMainWindow);
			lbProcesses.Items.Remove(lbProcesses.SelectedItem);
		}

		void Refresh(Process process)
		{
			process.Refresh();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			ExecuteOnProcessByName(lbProcesses.SelectedItem.ToString(), Refresh);
		}

		private void lbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(lbAssemblies.SelectedItems.Count == 0)btnStart.Enabled = false;
			else btnStart.Enabled = true;
		}

		private void lbProcesses_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbProcesses.SelectedItems.Count == 0)
			{
				btnStop.Enabled = false;
				btnCloseWindow.Enabled = false;
				btnRefresh.Enabled = false;
			}
			else
			{
				btnStop.Enabled = true; 
				btnCloseWindow.Enabled = true;
				btnRefresh.Enabled = true;
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach(Process process in processes) process.Kill(); 
		}

		private void btnChangeDirectory_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			Path = dialog.SelectedPath;
		}
	}
}
