using Snobol4;
namespace TestLexer
{


    [TestClass]
    public class Test218Goto
    {
        [TestMethod]
        public void TEST_218_001()
        {
            SyntaxError e = new(0);
            string s = "    :S(test)S(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_002()
        {
            SyntaxError e = new(0);
            string s = "    :S(test)(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_003()
        {
            SyntaxError e = new(0);
            string s = "    :F(test)F(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_004()
        {
            SyntaxError e = new(0);
            string s = "    :F(test)(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_005()
        {
            SyntaxError e = new(0);
            string s = "    :(test)S(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_006()
        {
            SyntaxError e = new(0);
            string s = "    :(test)S(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_007()
        {
            SyntaxError e = new(0);
            string s = "    :(test)(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }


        [TestMethod]
        public void TEST_218_008()
        {
            SyntaxError e = new(0);
            string s = "    :S(test)s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_009()
        {
            SyntaxError e = new(0);
            string s = "    :S(test)<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_010()
        {
            SyntaxError e = new(0);
            string s = "    :F(test)F<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_011()
        {
            SyntaxError e = new(0);
            string s = "    :F(test)<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_012()
        {
            SyntaxError e = new(0);
            string s = "    :(test)S<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_013()
        {
            SyntaxError e = new(0);
            string s = "    :(test)S<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_014()
        {
            SyntaxError e = new(0);
            string s = "    :(test)<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }


        [TestMethod]
        public void TEST_218_015()
        {
            SyntaxError e = new(0);
            string s = "    :S<test>S(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_016()
        {
            SyntaxError e = new(0);
            string s = "    :S<test>(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_017()
        {
            SyntaxError e = new(0);
            string s = "    :F<test>F(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_018()
        {
            SyntaxError e = new(0);
            string s = "    :F<test>(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_019()
        {
            SyntaxError e = new(0);
            string s = "    :<test>S(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_020()
        {
            SyntaxError e = new(0);
            string s = "    :<test>S(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_021()
        {
            SyntaxError e = new(0);
            string s = "    :<test>(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_022()
        {
            SyntaxError e = new(0);
            string s = "    :S<test>S<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_023()
        {
            SyntaxError e = new(0);
            string s = "    :S<test><test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_024()
        {
            SyntaxError e = new(0);
            string s = "    :F<test>F<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_025()
        {
            SyntaxError e = new(0);
            string s = "    :F<test><test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_026()
        {
            SyntaxError e = new(0);
            string s = "    :<test>S<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_027()
        {
            SyntaxError e = new(0);
            string s = "    :<test>S<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_028()
        {
            SyntaxError e = new(0);
            string s = "    :<test><test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_101()
        {
            SyntaxError e = new(0);
            string s = "    :s(test)s(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_102()
        {
            SyntaxError e = new(0);
            string s = "    :s(test)(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_103()
        {
            SyntaxError e = new(0);
            string s = "    :f(test)f(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_104()
        {
            SyntaxError e = new(0);
            string s = "    :f(test)(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_105()
        {
            SyntaxError e = new(0);
            string s = "    :(test)s(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_106()
        {
            SyntaxError e = new(0);
            string s = "    :(test)s(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_107()
        {
            SyntaxError e = new(0);
            string s = "    :(test)(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_108()
        {
            SyntaxError e = new(0);
            string s = "    :s(test)s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_109()
        {
            SyntaxError e = new(0);
            string s = "    :s(test)<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_110()
        {
            SyntaxError e = new(0);
            string s = "    :f(test)f<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_111()
        {
            SyntaxError e = new(0);
            string s = "    :f(test)<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_112()
        {
            SyntaxError e = new(0);
            string s = "    :(test)s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_113()
        {
            SyntaxError e = new(0);
            string s = "    :(test)s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_114()
        {
            SyntaxError e = new(0);
            string s = "    :(test)<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }


        [TestMethod]
        public void TEST_218_115()
        {
            SyntaxError e = new(0);
            string s = "    :s<test>s(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_116()
        {
            SyntaxError e = new(0);
            string s = "    :s<test>(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_117()
        {
            SyntaxError e = new(0);
            string s = "    :f<test>f(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_118()
        {
            SyntaxError e = new(0);
            string s = "    :f<test>(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_119()
        {
            SyntaxError e = new(0);
            string s = "    :<test>s(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_120()
        {
            SyntaxError e = new(0);
            string s = "    :<test>s(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_121()
        {
            SyntaxError e = new(0);
            string s = "    :<test>(test)";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_122()
        {
            SyntaxError e = new(0);
            string s = "    :s<test>s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_123()
        {
            SyntaxError e = new(0);
            string s = "    :s<test><test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_124()
        {
            SyntaxError e = new(0);
            string s = "    :f<test>f<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_125()
        {
            SyntaxError e = new(0);
            string s = "    :f<test><test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(13, e.Column);
        }

        [TestMethod]
        public void TEST_218_126()
        {
            SyntaxError e = new(0);
            string s = "    :<test>s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_127()
        {
            SyntaxError e = new(0);
            string s = "    :<test>s<test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }

        [TestMethod]
        public void TEST_218_128()
        {
            SyntaxError e = new(0);
            string s = "    :<test><test>";
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
            Assert.AreEqual(218, e.Code);
            Assert.AreEqual(12, e.Column);
        }


    }
}