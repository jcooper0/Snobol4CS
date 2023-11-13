using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test220Operator
    {
        [TestMethod]
        public void TEST220_001()
        {
            SyntaxError se = new(1);
            string s = " F(0)1.23E4";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_002()
        {
            SyntaxError se = new(1);
            string s = " \"str\"1.23E4 ";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(6, se.Column);
        }

        [TestMethod]
        public void TEST220_003()
        {
            SyntaxError se = new(1);
            string s = " \"str\"1.23E4";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(6, se.Column);
        }

        [TestMethod]
        public void TEST220_004()
        {
            SyntaxError se = new(1);
            string s = " A<0>1.23E4";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_005()
        {
            SyntaxError se = new(1);
            string s = " T[0]1.23E4";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_006()
        {
            SyntaxError se = new(1);
            string s = " A<0>'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_007()
        {
            SyntaxError se = new(1);
            string s = " T[0]'test'";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_008()
        {
            SyntaxError se = new(1);
            string s = " A<0>\"test\"";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_009()
        {
            SyntaxError se = new(1);
            string s = " T[0]\"test\"";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_010()
        {
            SyntaxError se = new(1);
            string s = " F(0)ID";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_011()
        {
            SyntaxError se = new(1);
            string s = " \"str\"ID";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(6, se.Column);
        }

        [TestMethod]
        public void TEST220_012()
        {
            SyntaxError se = new(1);
            string s = " A<0>ID";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST220_013()
        {
            SyntaxError se = new(1);
            string s = " T[0]ID";
            Lexer lex = new();
            SourceLine source = new("TestFile", 1, s);
            try
            {
                lex.Lex(source);
            }
            catch (SyntaxError e)
            {
                se = e;
            }

            Assert.AreEqual(220, se.Code);
            Assert.AreEqual(5, se.Column);
        }

        [TestMethod]
        public void TEST_220_014()
        {
            SyntaxError e = new(0);
            string s = "    :S(end()F(END)";
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

            Assert.AreEqual(220, e.Code);
            Assert.AreEqual(13, e.Column);
        }

    }
}

