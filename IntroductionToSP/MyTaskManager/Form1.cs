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
		ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
		ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
		Process[] processes = Process.GetProcesses();
		public Form1()
		{
			InitializeComponent();

			processStartEvent.EventArrived += new EventArrivedEventHandler(processStartEvent_EventArrived);
			LoadProcesses();
			processStartEvent.Start();
			processStopEvent.EventArrived += new EventArrivedEventHandler(processStopEvent_EventArrived);
			processStopEvent.Start();
			listViewProcesses.Columns.Add("Process name");
			listViewProcesses.Columns.Add("Process ID");
			listViewProcesses.Columns.Add("CPU, %");
			listViewProcesses.Columns.Add("Memory, %");
			listViewProcesses.Columns.Add("Disk, %");
		}

		void processStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
		{
			
		}

		void processStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
			string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();
			//MessageBox.Show(this, $"Stopped {processName}", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
			DeleteProcess(processName);

		}

		void DeleteProcess(string  processName)
		{
			ListViewItem item = new ListViewItem(processName);
			listViewProcesses.Items.IndexOf(item);   
		}

		void LoadProcesses()
		{
			foreach (Process process in processes)
			{
				process.Exited += Proc_Exited;
				listViewProcesses.Items.Add(process.ProcessName.ToString());
				listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems.Add(process.Id.ToString());
				//PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
				//listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems.Add(pcProcess.NextValue().ToString());
				listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems.Add(Math.Round((float)process.WorkingSet64 / (1024*1024), 1).ToString() + ", MB");
			}
		}

		void Proc_Exited(object sender, EventArgs e)
		{
			
		}

		void Refresh()
		{
			
		}

		float GetProcessorUsage(Process process)
		{
			PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
			pcProcess.NextValue();
			Thread.Sleep(1000);
			return pcProcess.NextValue();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			listViewProcesses.Refresh();
		}
	}
}
