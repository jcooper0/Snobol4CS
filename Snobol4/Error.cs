using System.Data;

namespace Snobol4
{
    public class SyntaxError : ApplicationException
    {

        public string Description { get; set; } = "";

        public SyntaxError(ErrorType errorType, int column, SourceLine source) : base()
        {
            Description = "Error: " + ErrorMessage[(int)errorType] + "\n" + " File: " + 
                source.Path + " (" + source.SourceLineNumber + ")\n" + 
                source.SourceLineText.Replace('\t',' ') + 
                "\n" + new string(' ', column) + "^\n";
        }

        public SyntaxError() : base()
        {
        }

        public enum ErrorType
        {
            NO_ERROR = 0,

            //This error indicates an erroneous binary operator or a missing blank between
            //expressions. Some examples are:
            //  X = F(X)*** 2
            //  TEXT = '('TEXT ')'
            //  M = (A B)N
            BINARY_OPERATOR_MISSING_OR_IN_ERROR = 1,

            //This error occurs if an integer literal in a statement exceeds the
            //magnitude of the largest possible 64 bit integer. 
            ERRONEOUS_INTEGER = 2,

            //This error occurs if the first character of a statement is not a
            //blank, integer, letter, * , or - .
            ERRONEOUS_LABEL = 3,

            //This error occurs if a break character appears in an erroneous context, 
            //or if a nested expression is not closed. Some examples are:
            //  X = (A<B)
            //  A<1,2) =5
            //  F(G(X)     :S(LOOP)
            ERRONEOUS_OR_MISSING_BREAK_CHARACTER = 4,

            //This error occurs if a real literal that is too large or too
            //small appears in a statement.
            ERRONEOUS_REAL_NUMBER = 5,

            //This error occurs if an erroneous construction appears in the
            //subject field. An example is:
            //   , = 2
            ERRONEOUS_SUBJECT = 6,

            //This error occurs when a syntactic error is found in the goto field.
            //Some typical errors are:
            //   :S(L1)S(L2)
            //   :S(A1)  F(A2)
            //   :<CODE)
            ERROR_IN_GOTO = 7,

            //This error typically occurs when blanks are not
            //provided where required. Some examples are:
            //   X = 3:
            //   E = 3.5P
            ILLEGAL_CHARACTER_IN_ELEMENT = 8,

            //his error occurs when a statement
            //terminates before a construction is complete. An example is:
            //   N = M +
            IMPROPERLY_TERMINATED_STATEMENT = 9,

            //This error occurs when a duplicate label is encountered.
            //The first occurrence of a label holds, and subsequent occurrences are
            //erroneous.
            PREVIOUSLY_DEFINED_LABEL = 10,

            //This error occurs when a closing quotation mark is omitted.
            //Examples are:
            //   LETTER = 'A
            //   TEXT = 'HE YELLED STOP"
            UNCLOSED_LITERAL = 11,

            // Catch all
            UNEXPECTED_CHARACTER = 12
        }

        public static readonly string[] ErrorMessage =
        {
            (int)ErrorType.NO_ERROR + ". No Error",
            (int)ErrorType.BINARY_OPERATOR_MISSING_OR_IN_ERROR + ". Binary Operator Missing Or In Error",
            (int)ErrorType.ERRONEOUS_INTEGER + ". Erroneous Integer",
            (int)ErrorType.ERRONEOUS_LABEL + ". Erroneous Label",
            (int)ErrorType.ERRONEOUS_OR_MISSING_BREAK_CHARACTER + ". Erroneous Or Missing Break Character",
            (int)ErrorType.ERRONEOUS_REAL_NUMBER + ". Erroneous Real Number",
            (int)ErrorType.ERRONEOUS_SUBJECT + ". Erroneous Subject",
            (int)ErrorType.ERROR_IN_GOTO + ". Error In Goto",
            (int)ErrorType.ILLEGAL_CHARACTER_IN_ELEMENT + ". Illegal Character In Element",
            (int)ErrorType.IMPROPERLY_TERMINATED_STATEMENT + ". Improperly_Terminated StatemenT",
            (int)ErrorType.PREVIOUSLY_DEFINED_LABEL + ". Previously Defined Label",
            (int)ErrorType.UNCLOSED_LITERAL + ". Unclosed Literal",
            (int)ErrorType.UNEXPECTED_CHARACTER + ". Unexpected Character"
        };

    }


}
