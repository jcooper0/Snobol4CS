namespace Snobol4;

public class YYMINORTYPE : object
{
    public string S
    {
        get; set;
    }

    public int Count
    {
        get;
        set;
    }

    public YYMINORTYPE(string s)
    {
        S = s;
        Count = 0;
    }

    public YYMINORTYPE()
    {
        S = "";
    }

    public static implicit operator YYMINORTYPE(string s)
    {
        return new YYMINORTYPE(s);
    }

    public int Increment()
    {
        Count++;
        return Count;
    }

    public override string ToString()
    {
        return S;
    }

}