using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class TestGoTo
    {
        [TestMethod]
        public void TEST_GOTO_001()
        {
            string s = "  :S(test)F(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_002()
        {
            string s = "  :F(test)S(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_003()
        {
            string s = "  :S<test>F(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_004()
        {
            string s = "  :F<test>S(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_005()
        {
            string s = "  :S(test)F<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_006()
        {
            string s = "  :F(test)S<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_007()
        {
            string s = "  :S<test>F<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_008()
        {
            string s = "  :F<test>S<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(10, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
            Assert.AreEqual("test", source.LexLine[8].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_009()
        {
            string s = "  :S(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(6, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
        }


        [TestMethod]
        public void TEST_GOTO_010()
        {
            string s = "  :S<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(6, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
        }       
        
         [TestMethod]
        public void TEST_GOTO_011()
        {
            string s = "  :F(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(6, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
        }


        [TestMethod]
        public void TEST_GOTO_012()
        {
            string s = "  :F<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(6, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
        }

        [TestMethod]
        public void TEST_GOTO_013()
        {
            string s = "  :F(test)";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(6, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
        }


        [TestMethod]
        public void TEST_GOTO_014()
        {
            string s = "  :F<test>";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            lex.Lex(source);
            Assert.AreEqual(6, source.LexLine.Count());
            Assert.AreEqual("test", source.LexLine[4].MatchedString);
        }



    }
}