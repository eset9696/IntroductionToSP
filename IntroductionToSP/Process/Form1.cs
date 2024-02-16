using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process
{
	public partial class Form1 : Form
	{
		//Stack<System.Diagnostics.Process> processes = new Stack<System.Diagnostics.Process>();
		public Form1()
		{
			InitializeComponent();
			AllignText();
			listViewProcesses.Columns.Add("PID");
			listViewProcesses.Columns.Add("Name");
		}

		void InitProcess()
		{
			AllignText();
			myProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(rtbProcessName.Text);
			myProcess.Start();
			listViewProcesses.Items.Add(myProcess.Id.ToString());
			listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems.Add(myProcess.ProcessName.ToString());
		}

		void AllignText()
		{
			rtbProcessName.SelectAll();
			rtbProcessName.SelectionAlignment = HorizontalAlignment.Center;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			InitProcess();
			//processes.Push(myProcess);
			Info();
			myProcess = new System.Diagnostics.Process();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			try
			{
				Info();
				myProcess = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems[0].Text));
				//myProcess = processes.Pop();
				myProcess.CloseMainWindow(); // закрывает процесс
				myProcess.Close(); // освобождает ресурсы занимаемые процессом
				listViewProcesses.Items.RemoveAt(listViewProcesses.Items.Count - 1);
			}
			catch (Exception myProcessIsNullException)
			{
				listViewProcesses.Items.RemoveAt(listViewProcesses.Items.Count - 1);
				//processes.Pop();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			/*foreach (System.Diagnostics.Process process in processes)
			{
				try
				{
					process.CloseMainWindow(); // закрывает процесс
					process.Close();
				}
				catch (Exception currentProcessIsNullException)
				{
					processes.Pop();
				}
			}
			processes.Clear();*/
			while (listViewProcesses.Items.Count > 0)
			{
				try
				{
					myProcess = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems[0].Text));
					myProcess.CloseMainWindow(); // закрывает процесс
					myProcess.Close();
					listViewProcesses.Items.RemoveAt(listViewProcesses.Items.Count - 1);
				}
				catch (Exception currentProcessIsNullException)
				{
					listViewProcesses.Items.RemoveAt(listViewProcesses.Items.Count - 1);
				}
			}
		}

		void Info()
		{
			myProcess = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(listViewProcesses.Items[listViewProcesses.Items.Count - 1].SubItems[0].Text)); ;
			labelProcessInfo.Text = $"Processes {listViewProcesses.Items.Count} \n";
			labelProcessInfo.Text += "Process info \n";
			labelProcessInfo.Text += $"PID:\t{myProcess.Id} \n";
			labelProcessInfo.Text += $"Base priority:\t{myProcess.BasePriority} \n";
			labelProcessInfo.Text += $"Start time:\t{myProcess.StartTime} \n";
			labelProcessInfo.Text += $"Total CPU Time:\t{myProcess.TotalProcessorTime} \n";
			labelProcessInfo.Text += $"User CPU Time:\t{myProcess.UserProcessorTime} \n";
			labelProcessInfo.Text += $"Session id:\t{myProcess.SessionId} \n";
			labelProcessInfo.Text += $"Name:\t{myProcess.ProcessName} \n";
			labelProcessInfo.Text += $"Affinity:\t{myProcess.ProcessorAffinity} \n";
		}
	}
}
