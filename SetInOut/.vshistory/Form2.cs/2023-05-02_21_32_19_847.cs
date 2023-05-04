using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetInOut
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        [STAThread]
        private static void Main()
        {
            Application.Run(new Form2());
        }




        private void Start()
        {
            bool flag = !this.ExecThread.IsAlive;
            if (flag)
            {
                this.ExecThread = new Thread(new ThreadStart(this.Execute));
                this.ExecThread.IsBackground = true;
                this.ExecThread.Start();
            }
        }
        private void Stop()
        {
            bool isAlive = this.ExecThread.IsAlive;
            if (isAlive)
            {
                this.ExecThread.Abort();
                this.ExecThread.Join();
            }
        }
        private void Disconnect()
        {
            bool isAlive = this.ExecThread.IsAlive;
            if (isAlive)
            {
                this.ExecThread.Abort();
                this.ExecThread.Join();
            }
            this.ResetTab();
            this.listBox1.Items.Add("Disconnessione da PLC...");
        }

        private void openTSMI1_Click(object sender, EventArgs e)
        {

        }

        private void saveTSMI1_Click(object sender, EventArgs e)
        {

        }

        private void exitTSMI1_Click(object sender, EventArgs e)
        {

        }

        private void StartTSMI1_Click(object sender, EventArgs e)
        {

        }

        private void StopTSMI1_Click(object sender, EventArgs e)
        {

        }

        private void disconnectTSMI1_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {

        }
    }
}
