using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test225Bracket
    {
        [TestMethod]
        public void TEST_225_001()
        {
            SyntaxError e = new(0);
            string s = "   A>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(225, e.Code);
            Assert.AreEqual(4, e.Column);
        }

 
        [TestMethod]
        public void TEST_225_002()
        {
            SyntaxError e = new(0);
            string s = "   A]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(225, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_225_003()
        {
            SyntaxError e = new(0);
            string s = " B A>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(225, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_225_004()
        {
            SyntaxError e = new(0);
            string s = " B A]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(225, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_225_005()
        {
            SyntaxError e = new(0);
            string s = " (A + B])";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(225, e.Code);
            Assert.AreEqual(7, e.Column);
        }


        [TestMethod]
        public void TEST_225_006()
        {
            SyntaxError e = new(0);
            string s = "   A[B + C(]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(225, e.Code);
            Assert.AreEqual(11, e.Column);
        }
    }
}