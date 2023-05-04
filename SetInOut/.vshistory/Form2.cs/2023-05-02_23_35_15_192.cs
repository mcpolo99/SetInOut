using cni.daticn;
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
        private Thread ExecThread;
        private bool siCN = true;
        private DatiCn datiCN;
        private static Instruct[] istrList;
        private int numIstr = 0;
        private string FormTitle = "SetInOut";
        private string dataDiCompilazione;
        private string stringVer;
        private const string msgErrorCnKo = "SetIO: Error on CN connection";
        private string titoloForm = "SetInOut";
        private bool LivelloLogico(char liv) => liv != '0';
        public Form2()
        {
            InitializeComponent();
            bool flag = this.siCN;
            if (!flag)
            {
                this.CollegamentoCN();
            }
            Version version = new Version(Application.ProductVersion);
            this.stringVer = version.ToString();
            this.dataDiCompilazione = "22/07/2008";
            this.titoloForm = "SetInOut (ver. " + this.stringVer + ") ";
            this.Text = this.titoloForm;
            this.ExecThread = new Thread(new ThreadStart(this.Execute));
        }
        [STAThread]
        private static void Main()
        {
            Application.Run(new Form2());
            istrList = new Instruct[100];
        }




        public void Execute()
        {
            try
            {
                bool flag = this.VerifySyntax();
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

        private void CollegamentoCN() //connect CN
        {
            try
            {
                this.datiCN = new DatiCn();
                this.datiCN.Attach();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "SetIO: Error on CN connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }


        private bool Verify()
        {
            bool flag = true;
            string[] lines = this.rTB1.Lines;
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
                            Form2.istrList[this.numIstr] = new Instruct(r);
                            ++this.numIstr;
                            break;
                        #region
                        //case 'D':
                        //    int numEqual = r.IndexOf('=');
                        //    if (numEqual < 0)
                        //    {
                        //        this.listBox1.Items.Add((object)(r + " <- errore: manca l'uguale"));
                        //        flag = false;
                        //        break;
                        //    }
                        //    string varName = r.Substring(1, numEqual - 1).Trim();
                        //    if (varName.Length == 0)
                        //    {
                        //        this.listBox1.Items.Add((object)(r + " <- errore: manca il nome della variabile"));
                        //        flag = false;
                        //        break;
                        //    }
                        //    string varValStr = r.Substring(numEqual + 1).Trim();
                        //    int varVal;
                        //    if (!Int32.TryParse(varValStr, out varVal))
                        //    {
                        //        this.listBox1.Items.Add((object)(r + " <- errore: il valore assegnato non è un intero"));
                        //        flag = false;
                        //        break;
                        //    }
                        //    this.listBox1.Items.Add((object)r);
                        //    Form2.istrList[this.numIstr] = new Instruct('D', varVal, false, varName);
                        //    ++this.numIstr;
                        //    break;
                        #endregion
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
                            Form2.istrList[this.numIstr] = new Instruct('D', int32_1, r);
                            ++this.numIstr;
                            break;

                            #region
                            //////case 'N':
                            //////    int numIf = r.IndexOf("(", 1, r.Length - 1);
                            //////    if (numIf < 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca la condizione"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    string strIf = r.Substring(numIf + 1, r.IndexOf(")", numIf + 1, r.Length - numIf - 1) - numIf - 1);
                            //////    if (strIf.Length == 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca la condizione"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    int numThen = r.IndexOf("THEN", numIf + 1, r.Length - numIf - 1);
                            //////    if (numThen < 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca il THEN"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    string strThen = r.Substring(numIf + 1 + strIf.Length + 1, numThen - numIf - 1 - strIf.Length - 1).Trim();
                            //////    if (strThen.Length == 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca l'istruzione THEN"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    int thenIndex = Array.IndexOf(lines, strThen);
                            //////    if (thenIndex < 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: istruzione THEN non trovata"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    this.listBox1.Items.Add((object)r);
                            //////    Form2.istrList[this.numIstr] = new Instruct('I', 0, false, "", strIf, thenIndex);
                            //////    ++this.numIstr;
                            //////    break;
                            //////case 'M':
                            //////    int numOut = r.IndexOf("(", 1, r.Length - 1);
                            //////    if (numOut < 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca l'uscita"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    string strOut = r.Substring(numOut + 1, r.IndexOf(")", numOut + 1, r.Length - numOut - 1) - numOut - 1);
                            //////    if (strOut.Length == 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca l'uscita"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    int outIndex = Array.IndexOf(lines, strOut);
                            //////    if (outIndex < 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: istruzione uscita non trovata"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    this.listBox1.Items.Add((object)r);
                            //////    Form2.istrList[this.numIstr] = new Instruct('O', 0, false, "", "", 0, outIndex);
                            //////    ++this.numIstr;
                            //////    break;
                            //////case 'I':
                            //////case 'O':
                            //////    char current1 = enumerator.Current;
                            //////    int num2 = r.IndexOf("=", 1, r.Length - 1);
                            //////    if (num2 < 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca il segno '='"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    if (num2 == r.Length - 1)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca il valore logico"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    string str2 = r.Substring(1, num2 - 1);
                            //////    if (str2.Length == 0)
                            //////    {
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: manca l'indirizzo di I/O"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    for (int index2 = 1; index2 <= num2 + 1; ++index2)
                            //////        enumerator.MoveNext();
                            //////    char current2 = enumerator.Current;
                            //////    if (num2 + 2 < r.Length)
                            //////    {
                            //////        for (int index3 = num2 + 2; index3 < r.Length; ++index3)
                            //////        {
                            //////            enumerator.MoveNext();
                            //////            if (enumerator.Current != ' ' && enumerator.Current != '\t')
                            //////            {
                            //////                if (enumerator.Current != ';')
                            //////                {
                            //////                    this.listBox1.Items.Add((object)(r + " <- errore: sintassi non corretta a destra del segno '='"));
                            //////                    flag = false;
                            //////                    break;
                            //////                }
                            //////                break;
                            //////            }
                            //////        }
                            //////    }
                            //////    if (flag)
                            //////    {
                            //////        int int32_2;
                            //////        try
                            //////        {
                            //////            int32_2 = Convert.ToInt32(str2);
                            //////        }
                            //////        catch
                            //////        {
                            //////            this.listBox1.Items.Add((object)(r + " <- errore: '" + str2 + "' deve essere un numero!"));
                            //////            flag = false;
                            //////            break;
                            //////        }
                            //////        if (current2 == '1' || current2 == '0')
                            //////        {
                            //////            Convert.ToInt32(current2);
                            //////            this.listBox1.Items.Add((object)r);
                            //////            Form2.istrList[this.numIstr] = new Instruct(current1, int32_2, this.LivelloLogico(current2), r);
                            //////            ++this.numIstr;
                            //////            break;
                            //////        }
                            //////        this.listBox1.Items.Add((object)(r + " <- errore: il valore a destra di '=' deve essere 1 o 0!"));
                            //////        flag = false;
                            //////        break;
                            //////    }
                            //////    break;
                            //////default:
                            //////    this.listBox1.Items.Add((object)(r + " <- errore: carattere iniziale non valido"));
                            //////    flag = false;
                            //////    break;
                            ///
                            #endregion
                    }
                }

            }
        }


        private bool VerifySyntax() //Verify syntax
        {
            bool flag = true;
            string[] lines = this.rTB1.Lines;
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
                            Form2.istrList[this.numIstr] = new Instruct(r);
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
                                    Form2.istrList[this.numIstr] = new Instruct(current1, int32_2, this.LivelloLogico(current2), r);
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
        private void EseguiIstruzioni() //Execute Instructions
        {
            int num = 1;
            this.listBox1.Items.Clear();
            this.ResetTab();
            for (int index = 0; index < this.numIstr; ++index)
            {
                switch (Form2.istrList[index].GetType())
                {
                    case ';':
                        this.listBox1.Items.Add((object)Form2.istrList[index].GetRow());
                        break;
                    case 'D':
                        this.listBox1.Items.Add((object)Form2.istrList[index].GetRow());
                        Thread.Sleep(Form2.istrList[index].GetLefthVal() * 10);
                        break;
                    case 'I':
                    case 'O':
                        this.listBox1.Items.Add((object)Form2.istrList[index].GetRow());
                        if (this.siCN)
                        {
                            double DataValue = Form2.istrList[index].GetType() != 'I' ? 0.0 : 1.0;
                            this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "TipoIO", DataValue);
                            this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "Ind", (double)Form2.istrList[index].GetLefthVal());
                            this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "Valore", (double)Form2.istrList[index].GetLogicLevel());
                            ++num;
                            break;
                        }
                        break;
                }
            }
            if (num > 1)
                this.datiCN.Sdm.SaveData("SetIO");
            this.listBox1.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.listBox1.Items.Add((object)"Esecuzione completata...");
        }

        private void ResetTab()
        {
            if (!this.siCN)
                return;
            int num = this.datiCN.Sdm.GetItem("SetIO", (string)null);
            for (int index = 1; index <= num; ++index)
            {
                this.datiCN.Sdm.SetData("SetIO", (string)null, index.ToString(), "TipoIO", -1.0);
                this.datiCN.Sdm.SetData("SetIO", (string)null, index.ToString(), "Ind", -1.0);
                this.datiCN.Sdm.SetData("SetIO", (string)null, index.ToString(), "Valore", 0.0);
            }
            this.datiCN.Sdm.SaveData("SetIO");
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
        private void SetFileNameInTitle(string newFilename)
        {
            this.Text = this.FormTitle + " - " + newFilename;
            int num = 35;
            if (this.Text.Length < num)
                return;
            this.Text = this.FormTitle + " - ..." + newFilename.Substring(newFilename.Length - num);
        }

        private void openTSMI1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.txt";
            openFileDialog.Filter = "TXT Files|*.txt";
            if (openFileDialog.ShowDialog() != DialogResult.OK || openFileDialog.FileName.Length <= 0)
                return;
            this.rTB1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            this.SetFileNameInTitle(openFileDialog.FileName);

        }

        private void saveTSMI1_Click(object sender, EventArgs e)
        {
          
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            this.SetFileNameInTitle(saveFileDialog.FileName);
            saveFileDialog.DefaultExt = "*.txt";
            saveFileDialog.Filter = "TXT Files|*.txt";
            if (saveFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.FileName.Length <= 0)
                return;
            this.rTB1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            

        }

        private void exitTSMI1_Click(object sender, EventArgs e)
        {
            this.ResetTab();
            Application.Exit();

        }



        private void StartTSMI1_Click(object sender, EventArgs e)
        {
            this.Start();
        }
        private void StopTSMI1_Click(object sender, EventArgs e)
        {
            this.Stop();
        }
        private void disconnectTSMI1_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }




        private void buttonStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop(); 
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ResetTab();
        }
    }
}
