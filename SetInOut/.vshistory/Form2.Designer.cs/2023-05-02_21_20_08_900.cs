﻿namespace SetInOut
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
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
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonDisconnect);
            this.panel3.Controls.Add(this.buttonStop);
            this.panel3.Controls.Add(this.buttonStart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 491);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(830, 30);
            this.panel3.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(830, 457);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 11;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnect.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonDisconnect.Location = new System.Drawing.Point(189, 1);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(87, 27);
            this.buttonDisconnect.TabIndex = 7;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Salmon;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonStop.Location = new System.Drawing.Point(96, 1);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(87, 27);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LightGreen;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Green;
            this.buttonStart.Location = new System.Drawing.Point(3, 1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(87, 27);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 531);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
    }
}