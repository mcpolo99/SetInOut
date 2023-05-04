using System;

namespace SetInOut
{
	public class istruzione
	{
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
		public char GetTipo()
		{
			return this.tipo;
		}
		public int GetLefthVal()
		{
			return this.lefth;
		}
		public int GetLivelloLogico()
		{
			bool flag = !this.val;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}
		public string GetTestoRiga()
		{
			return this.riga;
		}
		private char tipo;
		private int lefth;
		private bool val;
		private string riga;
	}
}
