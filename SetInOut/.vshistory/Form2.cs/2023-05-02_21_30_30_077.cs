﻿using System;
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
        [STAThread]
        private static void Main()
        {
            Application.Run(new Form2());
        }



    }
}