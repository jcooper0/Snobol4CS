using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test214Label
    {
        [TestMethod]
        public void TEST_214_001()
        {
            SyntaxError e = new(0);
            string s = "£   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_002()
        {
            SyntaxError e = new(0);
            string s = "£";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_003()
        {
            SyntaxError e = new(0);
            string s = ":   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_004()
        {
            SyntaxError e = new(0);
            string s = ")   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_005()
        {
            SyntaxError e = new(0);
            string s = "[   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_006()
        {
            SyntaxError e = new(0);
            string s = "]   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_007()
        {
            SyntaxError e = new(0);
            string s = "<   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_008()
        {
            SyntaxError e = new(0);
            string s = ">   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_009()
        {
            SyntaxError e = new(0);
            string s = "(   'test'";
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

            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_010()
        {
            SyntaxError e = new(0);
            string s = "/   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_011()
        {
            SyntaxError e = new(0);
            string s = "\"   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }

        [TestMethod]
        public void TEST_214_012()
        {
            SyntaxError e = new(0);
            string s = ",   'test'";
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
            Assert.AreEqual(214, e.Code);
            Assert.AreEqual(0, e.Column);
        }
    }
}