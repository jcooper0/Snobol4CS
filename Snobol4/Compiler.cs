namespace Snobol4
{
    public class Compiler
    {
        internal Lexer Lex
        {
            get; set;
        }

        internal Parser Parse
        {
            get; set;
        }

        public SourceFile Source
        {
            get; set;
        }

        public SourceLine Line
        {
            get; set;
        }

        public Compiler()
        {
            Lex = new Lexer();
            Parse = new Parser();
            Source = new SourceFile();
        }

        public void Compile(string path)
        {
            if (!Source.ReadSourceToList(path))
                return;

            foreach (SourceLine line in Source.SourceLines)
            {
                Parse.Line = line;
                try
                {
                    Lex.LexLine(line);
                    foreach (Token t in line.LexResult)
                    {
                        Parse.Parse((int)t.TokenType, t.MatchedString);
                    }
                    Parse.End();
                }
                catch (SyntaxError e)
                {
                    if (e.Description == "")
                        e.Description = "Syntax Error\r\n" + line.Path + " (" + line.SourceLineNumber + ")\r\n" + line.SourceLineText;

                    Parse.Line.Error = true;
                    Parse.Line.ErrorDescription = e.Description;
                    Parse.Reset();
                }
            }
        }
    }
}
