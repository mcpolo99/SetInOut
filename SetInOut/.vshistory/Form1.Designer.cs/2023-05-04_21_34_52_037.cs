namespace SetInOut
{
    public partial class Form1 : global::System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool flag = this.components != null;
                if (flag)
                {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StartTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StopTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Green;
            this.listBox1.ItemHeight = 11;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(889, 260);
            this.listBox1.TabIndex = 5;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LightGreen;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Green;
            this.buttonStart.Location = new System.Drawing.Point(0, 0);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(200, 50);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Salmon;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonStop.Location = new System.Drawing.Point(210, 0);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(200, 50);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonDisconnect.Location = new System.Drawing.Point(420, 0);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(200, 50);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMI,
            this.CommandTSMI,
            this.AboutTSMI});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(92, 61);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileTSMI
            // 
            this.FileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI1,
            this.saveTSMI1,
            this.exitTSMI1,
            this.recentToolStripMenuItem});
            this.FileTSMI.Name = "FileTSMI";
            this.FileTSMI.Size = new System.Drawing.Size(37, 19);
            this.FileTSMI.Text = "File";
            this.FileTSMI.Click += new System.EventHandler(this.FileTSMI_Click);
            // 
            // openTSMI1
            // 
            this.openTSMI1.Name = "openTSMI1";
            this.openTSMI1.Size = new System.Drawing.Size(180, 22);
            this.openTSMI1.Text = "Open";
            this.openTSMI1.Click += new System.EventHandler(this.openTSMI1_Click);
            // 
            // saveTSMI1
            // 
            this.saveTSMI1.Name = "saveTSMI1";
            this.saveTSMI1.Size = new System.Drawing.Size(180, 22);
            this.saveTSMI1.Text = "Save";
            this.saveTSMI1.Click += new System.EventHandler(this.saveTSMI1_Click);
            // 
            // exitTSMI1
            // 
            this.exitTSMI1.Name = "exitTSMI1";
            this.exitTSMI1.Size = new System.Drawing.Size(180, 22);
            this.exitTSMI1.Text = "Exit";
            this.exitTSMI1.Click += new System.EventHandler(this.exitTSMI1_Click);
            // 
            // CommandTSMI
            // 
            this.CommandTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartTSMI1,
            this.StopTSMI1,
            this.disconnectTSMI1});
            this.CommandTSMI.Name = "CommandTSMI";
            this.CommandTSMI.Size = new System.Drawing.Size(76, 19);
            this.CommandTSMI.Text = "Command";
            // 
            // StartTSMI1
            // 
            this.StartTSMI1.Name = "StartTSMI1";
            this.StartTSMI1.Size = new System.Drawing.Size(180, 22);
            this.StartTSMI1.Text = "Start";
            this.StartTSMI1.Click += new System.EventHandler(this.StartTSMI1_Click);
            // 
            // StopTSMI1
            // 
            this.StopTSMI1.Name = "StopTSMI1";
            this.StopTSMI1.Size = new System.Drawing.Size(180, 22);
            this.StopTSMI1.Text = "Stop";
            this.StopTSMI1.Click += new System.EventHandler(this.StopTSMI1_Click);
            // 
            // disconnectTSMI1
            // 
            this.disconnectTSMI1.Name = "disconnectTSMI1";
            this.disconnectTSMI1.Size = new System.Drawing.Size(180, 22);
            this.disconnectTSMI1.Text = "Disconnect";
            this.disconnectTSMI1.Click += new System.EventHandler(this.disconnectTSMI1_Click);
            // 
            // AboutTSMI
            // 
            this.AboutTSMI.Name = "AboutTSMI";
            this.AboutTSMI.Size = new System.Drawing.Size(24, 19);
            this.AboutTSMI.Text = "?";
            // 
            // toolstripFile
            // 
            this.toolstripFile.Name = "toolstripFile";
            this.toolstripFile.Size = new System.Drawing.Size(65, 20);
            this.toolstripFile.Text = "tsmi_File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.richTextBox1.MinimumSize = new System.Drawing.Size(10, 10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(889, 264);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(889, 528);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDisconnect);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 50);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(889, 25);
            this.panel2.TabIndex = 9;
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            this.recentToolStripMenuItem.Click += new System.EventHandler(this.recentToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(889, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.recentToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(164, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem1
            // 
            this.recentToolStripMenuItem1.Name = "recentToolStripMenuItem1";
            this.recentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.recentToolStripMenuItem1.Text = "Recent";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(889, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SetInOut";
            this.TopMost = true;
            this.Closed += new System.EventHandler(this.buttonDisconnect_Click);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
        private global::System.Windows.Forms.ListBox listBox1;
        private global::System.Windows.Forms.Button buttonStart;
        private global::System.Windows.Forms.Button buttonStop;
        private global::System.Windows.Forms.Button buttonDisconnect;
        private global::System.ComponentModel.IContainer components;
        private global::System.Windows.Forms.MainMenu mainMenu1;
        private global::System.Windows.Forms.MenuItem menuItem1;
        private global::System.Windows.Forms.MenuItem menuItem2;
        private global::System.Windows.Forms.MenuItem menuItem3;
        private global::System.Windows.Forms.MenuItem menuItem4;
        private global::System.Windows.Forms.MenuItem menuItem5;
        private global::System.Windows.Forms.MenuItem menuItem6;
        private global::System.Windows.Forms.MenuItem menuItem7;
        private global::System.Windows.Forms.MenuItem menuItem8;
        private global::System.Windows.Forms.MenuItem menuItem9;
        private global::System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolstripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem FileTSMI;
        private System.Windows.Forms.ToolStripMenuItem openTSMI1;
        private System.Windows.Forms.ToolStripMenuItem saveTSMI1;
        private System.Windows.Forms.ToolStripMenuItem CommandTSMI;
        private System.Windows.Forms.ToolStripMenuItem exitTSMI1;
        private System.Windows.Forms.ToolStripMenuItem StartTSMI1;
        private System.Windows.Forms.ToolStripMenuItem StopTSMI1;
        private System.Windows.Forms.ToolStripMenuItem disconnectTSMI1;
        private System.Windows.Forms.ToolStripMenuItem AboutTSMI;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
