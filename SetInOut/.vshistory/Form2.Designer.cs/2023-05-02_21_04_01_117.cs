namespace SetInOut
{
    partial class Form2
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rTB1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTSMI,
            this.CommandTSMI,
            this.AboutTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(10, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
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
            // openTSMI1
            // 
            this.openTSMI1.Name = "openTSMI1";
            this.openTSMI1.Size = new System.Drawing.Size(103, 22);
            this.openTSMI1.Text = "Open";
            // 
            // saveTSMI1
            // 
            this.saveTSMI1.Name = "saveTSMI1";
            this.saveTSMI1.Size = new System.Drawing.Size(103, 22);
            this.saveTSMI1.Text = "Save";
            // 
            // exitTSMI1
            // 
            this.exitTSMI1.Name = "exitTSMI1";
            this.exitTSMI1.Size = new System.Drawing.Size(103, 22);
            this.exitTSMI1.Text = "Exit";
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
            // StartTSMI1
            // 
            this.StartTSMI1.Name = "StartTSMI1";
            this.StartTSMI1.Size = new System.Drawing.Size(180, 22);
            this.StartTSMI1.Text = "Start";
            // 
            // StopTSMI1
            // 
            this.StopTSMI1.Name = "StopTSMI1";
            this.StopTSMI1.Size = new System.Drawing.Size(180, 22);
            this.StopTSMI1.Text = "Stop";
            // 
            // disconnectTSMI1
            // 
            this.disconnectTSMI1.Name = "disconnectTSMI1";
            this.disconnectTSMI1.Size = new System.Drawing.Size(180, 22);
            this.disconnectTSMI1.Text = "Disconnect";
            // 
            // AboutTSMI
            // 
            this.AboutTSMI.Name = "AboutTSMI";
            this.AboutTSMI.Size = new System.Drawing.Size(24, 20);
            this.AboutTSMI.Text = "?";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 34);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(200, 200);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(830, 200);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // rTB1
            // 
            this.rTB1.AutoSize = true;
            this.rTB1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rTB1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTB1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rTB1.Location = new System.Drawing.Point(187, 293);
            this.rTB1.Name = "rTB1";
            this.rTB1.Size = new System.Drawing.Size(127, 152);
            this.rTB1.TabIndex = 9;
            this.rTB1.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 531);
            this.Controls.Add(this.rTB1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileTSMI;
        private System.Windows.Forms.ToolStripMenuItem openTSMI1;
        private System.Windows.Forms.ToolStripMenuItem saveTSMI1;
        private System.Windows.Forms.ToolStripMenuItem exitTSMI1;
        private System.Windows.Forms.ToolStripMenuItem CommandTSMI;
        private System.Windows.Forms.ToolStripMenuItem StartTSMI1;
        private System.Windows.Forms.ToolStripMenuItem StopTSMI1;
        private System.Windows.Forms.ToolStripMenuItem disconnectTSMI1;
        private System.Windows.Forms.ToolStripMenuItem AboutTSMI;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox rTB1;
    }
}