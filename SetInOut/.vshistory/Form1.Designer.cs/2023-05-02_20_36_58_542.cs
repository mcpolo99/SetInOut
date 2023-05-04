namespace SetInOut
{
    // Token: 0x02000002 RID: 2
    public partial class Form1 : global::System.Windows.Forms.Form
    {
        // Token: 0x06000002 RID: 2 RVA: 0x000020F8 File Offset: 0x000010F8
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

        // Token: 0x06000003 RID: 3 RVA: 0x00002130 File Offset: 0x00001130
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.rTB1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolstripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.FileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StartTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StopTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectTSMI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Green;
            this.listBox1.ItemHeight = 11;
            this.listBox1.Location = new System.Drawing.Point(12, 311);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(609, 202);
            this.listBox1.TabIndex = 5;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LightGreen;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Green;
            this.buttonStart.Location = new System.Drawing.Point(12, 277);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(87, 28);
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
            this.buttonStop.Location = new System.Drawing.Point(105, 277);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(87, 28);
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
            this.buttonDisconnect.Location = new System.Drawing.Point(198, 277);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(87, 28);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // rTB1
            // 
            this.rTB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTB1.AutoSize = true;
            this.rTB1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rTB1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTB1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rTB1.Location = new System.Drawing.Point(0, 39);
            this.rTB1.Name = "rTB1";
            this.rTB1.Size = new System.Drawing.Size(621, 187);
            this.rTB1.TabIndex = 1;
            this.rTB1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMI,
            this.CommandTSMI,
            this.AboutTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
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
            // FileTSMI
            // 
            this.FileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI1,
            this.saveTSMI1,
            this.exitTSMI1});
            this.FileTSMI.Name = "FileTSMI";
            this.FileTSMI.Size = new System.Drawing.Size(37, 20);
            this.FileTSMI.Text = "File";
            // 
            // CommandTSMI
            // 
            this.CommandTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartTSMI1,
            this.StopTSMI1,
            this.disconnectTSMI1});
            this.CommandTSMI.Name = "CommandTSMI";
            this.CommandTSMI.Size = new System.Drawing.Size(76, 20);
            this.CommandTSMI.Text = "Command";
            // 
            // openTSMI1
            // 
            this.openTSMI1.Name = "openTSMI1";
            this.openTSMI1.Size = new System.Drawing.Size(180, 22);
            this.openTSMI1.Text = "Open";
            this.openTSMI1.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveTSMI1
            // 
            this.saveTSMI1.Name = "saveTSMI1";
            this.saveTSMI1.Size = new System.Drawing.Size(180, 22);
            this.saveTSMI1.Text = "Save";
            // 
            // exitTSMI1
            // 
            this.exitTSMI1.Name = "exitTSMI1";
            this.exitTSMI1.Size = new System.Drawing.Size(180, 22);
            this.exitTSMI1.Text = "Exit";
            // 
            // AboutTSMI
            // 
            this.AboutTSMI.Name = "AboutTSMI";
            this.AboutTSMI.Size = new System.Drawing.Size(24, 20);
            this.AboutTSMI.Text = "?";
            this.AboutTSMI.Click += new System.EventHandler(this.AboutTSMI_Click);
            // 
            // StartTSMI1
            // 
            this.StartTSMI1.Name = "StartTSMI1";
            this.StartTSMI1.Size = new System.Drawing.Size(133, 22);
            this.StartTSMI1.Text = "Start";
            // 
            // StopTSMI1
            // 
            this.StopTSMI1.Name = "StopTSMI1";
            this.StopTSMI1.Size = new System.Drawing.Size(133, 22);
            this.StopTSMI1.Text = "Stop";
            // 
            // disconnectTSMI1
            // 
            this.disconnectTSMI1.Name = "disconnectTSMI1";
            this.disconnectTSMI1.Size = new System.Drawing.Size(133, 22);
            this.disconnectTSMI1.Text = "Disconnect";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 525);
            this.Controls.Add(this.rTB1);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SetInOut";
            this.Closed += new System.EventHandler(this.buttonDisconnect_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x04000001 RID: 1
        private global::System.Windows.Forms.ListBox listBox1;

        // Token: 0x04000002 RID: 2
        private global::System.Windows.Forms.Button buttonStart;

        // Token: 0x04000003 RID: 3
        private global::System.Windows.Forms.Button buttonStop;

        // Token: 0x04000004 RID: 4
        private global::System.Windows.Forms.Button buttonDisconnect;

        // Token: 0x04000005 RID: 5
        private global::System.ComponentModel.IContainer components;

        // Token: 0x0400000B RID: 11
        private global::System.Windows.Forms.MainMenu mainMenu1;

        // Token: 0x0400000C RID: 12
        private global::System.Windows.Forms.MenuItem menuItem1;

        // Token: 0x0400000D RID: 13
        private global::System.Windows.Forms.MenuItem menuItem2;

        // Token: 0x0400000E RID: 14
        private global::System.Windows.Forms.MenuItem menuItem3;

        // Token: 0x0400000F RID: 15
        private global::System.Windows.Forms.MenuItem menuItem4;

        // Token: 0x04000010 RID: 16
        private global::System.Windows.Forms.RichTextBox rTB1;

        // Token: 0x04000011 RID: 17
        private global::System.Windows.Forms.MenuItem menuItem5;

        // Token: 0x04000012 RID: 18
        private global::System.Windows.Forms.MenuItem menuItem6;

        // Token: 0x04000013 RID: 19
        private global::System.Windows.Forms.MenuItem menuItem7;

        // Token: 0x04000014 RID: 20
        private global::System.Windows.Forms.MenuItem menuItem8;

        // Token: 0x04000016 RID: 22
        private global::System.Windows.Forms.MenuItem menuItem9;

        // Token: 0x04000017 RID: 23
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
    }
}
