using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test227Paren
    {
        [TestMethod]
        public void TEST_227_001()
        {
            SyntaxError e = new(0);
            string s = "    :S(end";
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
            Assert.AreEqual(227, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_227_002()
        {
            SyntaxError e = new(0);
            string s = "    :S(end)F(end";
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
            Assert.AreEqual(227, e.Code);
            Assert.AreEqual(15, e.Column);
        }

        [TestMethod]
        public void TEST_227_003()
        {
            SyntaxError e = new(0);
            string s = "    :S(end)F(()";
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
            Assert.AreEqual(227, e.Code);
            Assert.AreEqual(14, e.Column);
        }

        [TestMethod]
        public void TEST_227_004()
        {
            SyntaxError e = new(0);
            string s = "    :S(end";
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
            Assert.AreEqual(227, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_227_005()
        {
            SyntaxError e = new(0);
            string s = "    :S<end>F(end";
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
            Assert.AreEqual(227, e.Code);
            Assert.AreEqual(15, e.Column);
        }

        [TestMethod]
        public void TEST_227_006()
        {
            SyntaxError e = new(0);
            string s = "    :S<end>F(()";
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
            Assert.AreEqual(227, e.Code);
            Assert.AreEqual(14, e.Column);
        }
    }
}