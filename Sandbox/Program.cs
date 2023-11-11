using System.Text.RegularExpressions;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                string input = Console.ReadLine();
                Regex r = new("^test");

                Match m = r.Match(input, 4);

                Console.WriteLine(m.Value);
            }

        }
    }
}