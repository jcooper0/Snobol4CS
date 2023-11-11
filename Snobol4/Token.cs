namespace Snobol4;

public class Token
{
    #region Properties

    public Type TokenType { get; set; } = Type.NULL;
    public string MatchedString { get; set; } = "";

    public double DoubleValue
    {
        get; set;
    }

    public int IntegerValue
    {
        get; set;
    }

    internal int StringStartIndex
    {
        get;
    }

    internal int StringEndIndex
    {
        get;
    }

    #endregion

    #region Enumerations

    public enum Type
    {
        BINARY_AMPERSAND = 1,
        BINARY_AT = 2,
        BINARY_CARET = 3,
        BINARY_CONCAT = 4,
        BINARY_DOLLAR = 5,
        BINARY_EQUAL = 6,
        BINARY_HASH = 7,
        BINARY_MINUS = 8,
        BINARY_PERCENT = 9,
        BINARY_PERIOD = 10,
        BINARY_PIPE = 11,
        BINARY_PLUS = 12,
        BINARY_QUESTION = 13,
        BINARY_SLASH = 14,
        BINARY_STAR = 15,
        BINARY_TILDE = 16,
        COLON = 17,
        COMMA = 18,
        FAILURE_GOTO = 19,
        IDENTIFIER = 20,
        INTEGER = 21,
        L_ANGLE = 22,
        L_ANGLE_FAILURE = 23,
        L_ANGLE_SUCCESS = 24,
        L_ANGLE_UNCONDITIONAL = 25,
        L_PAREN = 26,
        L_PAREN_FAILURE = 27,
        L_PAREN_SUCCESS = 28,
        L_PAREN_UNCONDITIONAL = 29,
        L_SQUARE = 30,
        LABEL = 31,
        NULL = 32,
        R_ANGLE = 33,
        R_PAREN = 34,
        R_SQUARE = 35,
        REAL = 36,
        SPACE = 37,
        STRING = 38,
        SUCCESS_GOTO = 39,
        UNARY_AMPERSAND = 40,
        UNARY_AT = 41,
        UNARY_CARET = 42,
        UNARY_DELETE = 43,
        UNARY_DOLLAR = 44,
        UNARY_EQUAL = 45,
        UNARY_EXCLAMATION = 46,
        UNARY_HASH = 47,
        UNARY_MINUS = 48,
        UNARY_PERCENT = 49,
        UNARY_PERIOD = 50,
        UNARY_PIPE = 51,
        UNARY_PLUS = 52,
        UNARY_QUESTION = 53,
        UNARY_SLASH = 54,
        UNARY_STAR = 55,
        UNARY_TILDE = 56,
    }

    #endregion

    #region Constructor

    public Token()
    {
    }

    internal Token(Type type, string match, int stringStartIndex, int stringEndIndex)
    {
        TokenType = type;
        MatchedString = match;
        StringStartIndex = stringStartIndex;
        StringEndIndex = stringEndIndex;
    }

    internal Token(Type type, string match, int stringStartIndex, int stringEndIndex, int value)
    {
        TokenType = type;
        MatchedString = match;
        StringStartIndex = stringStartIndex;
        StringEndIndex = stringEndIndex;
        IntegerValue = value;
    }

    internal Token(Type type, string match, int stringStartIndex, int stringEndIndex, double value)
    {
        TokenType = type;
        MatchedString = match;
        StringStartIndex = stringStartIndex;
        StringEndIndex = stringEndIndex;
        DoubleValue = value;
    }

    #endregion

    #region Methods

    public override string ToString()
    {
        return ToString(false);
    }

    public string ToString(bool detailed)
    {
        if (detailed)
            return "Type: " + TokenType + " <" + MatchedString + "> Start Index: " + StringStartIndex + " End Index: " + StringEndIndex;
        return TokenType + new string(' ', 32 - TokenType.ToString().Length) + "<" + MatchedString + ">";
    }

    #endregion
}