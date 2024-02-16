namespace InterprocessCommunication
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
			this.lbProcesses = new System.Windows.Forms.ListBox();
			this.lbAssemblies = new System.Windows.Forms.ListBox();
			this.labelProcesses = new System.Windows.Forms.Label();
			this.labelAssemblies = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnCloseWindow = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnChangeDirectory = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbProcesses
			// 
			this.lbProcesses.FormattingEnabled = true;
			this.lbProcesses.Location = new System.Drawing.Point(12, 38);
			this.lbProcesses.Name = "lbProcesses";
			this.lbProcesses.Size = new System.Drawing.Size(261, 277);
			this.lbProcesses.TabIndex = 0;
			this.lbProcesses.SelectedIndexChanged += new System.EventHandler(this.lbProcesses_SelectedIndexChanged);
			// 
			// lbAssemblies
			// 
			this.lbAssemblies.FormattingEnabled = true;
			this.lbAssemblies.Location = new System.Drawing.Point(360, 38);
			this.lbAssemblies.Name = "lbAssemblies";
			this.lbAssemblies.Size = new System.Drawing.Size(258, 277);
			this.lbAssemblies.TabIndex = 1;
			this.lbAssemblies.SelectedIndexChanged += new System.EventHandler(this.lbAssemblies_SelectedIndexChanged);
			// 
			// labelProcesses
			// 
			this.labelProcesses.AutoSize = true;
			this.labelProcesses.Location = new System.Drawing.Point(12, 13);
			this.labelProcesses.Name = "labelProcesses";
			this.labelProcesses.Size = new System.Drawing.Size(125, 13);
			this.labelProcesses.TabIndex = 2;
			this.labelProcesses.Text = "Запущенные процессы";
			// 
			// labelAssemblies
			// 
			this.labelAssemblies.AutoSize = true;
			this.labelAssemblies.Location = new System.Drawing.Point(357, 13);
			this.labelAssemblies.Name = "labelAssemblies";
			this.labelAssemblies.Size = new System.Drawing.Size(103, 13);
			this.labelAssemblies.TabIndex = 2;
			this.labelAssemblies.Text = "Доступные сборки";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(279, 38);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(279, 67);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnCloseWindow
			// 
			this.btnCloseWindow.Location = new System.Drawing.Point(279, 125);
			this.btnCloseWindow.Name = "btnCloseWindow";
			this.btnCloseWindow.Size = new System.Drawing.Size(75, 23);
			this.btnCloseWindow.TabIndex = 3;
			this.btnCloseWindow.Text = "Close";
			this.btnCloseWindow.UseVisualStyleBackColor = true;
			this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(279, 96);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnChangeDirectory
			// 
			this.btnChangeDirectory.Location = new System.Drawing.Point(279, 154);
			this.btnChangeDirectory.Name = "btnChangeDirectory";
			this.btnChangeDirectory.Size = new System.Drawing.Size(75, 23);
			this.btnChangeDirectory.TabIndex = 4;
			this.btnChangeDirectory.Text = "Directory";
			this.btnChangeDirectory.UseVisualStyleBackColor = true;
			this.btnChangeDirectory.Click += new System.EventHandler(this.btnChangeDirectory_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 334);
			this.Controls.Add(this.btnChangeDirectory);
			this.Controls.Add(this.btnCloseWindow);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.labelAssemblies);
			this.Controls.Add(this.labelProcesses);
			this.Controls.Add(this.lbAssemblies);
			this.Controls.Add(this.lbProcesses);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbProcesses;
		private System.Windows.Forms.ListBox lbAssemblies;
		private System.Windows.Forms.Label labelProcesses;
		private System.Windows.Forms.Label labelAssemblies;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnCloseWindow;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnChangeDirectory;
	}
}

