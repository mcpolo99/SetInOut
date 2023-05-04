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
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::SetInOut.Form1));
            this.listBox1 = new global::System.Windows.Forms.ListBox();
            this.buttonStart = new global::System.Windows.Forms.Button();
            this.buttonStop = new global::System.Windows.Forms.Button();
            this.buttonDisconnect = new global::System.Windows.Forms.Button();
            this.mainMenu1 = new global::System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new global::System.Windows.Forms.MenuItem();
            this.menuItem2 = new global::System.Windows.Forms.MenuItem();
            this.menuItem3 = new global::System.Windows.Forms.MenuItem();
            this.menuItem4 = new global::System.Windows.Forms.MenuItem();
            this.menuItem5 = new global::System.Windows.Forms.MenuItem();
            this.menuItem6 = new global::System.Windows.Forms.MenuItem();
            this.menuItem7 = new global::System.Windows.Forms.MenuItem();
            this.menuItem8 = new global::System.Windows.Forms.MenuItem();
            this.menuItem9 = new global::System.Windows.Forms.MenuItem();
            this.menuItem10 = new global::System.Windows.Forms.MenuItem();
            this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
            base.SuspendLayout();
            this.listBox1.BackColor = global::System.Drawing.Color.FromArgb(192, 255, 192);
            this.listBox1.Font = new global::System.Drawing.Font("Lucida Console", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.listBox1.ForeColor = global::System.Drawing.Color.Green;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new global::System.Drawing.Point(8, 272);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = global::System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new global::System.Drawing.Size(615, 242);
            this.listBox1.TabIndex = 5;
            this.buttonStart.BackColor = global::System.Drawing.Color.LightGreen;
            this.buttonStart.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.buttonStart.ForeColor = global::System.Drawing.Color.Green;
            this.buttonStart.Location = new global::System.Drawing.Point(16, 232);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new global::System.Drawing.Size(104, 32);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new global::System.EventHandler(this.buttonStart_Click);
            this.buttonStop.BackColor = global::System.Drawing.Color.Salmon;
            this.buttonStop.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.buttonStop.ForeColor = global::System.Drawing.Color.DarkRed;
            this.buttonStop.Location = new global::System.Drawing.Point(136, 232);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new global::System.Drawing.Size(104, 32);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new global::System.EventHandler(this.buttonStop_Click);
            this.buttonDisconnect.BackColor = global::System.Drawing.Color.LightSteelBlue;
            this.buttonDisconnect.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.buttonDisconnect.ForeColor = global::System.Drawing.Color.DarkBlue;
            this.buttonDisconnect.Location = new global::System.Drawing.Point(256, 232);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new global::System.Drawing.Size(104, 32);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new global::System.EventHandler(this.buttonDisconnect_Click);
            this.mainMenu1.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
            {
                this.menuItem1,
                this.menuItem5,
                this.menuItem9
            });
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
            {
                this.menuItem2,
                this.menuItem3,
                this.menuItem4
            });
            this.menuItem1.Text = "&File";
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "&Apri";
            this.menuItem2.Click += new global::System.EventHandler(this.menuItem2_Click);
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "&Salva";
            this.menuItem3.Click += new global::System.EventHandler(this.menuItem3_Click);
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "&Esci";
            this.menuItem4.Click += new global::System.EventHandler(this.menuItem4_Click);
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
            {
                this.menuItem6,
                this.menuItem7,
                this.menuItem8
            });
            this.menuItem5.Text = "&Comandi";
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "&Start";
            this.menuItem6.Click += new global::System.EventHandler(this.menuItem6_Click);
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Sto&p";
            this.menuItem7.Click += new global::System.EventHandler(this.menuItem7_Click);
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "&Disconnect";
            this.menuItem8.Click += new global::System.EventHandler(this.menuItem8_Click);
            this.menuItem9.Index = 2;
            this.menuItem9.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
            {
                this.menuItem10
            });
            this.menuItem9.Text = "&?";
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "&Informazioni su SetInOut";
            this.menuItem10.Click += new global::System.EventHandler(this.menuItem10_Click);
            this.richTextBox1.AutoSize = true;
            this.richTextBox1.BackColor = global::System.Drawing.SystemColors.HighlightText;
            this.richTextBox1.Font = new global::System.Drawing.Font("Lucida Console", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.richTextBox1.ForeColor = global::System.Drawing.SystemColors.HotTrack;
            this.richTextBox1.Location = new global::System.Drawing.Point(8, 8);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new global::System.Drawing.Size(616, 216);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.AutoScaleBaseSize = new global::System.Drawing.Size(6, 15);
            base.ClientSize = new global::System.Drawing.Size(632, 525);
            base.Controls.Add(this.richTextBox1);
            base.Controls.Add(this.buttonDisconnect);
            base.Controls.Add(this.buttonStop);
            base.Controls.Add(this.buttonStart);
            base.Controls.Add(this.listBox1);
          //  base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            //base.Menu = this.mainMenu1;
            base.Name = "Form1";
            this.Text = "SetInOut";
            base.Closed += new global::System.EventHandler(this.buttonDisconnect_Click);
            base.ResumeLayout(false);
            base.PerformLayout();
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
        private global::System.Windows.Forms.RichTextBox richTextBox1;

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
    }
}
