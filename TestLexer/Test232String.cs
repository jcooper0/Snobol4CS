using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test232Label
    {
        [TestMethod]
        public void TEST_232_001()
        {
            SyntaxError e = new(0);
            string s = "\t\"test";
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
            Assert.AreEqual(232, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_232_002()
        {
            SyntaxError e = new(0);
            string s = "\t'test";
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
            Assert.AreEqual(232, e.Code);
            Assert.AreEqual(6, e.Column);
        }

    }
}