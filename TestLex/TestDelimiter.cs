using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestDelimiter
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("",0,"");

        [TestMethod]
        public void Test_LEFT_ANGLE_BRACKET_01()
        {
            Lex.Input = "<";
            Lex.CursorCurrent = 0;

            string tokenValue = "<";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.LEFT_ANGLE_BRACKET, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_LEFT_SQUARE_BRACKET_01()
        {
            Lex.Input = "[";
            Lex.CursorCurrent = 0;

            string tokenValue = "[";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.LEFT_SQUARE_BRACKET, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_LEFT_PAREN_01()
        {
            Lex.Input = "(";
            Lex.CursorCurrent = 0;

            string tokenValue = "(";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.LEFT_PAREN, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_RIGHT_ANGLE_BRACKET_01()
        {
            Lex.Input = ">";
            Lex.CursorCurrent = 0;

            string tokenValue = ">";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.RIGHT_ANGLE_BRACKET, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_RIGHT_SQUARE_BRACKET_01()
        {
            Lex.Input = "]";
            Lex.CursorCurrent = 0;

            string tokenValue = "]";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.RIGHT_SQUARE_BRACKET, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_RIGHT_PAREN_01()
        {
            Lex.Input = ")";
            Lex.CursorCurrent = 0;

            string tokenValue = ")";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.RIGHT_PAREN, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_COLON_01()
        {
            Lex.Input = ":";
            Lex.CursorCurrent = 0;

            string tokenValue = ":";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.COLON, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void Test_COMMA_01()
        {
            Lex.Input = ",";
            Lex.CursorCurrent = 0;

            string tokenValue = ",";

            Token t = Lex.MatchDelimiter();

            Assert.AreEqual(Token.Type.COMMA, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

    }
}