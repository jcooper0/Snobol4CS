using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestEqual
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestEqual01()
        {
            Lex.Input = " =         ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "=";

            Token t = Lex.MatchEqual();

            Assert.AreEqual(Token.Type.UNARY_EQUAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestEqual02()
        {
            Lex.Input = " =         ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "=";

            Token t = Lex.MatchEqual();

            Assert.AreEqual(Token.Type.UNARY_EQUAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestEqual03()
        {
            Lex.Input = " =         :";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "=";

            Token t = Lex.MatchEqual();

            Assert.AreEqual(Token.Type.UNARY_EQUAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestEqual12()
        {
            Lex.Input = " = A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "=";

            Token t = Lex.MatchEqual();

            Assert.AreEqual(Token.Type.BINARY_EQUAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestEqual13()
        {
            Lex.Input = " = 12";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "=";

            Token t = Lex.MatchEqual();

            Assert.AreEqual(Token.Type.BINARY_EQUAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestEqual14()
        {
            Lex.Input = " = 'A'";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "=";

            Token t = Lex.MatchEqual();

            Assert.AreEqual(Token.Type.BINARY_EQUAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }
    }
}