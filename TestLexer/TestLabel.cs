using Snobol4;

namespace TestLexer
{
    [TestClass]
    public class TestLabel
    {
        [TestMethod]
        public void TEST_LABEL_001()
        {
            string s = "ABC1223   'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(3, source.LexLine.Count());
            Assert.AreEqual(s[0..7], source.LexLine[0].MatchedString);
        }

        [TestMethod]
        public void TEST_LABEL_002()
        {
            string s = "123ABC   'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(3, source.LexLine.Count());
            Assert.AreEqual(s[0..6], source.LexLine[0].MatchedString);
        }

        [TestMethod]
        public void TEST_LABEL_003()
        {
            string s = "123£ËABC   'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(3, source.LexLine.Count());
            Assert.AreEqual(s[0..8], source.LexLine[0].MatchedString);
        }

        [TestMethod]
        public void TEST_LABEL_004()
        {
            string s = "123£ËABC   'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(3, source.LexLine.Count(), 3);
            Assert.AreEqual("123£ËABC", source.LexLine[0].MatchedString);
            Assert.AreEqual("test", source.LexLine[2].MatchedString);
        }

        [TestMethod]
        public void TEST_LABEL_005()
        {
            string s1 = "test  OUTPUT = 4";
            string s2 = "END   test";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s1);
            lex.Lex(source);
            source = new("TestFile", 2, s2);
            lex.Lex(source);
            string entryLabel = lex.GetEntryLabel(source);
            Assert.AreEqual("test", entryLabel);
        }

        [TestMethod]
        public void TEST_LABEL_006()
        {
            string s = "END";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            string entryLabel = lex.GetEntryLabel(source);
            Assert.AreEqual("", entryLabel);
        }

        [TestMethod]
        public void TEST_LABEL_007()
        {
            string s = "END    ";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            string entryLabel = lex.GetEntryLabel(source);
            Assert.AreEqual("", entryLabel);
        }
    }
}