using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("TestLexer")]

namespace Snobol4;
public partial class Lexer
{
    #region Embedded Class

    public class BracketStackEntry
    {
        public string Bracket
        {
            set; get;
        }
        public int Column
        {
            get; set;
        }

        public BracketStackEntry(string bracket, int column)
        {
            Bracket = bracket;
            Column = column;
        }
    }

    #endregion

    #region Precedence and Associaton Documenation

    /*
    ~ R 12
    ? L 12
    $ L 11
    . L 11
    ! ,**,^ R 10
    % L 9
    * L 8
    / L 7
    # L 6
    + L 5
    - L 5
    @ L 4
    blank L 3
    | L 2
    & L 1
    = R
    */

    #endregion

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

    #region Constructors

    public Lexer()
    {
        if (Lexer.BinaryOperators.Count > 0)
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

        BracketOperators[")"] = Token.Type.R_PAREN;
        BracketOperators[">"] = Token.Type.R_ANGLE;
        BracketOperators["]"] = Token.Type.R_SQUARE;
    }

    #endregion

    #region Methods

    internal string GetEntryLabel(SourceLine line)
    {
        string entryLabel = "";
        switch (line.LexLine.Count)
        {
            case 1:
                break;
            case 2:
                throw new SyntaxError(215, line.LexLine[1].StringStartIndex, line);
            case 3:
                if (line.LexLine[2].TokenType != Token.Type.IDENTIFIER)
                    throw new SyntaxError(215, line.LexLine[2].StringStartIndex, line);
                entryLabel = line.LexLine[2].MatchedString;
                if (!Labels.ContainsKey(entryLabel))
                    throw new SyntaxError(215, line.LexLine[2].StringStartIndex, line);
                break;
            default:
                throw new SyntaxError(215, line.LexLine[2].StringStartIndex, line);
        }
        return entryLabel;
    }

    public static Regex UnaryDeletePattern =
        new(@"\A[\t ]*[)>:\]]", RegexOptions.Compiled);

    public bool IsUnaryDelete()
    {
        Debug.Assert(Source != null, nameof(Source) + " == null");
        if (Source.Text[CursorStart..CursorCurrent] != "=")
            return false;
        string subString = Source.Text[CursorCurrent..];
        return subString == "" || UnaryDeletePattern.IsMatch(subString);
    }

    public void CheckForUnconditionalGoToParen()
    {
        Debug.Assert(Source != null, nameof(Source) + " = null");
        switch (Source.LexLine[^1].TokenType)
        {
            case Token.Type.R_PAREN:
            case Token.Type.R_ANGLE:
                if (ColonFound && BracketStack.Count == 0)
                    throw new SyntaxError(218, CursorCurrent, Source);
                throw new SyntaxError(220, CursorCurrent, Source);
        }
    }

    public void CheckForUnconditionalGoToAngle()
    {
        Debug.Assert(Source != null, nameof(Source) + " == null");
        switch (Source.LexLine[^1].TokenType)
        {
            case Token.Type.R_PAREN:
            case Token.Type.R_ANGLE:
                if (ColonFound && BracketStack.Count == 0)
                    throw new SyntaxError(218, CursorCurrent, Source);
                break;
        }
    }

    public Token.Type MatchOrConcat()
    {
        if (PatternMatchFound || EqualFound)
            return Token.Type.BINARY_CONCAT;
        if (BracketStack.Count > 0)
            return Token.Type.BINARY_CONCAT;
        PatternMatchFound = true;
        return Token.Type.BINARY_QUESTION;
    }

    public void CheckForBalancedBrackets()
    {
        if (BracketStack.Count == 0)
            return;
        if (BracketStack.Pop().Bracket == ")")
            throw new SyntaxError(ColonFound ? 227 : 226, CursorCurrent - 1, Source);
        throw new SyntaxError(ColonFound ? 228 : 229, CursorCurrent - 1, Source);
    }

