using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestInteger
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestInteger001()
        {
            Lex.Input = "1 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger002()
        {
            Lex.Input = "1";
            Lex.CursorCurrent = 0;

            string tokenValue = "1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger003()
        {
            Lex.Input = "+1 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger004()
        {
            Lex.Input = "+1";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger005()
        {
            Lex.Input = "-1 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger006()
        {
            Lex.Input = "-1";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestInteger007()
        {
            Lex.Input = "+ ";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestInteger008()
        {
            Lex.Input = "- ";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger011()
        {
            Lex.Input = "12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger012()
        {
            Lex.Input = "12";
            Lex.CursorCurrent = 0;

            string tokenValue = "12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger013()
        {
            Lex.Input = "+12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger014()
        {
            Lex.Input = "+12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger015()
        {
            Lex.Input = "-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger016()
        {
            Lex.Input = "-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger017()
        {
            Lex.Input = "-12)";
            Lex.CursorCurrent = 0;

            string tokenValue = "-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger018()
        {
            Lex.Input = "-12]";
            Lex.CursorCurrent = 0;

            string tokenValue = "-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger019()
        {
            Lex.Input = "-12>";
            Lex.CursorCurrent = 0;

            string tokenValue = "-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestInteger020()
        {
            Lex.Input = "-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestInteger02()
        {
            Lex.Input = "-12A";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

    }
}
