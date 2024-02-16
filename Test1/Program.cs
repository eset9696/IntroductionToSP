using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			
			process.StartInfo = new System.Diagnostics.ProcessStartInfo("Notepad.exe");
			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.UseShellExecute = false;
			//ProcessManager()
			process.Start();
			//ShowWindow(process.MainWindowHandle, 5);
			// Discard cached information about the process.
			Console.WriteLine(process.MainWindowHandle);
			Console.WriteLine(process.Id);
			process.Refresh();
			//process.Id = 29392;
			/*foreach (var proc in Process.GetProcesses()
							.OrderBy(proc => proc.Id))
			{
				Console.WriteLine("{0}: {1}",proc.Id, proc.ProcessName);
			}*/
			Console.WriteLine(process.MainWindowHandle);
			Console.WriteLine(process.Id);
			// Print working set to console.
			Console.WriteLine($"Physical Memory Usage: {process.WorkingSet}");
			// Wait 2 seconds.
			Thread.Sleep(2000);
			process.CloseMainWindow();
			// Free resources associated with process.
			process.Close();
		}
	}
}
