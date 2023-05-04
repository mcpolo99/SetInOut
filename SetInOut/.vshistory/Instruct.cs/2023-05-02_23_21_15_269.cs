using System;

namespace SetInOut
{
	public class Instruct
    {
        public Instruct(char t, int l, bool v, string r)
        {
            this.type = t;
            this.lefth = l;
            this.val = v;
            this.row = r;
        }
        public Instruct(char t, int l, string r)
        {
            this.type = t;
            this.lefth = l;
            this.val = false;
            this.row = r;
        }
        public Instruct(string r)
        {
            this.type = ';';
            this.lefth = 0;
            this.val = false;
            this.row = r;
        }
        public Instruct(char type, int lefth, bool val, string row, string condition, int thenIndex)
        {
            this.type = type;
            this.lefth = lefth;
            this.val = val;
            this.row = row;
            this.Condition = condition;
            this.ThenIndex = thenIndex;
        }




        //       public char GetType()
        //	{
        //		return this.type;
        //	}
        //	public int GetLefthVal()
        //	{
        //		return this.lefth;
        //	}
        //	public int GetLogicLevel()
        //	{
        //		bool flag = !this.val;
        //		int result;
        //		if (flag)
        //		{
        //			result = 0;
        //		}
        //		else
        //		{
        //			result = 1;
        //		}
        //		return result;
        //	}
        //	public string GetRow()
        //	{
        //		return this.row;
        //	}
        //	private char type;
        //	private int lefth;
        //	private bool val;
        //	private string row;

        public char GetType()
    {
        return this.type;
    }
    public int GetLefthVal()
    {
        return this.lefth;
    }
    public int GetLogicLevel()
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
    public string GetRow()
    {
        return this.row;
    }

    // Properties for I-type instruction
    public string Condition { get; set; }
    public int ThenIndex { get; set; }

    // Properties for E-type instruction
    public int EndIndex { get; set; }

    // Properties for T-type instruction
    public string ThenInstruction { get; set; }

    private char type;
    private int lefth;
    private bool val;
    private string row;

	}
}
