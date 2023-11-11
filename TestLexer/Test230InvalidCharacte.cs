using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test230InvalidCharacter
    {
        [TestMethod]
        public void TEST_INVALID_CHARACTER_001()
        {
            SyntaxError e = new(0);
            string s = "        §";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_002()
        {
            SyntaxError e = new(0);
            string s = " 12§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(3, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_003()
        {
            SyntaxError e = new(0);
            string s = "    12.34§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_004()
        {
            SyntaxError e = new(0);
            string s = "    12.34e-7§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_005()
        {
            SyntaxError e = new(0);
            string s = "    ID§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_006()
        {
            SyntaxError e = new(0);
            string s = "   F(§)";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_007()
        {
            SyntaxError e = new(0);
            string s = "   F(0)§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_008()
        {
            SyntaxError e = new(0);
            string s = "   F2(0,§)";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_009()
        {
            SyntaxError e = new(0);
            string s = "    \"str\"§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_010()
        {
            SyntaxError e = new(0);
            string s = "    A<§>";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_011()
        {
            SyntaxError e = new(0);
            string s = "    T[§]";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_012()
        {
            SyntaxError e = new(0);
            string s = "    A<0>§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_INVALID_CHARACTER_013()
        {
            SyntaxError e = new(0);
            string s = "     T[0]§";
            Lexer lex = new();
            SourceLine source = new SourceLine("TEST", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError ex)
            {
                e = ex;
            }
            Assert.AreEqual(230, e.Code);
            Assert.AreEqual(9, e.Column);
        }
    }
}