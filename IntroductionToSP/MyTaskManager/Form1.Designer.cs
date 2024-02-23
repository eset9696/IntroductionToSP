namespace MyTaskManager
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
			this.components = new System.ComponentModel.Container();
			this.listViewProcesses = new System.Windows.Forms.ListView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.taskKillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.terminateTheProcessTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rtbSearcher = new System.Windows.Forms.RichTextBox();
			this.btnNewTask = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewProcesses
			// 
			this.listViewProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewProcesses.ContextMenuStrip = this.contextMenuStrip1;
			this.listViewProcesses.FullRowSelect = true;
			this.listViewProcesses.HideSelection = false;
			this.listViewProcesses.Location = new System.Drawing.Point(12, 44);
			this.listViewProcesses.MultiSelect = false;
			this.listViewProcesses.Name = "listViewProcesses";
			this.listViewProcesses.Size = new System.Drawing.Size(776, 394);
			this.listViewProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listViewProcesses.TabIndex = 0;
			this.listViewProcesses.UseCompatibleStateImageBehavior = false;
			this.listViewProcesses.View = System.Windows.Forms.View.Details;
			this.listViewProcesses.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProcesses_ColumnClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskKillToolStripMenuItem,
            this.terminateTheProcessTreeToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(213, 48);
			// 
			// taskKillToolStripMenuItem
			// 
			this.taskKillToolStripMenuItem.Name = "taskKillToolStripMenuItem";
			this.taskKillToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.taskKillToolStripMenuItem.Text = "Task kill";
			this.taskKillToolStripMenuItem.Click += new System.EventHandler(this.taskKillToolStripMenuItem_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(12, 12);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 1;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// terminateTheProcessTreeToolStripMenuItem
			// 
			this.terminateTheProcessTreeToolStripMenuItem.Name = "terminateTheProcessTreeToolStripMenuItem";
			this.terminateTheProcessTreeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.terminateTheProcessTreeToolStripMenuItem.Text = "Terminate the process tree";
			this.terminateTheProcessTreeToolStripMenuItem.Click += new System.EventHandler(this.terminateTheProcessTreeToolStripMenuItem_Click);
			// 
			// rtbSearcher
			// 
			this.rtbSearcher.Location = new System.Drawing.Point(232, 12);
			this.rtbSearcher.Name = "rtbSearcher";
			this.rtbSearcher.Size = new System.Drawing.Size(318, 23);
			this.rtbSearcher.TabIndex = 2;
			this.rtbSearcher.Text = "Введите имя или PID";
			this.rtbSearcher.TextChanged += new System.EventHandler(this.rtbSearcher_TextChanged);
			// 
			// btnNewTask
			// 
			this.btnNewTask.Location = new System.Drawing.Point(106, 12);
			this.btnNewTask.Name = "btnNewTask";
			this.btnNewTask.Size = new System.Drawing.Size(75, 23);
			this.btnNewTask.TabIndex = 3;
			this.btnNewTask.Text = "New task";
			this.btnNewTask.UseVisualStyleBackColor = true;
			this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnNewTask);
			this.Controls.Add(this.rtbSearcher);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.listViewProcesses);
			this.Name = "Form1";
			this.Text = "Form1";
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView listViewProcesses;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem taskKillToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem terminateTheProcessTreeToolStripMenuItem;
		private System.Windows.Forms.RichTextBox rtbSearcher;
		private System.Windows.Forms.Button btnNewTask;
	}
}

