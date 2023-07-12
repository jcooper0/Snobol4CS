using System.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestLex")]

namespace Snobol4
{
    public class Lexer
    {
        #region Precedence and Associaton Documenation

        /*
        ~	    R	12
        ?   	L	12
        $	    L	11
        .	    L	11
        ! ,**,^	R	10
        %	    L	9
        *	    L	8
        /	    L	7
        #	    L	6
        +	    L	5
        -	    L	5
        @	    L	4
        blank	L	3
        |	    L	2
        &	    L	1
        =	    R	
        */

        #endregion

        #region Properties

        internal string Input = null!;
        internal SourceFile? Program = null!;
        internal SourceLine? Source = null;
        internal int CursorCurrent { get; set; } = 0;
        internal int CursorStart { get; set; } = 0;

        #endregion

        #region Enumerations

        private enum CharacterClassType
        {
            NONE,
            ALPHA,
            DELIMITER,
            DIGIT,
            EQUAL,
            OPERATOR,
            QUOTE,
            WHITESPACE
        }

        #endregion

        #region Static Table Builders

        private static bool[] Any(string str)
        {
            bool[] result = new bool[256];
            for (int i = 0; i < 256; ++i)
            {
                result[i] = false;
            }

            foreach (char j in str)
            {
                result[j] = true;
            }

            return result;
        }

        private static bool[] NotAny(string str)
        {
            bool[] result = new bool[256];
            for (int i = 0; i < 256; ++i)
            {
                result[i] = true;
            }

            foreach (char j in str)
            {
                result[j] = false;
            }

            return result;
        }

        private static CharacterClassType[] BuildCharacterClass()
        {
            CharacterClassType[] result = new CharacterClassType[256];
            for (char c = '\0'; c < 255; ++c)
            {
                result[c] = CharacterClassType.NONE;
                if (IsAlpha[c])
                {
                    result[c] = CharacterClassType.ALPHA;
                    continue;
                }

                if (IsDelimiter[c])
                {
                    result[c] = CharacterClassType.DELIMITER;
                    continue;
                }

                if (IsDigit[c])
                {
                    result[c] = CharacterClassType.DIGIT;
                    continue;
                }

                if (c == '=')
                {
                    result[c] = CharacterClassType.EQUAL;
                    continue;
                }

                if (IsOperator[c])
                {
                    result[c] = CharacterClassType.OPERATOR;
                    continue;
                }

                if (IsQuote[c])
                {
                    result[c] = CharacterClassType.QUOTE;
                    continue;
                }

                if (IsWhiteSpace[c])
                {
                    result[c] = CharacterClassType.WHITESPACE;
                }

            }

            return result;
        }

        #endregion

        #region Static Lexing Tables

