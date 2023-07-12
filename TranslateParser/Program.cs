using TranslateParser;

namespace TranslateParserCS
{

    internal class Program
    {
        private static readonly Dictionary<string, string> Defines = new();
        private static readonly Dictionary<string, string> Headers = new();
        private static readonly List<string> ParseTables = new();
        private static CReader CSourceFile;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("lemon input_file_path [output_file_path [namespace]]");
                Console.WriteLine("  The input_file_name is specified without an extension. FOr example,");
                Console.WriteLine("     if the Lemon Parser Generator created gram.out, gran.c, and gram.h, ");
                Console.WriteLine("     in directory C:\\Lemon, then the input file path should be");
                Console.WriteLine("     C:\\Lemon\\gram");
                Console.WriteLine("  The output_file_path should have extension .cs. If omitted, the default");
                Console.WriteLine("     is the input_file_pat appended with .cs");
                Console.WriteLine("  The default namespace is \"Parse\"");
                return;
            }

            AddDefaultDefines();

            CSourceFile = new CReader(args[0] + ".c");
            if (CSourceFile.Reader == null)
                return;

            string reduceActions = "";
            string syntaxErrorCode = "";
            string acceptCode = "";
            string parseFailureCode = "";

            string line;
            while ((line = CSourceFile.ReadLine()) != null)
            {
                if (line.StartsWith("/********** Begin reduce actions"))
                {
                    reduceActions = ScanReduceActions();
                }

                if (line.StartsWith("/************ Begin %syntax_error code"))
                {
                    syntaxErrorCode = ScanSyntaxErrorCode();
                }

                if (line.StartsWith("/*********** Begin %parse_accept code"))
                {
                    acceptCode = ScanAcceptCode();
                }

                if (line.StartsWith("/************ Begin %parse_failure code"))
                {
                    parseFailureCode = ScanParseFailureCode();
                }

                if ((line.Length > 1) && ((line[0] == '*' || (line[0] == '/'))))
                    continue;

                if (ScanForDefine(line))
                    continue;

                TranslateParseTables(line);
            }
            CSourceFile.Close();

            CReader? includeFile = new CReader(args[0] + ".h");
            if (includeFile.Reader == null)
                return;

            while ((line = includeFile.ReadLine()) != null)
            {
                ScanTokens(line);
            }

            includeFile.Close();

            string path = args.Length < 2 ? args[0] : args[1];
            CSharpWriter destinationFile = new(path);
            if (destinationFile.Writer == null)
                return;

            string nameSpace = args.Length < 3 ? "Parse" : args[2];

            destinationFile.WriteLine("// Machine Generated C# Parsing File\r\n");
            destinationFile.WriteLine("namespace " + nameSpace);
            destinationFile.WriteLine("{");
            destinationFile.WriteLine("\tpublic partial class Parser");
            destinationFile.WriteLine("\t{");

            destinationFile.WriteLine("\r\n\t\t    // Token Constants\r\n");
            foreach (KeyValuePair<string, string> key in Headers)
            {
                destinationFile.WriteLine(key.Value);
            }

            destinationFile.WriteLine("\r\n\t\t    // Parser Control Constants\r\n");

            foreach (KeyValuePair<string, string> key in Defines)
            {
                destinationFile.WriteLine(key.Value);
            }

            destinationFile.WriteLine("\r\n\t\t    // Parse Tables Constants");
            foreach (string table in ParseTables)
            {
                destinationFile.WriteLine(table);
            }

            destinationFile.WriteLine("\r\n\t\t    // Reduce Actions");
            destinationFile.WriteLine(reduceActions);


            destinationFile.WriteLine(syntaxErrorCode);
            destinationFile.WriteLine(acceptCode);
            destinationFile.WriteLine(parseFailureCode);

            destinationFile.WriteLine("\t}\r\n}");
            destinationFile.Close();

