using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test228Bracket
    {
        [TestMethod]
        public void TEST_228_001()
        {
            SyntaxError e = new(0);
            string s = "    :S<end";
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
            Assert.AreEqual(228, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_228_002()
        {
            SyntaxError e = new(0);
            string s = "    :S(end)F<end";
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
            Assert.AreEqual(228, e.Code);
            Assert.AreEqual(15, e.Column);
        }

        [TestMethod]
        public void TEST_228_004()
        {
            SyntaxError e = new(0);
            string s = "    :S<end";
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
            Assert.AreEqual(228, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_228_005()
        {
            SyntaxError e = new(0);
            string s = "    :S<end>F<end";
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
            Assert.AreEqual(228, e.Code);
            Assert.AreEqual(15, e.Column);
        }

    }
}