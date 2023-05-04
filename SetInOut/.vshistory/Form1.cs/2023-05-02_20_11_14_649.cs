﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using cni.daticn;

namespace SetInOut
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public Form1()
		{
			this.InitializeComponent();
			bool flag = this.siCN;
			if (flag)
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

		// Token: 0x06000004 RID: 4 RVA: 0x0000292A File Offset: 0x0000192A
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
                if (!this.VerificaSintassi())
                    return;
                this.EseguiIstruzioni();
            }
            catch (ThreadAbortException ex)
            {
                this.listBox1.Items.Add((object)"Esecuzione interrotta...");
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

        private void EseguiIstruzioni()
        {
            int num = 1;
            this.listBox1.Items.Clear();
            this.ResetTab();
            for (int index = 0; index < this.numIstr; ++index)
            {
                switch (Form1.istrList[index].GetTipo())
                {
                    case ';':
                        this.listBox1.Items.Add((object)Form1.istrList[index].GetTestoRiga());
                        break;
                    case 'D':
                        this.listBox1.Items.Add((object)Form1.istrList[index].GetTestoRiga());
                        Thread.Sleep(Form1.istrList[index].GetLefthVal() * 10);
                        break;
                    case 'I':
                    case 'O':
                        this.listBox1.Items.Add((object)Form1.istrList[index].GetTestoRiga());
                        if (this.siCN)
                        {
                            double DataValue = Form1.istrList[index].GetTipo() != 'I' ? 0.0 : 1.0;
                            this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "TipoIO", DataValue);
                            this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "Ind", (double)Form1.istrList[index].GetLefthVal());
                            this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "Valore", (double)Form1.istrList[index].GetLivelloLogico());
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

        private void buttonStart_Click(object sender, EventArgs e) => this.Start();

        private void buttonStop_Click(object sender, EventArgs e) => this.Stop();

        private void buttonDisconnect_Click(object sender, EventArgs e) => this.Disconnect();

        private void Start()
        {
            if (this.ExecThread.IsAlive)
                return;
            this.ExecThread = new Thread(new ThreadStart(this.Execute));
            this.ExecThread.IsBackground = true;
            this.ExecThread.Start();
        }

        private void Stop()
        {
            if (!this.ExecThread.IsAlive)
                return;
            this.ExecThread.Abort();
            this.ExecThread.Join();
        }

        private void Disconnect()
        {
            if (this.ExecThread.IsAlive)
            {
                this.ExecThread.Abort();
                this.ExecThread.Join();
            }
            this.ResetTab();
            this.listBox1.Items.Add((object)"Disconnessione da PLC...");
        }

        private bool LivelloLogico(char liv) => liv != '0';

        private void CollegamentoCN()
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

        private void FormMessage_Closing(object sender, CancelEventArgs e) => this.ResetTab();

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

        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.ResetTab();
            Application.Exit();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.txt";
            openFileDialog.Filter = "TXT Files|*.txt";
            if (openFileDialog.ShowDialog() != DialogResult.OK || openFileDialog.FileName.Length <= 0)
                return;
            this.richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            this.ImpostaNomeFileNelTitolo(openFileDialog.FileName);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.txt";
            saveFileDialog.Filter = "TXT Files|*.txt";
            if (saveFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.FileName.Length <= 0)
                return;
            this.richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            this.ImpostaNomeFileNelTitolo(saveFileDialog.FileName);
        }

        private void menuItem6_Click(object sender, EventArgs e) => this.Start();

        private void menuItem7_Click(object sender, EventArgs e) => this.Stop();

        private void menuItem8_Click(object sender, EventArgs e) => this.Disconnect();

        private void ImpostaNomeFileNelTitolo(string nuovoNomeFile)
        {
            this.Text = this.titoloForm + " - " + nuovoNomeFile;
            int num = 35;
            if (this.Text.Length < num)
                return;
            this.Text = this.titoloForm + " - ..." + nuovoNomeFile.Substring(nuovoNomeFile.Length - num);
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            int num = (int)MessageBox.Show("SetInOut\nVersione " + this.stringVer + " -  " + this.dataDiCompilazione + "\nUP 1 - Biesse SpA  -  Automation Dept.\n\nTool ad uso esclusivo del personale tecnico Biesse.    ", "SetInOut Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002944 File Offset: 0x00001944
        //////public void Execute()
        //////{
        //////	try
        //////	{
        //////		bool flag = this.VerificaSintassi();
        //////		if (flag)
        //////		{
        //////			this.EseguiIstruzioni();
        //////		}
        //////	}
        //////	catch (ThreadAbortException)
        //////	{
        //////		this.listBox1.Items.Add("Esecuzione interrotta...");
        //////	}
        //////}

        //////// Token: 0x06000006 RID: 6 RVA: 0x00002994 File Offset: 0x00001994
        //////private bool VerificaSintassi()
        //////{
        //////	bool flag = true;
        //////	string[] lines = this.richTextBox1.Lines;
        //////	this.listBox1.Items.Clear();
        //////	this.numIstr = 0;
        //////	int num = 0;
        //////	while (flag && num < lines.Length)
        //////	{
        //////		string text = lines[num].Trim();
        //////		bool flag2 = text.Length == 0;
        //////		if (flag2)
        //////		{
        //////			this.listBox1.Items.Add("");
        //////		}
        //////		else
        //////		{
        //////			CharEnumerator enumerator = text.GetEnumerator();
        //////			enumerator.MoveNext();
        //////			char c = enumerator.Current;
        //////			if (c <= 'D')
        //////			{
        //////				if (c != ';')
        //////				{
        //////					if (c != 'D')
        //////					{
        //////						goto IL_3F1;
        //////					}
        //////					int num2 = text.IndexOf(";", 1, text.Length - 1);
        //////					bool flag3 = num2 < 0;
        //////					string text2;
        //////					if (flag3)
        //////					{
        //////						text2 = text.Substring(1, text.Length - 1);
        //////					}
        //////					else
        //////					{
        //////						text2 = text.Substring(1, num2 - 1).Trim();
        //////					}
        //////					int l;
        //////					try
        //////					{
        //////						l = Convert.ToInt32(text2.Trim());
        //////					}
        //////					catch
        //////					{
        //////						this.listBox1.Items.Add(text + " <- errore: '" + text2 + "' deve essere un numero!");
        //////						flag = false;
        //////						goto IL_411;
        //////					}
        //////					this.listBox1.Items.Add(text);
        //////					Form1.istrList[this.numIstr] = new istruzione('D', l, text);
        //////					this.numIstr++;
        //////				}
        //////				else
        //////				{
        //////					this.listBox1.Items.Add(text);
        //////					Form1.istrList[this.numIstr] = new istruzione(text);
        //////					this.numIstr++;
        //////				}
        //////			}
        //////			else
        //////			{
        //////				if (c != 'I' && c != 'O')
        //////				{
        //////					goto IL_3F1;
        //////				}
        //////				char t = enumerator.Current;
        //////				int num2 = text.IndexOf("=", 1, text.Length - 1);
        //////				bool flag4 = num2 < 0;
        //////				if (flag4)
        //////				{
        //////					this.listBox1.Items.Add(text + " <- errore: manca il segno '='");
        //////					flag = false;
        //////				}
        //////				else
        //////				{
        //////					bool flag5 = num2 == text.Length - 1;
        //////					if (flag5)
        //////					{
        //////						this.listBox1.Items.Add(text + " <- errore: manca il valore logico");
        //////						flag = false;
        //////					}
        //////					else
        //////					{
        //////						string text2 = text.Substring(1, num2 - 1);
        //////						bool flag6 = text2.Length == 0;
        //////						if (flag6)
        //////						{
        //////							this.listBox1.Items.Add(text + " <- errore: manca l'indirizzo di I/O");
        //////							flag = false;
        //////						}
        //////						else
        //////						{
        //////							for (int i = 1; i <= num2 + 1; i++)
        //////							{
        //////								enumerator.MoveNext();
        //////							}
        //////							char c2 = enumerator.Current;
        //////							bool flag7 = num2 + 2 < text.Length;
        //////							if (flag7)
        //////							{
        //////								int j = num2 + 2;
        //////								while (j < text.Length)
        //////								{
        //////									enumerator.MoveNext();
        //////									bool flag8 = enumerator.Current == ' ' || enumerator.Current == '\t';
        //////									if (flag8)
        //////									{
        //////										j++;
        //////									}
        //////									else
        //////									{
        //////										bool flag9 = enumerator.Current == ';';
        //////										if (flag9)
        //////										{
        //////											break;
        //////										}
        //////										this.listBox1.Items.Add(text + " <- errore: sintassi non corretta a destra del segno '='");
        //////										flag = false;
        //////										break;
        //////									}
        //////								}
        //////							}
        //////							bool flag10 = !flag;
        //////							if (!flag10)
        //////							{
        //////								int l2;
        //////								try
        //////								{
        //////									l2 = Convert.ToInt32(text2);
        //////								}
        //////								catch
        //////								{
        //////									this.listBox1.Items.Add(text + " <- errore: '" + text2 + "' deve essere un numero!");
        //////									flag = false;
        //////									goto IL_411;
        //////								}
        //////								bool flag11 = c2 == '1' || c2 == '0';
        //////								if (flag11)
        //////								{
        //////									int num3 = Convert.ToInt32(c2);
        //////									this.listBox1.Items.Add(text);
        //////									Form1.istrList[this.numIstr] = new istruzione(t, l2, this.LivelloLogico(c2), text);
        //////									this.numIstr++;
        //////								}
        //////								else
        //////								{
        //////									this.listBox1.Items.Add(text + " <- errore: il valore a destra di '=' deve essere 1 o 0!");
        //////									flag = false;
        //////								}
        //////							}
        //////						}
        //////					}
        //////				}
        //////			}
        //////			IL_411:
        //////			goto IL_412;
        //////			IL_3F1:
        //////			this.listBox1.Items.Add(text + " <- Errore");
        //////			flag = false;
        //////		}
        //////		IL_412:
        //////		num++;
        //////	}
        //////	return flag;
        //////}

        //////      // Token: 0x06000007 RID: 7 RVA: 0x00002DF0 File Offset: 0x00001DF0
        //////      private void EseguiIstruzioni()
        //////      {
        //////          int num = 1;
        //////          this.listBox1.Items.Clear();
        //////          this.ResetTab();
        //////          for (int index = 0; index < this.numIstr; ++index)
        //////          {
        //////              switch (Form1.istrList[index].GetTipo())
        //////              {
        //////                  case ';':
        //////                      this.listBox1.Items.Add((object)Form1.istrList[index].GetTestoRiga());
        //////                      break;
        //////                  case 'D':
        //////                      this.listBox1.Items.Add((object)Form1.istrList[index].GetTestoRiga());
        //////                      Thread.Sleep(Form1.istrList[index].GetLefthVal() * 10);
        //////                      break;
        //////                  case 'I':
        //////                  case 'O':
        //////                      this.listBox1.Items.Add((object)Form1.istrList[index].GetTestoRiga());
        //////                      if (this.siCN)
        //////                      {
        //////                          double DataValue = Form1.istrList[index].GetTipo() != 'I' ? 0.0 : 1.0;
        //////                          this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "TipoIO", DataValue);
        //////                          this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "Ind", (double)Form1.istrList[index].GetLefthVal());
        //////                          this.datiCN.Sdm.SetData("SetIO", (string)null, num.ToString(), "Valore", (double)Form1.istrList[index].GetLivelloLogico());
        //////                          ++num;
        //////                          break;
        //////                      }
        //////                      break;
        //////              }
        //////          }
        //////          if (num > 1)
        //////              this.datiCN.Sdm.SaveData("SetIO");
        //////          this.listBox1.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
        //////          this.listBox1.Items.Add((object)"Esecuzione completata...");
        //////      }

        //////      // Token: 0x06000008 RID: 8 RVA: 0x00003002 File Offset: 0x00002002
        //////      private void buttonStart_Click(object sender, EventArgs e)
        //////{
        //////	this.Start();
        //////}

        //////// Token: 0x06000009 RID: 9 RVA: 0x0000300C File Offset: 0x0000200C
        //////private void buttonStop_Click(object sender, EventArgs e)
        //////{
        //////	this.Stop();
        //////}

        //////// Token: 0x0600000A RID: 10 RVA: 0x00003016 File Offset: 0x00002016
        //////private void buttonDisconnect_Click(object sender, EventArgs e)
        //////{
        //////	this.Disconnect();
        //////}

        //////// Token: 0x0600000B RID: 11 RVA: 0x00003020 File Offset: 0x00002020
        //////private void Start()
        //////{
        //////	bool flag = !this.ExecThread.IsAlive;
        //////	if (flag)
        //////	{
        //////		this.ExecThread = new Thread(new ThreadStart(this.Execute));
        //////		this.ExecThread.IsBackground = true;
        //////		this.ExecThread.Start();
        //////	}
        //////}

        //////// Token: 0x0600000C RID: 12 RVA: 0x00003074 File Offset: 0x00002074
        //////private void Stop()
        //////{
        //////	bool isAlive = this.ExecThread.IsAlive;
        //////	if (isAlive)
        //////	{
        //////		this.ExecThread.Abort();
        //////		this.ExecThread.Join();
        //////	}
        //////}

        //////// Token: 0x0600000D RID: 13 RVA: 0x000030AC File Offset: 0x000020AC
        //////private void Disconnect()
        //////{
        //////	bool isAlive = this.ExecThread.IsAlive;
        //////	if (isAlive)
        //////	{
        //////		this.ExecThread.Abort();
        //////		this.ExecThread.Join();
        //////	}
        //////	this.ResetTab();
        //////	this.listBox1.Items.Add("Disconnessione da PLC...");
        //////}

        //////// Token: 0x0600000E RID: 14 RVA: 0x00003100 File Offset: 0x00002100
        //////private bool LivelloLogico(char liv)
        //////{
        //////	bool flag = liv == '0';
        //////	return !flag;
        //////}

        //////// Token: 0x0600000F RID: 15 RVA: 0x00003120 File Offset: 0x00002120
        //////private void CollegamentoCN()
        //////{
        //////	try
        //////	{
        //////		this.datiCN = new DatiCn();
        //////		this.datiCN.Attach();
        //////	}
        //////	catch (Exception ex)
        //////	{
        //////		MessageBox.Show(ex.Message, "SetIO: Error on CN connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //////		Application.Exit();
        //////	}
        //////}

        //////// Token: 0x06000010 RID: 16 RVA: 0x00003178 File Offset: 0x00002178
        //////private void FormMessage_Closing(object sender, CancelEventArgs e)
        //////{
        //////	this.ResetTab();
        //////}

        //////// Token: 0x06000011 RID: 17 RVA: 0x00003184 File Offset: 0x00002184
        //////private void ResetTab()
        //////{
        //////	bool flag = !this.siCN;
        //////	if (!flag)
        //////	{
        //////		int item = this.datiCN.Sdm.GetItem("SetIO", null);
        //////		for (int i = 1; i <= item; i++)
        //////		{
        //////			this.datiCN.Sdm.SetData("SetIO", null, i.ToString(), "TipoIO", -1.0);
        //////			this.datiCN.Sdm.SetData("SetIO", null, i.ToString(), "Ind", -1.0);
        //////			this.datiCN.Sdm.SetData("SetIO", null, i.ToString(), "Valore", 0.0);
        //////		}
        //////		this.datiCN.Sdm.SaveData("SetIO");
        //////	}
        //////}

        //////// Token: 0x06000012 RID: 18 RVA: 0x00003270 File Offset: 0x00002270
        //////private void menuItem4_Click(object sender, EventArgs e)
        //////{
        //////	this.ResetTab();
        //////	Application.Exit();
        //////}

        //////// Token: 0x06000013 RID: 19 RVA: 0x00003280 File Offset: 0x00002280
        //////private void menuItem2_Click(object sender, EventArgs e)
        //////{
        //////	OpenFileDialog openFileDialog = new OpenFileDialog();
        //////	openFileDialog.DefaultExt = "*.txt";
        //////	openFileDialog.Filter = "TXT Files|*.txt";
        //////	bool flag = openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0;
        //////	if (flag)
        //////	{
        //////		this.richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
        //////		this.ImpostaNomeFileNelTitolo(openFileDialog.FileName);
        //////	}
        //////}

        //////// Token: 0x06000014 RID: 20 RVA: 0x000032EC File Offset: 0x000022EC
        //////private void menuItem3_Click(object sender, EventArgs e)
        //////{
        //////	SaveFileDialog saveFileDialog = new SaveFileDialog();
        //////	saveFileDialog.DefaultExt = "*.txt";
        //////	saveFileDialog.Filter = "TXT Files|*.txt";
        //////	bool flag = saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0;
        //////	if (flag)
        //////	{
        //////		this.richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
        //////		this.ImpostaNomeFileNelTitolo(saveFileDialog.FileName);
        //////	}
        //////}

        //////// Token: 0x06000015 RID: 21 RVA: 0x00003002 File Offset: 0x00002002
        //////private void menuItem6_Click(object sender, EventArgs e)
        //////{
        //////	this.Start();
        //////}

        //////// Token: 0x06000016 RID: 22 RVA: 0x0000300C File Offset: 0x0000200C
        //////private void menuItem7_Click(object sender, EventArgs e)
        //////{
        //////	this.Stop();
        //////}

        //////// Token: 0x06000017 RID: 23 RVA: 0x00003016 File Offset: 0x00002016
        //////private void menuItem8_Click(object sender, EventArgs e)
        //////{
        //////	this.Disconnect();
        //////}

        //////// Token: 0x06000018 RID: 24 RVA: 0x00003358 File Offset: 0x00002358
        //////private void ImpostaNomeFileNelTitolo(string nuovoNomeFile)
        //////{
        //////	this.Text = this.titoloForm + " - " + nuovoNomeFile;
        //////	int num = 35;
        //////	bool flag = this.Text.Length >= num;
        //////	if (flag)
        //////	{
        //////		this.Text = this.titoloForm + " - ..." + nuovoNomeFile.Substring(nuovoNomeFile.Length - num);
        //////	}
        //////}

        //////// Token: 0x06000019 RID: 25 RVA: 0x000033BC File Offset: 0x000023BC
        //////private void menuItem10_Click(object sender, EventArgs e)
        //////{
        //////	string text = string.Concat(new string[]
        //////	{
        //////		"SetInOut\nVersione ",
        //////		this.stringVer,
        //////		" -  ",
        //////		this.dataDiCompilazione,
        //////		"\nUP 1 - Biesse SpA  -  Automation Dept.\n\nTool ad uso esclusivo del personale tecnico Biesse.    "
        //////	});
        //////	MessageBox.Show(text, "SetInOut Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //////}

        // Token: 0x04000006 RID: 6
        private static istruzione[] istrList;

		// Token: 0x04000007 RID: 7
		private int numIstr = 0;

		// Token: 0x04000008 RID: 8
		private bool siCN = true;

		// Token: 0x04000009 RID: 9
		private DatiCn datiCN;

		// Token: 0x0400000A RID: 10
		private const string msgErrorCnKo = "SetIO: Error on CN connection";

		// Token: 0x04000015 RID: 21
		private string titoloForm = "SetInOut";

		// Token: 0x04000018 RID: 24
		private Thread ExecThread;

		// Token: 0x04000019 RID: 25
		private string dataDiCompilazione;

		// Token: 0x0400001A RID: 26
		private string stringVer;
	}
}
