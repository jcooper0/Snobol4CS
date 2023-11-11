using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test226Paren
    {
        [TestMethod]
        public void TEST_226_001()
        {
            SyntaxError e = new(0);
            string s = "\tB A(";
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
            Assert.AreEqual(226, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_226_002()
        {
            SyntaxError e = new(0);
            string s = "\tB A (B,C";
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
            Assert.AreEqual(226, e.Code);
            Assert.AreEqual(8, e.Column);
        }
    }
}