            Console.Write("DONE");
        }

        /// <summary>
        /// Set default C# assignments 
        /// </summary>
        internal static void AddDefaultDefines()
        {
            Defines["YYWILDCARD"] = "\t\tpublic int YYWILDCARD = 0;";
            Defines["YYFALLBACK"] = "\t\tpublic bool YYFALLBACK = false;";
            Defines["YYERRORSYMBOL"] = "\t\tpublic int YYERRORSYMBOL = -1;";
            Defines["YYNOERRORRECOVERY"] = "\t\tpublic bool YYNOERRORRECOVERY = false;";
            Defines["NDEBUG"] = "\t\tpublic bool NDEBUG = true;";
        }

        /// <summary>
        /// Scan for #DEFINE's and convert to C# assignments
        /// </summary>
        /// <param name="line">Input line from C file</param>
        /// <returns>true if a #define was found</returns>
        internal static bool ScanForDefine(string line)
        {
            if (!line.StartsWith("#define"))
                return false;

            int space2 = line.IndexOf(' ', 9);
            if (space2 > -1)
            {
                string keyword = line.Substring(8, space2 - 8);
                string definition = line.Substring(space2 + 1).Trim();

                switch (keyword)
                {
                    case "NDEBUG":
                    case "YYERRORSYMBOL":
                    case "YYFALLBACK":
                    case "YYNOERRORRECOVERY":
                    case "YYWILDCARD":
                        {
                            definition = definition.Replace("(", "").Replace(")", "");
                            if ((definition == "true") || (definition == "false"))
                                Defines[keyword] = "\t\tpublic bool " + keyword + " = " + definition + ";";
                            else
                                Defines[keyword] = "\t\tpublic int " + keyword + " = " + definition + ";";
                            break;
                        }
                    case "Parse_ENGINEALWAYSONSTACKcase":   // Not needed as C# safely handles the stack
                    case "ParseARG_FETCH":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseARG_PARAM":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseARG_PDECL":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseARG_SDECL":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseARG_STORE":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseCTX_FETCH":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseCTX_PARAM":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseCTX_PDECL":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseCTX_SDECL":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseCTX_STORE":                  // Not needed as this is handled by the YYMINOR class
                    case "ParseTOKENTYPE":                  // Unused. See YYMINORTYPE.
                    case "INTERFACE":                       // Documentation states that the function of this is unknown
                    case "TOKEN":                           // Not needed as all tokens are 32 bit signed int
                    case "YYACTIONTYPE":                    // Actions are fixed 32 bit signed int
                    case "YYCODETYPE":                      // Codes are fixed at 32 bit signed int
                    case "YYMALLOCARGTYPE":                 // Not needed as C# handles all memory
                    case "YYMINORTYPE":                     // Used as class name
                    case "YYPARSEFREENEVERNULL":            // Not needed as C# handles all memoryc
                    case "YYTRACKMAXSTACKDEPTH":            // Not needed as C# safely handles the stack
                        {
                            break;
                        }
                    default:
                        {
                            definition = definition.Replace("(", "").Replace(")", "");
                            if ((definition == "true") || (definition == "false"))
                                Defines[keyword] = "\t\tprivate readonly bool " + keyword + " = " + definition + ";";
                            else
                                Defines[keyword] = "\t\tprivate readonly int " + keyword + " = " + definition + ";";
                            break;
                        }
                }
            }
            return true;
        }

        /// <summary>
        /// Scan for Parsing Tables
        /// </summary>
        /// <param name="line">Input like</param>
        internal static void TranslateParseTables(string line)
        {
            int brackets = line.IndexOf("[]");
            if (brackets > -1)
            {
                int yy = line.IndexOf("yy");
                string tableName = line.Substring(yy, brackets - yy);
                string type;
                switch (tableName)
                {
                    case "yyRuleName":
                    case "yyTokenName":
                        {
                            type = "string";
                            break;
                        }
                    case "yyRuleInfo":
                        {
                            type = "Rule";
                            break;
                        }
                    default:
                        {
                            type = "int";
                            break;
                        }
                }
                string output = "\r\n\t\tprivate readonly " + type + "[] " + tableName + " =\r\n\t\t{";
                while (((line = CSourceFile.ReadLine()) != null) && (line != "};"))
                {
                    line = line.Replace("{", "new Rule(").Replace("}", ")");
                    output += "\r\n\t\t" + line;
                }
                output += "\n\t\t};";
                ParseTables.Add(output);
            }
        }

        /// <summary>
        /// Convert reduce actions to C#
        /// </summary>
        /// <returns>String with function to handle reduce actions</returns>
        internal static string ScanReduceActions()
        {
            string line;
            string output = "\r\n\t\tinternal YYMINORTYPE ExecuteReductions(int ruleno)\r\n\t\t{";
            output += "\r\n\t\t\tYYMINORTYPE yylhsminor = new();";
            output += "\r\n\t\t\tswitch(ruleno)\r\n\t\t\t{";

            while (((line = CSourceFile.ReadLine().Trim()) != null) && line.IndexOf("/********** End reduce actions") != 0)
            {
                if (line.Contains("yytestcase"))
                {
                    line = line[0..line.IndexOf("yytestcase")];
                }
                if (line.StartsWith("#"))
                    continue;
                if (line.StartsWith("YYMINORTYPE"))
                {
                    continue;
                }
                if (line.StartsWith("case"))
                {
                    output += "\r\n\t\t\t\t" + line.Trim();
                    continue;
                }
                if (line.StartsWith("YYMINORTYPE"))
                {
                    output += "\r\n\t\t\t\t" + line.Trim();
                    continue;
                }
                if (line.StartsWith("default"))
                {
                    output += "\r\n\t\t\t\t" + line.Trim();
                    continue;
                }
                output += "\r\n\t\t\t\t\t" + line.Trim();
            }
            output += "\r\n\t\t\t}\r\n\t\t\treturn yylhsminor;\r\n\t\t}";

            // Translate yymsp and yy0 functions to C# ParserStack references 
            output = output.Replace("yymsp", "ParserStack").Replace(".yy0", "");
            return output;
        }

        internal static string ScanSyntaxErrorCode()
        {
            string line;
            string output = "\r\n\t\tinternal void SyntaxError(int yymajor, YYMINORTYPE yyminor)\r\n\t\t{";
            while (((line = CSourceFile.ReadLine().Trim()) != null) &&
                   line.IndexOf("/************ End %syntax_error code") != 0)
            {
                output += "\r\n\t\t\t" + line.Trim();

            }
            output += "\r\n\t\t}";
            return output;
        }

        internal static string ScanAcceptCode()
        {
            string line;
            string output = "\r\n\t\tinternal void Accept()\r\n\t\t{";
            while (((line = CSourceFile.ReadLine().Trim()) != null) &&
                   line.IndexOf("/*********** End %parse_accept code") != 0)
            {
                output += "\r\n\t\t\t" + line.Trim();
            }
            output += "\r\n\t\t}";
            return output;
        }

        internal static string ScanParseFailureCode()
        {
            string line;
            string output = "\r\n\t\tinternal void ParseFailed()\r\n\t\t{";
            while (((line = CSourceFile.ReadLine().Trim()) != null) &&
                   line.IndexOf("/************ End %parse_failure code") != 0)
            {
                output += "\r\n\t\t\t" + line.Trim();
            }
            output += "\r\n\t\t}";
            return output;
        }

        /// <summary>
        /// Convert header #define to C# assignment 
        /// </summary>
        /// <param name="line">input line</param>
        internal static void ScanTokens(string line)
        {
            int space2 = line.IndexOf(' ', 9);
            if (space2 > -1)
            {
                string keyword = line.Substring(8, space2 - 8);
                string definition = line.Substring(space2 + 1).Trim();

                Headers[keyword] = "\t\tpublic readonly int " + keyword + " = " + definition + ";";
            }
        }
    }
}