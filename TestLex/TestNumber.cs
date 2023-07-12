using Snobol4;

namespace TestLex3
{
    [TestClass]
    public class TestNumber
    {
        public static Lexer Lex = new();
        public static SourceLine source = Lex.Source = new("", 0, "");

        [TestMethod]
        public void TestNumber001()
        {
            Lex.Input = "1234 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber002()
        {
            Lex.Input = "1234";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber003()
        {
            Lex.Input = "+1234 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber004()
        {
            Lex.Input = "+1234";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber005()
        {
            Lex.Input = "-1234 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber006()
        {
            Lex.Input = "-1234";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestNumber007()
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
        public void TestNumber008()
        {
            Lex.Input = "- ";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber009()
        {
            Lex.Input = "+1 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber010()
        {
            Lex.Input = "+1";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.INTEGER, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber011()
        {
            Lex.Input = "1234. ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber012()
        {
            Lex.Input = "1234.";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber013()
        {
            Lex.Input = "+1234. ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber014()
        {
            Lex.Input = "+1234.";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber015()
        {
            Lex.Input = "-1234. ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber016()
        {
            Lex.Input = "-1234.";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }




        [TestMethod]
        public void TestNumber021()
        {
            Lex.Input = "1234.5678 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber022()
        {
            Lex.Input = "1234.5678";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber023()
        {
            Lex.Input = "+1234.5678 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber024()
        {
            Lex.Input = "+1234.5678";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber025()
        {
            Lex.Input = "-1234.5678 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber026()
        {
            Lex.Input = "-1234.5678";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        public void TestNumber031()
        {
            Lex.Input = "1234e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber032()
        {
            Lex.Input = "1234e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber033()
        {
            Lex.Input = "+1234e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber034()
        {
            Lex.Input = "+1234e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber035()
        {
            Lex.Input = "-1234e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber036()
        {
            Lex.Input = "-1234e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestNumber037()
        {
            Lex.Input = "-1234e- ";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxError))]
        public void TestNumber038()
        {
            Lex.Input = "-1234e-";
            Lex.CursorCurrent = 0;

            string tokenValue = "";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.ERROR, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber039()
        {
            Lex.Input = "-1234e-1";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234e-1";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        public void TestNumber041()
        {
            Lex.Input = "1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber042()
        {
            Lex.Input = "1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber043()
        {
            Lex.Input = "+1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber044()
        {
            Lex.Input = "+1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber045()
        {
            Lex.Input = "-1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber046()
        {
            Lex.Input = "-1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }



        [TestMethod]
        public void TestNumber051()
        {
            Lex.Input = "1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber052()
        {
            Lex.Input = "1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber053()
        {
            Lex.Input = "+1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber054()
        {
            Lex.Input = "+1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber055()
        {
            Lex.Input = "-1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber056()
        {
            Lex.Input = "-1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        public void TestNumber061()
        {
            Lex.Input = "1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber062()
        {
            Lex.Input = "1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber063()
        {
            Lex.Input = "+1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber064()
        {
            Lex.Input = "+1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber065()
        {
            Lex.Input = "-1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber066()
        {
            Lex.Input = "-1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }



        [TestMethod]
        public void TestNumber071()
        {
            Lex.Input = "1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber072()
        {
            Lex.Input = "1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber073()
        {
            Lex.Input = "+1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber074()
        {
            Lex.Input = "+1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber075()
        {
            Lex.Input = "-1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber076()
        {
            Lex.Input = "-1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }





        [TestMethod]
        public void TestNumber081()
        {
            Lex.Input = "1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber082()
        {
            Lex.Input = "1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber083()
        {
            Lex.Input = "+1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber084()
        {
            Lex.Input = "+1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber085()
        {
            Lex.Input = "-1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber086()
        {
            Lex.Input = "-1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }





        [TestMethod]
        public void TestNumber091()
        {
            Lex.Input = "1234e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber092()
        {
            Lex.Input = "1234e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber093()
        {
            Lex.Input = "+1234e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber094()
        {
            Lex.Input = "+1234e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber095()
        {
            Lex.Input = "-1234e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber096()
        {
            Lex.Input = "-1234e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }



        [TestMethod]
        public void TestNumber101()
        {
            Lex.Input = "1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber102()
        {
            Lex.Input = "1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber103()
        {
            Lex.Input = "+1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber104()
        {
            Lex.Input = "+1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber105()
        {
            Lex.Input = "-1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber106()
        {
            Lex.Input = "-1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }



        [TestMethod]
        public void TestNumber111()
        {
            Lex.Input = "1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber112()
        {
            Lex.Input = "1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber113()
        {
            Lex.Input = "+1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber114()
        {
            Lex.Input = "+1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber115()
        {
            Lex.Input = "-1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber116()
        {
            Lex.Input = "-1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }


        [TestMethod]
        public void TestNumber121()
        {
            Lex.Input = "1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber122()
        {
            Lex.Input = "1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber123()
        {
            Lex.Input = "+1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber124()
        {
            Lex.Input = "+1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber125()
        {
            Lex.Input = "-1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber126()
        {
            Lex.Input = "-1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }



        [TestMethod]
        public void TestNumber131()
        {
            Lex.Input = "1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber132()
        {
            Lex.Input = "1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber133()
        {
            Lex.Input = "+1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber134()
        {
            Lex.Input = "+1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber135()
        {
            Lex.Input = "-1234.5678e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber136()
        {
            Lex.Input = "-1234.5678e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.5678e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }





        [TestMethod]
        public void TestNumber141()
        {
            Lex.Input = "1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber142()
        {
            Lex.Input = "1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber143()
        {
            Lex.Input = "+1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber144()
        {
            Lex.Input = "+1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "+1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber145()
        {
            Lex.Input = "-1234.e-12 ";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }

        [TestMethod]
        public void TestNumber146()
        {
            Lex.Input = "-1234.e-12";
            Lex.CursorCurrent = 0;

            string tokenValue = "-1234.e-12";

            Token t = Lex.MatchNumber();

            Assert.AreEqual(Token.Type.REAL, t.TokenType);
            Assert.AreEqual(tokenValue, t.MatchedString);
        }




    }
}
