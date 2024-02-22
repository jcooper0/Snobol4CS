using System.Diagnostics;

namespace Snobol4;

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

    public string EntryLabel { get; set; } = "";

    public Compiler()
    {
        Lex = new Lexer();
        Parse = new Parser();
        Source = new SourceFile();
    }

    public void Compile(string path, bool doParse = true)
    {
        if (!Source.ReadSourceToList(path))
            return;

        Stopwatch sw = new();
        sw.Start();
        foreach (SourceLine line in Source.SourceLines)
        {
            try
            {
                Parse.Line = line;
                Lex.Lex(line);
                if (line.LineLabel.ToUpper() == "END")
                {
                    EntryLabel = Lex.GetEntryLabel(line);
                    break;
                }
                if(line.LexLine.Count == 0)
                    continue;
                if (!doParse)
                    continue;
                foreach (Token t in line.LexLine)
                    Parse.Parse((int)t.TokenType, t.MatchedString);
                Parse.End();
            }
            catch (SyntaxError e)
            {
                Parse.Line.Error = true;
                Parse.Line.ErrorDescription = e.Description;
                Parse.Reset();
                Console.WriteLine(e.Description);
            }
        }
        Console.WriteLine(sw.ElapsedMilliseconds + " ms");
        if (!Lex.Labels.ContainsKey("END"))
        {
            SyntaxError e = new(216);
            Console.WriteLine(e.Description);
        }
    }
}

