using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using cni.daticn;
using Microsoft.Win32;


namespace SetInOut
{
    public partial class Form1 : Form
    {
        private static istruzione[] istrList;
        private int numIstr = 0;
        private bool siCN = true;
        private DatiCn datiCN;
        private const string msgErrorCnKo = "SetIO: Error on CN connection";
        private string titoloForm = "SetInOut";
        private Thread ExecThread;
        private string dataDiCompilazione;
        private string stringVer;
        List<string> recentFiles = new List<string>();
        ToolStripDropDownButton recentFilesDropDown = new ToolStripDropDownButton();




        public Form1()
        {
            
            this.InitializeComponent();
            bool flag = this.siCN;
            if (flag)
            {
                try
                {
                    this.CollegamentoCN();
                }
                catch (FileNotFoundException ex)
                {
                    DialogResult result = MessageBox.Show(ex.Message + " \n Please Put SetInOut in xnc\\Bin", "Cannot find assemblyfile", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    if (result == DialogResult.OK)
                    {
                        // Close the application
                        Application.Exit();
                    }


                }
            }
            Version version = new Version(Application.ProductVersion);
            this.stringVer = version.ToString();
            this.dataDiCompilazione = "22/07/2008";
            this.titoloForm = "SetInOut (ver. " + this.stringVer + ") ";
            this.Text = this.titoloForm;
            this.ExecThread = new Thread(new ThreadStart(this.Execute));
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\MyApp\RecentFiles");
            if (key != null)
            {
                for (int i = 0; ; i++)
                {
                    string filePath = (string)key.GetValue("File" + i);
                    if (filePath == null) break;
                    recentFiles.Add(filePath);
                }
            }





        }
        [STAThread]
        private static void Main()
        {
            Form1.istrList = new istruzione[100];
            Application.Run(new Form1());
        }
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
            string[] lines = this.richTextBox1.Lines;
            this.listBox1.Items.Clear();
            this.numIstr = 0;
            for (int index1 = 0; flag && index1 < lines.Length; ++index1)
            {
                string r = lines[index1].Trim();
                if (r.Length == 0)
                {
                    this.listBox1.Items.Add((object)"");
                }
                else
                {
                    CharEnumerator enumerator = r.GetEnumerator();
                    enumerator.MoveNext();
                    switch (enumerator.Current)
                    {
                        case ';':
                            this.listBox1.Items.Add((object)r);
                            Form1.istrList[this.numIstr] = new istruzione(r);
                            ++this.numIstr;
                            break;
                        case 'D':
                            int num1 = r.IndexOf(";", 1, r.Length - 1);
                            string str1 = num1 >= 0 ? r.Substring(1, num1 - 1).Trim() : r.Substring(1, r.Length - 1);
                            int int32_1;
                            try
                            {
                                int32_1 = Convert.ToInt32(str1.Trim());
                            }
                            catch
                            {
                                this.listBox1.Items.Add((object)(r + " <- errore: '" + str1 + "' deve essere un numero!"));
                                flag = false;
                                break;
                            }
                            this.listBox1.Items.Add((object)r);
                            Form1.istrList[this.numIstr] = new istruzione('D', int32_1, r);
                            ++this.numIstr;
                            break;
                        case 'I':
                        case 'O':
                            char current1 = enumerator.Current;
                            int num2 = r.IndexOf("=", 1, r.Length - 1);
                            if (num2 < 0)
                            {
                                this.listBox1.Items.Add((object)(r + " <- errore: manca il segno '='"));
                                flag = false;
                                break;
                            }
                            if (num2 == r.Length - 1)
                            {
                                this.listBox1.Items.Add((object)(r + " <- errore: manca il valore logico"));
                                flag = false;
                                break;
                            }
                            string str2 = r.Substring(1, num2 - 1);
                            if (str2.Length == 0)
                            {
                                this.listBox1.Items.Add((object)(r + " <- errore: manca l'indirizzo di I/O"));
                                flag = false;
                                break;
                            }
                            for (int index2 = 1; index2 <= num2 + 1; ++index2)
                                enumerator.MoveNext();
                            char current2 = enumerator.Current;
                            if (num2 + 2 < r.Length)
                            {
                                for (int index3 = num2 + 2; index3 < r.Length; ++index3)
                                {
                                    enumerator.MoveNext();
                                    if (enumerator.Current != ' ' && enumerator.Current != '\t')
                                    {
                                        if (enumerator.Current != ';')
                                        {
                                            this.listBox1.Items.Add((object)(r + " <- errore: sintassi non corretta a destra del segno '='"));
                                            flag = false;
                                            break;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (flag)
                            {
                                int int32_2;
                                try
                                {
                                    int32_2 = Convert.ToInt32(str2);
                                }
                                catch
                                {
                                    this.listBox1.Items.Add((object)(r + " <- errore: '" + str2 + "' deve essere un numero!"));
                                    flag = false;
                                    break;
                                }
                                if (current2 == '1' || current2 == '0')
                                {
                                    Convert.ToInt32(current2);
                                    this.listBox1.Items.Add((object)r);
                                    Form1.istrList[this.numIstr] = new istruzione(current1, int32_2, this.LivelloLogico(current2), r);
                                    ++this.numIstr;
                                    break;
                                }
                                this.listBox1.Items.Add((object)(r + " <- errore: il valore a destra di '=' deve essere 1 o 0!"));
                                flag = false;
                                break;
                            }
                            break;
                        default:
                            this.listBox1.Items.Add((object)(r + " <- Errore"));
                            flag = false;
                            break;
                    }
                }
            }
            return flag;
        }


        //private bool VerificaSintassi()
        //{
        //    bool flag = true;
        //    string[] lines = this.rTB1.Lines;
        //    this.listBox1.Items.Clear();
        //    this.numIstr = 0;
        //    int num = 0;
        //    while (flag && num < lines.Length)
        //    {
        //        string text = lines[num].Trim();
        //        bool flag2 = text.Length == 0;
        //        if (flag2)
        //        {
        //            this.listBox1.Items.Add("");
        //        }
        //        else
        //        {
        //            CharEnumerator enumerator = text.GetEnumerator();
        //            enumerator.MoveNext();
        //            char c = enumerator.Current;
        //            if (c <= 'D')
        //            {
        //                if (c != ';')
        //                {
        //                    if (c != 'D')
        //                    {
        //                        goto IL_3F1;
        //                    }
        //                    int num2 = text.IndexOf(";", 1, text.Length - 1);
        //                    bool flag3 = num2 < 0;
        //                    string text2;
        //                    if (flag3)
        //                    {
        //                        text2 = text.Substring(1, text.Length - 1);
        //                    }
        //                    else
        //                    {
        //                        text2 = text.Substring(1, num2 - 1).Trim();
        //                    }
        //                    int l;
        //                    try
        //                    {
        //                        l = Convert.ToInt32(text2.Trim());
        //                    }
        //                    catch
        //                    {
        //                        this.listBox1.Items.Add(text + " <- errore: '" + text2 + "' deve essere un numero!");
        //                        flag = false;
        //                        goto IL_411;
        //                    }
        //                    this.listBox1.Items.Add(text);
        //                    Form1.istrList[this.numIstr] = new istruzione('D', l, text);
        //                    this.numIstr++;
        //                }
        //                else
        //                {
        //                    this.listBox1.Items.Add(text);
        //                    Form1.istrList[this.numIstr] = new istruzione(text);
        //                    this.numIstr++;
        //                }
        //            }
        //            else
        //            {
        //                if (c != 'I' && c != 'O')
        //                {
        //                    goto IL_3F1;
        //                }
        //                char t = enumerator.Current;
        //                int num2 = text.IndexOf("=", 1, text.Length - 1);
        //                bool flag4 = num2 < 0;
        //                if (flag4)
        //                {
        //                    this.listBox1.Items.Add(text + " <- errore: manca il segno '='");
        //                    flag = false;
        //                }
        //                else
        //                {
        //                    bool flag5 = num2 == text.Length - 1;
        //                    if (flag5)
        //                    {
        //                        this.listBox1.Items.Add(text + " <- errore: manca il valore logico");
        //                        flag = false;
        //                    }
        //                    else
        //                    {
        //                        string text2 = text.Substring(1, num2 - 1);
        //                        bool flag6 = text2.Length == 0;
        //                        if (flag6)
        //                        {
        //                            this.listBox1.Items.Add(text + " <- errore: manca l'indirizzo di I/O");
        //                            flag = false;
        //                        }
        //                        else
        //                        {
        //                            for (int i = 1; i <= num2 + 1; i++)
        //                            {
        //                                enumerator.MoveNext();
        //                            }
        //                            char c2 = enumerator.Current;
        //                            bool flag7 = num2 + 2 < text.Length;
        //                            if (flag7)
        //                            {
        //                                int j = num2 + 2;
        //                                while (j < text.Length)
        //                                {
        //                                    enumerator.MoveNext();
        //                                    bool flag8 = enumerator.Current == ' ' || enumerator.Current == '\t';
        //                                    if (flag8)
        //                                    {
        //                                        j++;
        //                                    }
        //                                    else
        //                                    {
        //                                        bool flag9 = enumerator.Current == ';';
        //                                        if (flag9)
        //                                        {
        //                                            break;
        //                                        }
        //                                        this.listBox1.Items.Add(text + " <- errore: sintassi non corretta a destra del segno '='");
        //                                        flag = false;
        //                                        break;
        //                                    }
        //                                }
        //                            }
        //                            bool flag10 = !flag;
        //                            if (!flag10)
        //                            {
        //                                int l2;
        //                                try
        //                                {
        //                                    l2 = Convert.ToInt32(text2);
        //                                }
        //                                catch
        //                                {
        //                                    this.listBox1.Items.Add(text + " <- errore: '" + text2 + "' deve essere un numero!");
        //                                    flag = false;
        //                                    goto IL_411;
        //                                }
        //                                bool flag11 = c2 == '1' || c2 == '0';
        //                                if (flag11)
        //                                {
        //                                    int num3 = Convert.ToInt32(c2);
        //                                    this.listBox1.Items.Add(text);
        //                                    Form1.istrList[this.numIstr] = new istruzione(t, l2, this.LivelloLogico(c2), text);
        //                                    this.numIstr++;
        //                                }
        //                                else
        //                                {
        //                                    this.listBox1.Items.Add(text + " <- errore: il valore a destra di '=' deve essere 1 o 0!");
        //                                    flag = false;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        IL_411:
        //            goto IL_412;
        //        IL_3F1:
        //            this.listBox1.Items.Add(text + " <- Errore");
        //            flag = false;
        //        }
        //    IL_412:
        //        num++;
        //    }
        //    return flag;
        //}
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
        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Start();
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
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
        private bool LivelloLogico(char liv)
        {
            bool flag = liv == '0';
            return !flag;
        }
        private void CollegamentoCN()
        {
            try
            {
                this.datiCN = new DatiCn();
                this.datiCN.Attach();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetIO: Error on CN connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
               // Application.Exit();
            }
        }

        private void FormMessage_Closing(object sender, CancelEventArgs e)
        {
            this.ResetTab();
        }
        private void ResetTab()
        {
            bool flag = !this.siCN;
            if (!flag)
            {
                int item = this.datiCN.Sdm.GetItem("SetIO", null);
                for (int i = 1; i <= item; i++)
                {
                    this.datiCN.Sdm.SetData("SetIO", null, i.ToString(), "TipoIO", -1.0);
                    this.datiCN.Sdm.SetData("SetIO", null, i.ToString(), "Ind", -1.0);
                    this.datiCN.Sdm.SetData("SetIO", null, i.ToString(), "Valore", 0.0);
                }
                this.datiCN.Sdm.SaveData("SetIO");
            }
        }
        private void menuItem4_Click(object sender, EventArgs e)
        {

        }
       
       
        private void ImpostaNomeFileNelTitolo(string nuovoNomeFile)
        {
            this.Text = this.titoloForm + " - " + nuovoNomeFile;
            int num = 35;
            bool flag = this.Text.Length >= num;
            if (flag)
            {
                this.Text = this.titoloForm + " - ..." + nuovoNomeFile.Substring(nuovoNomeFile.Length - num);
            }
        }
        private void menuItem10_Click(object sender, EventArgs e)
        {
            string text = string.Concat(new string[]
            {
                "SetInOut\nVersione ",
                this.stringVer,
                " -  ",
                this.dataDiCompilazione,
                "\nUP 1 - Biesse SpA  -  Automation Dept.\n\nTool ad uso esclusivo del personale tecnico Biesse.    "
            });
            MessageBox.Show(text, "SetInOut Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RecentFile_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                string file = menuItem.Text;
                // Open or load the selected file

                // ...



                this.richTextBox1.LoadFile(file, RichTextBoxStreamType.PlainText);
                this.ImpostaNomeFileNelTitolo(file);
            }
        }



        private void addlist()
        {
            foreach (string file in recentFiles)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(file);
                menuItem.Click += new EventHandler(RecentFile_Click);
                recentToolStripMenuItem1.DropDownItems.Add(menuItem);
            }



       
        }






        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.txt";
            saveFileDialog.Filter = "TXT Files|*.txt";
            bool flag = saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0;
            if (flag)
            {
                this.richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.ImpostaNomeFileNelTitolo(saveFileDialog.FileName);
                recentFiles.Add(saveFileDialog.FileName);
                addlist();
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.txt";
            openFileDialog.Filter = "TXT Files|*.txt";
            bool flag = openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0;
            if (flag)
            {
                this.richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.ImpostaNomeFileNelTitolo(openFileDialog.FileName);
                recentFiles.Add(openFileDialog.FileName);
                addlist();
            }
        }

        private void recentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                string file = menuItem.Text;
                // Load the selected file
                // ...

                this.richTextBox1.LoadFile(file, RichTextBoxStreamType.PlainText);
                this.ImpostaNomeFileNelTitolo(file);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Stop();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ResetTab();
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\MyApp\RecentFiles");
            for (int i = 0; i < recentFiles.Count; i++)
            {
                key.SetValue("File" + i, recentFiles[i]);
            }
        }
    }
}
