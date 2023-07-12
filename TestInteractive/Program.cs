using Snobol4;

namespace TestInteractive
{
    internal class Program
    {
        public Compiler Compile { get; set; }

        static void Main(string[] args)
        {
            string path = @"..\..\..\test.sno";
            
            Compiler Compile = new Compiler();
            
            Compile.Compile(path);

            foreach (SourceLine sourceLine in Compile.Source.SourceLines)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(sourceLine.Path + " (" + sourceLine.SourceLineNumber + ")");
                Console.WriteLine(sourceLine.SourceLineText);
                Console.WriteLine("----------------------------------------------------------------------");
                if (sourceLine.Error)
                {
                    Console.Write(sourceLine.ErrorDescription);
                    continue;
                }
                foreach (Token t in sourceLine.LexResult)
                {
                    Console.WriteLine(t.ToString());
                }
                Console.WriteLine("");

                foreach (Command command in sourceLine.Commands)
                {
                    Console.WriteLine(command.ToString());
                }
                Console.WriteLine("");

                Console.ReadKey();
            }
        }
    }
}