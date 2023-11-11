using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test217Label
    {
        [TestMethod]
        public void TEST_217_001()
        {
            SyntaxError e = new(0);
            string s = "END   'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                // Duplicate entry
                lex.Lex(source);
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(217, e.Code);
            Assert.AreEqual(0, e.Column);
        }
    }
}