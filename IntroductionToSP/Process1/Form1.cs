using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		void InitProcess()
		{
			myProcess.StartInfo = new System.Diagnostics.ProcessStartInfo(rtbProcessName.Text);
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			InitProcess();
			myProcess.Start();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			myProcess.Refresh();
			myProcess.CloseMainWindow(); // закрывает процесс
			myProcess.Close(); // освобождает ресурсы занимаемые процессом
		}
	}
}
