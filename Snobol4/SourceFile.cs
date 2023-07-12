using System.Text.RegularExpressions;

namespace Snobol4
{
    public class SourceLine
    {
        public string Path { get; } = "";
        public int SourceLineNumber { get; } = 0;
        public string SourceLineText { get; } = "";
        public List<Token> LexResult = new();
        public bool Error { get; set; } = false;
        public string ErrorDescription { get; set; } = "";
        public List<Command> Commands { get; set; } = new();

        public SourceLine(string path, int sourceLineNumber, string sourceLineText)
        {
            Path = path;
            SourceLineNumber = sourceLineNumber;
            SourceLineText = sourceLineText;
        }

        public void AddCommand(string operation, string operand)
        {
            Commands.Add(new Command(operation, operand));
        }

        public void AddCommand(string operation)
        {
            Commands.Add(new Command(operation, ""));
        }
    }

    public class Command
    {
        public string Operation { get; set; } = "";
        public string Operand { get; set; } = "";

        public Command(string operation, string operand)
        {
            Operation = operation;
            Operand = operand;
        }

        public override string ToString()
        {
            return Operation + new string(' ', 30 - Operation.Length) + Operand;
        }
    }

    public class SourceFile
    {
        public string Path = "";
        public List<string> PathList = new();
        public List<SourceLine> SourceLines = new();

        internal int CurrentLineCount;
        internal int CurrentPathIndex;
        internal string CurrentLine = "";
        internal StreamReader CurrentStream = null!;
        internal readonly Stack<StreamReader> StreamStack = new();
        internal readonly Stack<int> LineCountStack = new();
        internal readonly Stack<int> PathIndexStack = new();
        internal static readonly string Bell = new(new[] { (char)7 });
        internal bool List = true;

        internal static IEnumerable<string> SplitLineBySemicolons(string line)
        {
            Regex r = new(@";(?=([^\""\']*[\""'][^\""\']*[\""\'])*[^\""\']*$)");
            return r.Replace(line, Bell).Split(Bell);
        }

        internal bool Open(string path)
        {
            Path = path;
            PathList.Add(Path);

            CurrentPathIndex = PathList.Count - 1;
            CurrentLineCount = 0;

            try
            {
                CurrentStream = new StreamReader(Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open '" + Path + "' " + ex.Message + " " + ex.Source);
                return false;
            }

            return true;
        }

        internal bool ReadLine()
        {
            try
            {
                CurrentLine = CurrentStream.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot read from '" + Path + "' " + ex.Message + " " + ex.Source);
                return false;
            }

            CurrentLineCount++;
            return true;
        }

        internal bool SwitchToParentOfIncludeFile()
        {
            CurrentStream.Close();
            if (StreamStack.Count == 0)
                return true;
            CurrentStream = StreamStack.Pop();
            CurrentLineCount = LineCountStack.Pop();
            CurrentPathIndex = PathIndexStack.Pop();
            return false;
        }

        internal bool SwitchToIncludeFile(string subLine)
        {
            // Read in include file
            string include = subLine.Replace('\'', '\"');
            Regex r = new(@""".+\""");
            string includeFile = r.Match(include).Value.Replace("\"", "");
            StreamStack.Push(CurrentStream);
            LineCountStack.Push(CurrentLineCount);
            PathIndexStack.Push(CurrentPathIndex);

            FileInfo fileInfo = new(Path);
            if (fileInfo.Directory != null)
                includeFile = fileInfo.Directory.FullName + "\\" + includeFile;

            return !Open(includeFile);
        }

        internal bool AppendContinuationLines()
        {
            string line = CurrentLine;
            while (CurrentStream.Peek() == '.' || CurrentStream.Peek() == '+')
            {
                if (!ReadLine())
                    return true;

                line += CurrentLine[1..];
            }
            CurrentLine = line;
            return false;
        }

        internal bool ReadSourceLines()
        {
            while (ReadLine())
            {
                if (CurrentLine == null)
                {
                    if (SwitchToParentOfIncludeFile())
                        return true; // If there is no parent return
                    continue;
                }

                if (List)
                    Console.WriteLine(CurrentLineCount.ToString("D4") + " " + CurrentLine);

                if (AppendContinuationLines())
                    return true;

                IEnumerable<string> subLines = SplitLineBySemicolons(CurrentLine);

                foreach (string subLine in subLines)
                {
                    if (subLine.Trim() == "")
                        continue; // Skip white space;

                    if (subLine[0] == '*')
                        continue; // Skip comments

                    if (subLine.StartsWith("-INCLUDE"))
                    {
                        if (subLine.Contains("INCLUDE"))
                        {
                            if (SwitchToIncludeFile(subLine))
                                return false;
                            continue;
                        }

                        if (subLine.Contains("UNLIST"))
                        {
                            List = false;
                            continue;
                        }

                        if (subLine.Contains("LIST"))
                        {
                            List = true;
                            continue;
                        }
                    }

                    SourceLines.Add(new SourceLine(Path, CurrentLineCount, subLine));
                }
            }
            return true;
        }

        public bool ReadSourceToList(string path)
        {
            return Open(path) && ReadSourceLines();
        }
    }
}
