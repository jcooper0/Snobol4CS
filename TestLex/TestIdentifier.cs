using Snobol4;

namespace TestLex3
{

    [TestClass]
    public class TestIdentifier
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestIdentifier01()
        {
            Lex.Input = "TEST ";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.IDENTIFIER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestIdentifier02()
        {
            Lex.Input = "TEST";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.IDENTIFIER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestIdentifier03()
        {
            Lex.Input = "TEST_.12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST_.12";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.IDENTIFIER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestIdentifier04()
        {
            Lex.Input = "TEST_.12";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST_.12";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.IDENTIFIER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);

        }

        [TestMethod]
        public void TestIdentifier05()
        {
            Lex.Input = "T ";
            Lex.CursorCurrent = 0;

            string tokenValue = "T";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.IDENTIFIER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestIdentifier06()
        {
            Lex.Input = "T";
            Lex.CursorCurrent = 0;

            string tokenValue = "T";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.IDENTIFIER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);

        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestIdentifier07()
        {
            Lex.Input = "T*";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchIdentifier();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

    }
}