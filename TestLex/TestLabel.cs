using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestLabel
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestLabel01()
        {
            Lex.Input = "TEST ";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchLabel();

            Assert.AreEqual(Token.Type.LABEL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestLabel02()
        {
            Lex.Input = "TEST";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchLabel();

            Assert.AreEqual(Token.Type.LABEL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        public void TestLabel03()
        {
            Lex.Input = "T ";
            Lex.CursorCurrent = 0;

            string tokenValue = "T";

            Token t = Lex.MatchLabel();

            Assert.AreEqual(Token.Type.LABEL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestLabel04()
        {
            Lex.Input = "1";
            Lex.CursorCurrent = 0;

            string tokenValue = "1";

            Token t = Lex.MatchLabel();

            Assert.AreEqual(Token.Type.LABEL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestLabel10()
        {
            Lex.Input = "A+7*3= "; // Yes! This is a valid label!
            Lex.CursorCurrent = 0;
            Lex.CursorStart = 0;

            string tokenValue = "A+7*3=";

            Token t = Lex.MatchLabel();

            Assert.AreEqual(Token.Type.LABEL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestLabel11()
        {
            Lex.Input = "%A+7*3= "; // Yes! This is a valid label!
            Lex.CursorCurrent = 0;
            Lex.CursorStart = 0;

            string tokenValue = "";

            Token t = Lex.MatchLabel();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


    }
}