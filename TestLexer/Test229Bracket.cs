using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test229Bracket
    {
        [TestMethod]
        public void TEST_229_001()
        {
            SyntaxError e = new(0);
            string s = "   A<";
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
            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_229_002()
        {
            SyntaxError e = new(0);
            string s = "   A[";
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
            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_229_003()
        {
            SyntaxError e = new(0);
            string s = "   A<0<>";
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

            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_229_004()
        {
            SyntaxError e = new(0);
            string s = " B A<";
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
            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_229_005()
        {
            SyntaxError e = new(0);
            string s = " B A[";
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
            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_229_006()
        {
            SyntaxError e = new(0);
            string s = "  (B A)<";
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
            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_229_007()
        {
            SyntaxError e = new(0);
            string s = "  (B A)[";
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
            Assert.AreEqual(229, e.Code);
            Assert.AreEqual(7, e.Column);
        }
    }
}