using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test219GoTo
    {
        [TestMethod]
        public void TEST_219_001()
        {
            string s = "test1  output = test2 :";
            SyntaxError se = new(1);
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                se = ex;
            }
            Assert.AreEqual(219, se.Code);
            Assert.AreEqual(23, se.Column);
        }
    }
}