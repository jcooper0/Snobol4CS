using Snobol4;
namespace TestLexer
{
    [TestClass]
    public class Test233Operator
    {
        [TestMethod]
        public void TEST_233_001()
        {
            SyntaxError e = new(0);
            string s = " ID*";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(3, e.Column);
        }

 

        [TestMethod]
        public void TEST_233_004()
        {
            SyntaxError e = new(0);
            string s = " 'test'*";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_233_005()
        {
            SyntaxError e = new(0);
            string s = " \"test\"*";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_233_006()
        {
            SyntaxError e = new(0);
            string s = " A(0)*";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_233_007()
        {
            SyntaxError e = new(0);
            string s = " A<0>*";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_233_008()
        {
            SyntaxError e = new(0);
            string s = " A[0]*";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_233_009()
        {
            SyntaxError e = new(0);
            string s = " ID* ID";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(3, e.Column);
        }

        [TestMethod]
        public void TEST_233_012()
        {
            SyntaxError e = new(0);
            string s = " 'test'* ID";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_233_013()
        {
            SyntaxError e = new(0);
            string s = " \"test\"* ID";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_233_014()
        {
            SyntaxError e = new(0);
            string s = " A(0)* ID";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_233_015()
        {
            SyntaxError e = new(0);
            string s = " A<0>* ID";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_233_016()
        {
            SyntaxError e = new(0);
            string s = " A[0]* ID";
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
            Assert.AreEqual(233, e.Code);
            Assert.AreEqual(5, e.Column);
        }
    }
}