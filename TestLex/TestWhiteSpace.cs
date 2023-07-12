using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestWhiteSpace
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestWhiteSpace01()
        {
            Lex.Input = " TEST";
            Lex.CursorCurrent = 0;

            string tokenValue = " ";

            Token t = Lex.MatchWhiteSpace();

            Assert.AreEqual(Token.Type.SPACE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestWhiteSpace02()
        {
            Lex.Input = " \t \t";
            Lex.CursorCurrent = 0;

            string tokenValue = " ";

            Token t = Lex.MatchWhiteSpace();

            Assert.AreEqual(Token.Type.SPACE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestWhiteSpace03()
        {
            Lex.Input = " ";
            Lex.CursorCurrent = 0;

            string tokenValue = " ";

            Token t = Lex.MatchWhiteSpace();

            Assert.AreEqual(Token.Type.SPACE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


    }
}