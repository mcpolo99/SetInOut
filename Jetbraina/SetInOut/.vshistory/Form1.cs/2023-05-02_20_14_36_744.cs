// Decompiled with JetBrains decompiler
// Type: SetInOut.Form1
// Assembly: SetInOut, Version=15.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: A3E7A417-4026-4567-B275-3D5E8BF6FC64
// Assembly location: C:\WNC\home\xnc\bin\SetInOut.exe

using cni.daticn;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SetInOut
{
  public class Form1 : Form
  {
    private ListBox listBox1;
    private Button buttonStart;
    private Button buttonStop;
    private Button buttonDisconnect;
    private IContainer components;
    private static istruzione[] istrList;
    private int numIstr = 0;
    private bool siCN = true;
    private DatiCn datiCN;
    private const string msgErrorCnKo = "SetIO: Error on CN connection";
    private MainMenu mainMenu1;
    private MenuItem menuItem1;
    private MenuItem menuItem2;
    private MenuItem menuItem3;
    private MenuItem menuItem4;
    private RichTextBox richTextBox1;
    private MenuItem menuItem5;
    private MenuItem menuItem6;
    private MenuItem menuItem7;
    private MenuItem menuItem8;
    private string titoloForm = "SetInOut";
    private MenuItem menuItem9;
    private MenuItem menuItem10;
    private Thread ExecThread;
    private string dataDiCompilazione;
    private string stringVer;

    public Form1()
    {
      this.InitializeComponent();
      if (this.siCN)
        this.CollegamentoCN();
      this.stringVer = new Version(Application.ProductVersion).ToString();
      this.dataDiCompilazione = "22/07/2008";
      this.titoloForm = "SetInOut (ver. " + this.stringVer + ") ";
      this.Text = this.titoloForm;
      this.ExecThread = new Thread(new ThreadStart(this.Execute));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.listBox1 = new ListBox();
      this.buttonStart = new Button();
      this.buttonStop = new Button();
      this.buttonDisconnect = new Button();
      this.mainMenu1 = new MainMenu(this.components);
      this.menuItem1 = new MenuItem();
      this.menuItem2 = new MenuItem();
      this.menuItem3 = new MenuItem();
      this.menuItem4 = new MenuItem();
      this.menuItem5 = new MenuItem();
      this.menuItem6 = new MenuItem();
      this.menuItem7 = new MenuItem();
      this.menuItem8 = new MenuItem();
      this.menuItem9 = new MenuItem();
      this.menuItem10 = new MenuItem();
      this.richTextBox1 = new RichTextBox();
      this.SuspendLayout();
      this.listBox1.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.listBox1.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listBox1.ForeColor = Color.Green;
      this.listBox1.ItemHeight = 14;
      this.listBox1.Location = new Point(8, 272);
      this.listBox1.Name = "listBox1";
      this.listBox1.SelectionMode = SelectionMode.None;
      this.listBox1.Size = new Size(615, 242);
      this.listBox1.TabIndex = 5;
      this.buttonStart.BackColor = Color.LightGreen;
      this.buttonStart.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonStart.ForeColor = Color.Green;
      this.buttonStart.Location = new Point(16, 232);
      this.buttonStart.Name = "buttonStart";
      this.buttonStart.Size = new Size(104, 32);
      this.buttonStart.TabIndex = 2;
      this.buttonStart.Text = "Start";
      this.buttonStart.UseVisualStyleBackColor = false;
      this.buttonStart.Click += new EventHandler(this.buttonStart_Click);
      this.buttonStop.BackColor = Color.Salmon;
      this.buttonStop.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonStop.ForeColor = Color.DarkRed;
      this.buttonStop.Location = new Point(136, 232);
      this.buttonStop.Name = "buttonStop";
      this.buttonStop.Size = new Size(104, 32);
      this.buttonStop.TabIndex = 3;
      this.buttonStop.Text = "Stop";
      this.buttonStop.UseVisualStyleBackColor = false;
      this.buttonStop.Click += new EventHandler(this.buttonStop_Click);
      this.buttonDisconnect.BackColor = Color.LightSteelBlue;
      this.buttonDisconnect.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.buttonDisconnect.ForeColor = Color.DarkBlue;
      this.buttonDisconnect.Location = new Point(256, 232);
      this.buttonDisconnect.Name = "buttonDisconnect";
      this.buttonDisconnect.Size = new Size(104, 32);
      this.buttonDisconnect.TabIndex = 4;
      this.buttonDisconnect.Text = "Disconnect";
      this.buttonDisconnect.UseVisualStyleBackColor = false;
      this.buttonDisconnect.Click += new EventHandler(this.buttonDisconnect_Click);
      this.mainMenu1.MenuItems.AddRange(new MenuItem[3]
      {
        this.menuItem1,
        this.menuItem5,
        this.menuItem9
      });
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new MenuItem[3]
      {
        this.menuItem2,
        this.menuItem3,
        this.menuItem4
      });
      this.menuItem1.Text = "&File";
      this.menuItem2.Index = 0;
      this.menuItem2.Text = "&Apri";
      this.menuItem2.Click += new EventHandler(this.menuItem2_Click);
      this.menuItem3.Index = 1;
      this.menuItem3.Text = "&Salva";
      this.menuItem3.Click += new EventHandler(this.menuItem3_Click);
      this.menuItem4.Index = 2;
      this.menuItem4.Text = "&Esci";
      this.menuItem4.Click += new EventHandler(this.menuItem4_Click);
      this.menuItem5.Index = 1;
      this.menuItem5.MenuItems.AddRange(new MenuItem[3]
      {
        this.menuItem6,
        this.menuItem7,
        this.menuItem8
      });
      this.menuItem5.Text = "&Comandi";
      this.menuItem6.Index = 0;
      this.menuItem6.Text = "&Start";
      this.menuItem6.Click += new EventHandler(this.menuItem6_Click);
      this.menuItem7.Index = 1;
      this.menuItem7.Text = "Sto&p";
      this.menuItem7.Click += new EventHandler(this.menuItem7_Click);
      this.menuItem8.Index = 2;
      this.menuItem8.Text = "&Disconnect";
      this.menuItem8.Click += new EventHandler(this.menuItem8_Click);
      this.menuItem9.Index = 2;
      this.menuItem9.MenuItems.AddRange(new MenuItem[1]
      {
        this.menuItem10
      });
      this.menuItem9.Text = "&?";
      this.menuItem10.Index = 0;
      this.menuItem10.Text = "&Informazioni su SetInOut";
      this.menuItem10.Click += new EventHandler(this.menuItem10_Click);
      this.richTextBox1.AutoSize = true;
      this.richTextBox1.BackColor = SystemColors.HighlightText;
      this.richTextBox1.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.richTextBox1.ForeColor = SystemColors.HotTrack;
      this.richTextBox1.Location = new Point(8, 8);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(616, 216);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      this.AutoScaleBaseSize = new Size(6, 15);
      this.ClientSize = new Size(632, 525);
      this.Controls.Add((Control) this.richTextBox1);
      this.Controls.Add((Control) this.buttonDisconnect);
      this.Controls.Add((Control) this.buttonStop);
      this.Controls.Add((Control) this.buttonStart);
      this.Controls.Add((Control) this.listBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Menu = this.mainMenu1;
      this.Name = nameof (Form1);
      this.Text = "SetInOut";
      this.Closed += new EventHandler(this.buttonDisconnect_Click);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [STAThread]
    private static void Main()
    {
      Form1.istrList = new istruzione[100];
      Application.Run((Form) new Form1());
    }

    public void Execute()
    {
      try
      {
        if (!this.VerificaSintassi())
          return;
        this.EseguiIstruzioni();
      }
      //catch (ThreadAbortException ex)
      //{
      //  this.listBox1.Items.Add((object) "Esecuzione interrotta...");
      //}
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
          this.listBox1.Items.Add((object) "");
        }
        else
        {
          CharEnumerator enumerator = r.GetEnumerator();
          enumerator.MoveNext();
          switch (enumerator.Current)
          {
            case ';':
              this.listBox1.Items.Add((object) r);
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
                this.listBox1.Items.Add((object) (r + " <- errore: '" + str1 + "' deve essere un numero!"));
                flag = false;
                break;
              }
              this.listBox1.Items.Add((object) r);
              Form1.istrList[this.numIstr] = new istruzione('D', int32_1, r);
              ++this.numIstr;
              break;
            case 'I':
            case 'O':
              char current1 = enumerator.Current;
              int num2 = r.IndexOf("=", 1, r.Length - 1);
              if (num2 < 0)
              {
                this.listBox1.Items.Add((object) (r + " <- errore: manca il segno '='"));
                flag = false;
                break;
              }
              if (num2 == r.Length - 1)
              {
                this.listBox1.Items.Add((object) (r + " <- errore: manca il valore logico"));
                flag = false;
                break;
              }
              string str2 = r.Substring(1, num2 - 1);
              if (str2.Length == 0)
              {
                this.listBox1.Items.Add((object) (r + " <- errore: manca l'indirizzo di I/O"));
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
                      this.listBox1.Items.Add((object) (r + " <- errore: sintassi non corretta a destra del segno '='"));
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
                  this.listBox1.Items.Add((object) (r + " <- errore: '" + str2 + "' deve essere un numero!"));
                  flag = false;
                  break;
                }
                if (current2 == '1' || current2 == '0')
                {
                  Convert.ToInt32(current2);
                  this.listBox1.Items.Add((object) r);
                  Form1.istrList[this.numIstr] = new istruzione(current1, int32_2, this.LivelloLogico(current2), r);
                  ++this.numIstr;
                  break;
                }
                this.listBox1.Items.Add((object) (r + " <- errore: il valore a destra di '=' deve essere 1 o 0!"));
                flag = false;
                break;
              }
              break;
            default:
              this.listBox1.Items.Add((object) (r + " <- Errore"));
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
            this.listBox1.Items.Add((object) Form1.istrList[index].GetTestoRiga());
            break;
          case 'D':
            this.listBox1.Items.Add((object) Form1.istrList[index].GetTestoRiga());
            Thread.Sleep(Form1.istrList[index].GetLefthVal() * 10);
            break;
          case 'I':
          case 'O':
            this.listBox1.Items.Add((object) Form1.istrList[index].GetTestoRiga());
            if (this.siCN)
            {
              double DataValue = Form1.istrList[index].GetTipo() != 'I' ? 0.0 : 1.0;
              this.datiCN.Sdm.SetData("SetIO", (string) null, num.ToString(), "TipoIO", DataValue);
              this.datiCN.Sdm.SetData("SetIO", (string) null, num.ToString(), "Ind", (double) Form1.istrList[index].GetLefthVal());
              this.datiCN.Sdm.SetData("SetIO", (string) null, num.ToString(), "Valore", (double) Form1.istrList[index].GetLivelloLogico());
              ++num;
              break;
            }
            break;
        }
      }
      if (num > 1)
        this.datiCN.Sdm.SaveData("SetIO");
      this.listBox1.Font = new Font("Lucida Console", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listBox1.Items.Add((object) "Esecuzione completata...");
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
      this.listBox1.Items.Add((object) "Disconnessione da PLC...");
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
        int num = (int) MessageBox.Show(ex.Message, "SetIO: Error on CN connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Application.Exit();
      }
    }

    private void FormMessage_Closing(object sender, CancelEventArgs e) => this.ResetTab();

    private void ResetTab()
    {
      if (!this.siCN)
        return;
      int num = this.datiCN.Sdm.GetItem("SetIO", (string) null);
      for (int index = 1; index <= num; ++index)
      {
        this.datiCN.Sdm.SetData("SetIO", (string) null, index.ToString(), "TipoIO", -1.0);
        this.datiCN.Sdm.SetData("SetIO", (string) null, index.ToString(), "Ind", -1.0);
        this.datiCN.Sdm.SetData("SetIO", (string) null, index.ToString(), "Valore", 0.0);
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
      int num = (int) MessageBox.Show("SetInOut\nVersione " + this.stringVer + " -  " + this.dataDiCompilazione + "\nUP 1 - Biesse SpA  -  Automation Dept.\n\nTool ad uso esclusivo del personale tecnico Biesse.    ", "SetInOut Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
  }
}
