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

        private Thread ExecThread;

        public void Execute()
        {
            try
            {
                bool flag = this.VerificaSintassi();
                if (flag)
                {
                    this.EseguiIstruzioni();
                }
            }
            catch (ThreadAbortException)
            {
                this.listBox1.Items.Add("Esecuzione interrotta...");
            }
        }

        private bool VerificaSintassi()
        {
            bool flag = true;
            string[] lines = this.rTB1.Lines;
            this.listBox1.Items.Clear();
            this.numIstr = 0;
            int num = 0;
            while (flag && num < lines.Length)
            {
                string text = lines[num].Trim();
                bool flag2 = text.Length == 0;
                if (flag2)
                {
                    this.listBox1.Items.Add("");
                }
                else
                {
                    CharEnumerator enumerator = text.GetEnumerator();
                    enumerator.MoveNext();
                    char c = enumerator.Current;
                    if (c <= 'D')
                    {
                        if (c != ';')
                        {
                            if (c != 'D')
                            {
                                goto IL_3F1;
                            }
                            int num2 = text.IndexOf(";", 1, text.Length - 1);
                            bool flag3 = num2 < 0;
                            string text2;
                            if (flag3)
                            {
                                text2 = text.Substring(1, text.Length - 1);
                            }
                            else
                            {
                                text2 = text.Substring(1, num2 - 1).Trim();
                            }
                            int l;
                            try
                            {
                                l = Convert.ToInt32(text2.Trim());
                            }
                            catch
                            {
                                this.listBox1.Items.Add(text + " <- errore: '" + text2 + "' deve essere un numero!");
                                flag = false;
                                goto IL_411;
                            }
                            this.listBox1.Items.Add(text);
                            Form1.istrList[this.numIstr] = new istruzione('D', l, text);
                            this.numIstr++;
                        }
                        else
                        {
                            this.listBox1.Items.Add(text);
                            Form1.istrList[this.numIstr] = new istruzione(text);
                            this.numIstr++;
                        }
                    }
                    else
                    {
                        if (c != 'I' && c != 'O')
                        {
                            goto IL_3F1;
                        }
                        char t = enumerator.Current;
                        int num2 = text.IndexOf("=", 1, text.Length - 1);
                        bool flag4 = num2 < 0;
                        if (flag4)
                        {
                            this.listBox1.Items.Add(text + " <- errore: manca il segno '='");
                            flag = false;
                        }
                        else
                        {
                            bool flag5 = num2 == text.Length - 1;
                            if (flag5)
                            {
                                this.listBox1.Items.Add(text + " <- errore: manca il valore logico");
                                flag = false;
                            }
                            else
                            {
                                string text2 = text.Substring(1, num2 - 1);
                                bool flag6 = text2.Length == 0;
                                if (flag6)
                                {
                                    this.listBox1.Items.Add(text + " <- errore: manca l'indirizzo di I/O");
                                    flag = false;
                                }
                                else
                                {
                                    for (int i = 1; i <= num2 + 1; i++)
                                    {
                                        enumerator.MoveNext();
                                    }
                                    char c2 = enumerator.Current;
                                    bool flag7 = num2 + 2 < text.Length;
                                    if (flag7)
                                    {
                                        int j = num2 + 2;
                                        while (j < text.Length)
                                        {
                                            enumerator.MoveNext();
                                            bool flag8 = enumerator.Current == ' ' || enumerator.Current == '\t';
                                            if (flag8)
                                            {
                                                j++;
                                            }
                                            else
                                            {
                                                bool flag9 = enumerator.Current == ';';
                                                if (flag9)
                                                {
                                                    break;
                                                }
                                                this.listBox1.Items.Add(text + " <- errore: sintassi non corretta a destra del segno '='");
                                                flag = false;
                                                break;
                                            }
                                        }
                                    }
                                    bool flag10 = !flag;
                                    if (!flag10)
                                    {
                                        int l2;
                                        try
                                        {
                                            l2 = Convert.ToInt32(text2);
                                        }
                                        catch
                                        {
                                            this.listBox1.Items.Add(text + " <- errore: '" + text2 + "' deve essere un numero!");
                                            flag = false;
                                            goto IL_411;
                                        }
                                        bool flag11 = c2 == '1' || c2 == '0';
                                        if (flag11)
                                        {
                                            int num3 = Convert.ToInt32(c2);
                                            this.listBox1.Items.Add(text);
                                            Form1.istrList[this.numIstr] = new istruzione(t, l2, this.LivelloLogico(c2), text);
                                            this.numIstr++;
                                        }
                                        else
                                        {
                                            this.listBox1.Items.Add(text + " <- errore: il valore a destra di '=' deve essere 1 o 0!");
                                            flag = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                IL_411:
                    goto IL_412;
                IL_3F1:
                    this.listBox1.Items.Add(text + " <- Errore");
                    flag = false;
                }
            IL_412:
                num++;
            }
            return flag;
        }
        private void EseguiIstruzioni()
        {
            int num = 1;
            this.listBox1.Items.Clear();
            this.ResetTab();
            int i = 0;
            while (i < this.numIstr)
            {
                char tipo = Form1.istrList[i].GetTipo();
                if (tipo <= 'D')
                {
                    if (tipo != ';')
                    {
                        if (tipo == 'D')
                        {
                            this.listBox1.Items.Add(Form1.istrList[i].GetTestoRiga());
                            Thread.Sleep(Form1.istrList[i].GetLefthVal() * 10);
                        }
                    }
                    else
                    {
                        this.listBox1.Items.Add(Form1.istrList[i].GetTestoRiga());
                    }
                }
                else if (tipo == 'I' || tipo == 'O')
                {
                    this.listBox1.Items.Add(Form1.istrList[i].GetTestoRiga());
                    bool flag = !this.siCN;
                    if (!flag)
                    {
                        bool flag2 = Form1.istrList[i].GetTipo() == 'I';
                        double num2;
                        if (flag2)
                        {
                            num2 = 1.0;
                        }
                        else
                        {
                            num2 = 0.0;
                        }
                        this.datiCN.Sdm.SetData("SetIO", null, num.ToString(), "TipoIO", num2);
                        this.datiCN.Sdm.SetData("SetIO", null, num.ToString(), "Ind", (double)Form1.istrList[i].GetLefthVal());
                        this.datiCN.Sdm.SetData("SetIO", null, num.ToString(), "Valore", (double)Form1.istrList[i].GetLivelloLogico());
                        num++;
                    }
                }
            IL_19A:
                i++;
                continue;
                goto IL_19A;
            }
            bool flag3 = num > 1;
            if (flag3)
            {
                this.datiCN.Sdm.SaveData("SetIO");
            }
            this.listBox1.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.listBox1.Items.Add("Esecuzione completata...");
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
