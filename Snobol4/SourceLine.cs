namespace Snobol4;

public class SourceLine
{
    public string Path
    {
        get;
    }

    public int LineNumber
    {
        get;
    }

    public string Text
    {
        get;
    }

    public List<Token> LexLine = new();
    public bool Error { get; set; } = false;
    public string ErrorDescription { get; set; } = "";
    public List<Command> Commands { get; set; } = new();
    public string LineLabel { get; set; } = string.Empty;

    public SourceLine(string path, int lineNumber, string text)
    {
        Path = path;
        LineNumber = lineNumber;
        Text = text.TrimEnd();
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