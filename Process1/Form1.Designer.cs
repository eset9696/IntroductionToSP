namespace Process1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.rtbProcessName = new System.Windows.Forms.RichTextBox();
			this.myProcess = new System.Diagnostics.Process();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 50);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(395, 50);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// rtbProcessName
			// 
			this.rtbProcessName.Location = new System.Drawing.Point(12, 12);
			this.rtbProcessName.Name = "rtbProcessName";
			this.rtbProcessName.Size = new System.Drawing.Size(458, 32);
			this.rtbProcessName.TabIndex = 2;
			this.rtbProcessName.Text = "";
			// 
			// myProcess
			// 
			this.myProcess.EnableRaisingEvents = true;
			this.myProcess.StartInfo.Domain = "";
			this.myProcess.StartInfo.LoadUserProfile = false;
			this.myProcess.StartInfo.Password = null;
			this.myProcess.StartInfo.StandardErrorEncoding = null;
			this.myProcess.StartInfo.StandardOutputEncoding = null;
			this.myProcess.StartInfo.UserName = "";
			this.myProcess.SynchronizingObject = this;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 110);
			this.Controls.Add(this.rtbProcessName);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.RichTextBox rtbProcessName;
		private System.Diagnostics.Process myProcess;
	}
}

