using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static Snobol4.Lexer;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
namespace Snobol4;

internal class Lexer2
{
    private static readonly RegexOptions Options = RegexOptions.None;

    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(2);

    internal static readonly Regex Label = new(@"\A([A-Za-z\d_][^ \t]*)", Options, Timeout);

    internal static readonly Regex Space = new(@"\A[ \t]+", Options, Timeout);

    internal static readonly Regex StringLiteralD = new(@"\A\""[^\""]*\""", Options, Timeout);

    internal static readonly Regex StringLiteralS = new(@"\A\'[^\']*\'", Options, Timeout);

    internal static readonly Regex Operator = new(@"\A([~?$.!^%*/#+@|&=\-]+)", Options, Timeout);

    internal static readonly Regex Integer = new(@"\A[0-9]+", Options, Timeout);

    internal static readonly Regex Real1 = new(@"\A[0-9]+.[0-9]*([Ee][+-]?[0-9]+)?", Options, Timeout);

    internal static readonly Regex Real2 = new(@"\A[0-9]+[Ee][+-]?[0-9]+", Options, Timeout);

    internal static readonly Regex Identifier = new(@"\A[a-zA-Z][a-zA-Z0-9_]*", Options, Timeout);

    #region Properties

    public bool CaseFolding { get; set; } = false;
    internal int SecondGotoPosition { get; set; } = -1;
    internal Stack<BracketStackEntry> BracketStack = new();
    internal Dictionary<string, int> Labels = new();
    internal static Dictionary<string, Token.Type> BinaryOperators = new();
    internal static Dictionary<string, Token.Type> BracketOperators = new();
    internal static Dictionary<char, Token.Type> UnaryOperators = new();

    internal bool ColonFound
    {
        get; set;
    }

    internal bool SuccessGoToFound
    {
        get; set;
    }

    internal bool FailureGoToFound
    {
        get; set;
    }

    internal bool UnconditionalGoToFound
    {
        get; set;
    }

    internal bool PatternMatchFound
    {
        get; set;
    }

    internal bool EqualFound
    {
        get; set;
    }

    internal int NextState
    {
        get; set;
    }

    internal int State
    {
        get; set;
    }

    internal SourceLine? Source
    {
        get; set;
    }

    internal int CursorCurrent
    {
        get; set;
    }

    internal int CursorStart
    {
        get; set;
    }

    #endregion


    internal string GetEntryLabel(SourceLine line)
    {
        return "";
    }



    #region Constructors

    public Lexer2()
    {
        if (Lexer2.BinaryOperators.Count > 0)
            return;
        BinaryOperators["~"] = Token.Type.BINARY_TILDE;
        BinaryOperators["?"] = Token.Type.BINARY_QUESTION;
        BinaryOperators["$"] = Token.Type.BINARY_DOLLAR;
        BinaryOperators["."] = Token.Type.BINARY_PERIOD;
        BinaryOperators["!"] = Token.Type.BINARY_CARET;
        BinaryOperators["**"] = Token.Type.BINARY_CARET;
        BinaryOperators["^"] = Token.Type.BINARY_CARET;
        BinaryOperators["%"] = Token.Type.BINARY_PERCENT;
        BinaryOperators["*"] = Token.Type.BINARY_STAR;
        BinaryOperators["/"] = Token.Type.BINARY_SLASH;
        BinaryOperators["#"] = Token.Type.BINARY_HASH;
        BinaryOperators["+"] = Token.Type.BINARY_PLUS;
        BinaryOperators["-"] = Token.Type.BINARY_MINUS;
        BinaryOperators["@"] = Token.Type.BINARY_AT;
        BinaryOperators["|"] = Token.Type.BINARY_PIPE;
        BinaryOperators["&"] = Token.Type.BINARY_AMPERSAND;
        BinaryOperators["="] = Token.Type.BINARY_EQUAL;

        UnaryOperators['~'] = Token.Type.UNARY_TILDE;
        UnaryOperators['?'] = Token.Type.UNARY_QUESTION;
        UnaryOperators['$'] = Token.Type.UNARY_DOLLAR;
        UnaryOperators['.'] = Token.Type.UNARY_PERIOD;
        UnaryOperators['!'] = Token.Type.UNARY_EXCLAMATION;
        UnaryOperators['^'] = Token.Type.UNARY_CARET;
        UnaryOperators['%'] = Token.Type.UNARY_PERCENT;
        UnaryOperators['*'] = Token.Type.UNARY_STAR;
        UnaryOperators['/'] = Token.Type.UNARY_SLASH;
        UnaryOperators['#'] = Token.Type.UNARY_HASH;
        UnaryOperators['+'] = Token.Type.UNARY_PLUS;
        UnaryOperators['-'] = Token.Type.UNARY_MINUS;
        UnaryOperators['@'] = Token.Type.UNARY_AT;
        UnaryOperators['|'] = Token.Type.UNARY_PIPE;
        UnaryOperators['&'] = Token.Type.UNARY_AMPERSAND;
        UnaryOperators['='] = Token.Type.UNARY_EQUAL;
    }

    #endregion

    public void Lex(SourceLine source)
    {
        Debug.Assert(source != null, "Source line is null");

        int cursorCurrent = 0;

        Match m = Label.Match(source.Text);
        source.LineLabel = m.Value;

        cursorCurrent += m.Length;

        while (cursorCurrent < source.Text.Length)
        {
            
            m = Space.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.SPACE, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            m = Identifier.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.IDENTIFIER, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            m = Real1.Match(source.Text[cursorCurrent..]);

            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.REAL, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            m = Real2.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.REAL, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            m = Integer.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.INTEGER, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            m = StringLiteralD.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.STRING, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            m = StringLiteralS.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.STRING, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }


            m = Operator.Match(source.Text[cursorCurrent..]);
            if (m.Success)
            {
                source.LexLine.Add(new(Token.Type.OPERATOR, m.Value, cursorCurrent, cursorCurrent + m.Length));
                cursorCurrent += m.Length;
                continue;
            }

            switch (source.Text[cursorCurrent])
            {
                case ':':
                    source.LexLine.Add(new(Token.Type.COLON, ":", cursorCurrent, ++cursorCurrent));
                    break;
                case ',':
                    source.LexLine.Add(new(Token.Type.COLON, ",", cursorCurrent, ++cursorCurrent));
                    break;
                case '(':
                    source.LexLine.Add(new(Token.Type.L_PAREN, "(", cursorCurrent, ++cursorCurrent));
                    break;
                case ')':
                    source.LexLine.Add(new(Token.Type.R_PAREN, ")", cursorCurrent, ++cursorCurrent));
                    break;
                case '[':
                    source.LexLine.Add(new(Token.Type.L_SQUARE, "[", cursorCurrent, ++cursorCurrent));
                    break;
                case ']':
                    source.LexLine.Add(new(Token.Type.R_SQUARE, "]", cursorCurrent, ++cursorCurrent));
                    break;
                case '<':
                    source.LexLine.Add(new(Token.Type.L_ANGLE, "<", cursorCurrent, ++cursorCurrent));
                    break;
                case '>':
                    source.LexLine.Add(new(Token.Type.R_ANGLE, ">", cursorCurrent, ++cursorCurrent));
                    break;
                default:
                    throw new ApplicationException("Lexeme not detected");
            }


        }
    }

}
