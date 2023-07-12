using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestOperator
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorAMPERSAND01()
        {
            Lex.Input = " &";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorAT01()
        {
            Lex.Input = " @";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorDOLLAR01()
        {
            Lex.Input = " $";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestDOUBLE_STAR01()
        {
            Lex.Input = " **";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "*";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_STAR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorEXCLAMATION01()
        {
            Lex.Input = " !";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorHASH01()
        {
            Lex.Input = " #";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorMINUS01()

        {
            Lex.Input = " -";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorPERCENT01()
        {
            Lex.Input = " %";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorPERIOD01()
        {
            Lex.Input = " .";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorPIPE01()
        {
            Lex.Input = " |";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorCARET01()
        {
            Lex.Input = " ^";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorPLUS01()
        {
            Lex.Input = " +";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorQUESTION01()
        {
            Lex.Input = " ?";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorSLASH01()
        {
            Lex.Input = " /";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorSTAR01()
        {
            Lex.Input = " *";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestOperatorTILDE01()
        {
            Lex.Input = " ~";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        /*====================================================*/

        [TestMethod]
        public void TestOperatorCARET02()
        {
            Lex.Input = " ^ ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "^";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_CARET, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorAMPERSAND02()
        {
            Lex.Input = " & ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "&";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_AMPERSAND, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorAT02()
        {
            Lex.Input = " @ ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "@";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_AT, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorDOLLAR02()
        {
            Lex.Input = " $ ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "$";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_DOLLAR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestDOUBLE_STAR02()
        {
            Lex.Input = " ** ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "**";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_DOUBLE_STAR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorEXCLAMATION02()
        {
            Lex.Input = " ! ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "!";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_EXCLAMATION, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorHASH02()
        {
            Lex.Input = " # ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "#";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_HASH, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorMINUS02()

        {
            Lex.Input = " - ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "-";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_MINUS, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPERCENT02()
        {
            Lex.Input = " % ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "%";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_PERCENT, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPERIOD02()
        {
            Lex.Input = " . ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = ".";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_PERIOD, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPIPE02()
        {
            Lex.Input = " | ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "|";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_PIPE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPLUS02()
        {
            Lex.Input = " + ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "+";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_PLUS, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorQUESTION02()
        {
            Lex.Input = " ? ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "?";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_QUESTION, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorSLASH02()
        {
            Lex.Input = " / ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "/";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_SLASH, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorSTAR02()
        {
            Lex.Input = " * ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "*";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_STAR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorTILDE02()
        {
            Lex.Input = " ~ ";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "~";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.BINARY_TILDE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        /*====================================================*/

        [TestMethod]
        public void TestOperatorCARET03()
        {
            Lex.Input = " ^A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "^";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_CARET, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        public void TestOperatorAMPERSAND03()
        {
            Lex.Input = " &A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "&";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_AMPERSAND, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorAT03()
        {
            Lex.Input = " @A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "@";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_AT, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorDOLLAR03()
        {
            Lex.Input = " $A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "$";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_DOLLAR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorEXCLAMATION03()
        {
            Lex.Input = " !A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "!";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_EXCLAMATION, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorHASH03()
        {
            Lex.Input = " #A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "#";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_HASH, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorMINUS03()

        {
            Lex.Input = " -A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "-";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_MINUS, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPERCENT03()
        {
            Lex.Input = " %A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "%";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_PERCENT, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPERIOD03()
        {
            Lex.Input = " .A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = ".";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_PERIOD, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPIPE03()
        {
            Lex.Input = " |A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "|";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_PIPE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorPLUS03()
        {
            Lex.Input = " +A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "+";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_PLUS, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorQUESTION03()
        {
            Lex.Input = " ?A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "?";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_QUESTION, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorSLASH03()
        {
            Lex.Input = " /A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "/";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_SLASH, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorSTAR03()
        {
            Lex.Input = " *A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "*";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_STAR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestOperatorTILDE03()
        {
            Lex.Input = " ~A";
            Lex.CursorCurrent = 1;
            Lex.CursorStart = 1;

            string tokenValue = "~";

            Token t = Lex.MatchOperator();

            Assert.AreEqual(Token.Type.UNARY_TILDE, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


    }
}