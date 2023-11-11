using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class TestBracket
    {
        [TestMethod]
        public void TEST_BRACKET_001()
        {
            string s = "   123.45e67<0>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(5, source.LexLine.Count());
            Assert.AreEqual(s[3..12], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_002()
        {
            string s = "   (123.45e67)<0>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(7, source.LexLine.Count());
            Assert.AreEqual(s[4..13], source.LexLine[2].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_003()
        {
            SyntaxError e = new(0);
            string s = "   12[0]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(5, source.LexLine.Count());
            Assert.AreEqual(s[3..5], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_004()
        {
            SyntaxError e = new(0);
            string s = "   (12)[0]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(7, source.LexLine.Count());
            Assert.AreEqual(s[4..6], source.LexLine[2].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_005()
        {
            SyntaxError e = new(0);
            string s = "   'abc'[0]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(5, source.LexLine.Count());
            Assert.AreEqual(s[4..7], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_006()
        {
            SyntaxError e = new(0);
            string s = "   ('abc')[0]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(7, source.LexLine.Count());
            Assert.AreEqual(s[5..8], source.LexLine[2].MatchedString);
        }
        
        [TestMethod]
        public void TEST_BRACKET_007()
        {
            SyntaxError e = new(0);
            string s = "   123.45e67[0]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(5, source.LexLine.Count());
            Assert.AreEqual(s[3..12], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_008()
        {
            SyntaxError e = new(0);
            string s = "   (123.45e67)[0]";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(7, source.LexLine.Count());
            Assert.AreEqual(s[4..13], source.LexLine[2].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_009()
        {
            SyntaxError e = new(0);
            string s = "   12<0>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(5, source.LexLine.Count());
            Assert.AreEqual(s[3..5], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_010()
        {
            SyntaxError e = new(0);
            string s = "   (12)<0>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(7, source.LexLine.Count());
            Assert.AreEqual(s[4..6], source.LexLine[2].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_011()
        {
            SyntaxError e = new(0);
            string s = "   'abc'<0>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(5, source.LexLine.Count());
            Assert.AreEqual(s[4..7], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_BRACKET_012()
        {
            SyntaxError e = new(0);
            string s = "   ('abc')<0>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(7, source.LexLine.Count());
            Assert.AreEqual(s[5..8], source.LexLine[2].MatchedString);
        }
    }
}