namespace Snobol4
{
    public class YYMINORTYPE : object
    {
        public string S
        {
            get; set;
        }

        public YYMINORTYPE(string s)
        {
            S = s;
        }

        public YYMINORTYPE()
        {
            S = "";
        }

        public static implicit operator YYMINORTYPE(string s)
        {
            return new YYMINORTYPE(s);
        }

        public override string ToString()
        {
            return S;
        }

    }
}
