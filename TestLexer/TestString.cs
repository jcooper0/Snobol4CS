using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class TestString
    {
        [TestMethod]
        public void TEST_STRING_001()
        {
            string s = " \"te'st\" \"pil'ot\"";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(4, source.LexLine.Count());
            Assert.AreEqual(s[2..7], source.LexLine[1].MatchedString);
            Assert.AreEqual(s[10..16], source.LexLine[3].MatchedString);
        }

        [TestMethod]
        public void TEST_STRING_002()
        {
            string s = " 'te\"st' 'pi\"lot'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(4, source.LexLine.Count());
            Assert.AreEqual(s[2..7], source.LexLine[1].MatchedString);
            Assert.AreEqual(s[10..16], source.LexLine[3].MatchedString);
        }

        [TestMethod]
        public void TEST_STRING_003()
        {
            string s = " 'te\"st' \"pi'lot\"";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(4, source.LexLine.Count());
            Assert.AreEqual(s[2..7], source.LexLine[1].MatchedString);
            Assert.AreEqual(s[10..16], source.LexLine[3].MatchedString);
        }

        [TestMethod]
        public void TEST_STRING_004()
        {
            string s = " \"te'st\" 'pil\"ot'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(s[2..7], source.LexLine[1].MatchedString);
            Assert.AreEqual(s[10..16], source.LexLine[3].MatchedString);
        }
    }
}