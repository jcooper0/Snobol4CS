using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test224Paren
    {
        [TestMethod]
        public void TEST_224_001()
        {
            SyntaxError e = new(0);
            string s = "\tB A)";
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
            Assert.AreEqual(224, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_224_002()
        {
            SyntaxError e = new(0);
            string s = "\tA[B + C)]";
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
            Assert.AreEqual(224, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_224_003()
        {
            SyntaxError e = new(0);
            string s = "\t(A + B[)";
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
            Assert.AreEqual(224, e.Code);
            Assert.AreEqual(8, e.Column);
        }
    }
}