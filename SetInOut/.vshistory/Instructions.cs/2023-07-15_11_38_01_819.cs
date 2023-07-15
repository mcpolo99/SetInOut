using System;

namespace SetInOut
{
    // Token: 0x02000003 RID: 3
    public class Instructions
    {
        // Token: 0x0600001A RID: 26 RVA: 0x000020A2 File Offset: 0x000002A2
        public Instructions(char t, int l, bool v, string r)
        {
            this.tipo = t;
            this.lefth = l;
            this.val = v;
            this.riga = r;
        }

        // Token: 0x0600001B RID: 27 RVA: 0x000020C9 File Offset: 0x000002C9
        public Instructions(char t, int l, string r)
        {
            this.tipo = t;
            this.lefth = l;
            this.val = false;
            this.riga = r;
        }

        // Token: 0x0600001C RID: 28 RVA: 0x000020EF File Offset: 0x000002EF
        public Instructions(string r)
        {
            this.tipo = ';';
            this.lefth = 0;
            this.val = false;
            this.riga = r;
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00003488 File Offset: 0x00001688
        public char GetTipo()
        {
            return this.tipo;
        }

        // Token: 0x0600001E RID: 30 RVA: 0x000034A0 File Offset: 0x000016A0
        public int GetLefthVal()
        {
            return this.lefth;
        }

        // Token: 0x0600001F RID: 31 RVA: 0x000034B8 File Offset: 0x000016B8
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

        // Token: 0x06000020 RID: 32 RVA: 0x000034DC File Offset: 0x000016DC
        public string GetTestoRiga()
        {
            return this.riga;
        }

        // Token: 0x0400001B RID: 27
        private char tipo;

        // Token: 0x0400001C RID: 28
        private int lefth;

        // Token: 0x0400001D RID: 29
        private bool val;

        // Token: 0x0400001E RID: 30
        private string riga;
    }
}