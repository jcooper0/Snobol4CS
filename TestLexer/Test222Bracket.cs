using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test222Bracket
    {
        [TestMethod]
        public void TEST_222_001()
        {
            SyntaxError e = new(0);
            string s = "   A[[]]";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_222_002()
        {
            SyntaxError e = new(0);
            string s = "   [0]";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(3, e.Column);
        }

        [TestMethod]
        public void TEST_222_003()
        {
            SyntaxError e = new(0);
            string s = "   ([0])";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_222_004()
        {
            SyntaxError e = new(0);
            string s = "   [[0]]";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(3, e.Column);
        }

        [TestMethod]
        public void TEST_222_005()
        {
            SyntaxError e = new(0);
            string s = "   A[[0]]";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_222_006()
        {
            SyntaxError e = new(0);
            string s = "   A([0])";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(5, e.Column);
        }


        [TestMethod]
        public void TEST_222_007()
        {
            SyntaxError e = new(0);
            string s = "   A<<>>";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_222_008()
        {
            SyntaxError e = new(0);
            string s = "   <0>";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(3, e.Column);
        }

        [TestMethod]
        public void TEST_222_009()
        {
            SyntaxError e = new(0);
            string s = "   (<0>)";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_222_010()
        {
            SyntaxError e = new(0);
            string s = "   <<0>>";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(3, e.Column);
        }

        [TestMethod]
        public void TEST_222_012()
        {
            SyntaxError e = new(0);
            string s = "   A<<0>>";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_222_013()
        {
            SyntaxError e = new(0);
            string s = "   A(<0>)";
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
            Assert.AreEqual(222, e.Code);
            Assert.AreEqual(5, e.Column);
        }




    }
}