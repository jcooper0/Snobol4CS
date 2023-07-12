using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestString
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestString01()
        {
            Lex.Input = "'TEST' ";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchString();

            Assert.AreEqual(Token.Type.STRING, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestString02()
        {
            Lex.Input = "'TEST'";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchString();

            Assert.AreEqual(Token.Type.STRING, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestString03()
        {
            Lex.Input = "''";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchString();

            Assert.AreEqual(Token.Type.STRING, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestString04()
        {
            Lex.Input = "'TEST";
            Lex.CursorCurrent = 0;

            Token t = Lex.MatchString();
            string tokenValue = "";

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestString11()
        {
            Lex.Input = "\"TEST\" ";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchString();

            Assert.AreEqual(Token.Type.STRING, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestString12()
        {
            Lex.Input = "\"TEST\"";
            Lex.CursorCurrent = 0;

            string tokenValue = "TEST";

            Token t = Lex.MatchString();

            Assert.AreEqual(Token.Type.STRING, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestString13()
        {
            Lex.Input = "\"\"";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchString();

            Assert.AreEqual(Token.Type.STRING, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestString14()
        {
            Lex.Input = "\"TEST";
            Lex.CursorCurrent = 0;

            Token t = Lex.MatchString();

            string tokenValue = "";

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestString21()
        {
            Lex.Input = "\"TEST'";
            Lex.CursorCurrent = 0;

            Token t = Lex.MatchString();

            string tokenValue = "";

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestString22()
        {
            Lex.Input = "'TEST\"";
            Lex.CursorCurrent = 0;

            Token t = Lex.MatchString();

            string tokenValue = "";

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestString23()
        {
            Lex.Input = "'TEST'*";
            Lex.CursorCurrent = 0;

            Token t = Lex.MatchString();

            string tokenValue = "";

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
          }

    }
}