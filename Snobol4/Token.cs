namespace Snobol4
{
    public class Token
    {
        #region Properties

        public Type TokenType { get; set; } = Type.NULL;
        public string MatchedString { get; set; } = "";

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
            BINARY_DOLLAR = 4,
            BINARY_DOUBLE_STAR = 5,
            BINARY_EQUAL = 6,
            BINARY_EXCLAMATION = 7,
            BINARY_HASH = 8,
            BINARY_MINUS = 9,
            BINARY_PERCENT = 10,
            BINARY_PERIOD = 11,
            BINARY_PIPE = 12,
            BINARY_PLUS = 13,
            BINARY_QUESTION = 14,
            BINARY_SLASH = 15,
            BINARY_SPACE = 16,
            BINARY_STAR = 17,
            BINARY_TILDE = 18,
            COLON = 19,
            COMMA = 20,
            ERROR = 21,
            F = 22,
            IDENTIFIER = 23,
            INTEGER = 24,
            LABEL = 25,
            LEFT_ANGLE_BRACKET = 26,
            LEFT_PAREN = 27,
            LEFT_SQUARE_BRACKET = 28,
            MATCH_DELETE = 29,
            MATCH_ONLY = 30,
            MATCH_REPLACE = 31,
            NO_LABEL = 32,
            NULL = 33,
            OBJECT_DELETE = 34,
            OBJECT_REPLACE = 35,
            REAL = 36,
            RIGHT_ANGLE_BRACKET = 37,
            RIGHT_PAREN = 38,
            RIGHT_SQUARE_BRACKET = 39,
            S = 40,
            SPACE = 41,
            STRING = 42,
            UNARY_AMPERSAND = 43,
            UNARY_AT = 44,
            UNARY_CARET = 45,
            UNARY_DOLLAR = 46,
            UNARY_EQUAL = 47,
            UNARY_EXCLAMATION = 48,
            UNARY_HASH = 49,
            UNARY_MINUS = 50,
            UNARY_PERCENT = 51,
            UNARY_PERIOD = 52,
            UNARY_PIPE = 53,
            UNARY_PLUS = 54,
            UNARY_QUESTION = 55,
            UNARY_SLASH = 56,
            UNARY_STAR = 57,
            UNARY_TILDE = 58,
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

        #endregion

        #region Static Members

        public static Token TokenNull = new(Type.NULL, "", 0, 0);

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
}