        private static readonly bool[] IsAlpha = Any("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

        private static readonly bool[] IsAlphaNumericIdentifier =
            Any("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz._");

        private static readonly bool[] IsBreak = Any(":");
        private static readonly bool[] IsDelimiter = Any("()[]<>:,");
        private static readonly bool[] IsDigit = Any("0123456789");
        private static readonly bool[] IsIdentifierTerminator = Any("\t (),<>[]");
        private static readonly bool[] IsLiteralTerminator = Any("\t ),>]");
        private static readonly bool[] IsLiteralTerminatorRightBracket = Any("\t ),>][(<FS");

        private static readonly bool[] IsNotAlphaNumeric =
            NotAny("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

        private static readonly bool[] IsNotLiteralTerminator = NotAny("\t ),>]<");
        private static readonly bool[] IsNotWhiteSpace = NotAny(" \t");
        private static readonly bool[] IsOperator = Any("&@$!^#-%.|+?*/~");
        private static readonly bool[] IsPlusMinus = Any("+-");
        private static readonly bool[] IsQuote = Any("'\"");
        private static readonly bool[] IsWhiteSpace = Any(" \t");
        private static readonly char[] FloatChars = { '.', 'e', 'E' };
        private static readonly CharacterClassType[] CharacterClass = BuildCharacterClass();

        #endregion

        #region Lexeme Matchers

        internal Token MatchDelimiter()
        {
            switch (Input[CursorCurrent++])
            {
                case '<':
                {
                    return new Token(Token.Type.LEFT_ANGLE_BRACKET, Input[CursorStart..CursorCurrent], CursorStart,
                        CursorCurrent);
                }
                case '(':
                {
                    return new Token(Token.Type.LEFT_PAREN, Input[CursorStart..CursorCurrent], CursorStart,
                        CursorCurrent);
                }
                case '[':
                {
                    return new Token(Token.Type.LEFT_SQUARE_BRACKET, Input[CursorStart..CursorCurrent], CursorStart,
                        CursorCurrent);
                }
                case '>':
                {
                    if (CursorCurrent == Input.Length || IsLiteralTerminatorRightBracket[Input[CursorCurrent]])
                        return new Token(Token.Type.RIGHT_ANGLE_BRACKET, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    break;
                }
                case ']':
                {
                    if (CursorCurrent == Input.Length || IsLiteralTerminatorRightBracket[Input[CursorCurrent]])
                        return new Token(Token.Type.RIGHT_SQUARE_BRACKET, Input[CursorStart..CursorCurrent],
                            CursorStart, CursorCurrent);
                    break;
                }
                case ')':
                {
                    if (CursorCurrent == Input.Length || IsLiteralTerminatorRightBracket[Input[CursorCurrent]])
                        return new Token(Token.Type.RIGHT_PAREN, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    break;
                }
                case ':':
                {
                    return new Token(Token.Type.COLON, Input[CursorStart..CursorCurrent], CursorStart, CursorCurrent);
                }
                case ',':
                {
                    return new Token(Token.Type.COMMA, Input[CursorStart..CursorCurrent], CursorStart, CursorCurrent);
                }
            }

            throw new SyntaxError(SyntaxError.ErrorType.ILLEGAL_CHARACTER_IN_ELEMENT, CursorCurrent + 1, Source);
        }

        internal Token MatchEqual()
        {
            int cursor = CursorCurrent++;
            while (++cursor < Input.Length && IsWhiteSpace[Input[cursor]])
            {
            }

            if (cursor == Input.Length || IsBreak[Input[cursor]])
                return new Token(Token.Type.UNARY_EQUAL, Input[CursorStart..CursorCurrent], CursorStart,
                    CursorCurrent);
            return new Token(Token.Type.BINARY_EQUAL, Input[CursorStart..CursorCurrent], CursorStart,
                CursorCurrent);
        }

        internal Token MatchLabel()
        {
            if (IsNotAlphaNumeric[Input[CursorCurrent]])
                throw new SyntaxError(SyntaxError.ErrorType.ERRONEOUS_LABEL, CursorCurrent, Source);

            // Include all other characters until a space, tab, or EOS
            while (++CursorCurrent < Input.Length && IsNotWhiteSpace[Input[CursorCurrent]])
            {
            }

            return new Token(Token.Type.LABEL, Input[CursorStart..CursorCurrent], CursorStart, CursorCurrent);
        }

        internal Token MatchNumber()
        {
            while (++CursorCurrent < Input.Length && IsNotLiteralTerminator[Input[CursorCurrent]])
            {
            }

            if (long.TryParse(Input[CursorStart..CursorCurrent], out _))
            {
                return new Token(Token.Type.INTEGER, Input[CursorStart..CursorCurrent], CursorStart,
                    CursorCurrent);
            }

            if (double.TryParse(Input[CursorStart..CursorCurrent], out _))
            {
                return new Token(Token.Type.REAL, Input[CursorStart..CursorCurrent], CursorStart,
                    CursorCurrent);
            }

            SyntaxError.ErrorType code = Input[CursorStart..CursorCurrent].IndexOfAny(FloatChars) > -1
                ? SyntaxError.ErrorType.ERRONEOUS_REAL_NUMBER
                : SyntaxError.ErrorType.ERRONEOUS_INTEGER;
            throw new SyntaxError(code, CursorStart, Source);
        }

        internal Token MatchIdentifier()
        {
            while (++CursorCurrent < Input.Length && IsAlphaNumericIdentifier[Input[CursorCurrent]])
            {
            }

            if (CursorCurrent == Input.Length || IsIdentifierTerminator[Input[CursorCurrent]])
            {
                if (Input[CursorStart..CursorCurrent] == "S")
                    return new Token(Token.Type.S, Input[CursorStart..CursorCurrent], CursorStart,
                        CursorCurrent);
                if (Input[CursorStart..CursorCurrent] == "F")
                    return new Token(Token.Type.F, Input[CursorStart..CursorCurrent], CursorStart,
                        CursorCurrent);
                return new Token(Token.Type.IDENTIFIER, Input[CursorStart..CursorCurrent], CursorStart,
                    CursorCurrent);
            }

            throw new SyntaxError(SyntaxError.ErrorType.ILLEGAL_CHARACTER_IN_ELEMENT, CursorCurrent, Source);
        }

        internal Token MatchOperator()
        {
            // Special case for Double Star
            if (CursorCurrent > 0 &&
                CursorCurrent + 2 < Input.Length &&
                IsWhiteSpace[Input[CursorCurrent - 1]] &&
                Input[CursorCurrent] == '*' &&
                Input[CursorCurrent + 1] == '*' &&
                IsWhiteSpace[Input[CursorCurrent + 2]])
            {
                CursorCurrent += 2;
                return new Token(Token.Type.BINARY_DOUBLE_STAR, Input[CursorStart..CursorCurrent], CursorStart,
                    CursorCurrent);
            }

            char oper = Input[CursorCurrent];
            CursorCurrent++;

            if (CursorCurrent == Input.Length)
            {
                CursorCurrent = CursorStart;
                throw new SyntaxError(SyntaxError.ErrorType.BINARY_OPERATOR_MISSING_OR_IN_ERROR, CursorCurrent, Source);
            }

            if (IsWhiteSpace[Input[CursorCurrent - 2]] && IsWhiteSpace[Input[CursorCurrent]])
            {
                switch (oper)
                {
                    case '~':
                    {
                        return new Token(Token.Type.BINARY_TILDE, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '?':
                    {
                        return new Token(Token.Type.BINARY_QUESTION, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '$':
                    {
                        return new Token(Token.Type.BINARY_DOLLAR, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '.':
                    {
                        return new Token(Token.Type.BINARY_PERIOD, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '!':
                    {
                        return new Token(Token.Type.BINARY_EXCLAMATION, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '^':
                    {
                        return new Token(Token.Type.BINARY_CARET, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '%':
                    {
                        return new Token(Token.Type.BINARY_PERCENT, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '*':
                    {
                        return new Token(Token.Type.BINARY_STAR, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '/':
                    {
                        return new Token(Token.Type.BINARY_SLASH, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '#':
                    {
                        return new Token(Token.Type.BINARY_HASH, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '+':
                    {
                        return new Token(Token.Type.BINARY_PLUS, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '-':
                    {
                        return new Token(Token.Type.BINARY_MINUS, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '@':
                    {
                        return new Token(Token.Type.BINARY_AT, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '|':
                    {
                        return new Token(Token.Type.BINARY_PIPE, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '&':
                    {
                        return new Token(Token.Type.BINARY_AMPERSAND, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                }
            }
            else
            {
                switch (oper)
                {
                    case '~':
                    {
                        return new Token(Token.Type.UNARY_TILDE, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '?':
                    {
                        return new Token(Token.Type.UNARY_QUESTION, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '$':
                    {
                        return new Token(Token.Type.UNARY_DOLLAR, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '.':
                    {
                        return new Token(Token.Type.UNARY_PERIOD, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '!':
                    {
                        return new Token(Token.Type.UNARY_EXCLAMATION, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '^':
                    {
                        return new Token(Token.Type.UNARY_CARET, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '%':
                    {
                        return new Token(Token.Type.UNARY_PERCENT, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '*':
                    {
                        return new Token(Token.Type.UNARY_STAR, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '/':
                    {
                        return new Token(Token.Type.UNARY_SLASH, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '#':
                    {
                        return new Token(Token.Type.UNARY_HASH, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '+':
                    {
                        return new Token(Token.Type.UNARY_PLUS, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '-':
                    {
                        return new Token(Token.Type.UNARY_MINUS, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '@':
                    {
                        return new Token(Token.Type.UNARY_AT, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '|':
                    {
                        return new Token(Token.Type.UNARY_PIPE, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                    case '&':
                    {
                        return new Token(Token.Type.UNARY_AMPERSAND, Input[CursorStart..CursorCurrent], CursorStart,
                            CursorCurrent);
                    }
                }
            }

            throw new ApplicationException("Unhandled operator in Lexer.MatchOperator");
        }

        internal Token MatchString()
        {
            if (Input[CursorCurrent] == '"')
            {
                while (++CursorCurrent < Input.Length && Input[CursorCurrent] != '"')
                {
                }
            }
            else
            {
                while (++CursorCurrent < Input.Length && Input[CursorCurrent] != '\'')
                {
                }
            }

            if (CursorCurrent == Input.Length)
            {
                CursorCurrent = CursorStart;
                throw new SyntaxError(SyntaxError.ErrorType.UNCLOSED_LITERAL, CursorStart, Source);
            }

            CursorCurrent++;
            if (CursorCurrent == Input.Length || IsLiteralTerminator[Input[CursorCurrent]])
                return new Token(Token.Type.STRING, Input[(CursorStart + 1)..(CursorCurrent - 1)], CursorStart,
                    CursorCurrent);

            throw new SyntaxError(SyntaxError.ErrorType.ILLEGAL_CHARACTER_IN_ELEMENT, CursorCurrent, Source);
        }

        internal Token MatchWhiteSpace()
        {
            //if (IsNotWhiteSpace[Input[CursorCurrent]])
            //    return Token.TokenNull;

            while (CursorCurrent < Input.Length && IsWhiteSpace[Input[CursorCurrent]])
                CursorCurrent++;
            if (CursorCurrent > CursorStart)
                return new Token(Token.Type.SPACE, " ", CursorStart,
                    CursorCurrent);
            return Token.TokenNull;
        }

        internal Token MatchColumnZero()
        {
            return IsWhiteSpace[Input[0]] ? MatchWhiteSpace() : MatchLabel();
        }

        internal Token MatchColumnOneAndUp()
        {
            switch (CharacterClass[Input[CursorCurrent]])
            {
                case CharacterClassType.ALPHA:
                {
                    return MatchIdentifier();
                }
                case CharacterClassType.DIGIT:
                {
                    return MatchNumber();
                }
                case CharacterClassType.DELIMITER:
                {
                    return MatchDelimiter();
                }
                case CharacterClassType.EQUAL:
                {
                    return MatchEqual();
                }
                case CharacterClassType.NONE:
                {
                    throw new SyntaxError(SyntaxError.ErrorType.UNEXPECTED_CHARACTER, CursorCurrent, Source);
                }
                case CharacterClassType.QUOTE:
                {
                    return MatchString();
                }
                case CharacterClassType.OPERATOR:
                {
                    if (IsPlusMinus[Input[CursorCurrent]] && CursorCurrent + 1 < Input.Length &&
                        IsDigit[Input[CursorCurrent + 1]])
                        return MatchNumber();
                    return MatchOperator();
                }
                case CharacterClassType.WHITESPACE:
                {
                    return MatchWhiteSpace();
                }
                default:
                {
                    throw new ApplicationException("Unhandled match type in Lexer.MatchColumnOneAndUp.");
                }
            }
        }

        internal Token Match()
        {
            return CursorCurrent == 0 ? MatchColumnZero() : MatchColumnOneAndUp();
        }

        #endregion

        #region File interfaces

        public void LexLine(SourceLine source)
        {

            Source = source;
            CursorCurrent = 0;
            Input = Source.SourceLineText;
            while (CursorCurrent < Input.Length)
            {
                CursorStart = CursorCurrent;
                Token t = Match();

                if (t.TokenType == Token.Type.ERROR)
                    throw new SyntaxError(SyntaxError.ErrorType.ERRONEOUS_OR_MISSING_BREAK_CHARACTER, CursorCurrent,
                        Source);

                Source.LexResult.Add(t);

                CursorStart = CursorCurrent;

                if (CursorCurrent >= Input.Length)
                    break;

                t = MatchWhiteSpace();

                if (t.TokenType == Token.Type.SPACE)
                    Source.LexResult.Add(t);
            }

            RemoveSpaces(Source.LexResult);

            if (CheckForUnbalancedParensOrBrackets(Source.LexResult))
            {
                throw new SyntaxError(SyntaxError.ErrorType.ERRONEOUS_OR_MISSING_BREAK_CHARACTER, CursorCurrent,
                    Source);
            }

            int match = FindMatchOperator(Source.LexResult);
            int replace = match > 0 ? FindReplaceOperator(Source.LexResult, match) : -1;

            if (match < 0)
                return;

            if (replace < 0)
            {
                Source.LexResult[match].TokenType = Token.Type.MATCH_ONLY;
                return;
            }

            Source.LexResult[match].TokenType = Source.LexResult[replace].TokenType == Token.Type.UNARY_EQUAL
                ? Token.Type.MATCH_DELETE
                : Token.Type.MATCH_REPLACE;
            Source.LexResult[replace].TokenType = Source.LexResult[replace].TokenType == Token.Type.UNARY_EQUAL
                ? Token.Type.OBJECT_DELETE
                : Token.Type.OBJECT_REPLACE;
        }



        internal static void RemoveSpaces(List<Token> tokens)
        {
            if (tokens[0].TokenType == Token.Type.SPACE)
                tokens[0].TokenType = Token.Type.NO_LABEL;
            if (tokens[^1].TokenType == Token.Type.SPACE)
                tokens.RemoveAt(tokens.Count - 1);

            for (int i = 1; i < tokens.Count - 1; ++i)
            {
                if (tokens[i].TokenType != Token.Type.SPACE)
                    continue;
                if (CanConvertSpaceToOperator(tokens[i - 1].TokenType, tokens[i + 1].TokenType))
                {
                    tokens[i].TokenType = Token.Type.BINARY_SPACE;
                    tokens[i].MatchedString = "";
                }
                else
                    tokens.RemoveAt(i);
            }
        }

        internal static bool CanConvertSpaceToOperator(Token.Type ttBefore, Token.Type ttAfter)
        {
            switch (ttBefore)
            {
                case Token.Type.IDENTIFIER:
                case Token.Type.INTEGER:
                case Token.Type.REAL:
                case Token.Type.RIGHT_ANGLE_BRACKET:
                case Token.Type.RIGHT_PAREN:
                case Token.Type.RIGHT_SQUARE_BRACKET:
                case Token.Type.STRING:
                {
                    switch (ttAfter)
                    {
                        case Token.Type.IDENTIFIER:
                        case Token.Type.INTEGER:
                        case Token.Type.LEFT_PAREN:
                        case Token.Type.REAL:
                        case Token.Type.STRING:
                        case Token.Type.UNARY_AMPERSAND:
                        case Token.Type.UNARY_AT:
                        case Token.Type.UNARY_CARET:
                        case Token.Type.UNARY_DOLLAR:
                        case Token.Type.UNARY_EXCLAMATION:
                        case Token.Type.UNARY_HASH:
                        case Token.Type.UNARY_MINUS:
                        case Token.Type.UNARY_PERCENT:
                        case Token.Type.UNARY_PERIOD:
                        case Token.Type.UNARY_PIPE:
                        case Token.Type.UNARY_PLUS:
                        case Token.Type.UNARY_QUESTION:
                        case Token.Type.UNARY_SLASH:
                        case Token.Type.UNARY_STAR:
                        case Token.Type.UNARY_TILDE:
                        {
                            return true;
                        }
                        default:
                            return false;
                    }
                }
                default:
                    return false;
            }
        }

        internal int FindReplaceOperator(List<Token> tokens, int cursor)
        {
            while (++cursor < tokens.Count)
            {
                if (IsLeftParenOrBracket(tokens, cursor))
                {
                    cursor = SkipBalancedParensOrBrackets(tokens, cursor);

                    if (cursor < 0)
                        return -1;

                    continue;
                }

                if (tokens[cursor].TokenType == Token.Type.UNARY_EQUAL)
                    return cursor;
                if (tokens[cursor].TokenType == Token.Type.BINARY_EQUAL)
                    return cursor;
            }

            return -1;
        }

        /// <summary>
        /// Look for a BINARY_SPACE token that is really a MATCH operator.
        /// Specifically, look for a BINARY_SPACE after an element.
        /// Elements are unary operators followed by an atomic element 
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        internal int FindMatchOperator(List<Token> tokens)
        {
            int cursor = 0;

            while (++cursor < tokens.Count && IsUnaryOperator(tokens, cursor))
            {
            }

            if (cursor >= tokens.Count)
                return -1;

            if (IsAtomicElement(tokens, cursor))
            {
                if (++cursor >= tokens.Count)
                    return -1;

                if (tokens[cursor].TokenType == Token.Type.BINARY_SPACE)
                    return cursor;

                if (!IsLeftParenOrBracket(tokens, cursor))
                    return -1;

                cursor = SkipBalancedParensOrBrackets(tokens, cursor);

                if (cursor < 0)
                    return -1;

                if (++cursor < tokens.Count && tokens[cursor].TokenType == Token.Type.BINARY_SPACE)
                    return cursor;

                return -1;
            }

            if (tokens[cursor].TokenType != Token.Type.LEFT_PAREN)
                return -1;

            cursor = SkipBalancedParensOrBrackets(tokens, cursor);

            if (cursor < 0)
                return cursor;

            if (++cursor < tokens.Count && tokens[cursor].TokenType == Token.Type.BINARY_SPACE)
                return cursor;

            return -1;
        }

        internal bool IsUnaryOperator(List<Token> tokens, int cursor)
        {
            switch (tokens[cursor].TokenType)
            {
                case Token.Type.UNARY_AMPERSAND:
                case Token.Type.UNARY_AT:
                case Token.Type.UNARY_CARET:
                case Token.Type.UNARY_DOLLAR:
                case Token.Type.UNARY_EQUAL:
                case Token.Type.UNARY_EXCLAMATION:
                case Token.Type.UNARY_HASH:
                case Token.Type.UNARY_MINUS:
                case Token.Type.UNARY_PERCENT:
                case Token.Type.UNARY_PERIOD:
                case Token.Type.UNARY_PIPE:
                case Token.Type.UNARY_PLUS:
                case Token.Type.UNARY_QUESTION:
                case Token.Type.UNARY_SLASH:
                case Token.Type.UNARY_STAR:
                case Token.Type.UNARY_TILDE:
                {
                    return true;
                }
            }

            return false;
        }

        internal bool IsAtomicElement(List<Token> tokens, int cursor)
        {
            switch (tokens[cursor].TokenType)
            {
                case Token.Type.IDENTIFIER:
                case Token.Type.STRING:
                case Token.Type.INTEGER:
                case Token.Type.REAL:
                {
                    return true;
                }
            }

            return false;
        }

        internal bool IsLeftParenOrBracket(List<Token> tokens, int cursor)
        {
            switch (tokens[cursor].TokenType)
            {
                case Token.Type.LEFT_PAREN:
                case Token.Type.LEFT_SQUARE_BRACKET:
                case Token.Type.LEFT_ANGLE_BRACKET:
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Given a list of tokens and a position with a left parenthesis,
        /// square bracket, or angle bracket find the position of the first
        /// token after balancing parentheses, square brackets, or angle
        /// brackets, respectively.
        /// </summary>
        /// <param name="tokens">List of tokens</param>
        /// <param name="startingPoint">starting point</param>
        /// <returns>Index of first token after balanced parentheses or
        /// brackets. -1 if not found.</returns>
        internal int SkipBalancedParensOrBrackets(List<Token> tokens, int startingPoint)
        {
            int balanceCount = 1;
            Token t = tokens[startingPoint];
            Token.Type searchTokenType = Token.Type.NULL;

            if (t.TokenType == Token.Type.LEFT_PAREN)
                searchTokenType = Token.Type.RIGHT_PAREN;

            if (t.TokenType == Token.Type.LEFT_ANGLE_BRACKET)
                searchTokenType = Token.Type.RIGHT_ANGLE_BRACKET;

            if (t.TokenType == Token.Type.LEFT_SQUARE_BRACKET)
                searchTokenType = Token.Type.RIGHT_SQUARE_BRACKET;

            int i = 0;
            for (++startingPoint; startingPoint < tokens.Count; ++startingPoint)
            {
                if (tokens[startingPoint].TokenType == searchTokenType)
                    --balanceCount;
                if (tokens[startingPoint].TokenType == t.TokenType)
                    ++balanceCount;
                if (balanceCount == 0)
                    break;
            }

            if (startingPoint == tokens.Count)
                return -1;

            return startingPoint;
        }

        internal bool CheckForUnbalancedParensOrBrackets(List<Token> tokens)
        {
            int balancedParen = 0;
            int balancedAngleBracket = 0;
            int balancedSquareBracket = 0;

            foreach (Token t in tokens)
            {
                switch (t.TokenType)
                {
                    case Token.Type.LEFT_ANGLE_BRACKET:
                    {
                        break;
                        balancedAngleBracket++;
                    }
                    case Token.Type.LEFT_PAREN:
                    {
                        balancedParen++;
                        break;
                    }
                    case Token.Type.LEFT_SQUARE_BRACKET:
                    {
                        balancedSquareBracket++;
                        break;
                    }
                    case Token.Type.RIGHT_ANGLE_BRACKET:
                    {
                        balancedAngleBracket--;
                        break;
                    }
                    case Token.Type.RIGHT_PAREN:
                    {
                        balancedParen--;
                        break;
                    }
                    case Token.Type.RIGHT_SQUARE_BRACKET:
                    {
                        balancedSquareBracket--;
                        break;
                    }
                }

                if (balancedAngleBracket < 0 || balancedParen < 0 || balancedSquareBracket < 0)
                    return true;
            }

            if (balancedAngleBracket == 0 && balancedParen == 0 && balancedSquareBracket == 0)
                return false;

            return true;
        }

        #endregion
    }
}
