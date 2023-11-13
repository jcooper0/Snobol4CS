using Snobol4;

namespace TestInteractive
{
    internal class Program
    {
        static void Main()
        {
            bool debugTrace = true;

            string path = @"..\..\..\test.sbl";
            //string path = @"..\..\..\TestArgumentList.sno";
            //string path = @"..\..\..\TestNullArguments.sno";
            //string path = @"..\..\..\TestConditional.sno";
            //string path = @"..\..\..\TestArrayTable.sno";
            //string path = @"C:\Users\jcooper\Documents\Desktop\Beautiful\Beautiful.sno";
            //string path = @"..\..\..\errors.sno";
            //string path = @"..\..\..\TestMatch.sno";
            Compiler compiler = new();

            compiler.Compile(path, false);

            foreach (SourceLine sourceLine in compiler.Source.SourceLines)
            {
                if (debugTrace)
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine(sourceLine.Path + " (" + sourceLine.LineNumber + ")");
                    Console.WriteLine(sourceLine.Text);
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine("Label: " + sourceLine.LineLabel);
                    Console.WriteLine("Tokens:");
                    foreach (Token t in sourceLine.LexLine)
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
}