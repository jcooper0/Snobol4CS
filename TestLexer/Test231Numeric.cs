using Snobol4;

namespace TestLexer
{
    [TestClass]
    public class Test231Numeric
    {
        [TestMethod]
        public void TEST_231_001()
        {
            SyntaxError e = new(0);
            string s = " 123D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_231_002()
        {
            SyntaxError e = new(0);
            string s = " 123.123D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_003()
        {
            SyntaxError e = new(0);
            string s = " 123e45D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_004()
        {
            SyntaxError e = new(0);
            string s = " 123e+45D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_005()
        {
            SyntaxError e = new(0);
            string s = " 123e-45D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_006()
        {
            SyntaxError e = new(0);
            string s = " 123.e45D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_007()
        {
            SyntaxError e = new(0);
            string s = " 123.e+45D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_008()
        {
            SyntaxError e = new(0);
            string s = " 123.e-45D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_009()
        {
            SyntaxError e = new(0);
            string s = " 123.456e78D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(11, e.Column);
        }

        [TestMethod]
        public void TEST_231_010()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+78D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_011()
        {
            SyntaxError e = new(0);
            string s = " 123.456e-78D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_012()
        {
            SyntaxError e = new(0);
            string s = " 123e+D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_013()
        {
            SyntaxError e = new(0);
            string s = " 123e-D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_014()
        {
            SyntaxError e = new(0);
            string s = " 123.eD";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_015()
        {
            SyntaxError e = new(0);
            string s = " 123.e+D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_016()
        {
            SyntaxError e = new(0);
            string s = " 123.e-D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_017()
        {
            SyntaxError e = new(0);
            string s = " 123.456eD";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_018()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+D";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(10, e.Column);
        }

        //////////////////////////////////////////////////////////////////////////////////////


        [TestMethod]
        public void TEST_231_101()
        {
            SyntaxError e = new(0);
            string s = " 123'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_231_102()
        {
            SyntaxError e = new(0);
            string s = " 123.123'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_103()
        {
            SyntaxError e = new(0);
            string s = " 123e45'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_104()
        {
            SyntaxError e = new(0);
            string s = " 123e+45'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_105()
        {
            SyntaxError e = new(0);
            string s = " 123e-45'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_106()
        {
            SyntaxError e = new(0);
            string s = " 123.e45'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_107()
        {
            SyntaxError e = new(0);
            string s = " 123.e+45'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_108()
        {
            SyntaxError e = new(0);
            string s = " 123.e-45'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_109()
        {
            SyntaxError e = new(0);
            string s = " 123.456e78'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(11, e.Column);
        }

        [TestMethod]
        public void TEST_231_110()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+78'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_111()
        {
            SyntaxError e = new(0);
            string s = " 123.456e-78'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_112()
        {
            SyntaxError e = new(0);
            string s = " 123e+'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_113()
        {
            SyntaxError e = new(0);
            string s = " 123e-'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_114()
        {
            SyntaxError e = new(0);
            string s = " 123.e'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_115()
        {
            SyntaxError e = new(0);
            string s = " 123.e+'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_116()
        {
            SyntaxError e = new(0);
            string s = " 123.e-'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_117()
        {
            SyntaxError e = new(0);
            string s = " 123.456e'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_118()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+'";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(10, e.Column);
        }

        ///////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TEST_231_201()
        {
            SyntaxError e = new(0);
            string s = " 123\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(4, e.Column);
        }

        [TestMethod]
        public void TEST_231_202()
        {
            SyntaxError e = new(0);
            string s = " 123.123\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_203()
        {
            SyntaxError e = new(0);
            string s = " 123e45\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_204()
        {
            SyntaxError e = new(0);
            string s = " 123e+45\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_205()
        {
            SyntaxError e = new(0);
            string s = " 123e-45\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_206()
        {
            SyntaxError e = new(0);
            string s = " 123.e45\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_207()
        {
            SyntaxError e = new(0);
            string s = " 123.e+45\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_208()
        {
            SyntaxError e = new(0);
            string s = " 123.e-45\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_209()
        {
            SyntaxError e = new(0);
            string s = " 123.456e78\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(11, e.Column);
        }

        [TestMethod]
        public void TEST_231_210()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+78\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_211()
        {
            SyntaxError e = new(0);
            string s = " 123.456e-78\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_212()
        {
            SyntaxError e = new(0);
            string s = " 123e+\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_213()
        {
            SyntaxError e = new(0);
            string s = " 123e-\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_214()
        {
            SyntaxError e = new(0);
            string s = " 123.e\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(6, e.Column);
        }

        [TestMethod]
        public void TEST_231_215()
        {
            SyntaxError e = new(0);
            string s = " 123.e+\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_216()
        {
            SyntaxError e = new(0);
            string s = " 123.e-\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_217()
        {
            SyntaxError e = new(0);
            string s = " 123.456e\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_218()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+\"";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(10, e.Column);
        }

        ////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TEST_231_301()
        {
            SyntaxError e = new(0);
            string s = " 123+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(5, e.Column);
        }

        [TestMethod]
        public void TEST_231_302()
        {
            SyntaxError e = new(0);
            string s = " 123.123+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_303()
        {
            SyntaxError e = new(0);
            string s = " 123e45+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_304()
        {
            SyntaxError e = new(0);
            string s = " 123e+45+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_305()
        {
            SyntaxError e = new(0);
            string s = " 123e-45+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_306()
        {
            SyntaxError e = new(0);
            string s = " 123.e45+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(9, e.Column);
        }

        [TestMethod]
        public void TEST_231_307()
        {
            SyntaxError e = new(0);
            string s = " 123.e+45+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(10, e.Column);
        }

        [TestMethod]
        public void TEST_231_308()
        {
            SyntaxError e = new(0);
            string s = " 123.e-45+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(10, e.Column);
        }

        [TestMethod]
        public void TEST_231_309()
        {
            SyntaxError e = new(0);
            string s = " 123.456e78+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_231_310()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+78+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_231_311()
        {
            SyntaxError e = new(0);
            string s = " 123.456e-78+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_231_312()
        {
            SyntaxError e = new(0);
            string s = " 123e++";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_313()
        {
            SyntaxError e = new(0);
            string s = " 123e-+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_314()
        {
            SyntaxError e = new(0);
            string s = " 123.e+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(7, e.Column);
        }

        [TestMethod]
        public void TEST_231_315()
        {
            SyntaxError e = new(0);
            string s = " 123.e++";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_316()
        {
            SyntaxError e = new(0);
            string s = " 123.e-+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(8, e.Column);
        }

        [TestMethod]
        public void TEST_231_317()
        {
            SyntaxError e = new(0);
            string s = " 123.456e+";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(10, e.Column);
        }

        [TestMethod]
        public void TEST_231_318()
        {
            SyntaxError e = new(0);
            string s = " 123.456e++";
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

            Assert.AreEqual(231, e.Code);
            Assert.AreEqual(11, e.Column);
        }

        //////////////////////////////////////////////////////////////////////////////////////



    }
}