using Snobol4;
namespace TestLexer;

[TestClass]
public class Test215Label
{
    [TestMethod]
    public void TEST_215_001()
    {
        SyntaxError e = new(0);
        string s = "END   'test'";
        Lexer lex = new();
        SourceLine source = new("TestFile", 1, s);
        try
        {
            lex.Lex(source);
            lex.GetEntryLabel(source);
        }
        catch (SyntaxError ex)
        {
            e = ex;
        }
        Assert.AreEqual(215, e.Code);
        Assert.AreEqual(7, e.Column);
    }

    [TestMethod]
    public void TEST_215_002()
    {
        SyntaxError e = new(0);
        string s = "END   test";
        Lexer lex = new();
        SourceLine source = new("TestFile", 1, s);
        try
        {
            lex.Lex(source);
            lex.GetEntryLabel(source);
        }
        catch (SyntaxError ex)
        {
            e = ex;
        }
        Assert.AreEqual(215, e.Code);
        Assert.AreEqual(6, e.Column);
    }

    [TestMethod]
    public void TEST_215_003()
    {
        SyntaxError e = new(0);
        string s = "END   125.3";
        Lexer lex = new();
        SourceLine source = new("TestFile", 1, s);
        try
        {
            lex.Lex(source);
            lex.GetEntryLabel(source);
        }
        catch (SyntaxError ex)
        {
            e = ex;
        }
        Assert.AreEqual(215, e.Code);
        Assert.AreEqual(6, e.Column);
    }
}