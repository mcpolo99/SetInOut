// Decompiled with JetBrains decompiler
// Type: SetInOut.istruzione
// Assembly: SetInOut, Version=15.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: A3E7A417-4026-4567-B275-3D5E8BF6FC64
// Assembly location: C:\WNC\home\xnc\bin\SetInOut.exe

namespace SetInOut
{
  public class istruzione
  {
    private char tipo;
    private int lefth;
    private bool val;
    private string riga;

    public istruzione(char t, int l, bool v, string r)
    {
      this.tipo = t;
      this.lefth = l;
      this.val = v;
      this.riga = r;
    }

    public istruzione(char t, int l, string r)
    {
      this.tipo = t;
      this.lefth = l;
      this.val = false;
      this.riga = r;
    }

    public istruzione(string r)
    {
      this.tipo = ';';
      this.lefth = 0;
      this.val = false;
      this.riga = r;
    }

    public char GetTipo() => this.tipo;

    public int GetLefthVal() => this.lefth;

    public int GetLivelloLogico() => !this.val ? 0 : 1;

    public string GetTestoRiga() => this.riga;
  }
}
