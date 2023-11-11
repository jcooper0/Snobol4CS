using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class TestNumeric
    {
        [TestMethod]
        public void TEST_INTEGER_001()
        {
            string s = " 123";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_001()
        {
            string s = " 123.123";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_002()
        {
            string s = " 123e45";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_003()
        {
            string s = " 123e+45";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_004()
        {
            string s = " 123e-45";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_005()
        {
            string s = " 123.e45";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_006()
        {
            string s = " 123.e+45";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_007()
        {
            string s = " 123.e-45";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_008()
        {
            string s = " 123.456e78";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_009()
        {
            string s = " 123.456e+78";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

        [TestMethod]
        public void TEST_REAL_010()
        {
            string s = " 123.456e-78";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(2, source.LexLine.Count());
            Assert.AreEqual(s[1..], source.LexLine[1].MatchedString);
        }

    }
}