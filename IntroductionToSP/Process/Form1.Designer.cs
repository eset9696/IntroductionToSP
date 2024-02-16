namespace Process
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
			this.rtbProcessName = new System.Windows.Forms.RichTextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.labelProcessInfo = new System.Windows.Forms.Label();
			this.myProcess = new System.Diagnostics.Process();
			this.listViewProcesses = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// rtbProcessName
			// 
			this.rtbProcessName.Location = new System.Drawing.Point(12, 12);
			this.rtbProcessName.Name = "rtbProcessName";
			this.rtbProcessName.Size = new System.Drawing.Size(511, 28);
			this.rtbProcessName.TabIndex = 0;
			this.rtbProcessName.Text = "calc.exe";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 46);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.Location = new System.Drawing.Point(448, 46);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// labelProcessInfo
			// 
			this.labelProcessInfo.AutoSize = true;
			this.labelProcessInfo.Location = new System.Drawing.Point(12, 84);
			this.labelProcessInfo.Name = "labelProcessInfo";
			this.labelProcessInfo.Size = new System.Drawing.Size(35, 13);
			this.labelProcessInfo.TabIndex = 2;
			this.labelProcessInfo.Text = "label1";
			// 
			// myProcess
			// 
			this.myProcess.StartInfo.Domain = "";
			this.myProcess.StartInfo.LoadUserProfile = false;
			this.myProcess.StartInfo.Password = null;
			this.myProcess.StartInfo.StandardErrorEncoding = null;
			this.myProcess.StartInfo.StandardOutputEncoding = null;
			this.myProcess.StartInfo.UserName = "";
			this.myProcess.SynchronizingObject = this;
			// 
			// listViewProcesses
			// 
			this.listViewProcesses.HideSelection = false;
			this.listViewProcesses.Location = new System.Drawing.Point(12, 118);
			this.listViewProcesses.Name = "listViewProcesses";
			this.listViewProcesses.Size = new System.Drawing.Size(511, 183);
			this.listViewProcesses.TabIndex = 3;
			this.listViewProcesses.UseCompatibleStateImageBehavior = false;
			this.listViewProcesses.View = System.Windows.Forms.View.Details;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(535, 313);
			this.Controls.Add(this.listViewProcesses);
			this.Controls.Add(this.labelProcessInfo);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.rtbProcessName);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtbProcessName;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label labelProcessInfo;
		private System.Diagnostics.Process myProcess;
		private System.Windows.Forms.ListView listViewProcesses;
	}
}

