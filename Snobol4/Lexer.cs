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

    public bool IsBinaryOperator(int nextState)
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        switch (CursorCurrent - CursorStart)
        {
            case 1:
                break;
            case 2:
                if (Source.Text[CursorStart..CursorCurrent] != "**")
                    return false;
                break;
            default:
                return false;
        }
        if (Source.LexLine[^1].TokenType != Token.Type.SPACE)
            return false;
        return nextState == 2;
    }

    public static Regex RightBinaryOperandPattern =
        new("\\A[\\t ]+[!~?$.*^%*/#+@|&=\\-]*[\\t ]*[A-Za-z0-9('\\\"]", RegexOptions.Compiled);

    public void CheckForBinaryOperands()
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        if (Source.LexLine.Count < 2)
            throw new SyntaxError(221, CursorStart, Source);
        switch (Source.LexLine[^2].TokenType)
        {
            case Token.Type.R_PAREN:
            case Token.Type.R_ANGLE:
            case Token.Type.R_SQUARE:
            case Token.Type.IDENTIFIER:
            case Token.Type.INTEGER:
            case Token.Type.REAL:
            case Token.Type.STRING:
                break;
            default:
                throw new SyntaxError(221, CursorStart, Source);
        }
        Debug.Assert(Source != null, nameof(Source) + " != null");
        string subString = Source.Text[CursorCurrent..];
        if (!RightBinaryOperandPattern.IsMatch(subString))
            throw new SyntaxError(221, CursorStart, Source);
    }

    public static Regex RightUnaryOperandPattern =
        new("\\A[!~?$.*^%*/#+@|&=\\-]*[\\t ]*[A-Za-z0-9('\\\"]", RegexOptions.Compiled);

    public void CheckForUnaryOperand(int nextState)
    {
        if (nextState == 2)
            throw new SyntaxError(221, CursorCurrent, Source);
        Debug.Assert(Source != null, nameof(Source) + " != null");
        string subString = Source.Text[CursorCurrent..];
        if (!RightUnaryOperandPattern.IsMatch(subString))
            throw new SyntaxError(221, CursorStart, Source);
    }

    public static Regex UnaryDeletePattern =
        new("\\A[\\t ]*[)>:\\]]", RegexOptions.Compiled);

    public bool IsUnaryDelete(int nextState)
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        if (Source.Text[CursorStart..CursorCurrent] != "=")
            return false;
        string subString = Source.Text[CursorCurrent..];
        return subString == "" || UnaryDeletePattern.IsMatch(subString);
    }

    public static Regex RightConcatenateOperandPattern =
        new("\\A[!~?$.*^%*/#+@|&=\\-]*[A-Za-z0-9('\\\"]", RegexOptions.Compiled);

    public bool IsConcatenateOperator()
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        if (Source.LexLine.Count < 2)
            return false;
        switch (Source.LexLine[^1].TokenType)
        {
            case Token.Type.R_PAREN:
            case Token.Type.R_ANGLE:
            case Token.Type.R_SQUARE:
            case Token.Type.IDENTIFIER:
            case Token.Type.INTEGER:
            case Token.Type.REAL:
            case Token.Type.STRING:
                break;
            default:
                return false;
        }
        Debug.Assert(Source != null, nameof(Source) + " != null");
        string subString = Source.Text[CursorCurrent..];
        return RightConcatenateOperandPattern.IsMatch(subString);
    }

    public void CheckForUnconditionalGoToParen()
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
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
        Debug.Assert(Source != null, nameof(Source) + " != null");
        switch (Source.LexLine[^1].TokenType)
        {
            case Token.Type.R_PAREN:
            case Token.Type.R_ANGLE:
                if (ColonFound && BracketStack.Count == 0)
                    throw new SyntaxError(218, CursorCurrent, Source);
                break;
        }
    }

    public bool IsMatchOperator()
    {
        if (PatternMatchFound)
            return false;
        if (BracketStack.Count > 0)
            return false;
        PatternMatchFound = true;
        return true;
    }

    public void CheckForBalancedBrackets()
    {
        if (BracketStack.Count == 0)
            return;
        if (BracketStack.Pop().Bracket == ")")
            throw new SyntaxError(226, CursorCurrent - 1, Source);
        throw new SyntaxError(229, CursorCurrent - 1, Source);
    }

    public void CheckForColonFound()
    {
        if (ColonFound)
            return;
        throw new SyntaxError(234, CursorCurrent, Source);
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
                Source.LexLine.Add(new(Token.Type.L_ANGLE_FAILURE, "(", CursorStart, CursorStart + 1));
                break;
            case Token.Type.SUCCESS_GOTO:
                Source.LexLine.Add(new(Token.Type.L_ANGLE_SUCCESS, "(", CursorStart, CursorStart + 1));
                break;
            case Token.Type.COLON:
                if (UnconditionalGoToFound || SuccessGoToFound || FailureGoToFound)
                    throw new SyntaxError(234, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.L_ANGLE_UNCONDITIONAL, "(", CursorStart, CursorStart + 1));
                UnconditionalGoToFound = true;
                break;
            default:
                throw new SyntaxError(234, CursorCurrent, Source);
        }
    }

    public void Accept(int state, int nextState = 0)
    {
        Debug.Assert(Source != null, nameof(Source) + " != null");
        Debug.Assert(state >= 0);
        switch (state)
        {
            case 1: // START
                break;
            case 2: // SPACE
                if (IsConcatenateOperator())
                {
                    if (IsMatchOperator())
                    {
                        Source.LexLine.Add(new(Token.Type.BINARY_QUESTION, Source.Text[CursorStart..CursorCurrent],
                             CursorStart, CursorCurrent));
                        break;
                    }
                    Source.LexLine.Add(new(Token.Type.BINARY_CONCAT, Source.Text[CursorStart..CursorCurrent],
                        CursorStart, CursorCurrent));
                    break;
                }
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
                CheckForBalancedBrackets();
                if (ColonFound)
                    throw new SyntaxError(234, CursorStart, Source);
                Source.LexLine.Add(new(Token.Type.COLON, Source.Text[CursorStart..CursorCurrent],
                    CursorStart, CursorCurrent));
                ColonFound = true;
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
                    if (ColonFound && firstTime)
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
                if (IsUnaryDelete(nextState))
                {
                    Source.LexLine.Add(new(Token.Type.UNARY_DELETE,
                         Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
                    if (BracketStack.Count == 0)
                        PatternMatchFound = true;
                    break;
                }
                if (IsBinaryOperator(nextState))
                {
                    CheckForBinaryOperands();
                    Source.LexLine.Add(new(BinaryOperators[Source.Text[CursorStart..CursorCurrent]],
                         Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
                    if (Source.Text[CursorStart] == '=' && BracketStack.Count == 0)
                        PatternMatchFound = true;
                    break;
                }
                CheckForUnaryOperand(nextState);
                foreach (char unaryOperator in Source.Text[CursorStart..CursorCurrent])
                {
                    Source.LexLine.Add(new(UnaryOperators[unaryOperator],
                        Source.Text[CursorStart..CursorCurrent], CursorStart, CursorCurrent));
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
                CheckForColonFound();
                if (FailureGoToFound || UnconditionalGoToFound)
                    throw new SyntaxError(218, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.FAILURE_GOTO, Source.Text[CursorStart..CursorCurrent],
                          CursorStart, CursorCurrent));
                CheckForBalancedBrackets();
                FailureGoToFound = true;
                break;
            case 21: // SUCCESS_GOTO
                CheckForColonFound();
                if (SuccessGoToFound || UnconditionalGoToFound)
                    throw new SyntaxError(218, CursorCurrent, Source);
                Source.LexLine.Add(new(Token.Type.SUCCESS_GOTO, Source.Text[CursorStart..CursorCurrent],
                     CursorStart, CursorCurrent));
                CheckForBalancedBrackets();
                SuccessGoToFound = true;
                break;
            default:
                throw new ApplicationException("Unhandled case in Lexer.");
        }
        CursorStart = CursorCurrent;
    }

    public void Lex(SourceLine source)
    {
        Debug.Assert(source != null, nameof(Source) + " != null");

        BracketStack.Clear();
        ColonFound = false;
        FailureGoToFound = false;
        SuccessGoToFound = false;
        UnconditionalGoToFound = false;
        CursorStart = CursorCurrent = 0;
        PatternMatchFound = false;
        SecondGotoPosition = -1;
        Source = source;

        int state = 1;

        while (true)
        {
            int nextState = Delta[state, Source.Text[CursorCurrent]];
            Console.WriteLine("State: " + state + "  CursorCurrent: " + CursorCurrent +
                             "  Char: " + Source.Text[CursorCurrent] + "  nextState: " + nextState);
            if (nextState > 100)
                throw new SyntaxError(nextState, CursorCurrent, Source);
            if (state != nextState && nextState >= 0)
                Accept(state, nextState);
            state = Math.Abs(nextState);
            CursorCurrent++;
            if (CursorCurrent != Source.Text.Length)
                continue;
            switch (state)
            {
                case 5:
                    throw new SyntaxError(219, CursorCurrent, Source);
                case 7 or 8:
                    throw new SyntaxError(232, CursorCurrent, Source);
            }

            Accept(state);
            break;
        }

        CheckForBalancedBrackets();
    }
    #endregion

}