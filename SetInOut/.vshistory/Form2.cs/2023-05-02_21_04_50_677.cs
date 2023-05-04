using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        // Token: 0x06000004 RID: 4 RVA: 0x0000292A File Offset: 0x0000192A
        [STAThread]
        private static void Main()
        {
            //Form1.istrList = new istruzione[100];
            Application.Run(new Form2());
        }



    }
}
