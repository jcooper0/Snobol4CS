namespace Snobol4;

public class Command
{
    public string Operation
    {
        get; set;
    }

    public string Operand
    {
        get; set;
    }

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