    public void AddGotoParen()
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        switch (Source.LexLine[^1].TokenType)
        {
            case Token.Type.FAILURE_GOTO:
                Source.LexLine.Add(new(Token.Type.L_PAREN_FAILURE, "(", CursorStart, CursorStart + 1));
                break;
            case Token.Type.SUCCESS_GOTO:
                Source.LexLine.Add(new(Token.Type.L_PAREN_SUCCESS, "(", CursorStart, CursorStart + 1));
                break;
            case Token.Type.COLON:
                if (UnconditionalGoToFound || SuccessGoToFound || FailureGoToFound)
                    throw new SyntaxError(234, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.L_PAREN_UNCONDITIONAL, "(", CursorStart, CursorStart + 1));
                UnconditionalGoToFound = true;
                break;
            default:
                throw new SyntaxError(234, CursorCurrent, Source);
        }
    }

    public void AddGotoAngle()
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        switch (Source.LexLine[^1].TokenType)
        {
            case Token.Type.FAILURE_GOTO:
                Source.LexLine.Add(new(Token.Type.L_ANGLE_FAILURE, "<", CursorStart, CursorStart + 1));
                break;
            case Token.Type.SUCCESS_GOTO:
                Source.LexLine.Add(new(Token.Type.L_ANGLE_SUCCESS, "<", CursorStart, CursorStart + 1));
                break;
            case Token.Type.COLON:
                if (UnconditionalGoToFound || SuccessGoToFound || FailureGoToFound)
                    throw new SyntaxError(234, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.L_ANGLE_UNCONDITIONAL, "<", CursorStart, CursorStart + 1));
                UnconditionalGoToFound = true;
                break;
            default:
                throw new SyntaxError(234, CursorCurrent, Source);
        }
    }

    public static Regex BinaryOperator1 =
        new(@"\A([ \t]+)[\*\~\?\$\.\!\^\%\/\#\+\-\@\|\&\=][ \t]", RegexOptions.Compiled);
    public static Regex BinaryOperator2 =
        new(@"\A([ \t]+)\*\*[ \t]", RegexOptions.Compiled);

    public void Accept()
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        Debug.Assert(State >= 0);
        switch (State)
        {
            case 1: // START
                break;
            case 2: // SPACE
                Source.LexLine.Add(new(Token.Type.SPACE, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                break;
            case 3: // INTEGER
                if (!int.TryParse(Source.Text[CursorStart..CursorCurrent], out int iValue))
                    throw new SyntaxError(231, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.INTEGER, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent, iValue));
                break;
            case 4: // REAL
                if (!double.TryParse(Source.Text[CursorStart..CursorCurrent], out double dValue))
                    throw new SyntaxError(231, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.REAL, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent, dValue));
                break;
            case 5: // COLON
                //CheckForBalancedBrackets();
                if (ColonFound && BracketStack.Count > 0)
                    throw new SyntaxError(234, CursorStart, Source);
                Source.LexLine.Add(new(Token.Type.COLON, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                ColonFound = true;
                break;
            case 6: // BINARY_CONCAT
                switch (NextState)
                {
                    case 5:
                    case 11:
                    case 12:
                    case 13:
                    case 17:
                    case 18:
                        Source.LexLine.Add(new(Token.Type.SPACE, Source.Text[CursorStart..CursorCurrent],
                            CursorStart, CursorCurrent));
                        break;
                    case 3:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        Source.LexLine.Add(new(MatchOrConcat(), Source.Text[CursorStart..CursorCurrent],
                              CursorStart, CursorCurrent));
                        break;
                    case 23:
                        if (BinaryOperator1.IsMatch(Source.Text[CursorStart..]) || BinaryOperator2.IsMatch(Source.Text[CursorStart..]))
                            Source.LexLine.Add(new(Token.Type.SPACE, Source.Text[CursorStart..CursorCurrent],
                                CursorStart, CursorCurrent));
                        else
                            Source.LexLine.Add(new(Token.Type.BINARY_CONCAT, Source.Text[CursorStart..CursorCurrent],
                                CursorStart, CursorCurrent));
                        break;
                }
                break;
            case 7: // STRING
            case 8:
                CursorStart++;
                Source.LexLine.Add(new(Token.Type.STRING, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                break;
            case 9: // IDENTIFIER
                Source.LexLine.Add(new(Token.Type.IDENTIFIER, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                break;
            case 10: // OPEN PAREN
                CheckForUnconditionalGoToParen();
                bool firstTime = true;
                foreach (char openParen in Source.Text[CursorStart..CursorCurrent])
                {
                    Debug.Assert(openParen == '(');
                    if (ColonFound && firstTime && BracketStack.Count == 0)
                    {
                        AddGotoParen();
                        firstTime = false;
                    }
                    else
                        Source.LexLine.Add(new(Token.Type.L_PAREN, "(", CursorStart, CursorStart + 1));
                    BracketStack.Push(new(")", CursorStart));
                    CursorStart++;
                }
                break;
            case 11: // CLOSE PAREN
                foreach (char closeParen in Source.Text[CursorStart..CursorCurrent])
                {
                    Debug.Assert(closeParen == ')');
                    Source.LexLine.Add(new(Token.Type.R_PAREN, ")", CursorStart, CursorStart + 1));
                    if ((BracketStack.Count == 0) || (BracketStack.Pop().Bracket != ")"))
                        throw new SyntaxError(224, CursorStart, Source);
                    CursorStart++;
                }
                break;
            case 12: // OPERATOR 
                if (IsUnaryDelete())
                {
                    Source.LexLine.Add(new(Token.Type.UNARY_DELETE,
                         Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
                    if (BracketStack.Count == 0)
                        PatternMatchFound = true;
                }
                break;
            case 13: // COMMA
                Source.LexLine.Add(new(Token.Type.COMMA, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                break;
            case 14: // QUOTE
                break;
            case 15: // OPEN ANGLE BRACKET
                CheckForUnconditionalGoToAngle();
                if (ColonFound)
                    AddGotoAngle();
                else
                    Source.LexLine.Add(new(Token.Type.L_ANGLE, "(", CursorStart, CursorStart + 1));
                BracketStack.Push(new(">", CursorCurrent));
                break;
            case 16: // OPEN LEFT SQUARE BRACKET
                Source.LexLine.Add(new(Token.Type.L_SQUARE, "[", CursorCurrent, CursorCurrent + 1));
                BracketStack.Push(new("]", CursorCurrent));
                break;
            case 17: // CLOSE ANGLE BRACKET
                Source.LexLine.Add(new(Token.Type.R_ANGLE, ">", CursorStart, CursorCurrent));
                if (BracketStack.Count == 0 || BracketStack.Pop().Bracket != ">")
                    throw new SyntaxError(225, CursorStart, Source);
                break;
            case 18: // CLOSE SQUARE BRACKET
                Source.LexLine.Add(new(Token.Type.R_SQUARE, "]", CursorStart, CursorCurrent));
                if (BracketStack.Count == 0 || BracketStack.Pop().Bracket != "]")
                    throw new SyntaxError(225, CursorStart, Source);
                break;
            case 19: // LABEL
                string label = Source.Text[CursorStart..CursorCurrent];
                if (CaseFolding)
                    label = label.ToUpper();
                if (Labels.ContainsKey(label))
                    throw new SyntaxError(217, 0, Source);
                Source.LexLine.Add(new(Token.Type.LABEL, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                Source.LineLabel = Source.Text[CursorStart..CursorCurrent];
                Labels[label] = Source.LineNumber;
                break;
            case 20: // FAILURE_GOTO
                if (!ColonFound || BracketStack.Count > 0)
                    throw new SyntaxError(220, CursorCurrent, Source);
                if (FailureGoToFound || UnconditionalGoToFound)
                    throw new SyntaxError(218, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.FAILURE_GOTO, Source.Text[CursorStart..CursorCurrent],
                          CursorStart, CursorCurrent));
                FailureGoToFound = true;
                break;
            case 21: // SUCCESS_GOTO
                if (!ColonFound || BracketStack.Count > 0)
                    throw new SyntaxError(220, CursorCurrent, Source);
                if (SuccessGoToFound || UnconditionalGoToFound)
                    throw new SyntaxError(218, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.SUCCESS_GOTO, Source.Text[CursorStart..CursorCurrent],
                     CursorStart, CursorCurrent));
                SuccessGoToFound = true;
                break;
            case 22: // UNARY_OPERATOR
                if (NextState != 2)
                {
                    foreach (char unaryOperator in Source.Text[CursorStart..CursorCurrent])
                    {
                        Source.LexLine.Add(new(UnaryOperators[unaryOperator],
                            Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
                    }
                }
                break;
            case 23: //OPERATOR
                if (NextState != 2)
                {
                    foreach (char unaryOperator in Source.Text[CursorStart..CursorCurrent])
                    {
                        Source.LexLine.Add(new(UnaryOperators[unaryOperator],
                            Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
                    }
                    break;
                }
                switch (CursorCurrent - CursorStart)
                {
                    case 1:
                    case 2:
                        if (BinaryOperators.ContainsKey(Source.Text[CursorStart..CursorCurrent]))
                        {
                            Source.LexLine.Add(new(BinaryOperators[Source.Text[CursorStart..CursorCurrent]],
                                Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
                            if (BinaryOperators[Source.Text[CursorStart..CursorCurrent]] == Token.Type.BINARY_EQUAL)
                                EqualFound = true;
                        }
                        break;
                    default:
                        throw new SyntaxError(233, CursorCurrent, Source);
                }
                break;
            default:
                throw new ApplicationException("Unhandled case in Lexer.");
        }
        CursorStart = CursorCurrent;
    }

    public void Lex(SourceLine source)
    {
        Debug.Assert(source != null, "Source line is null");

        BracketStack.Clear();
        ColonFound = false;
        FailureGoToFound = false;
        SuccessGoToFound = false;
        UnconditionalGoToFound = false;
        CursorStart = CursorCurrent = 0;
        PatternMatchFound = false;
        EqualFound = false;
        SecondGotoPosition = -1;
        Source = source;

        State = 1;

        while (true)
        {
            NextState = Delta[State, Source.Text[CursorCurrent]];
            //Console.WriteLine("State: " + State + "  CursorCurrent: " + CursorCurrent +
            //                  "  Char: " + Source.Text[CursorCurrent] + "  NextState: " + NextState);
            if (NextState > 100)
                throw new SyntaxError(NextState, CursorCurrent, Source);
            if (State != NextState && NextState >= 0)
                Accept();
            State = Math.Abs(NextState);
            CursorCurrent++;
            if (CursorCurrent != Source.Text.Length)
                continue;
            switch (State)
            {
                case 5:
                    throw new SyntaxError(219, CursorCurrent, Source);
                case 7 or 8:
                    throw new SyntaxError(232, CursorCurrent, Source);
            }
            Accept();
            break;
        }

        CheckForBalancedBrackets();
    }
    #endregion

}