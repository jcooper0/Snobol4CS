using System.Text.RegularExpressions;

namespace TestCases
{
    internal class Program
    {
        static void Main()
        {
            string pattern = "string s = \"(.*)\";";
            string path = @"C:\Users\jcooper\Documents\Visual Studio 2022\Snobol4CS\TestLexer\";
            string[] files = Directory.GetFiles(path, "Test*.cs");

            foreach (string file in files)
            {
                //Console.WriteLine("* " + file);
                try
                {
                    StreamReader sr = new(file);
                    string? line = sr.ReadLine();
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                            foreach (Match match in Regex.Matches(line, pattern))
                                Console.WriteLine(match.Groups[1].Value[0] == ' ' ?
                                    " " + Regex.Unescape(match.Groups[1].Value.Trim()) :
                                    Regex.Unescape(match.Groups[1].Value));
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}