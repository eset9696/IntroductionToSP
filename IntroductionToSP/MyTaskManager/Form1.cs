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
using System.Threading;
using System.Management;

namespace MyTaskManager
{
	public partial class Form1 : Form
	{
		List<Process> processes = new List<Process>();
		
		public Form1()
		{
			InitializeComponent();
			initListView();
		}

		void initListView()
		{
			listViewProcesses.Columns.Add("Process name");
			listViewProcesses.Columns.Add("PID");
			listViewProcesses.Columns.Add("Memory, MB");
			listViewProcesses.Groups.Add(new ListViewGroup("Applications"));
			listViewProcesses.Groups.Add(new ListViewGroup("Services"));
			LoadProcesses();
			listViewProcesses.Columns[0].Width = -1;
			listViewProcesses.Columns[1].Width = -2;
			listViewProcesses.Columns[2].Width = -2;
			listViewProcesses.Sorting = SortOrder.Ascending;
		}

		void LoadProcesses()
		{
			listViewProcesses.Items.Clear();
			processes.Clear();
			processes = Process.GetProcesses().ToList<Process>();
			double memoryUsage = 0;
			foreach (Process process in processes)
			{
				memoryUsage = 0;
				GetPerformanceData(process, out memoryUsage);
				string[] row = new string[] { process.ProcessName, process.Id.ToString(), memoryUsage.ToString()};
				ListViewItem item = new ListViewItem(row);
				listViewProcesses.Items.Add(item);
				item.Group = process.MainWindowHandle != IntPtr.Zero?
				listViewProcesses.Groups[0] : listViewProcesses.Groups[1];
			}
		}

		void LoadProcesses(List<Process> filteredProcesses, string key)
		{
			listViewProcesses.Items.Clear();
			double memoryUsage = 0;
			foreach (Process process in filteredProcesses)
			{
				memoryUsage = 0;
				GetPerformanceData(process, out memoryUsage);
				string[] row = new string[] { process.ProcessName, process.Id.ToString(), memoryUsage.ToString() };
				ListViewItem item = new ListViewItem(row);
				listViewProcesses.Items.Add(item);
				item.Group = process.MainWindowHandle != IntPtr.Zero ?
				listViewProcesses.Groups[0] : listViewProcesses.Groups[1];
			}
		}

		void GetPerformanceData(Process process, out double memoryUsage)
		{
			PerformanceCounter memoryCounter = new PerformanceCounter("Process", "Working Set - Private", process.ProcessName);
			memoryUsage = Math.Round(memoryCounter.NextValue() / (1024 * 1024), 1);
			memoryCounter.Close();
			memoryCounter.Dispose();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			LoadProcesses();
		}

		private void taskKillToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listViewProcesses.SelectedItems[0] != null)
			{
				foreach(Process proc in processes)
				{
					if (listViewProcesses.SelectedItems[0].SubItems[0].Text == proc.ProcessName) proc.Kill();
				}
			}
			LoadProcesses();
		}

		private void listViewProcesses_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			listViewProcesses.Sorting = listViewProcesses.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
		}

		int GetParentProcessId(int id)
		{
			int parentId = 0;
			using (ManagementObject obj = new ManagementObject($"win32_process.handle='{id}'"))
			{
				obj.Get();
				parentId = Convert.ToInt32(obj["ParentProcessId"]);
			};
			return parentId;
		}

		void TerminateTheProcessTree(int pid)
		{
			if (pid == 0) return;
			ManagementObjectSearcher objSearcher = new ManagementObjectSearcher($"Select * From Win32_Process Where ParentProcessID={pid}");
			ManagementObjectCollection objects = objSearcher.Get();
			foreach (ManagementObject obj in objects)
			{
				TerminateTheProcessTree(Convert.ToInt32(obj["ProcessID"]));
			}
			try
			{
				Process process = Process.GetProcessById(pid);
				process.Kill();
				process.WaitForExit();
			}
			catch (Exception){ }
		}

		private void terminateTheProcessTreeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process process = null;
			if (listViewProcesses.SelectedItems[0] != null)
			{
				foreach (Process proc in processes)
				{
					if (listViewProcesses.SelectedItems[0].SubItems[0].Text == proc.ProcessName)
					{
						process = proc;
					}
				}
				TerminateTheProcessTree(GetParentProcessId(process.Id));
				LoadProcesses();
			}
		}

		private void rtbSearcher_TextChanged(object sender, EventArgs e)
		{
			string rtbTextDefault = "Введите имя или PID";
			if(rtbSearcher.Text.Length == 0) { 
				rtbSearcher.Text = rtbTextDefault; 
				LoadProcesses();
				return;
			}
			if (rtbSearcher.Text.Contains(rtbTextDefault))
			{
				rtbSearcher.Text = rtbSearcher.Text.Replace(rtbTextDefault, "");
				rtbSearcher.SelectionStart = rtbSearcher.Text.Length;
				return;
			}
			List<Process> result = new List<Process>();
			foreach (Process proc in processes)
			{
				if(proc.ProcessName.ToLower().Contains(rtbSearcher.Text.ToLower()) || proc.Id.ToString().Contains(rtbSearcher.Text)) 
					result.Add(proc);
			}
			LoadProcesses(result, rtbSearcher.Text);
		}

		private void btnNewTask_Click(object sender, EventArgs e)
		{
			Process.Start("C:\\Users\\sherk\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\System Tools\\Run.lnk");
		}
	}
}
