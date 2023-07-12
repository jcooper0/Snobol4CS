%token_type { Token }

%token              BINARY_AMPERSAND.
%token              BINARY_AT.
%token              BINARY_CARET.
%token              BINARY_DOLLAR.
%token              BINARY_DOUBLE_STAR.
%token              BINARY_EQUAL.
%token              BINARY_EXCLAMATION.
%token              BINARY_HASH.
%token              BINARY_MINUS.
%token              BINARY_PERCENT.
%token              BINARY_PERIOD.
%token              BINARY_PIPE.
%token              BINARY_PLUS.
%token              BINARY_QUESTION.
%token              BINARY_SLASH.
%token              BINARY_SPACE.
%token              BINARY_STAR.
%token              BINARY_TILDE.
%token              COLON.
%token              COMMA.
%token              ERROR.
%token              F.
%token              IDENTIFIER.
%token              INTEGER.
%token              LABEL.
%token              LEFT_ANGLE_BRACKET.
%token              LEFT_PAREN.
%token              LEFT_SQUARE_BRACKET.
%token              MATCH_DELETE.
%token              MATCH_ONLY.
%token              MATCH_REPLACE.
%token              NO_LABEL.
%token              NULL.
%token              OBJECT_DELETE.
%token              OBJECT_REPLACE.
%token              REAL.
%token              RIGHT_ANGLE_BRACKET.
%token              RIGHT_PAREN.
%token              RIGHT_SQUARE_BRACKET.
%token              S.
%token              SPACE.
%token              STRING.
%token              UNARY_AMPERSAND.
%token              UNARY_AT.
%token              UNARY_CARET.
%token              UNARY_DOLLAR.
%token              UNARY_EQUAL.
%token              UNARY_EXCLAMATION.
%token              UNARY_HASH.
%token              UNARY_MINUS.
%token              UNARY_PERCENT.
%token              UNARY_PERIOD.
%token              UNARY_PIPE.
%token              UNARY_PLUS.
%token              UNARY_QUESTION.
%token              UNARY_SLASH.
%token              UNARY_STAR.
%token              UNARY_TILDE.

// Low to high precedence

%nonassoc MATCH_ONLY MATCH_DELETE MATCH_REPLACE.
%right BINARY_EQUAL.
%left BINARY_AMPERSAND.
%left BINARY_PIPE.
%left BINARY_SPACE.
%left BINARY_AT.
%left BINARY_MINUS BINARY_PLUS.
%left BINARY_HASH.
%left BINARY_SLASH.
%left BINARY_STAR.
%left BINARY_PERCENT.
%right BINARY_CARET BINARY_EXCLAMATION BINARY_DOUBLE_STAR.
%left BINARY_PERIOD BINARY_DOLLAR.
%left BINARY_QUESTION.
%right BINARY_TILDE.

%syntax_error { throw new SyntaxError();  }

%start_symbol program_line

program_line ::= label_field statement_field.
program_line ::= label_field statement_field goto_field.

label_field ::= LABEL.
label_field ::= NO_LABEL.

goto_field ::= COLON goto.
goto_field ::= COLON goto_success.
goto_field ::= COLON goto_failure.
goto_field ::= COLON goto_failure goto_success.
goto_field ::= COLON goto_success goto_failure.

statement_field ::= element UNARY_EQUAL.							{Line.AddCommand("UNARY_EQUAL");}
statement_field ::= element MATCH_REPLACE expression 
	OBJECT_REPLACE expression.										{Line.AddCommand("MATCH_REPLACE");}
statement_field ::= element MATCH_DELETE expression OBJECT_DELETE.	{Line.AddCommand("MATCH_DELETE");}
statement_field ::= element MATCH_ONLY expression.					{Line.AddCommand("MATCH_ONLY");}
statement_field ::= expression.

expression ::= element.
expression ::= element reference.							{Line.AddCommand("REFERENCE");}
expression ::= element BINARY_EQUAL expression.				{Line.AddCommand("BINARY_EQUAL");}
expression ::= expression BINARY_TILDE expression.          {Line.AddCommand("BINARY_TILDE");}
expression ::= expression BINARY_QUESTION expression.       {Line.AddCommand("BINARY_QUESTION");}
expression ::= expression BINARY_DOLLAR expression.         {Line.AddCommand("BINARY_DOLLAR");}
expression ::= expression BINARY_PERIOD expression.         {Line.AddCommand("BINARY_PERIOD");}
expression ::= expression BINARY_CARET expression.          {Line.AddCommand("BINARY_CARET");}
expression ::= expression BINARY_EXCLAMATION expression.    {Line.AddCommand("BINARY_EXCLAMATION");}
expression ::= expression BINARY_DOUBLE_STAR expression.    {Line.AddCommand("BINARY_DOUBLE_STAR");}
expression ::= expression BINARY_PERCENT expression.        {Line.AddCommand("BINARY_PERCENT");}
expression ::= expression BINARY_STAR expression.           {Line.AddCommand("BINARY_STAR");}
expression ::= expression BINARY_SLASH expression.          {Line.AddCommand("BINARY_SLASH");}
expression ::= expression BINARY_HASH expression.           {Line.AddCommand("BINARY_HASH");}
expression ::= expression BINARY_PLUS expression.           {Line.AddCommand("BINARY_PLUS");}
expression ::= expression BINARY_MINUS expression.          {Line.AddCommand("BINARY_MINUS");}
expression ::= expression BINARY_AT expression.             {Line.AddCommand("BINARY_AT");}
expression ::= expression BINARY_SPACE expression.          {Line.AddCommand("BINARY_SPACE");}
expression ::= expression BINARY_PIPE expression.           {Line.AddCommand("BINARY_PIPE");}
expression ::= expression BINARY_AMPERSAND expression.      {Line.AddCommand("BINARY_AMPERSAND");}

element ::= IDENTIFIER(A).										{Line.AddCommand("IDENTIFIER",A.ToString());}
element ::= F(A).												{Line.AddCommand("IDENTIFIER",A.ToString());}
element ::= S(A).												{Line.AddCommand("IDENTIFIER",A.ToString());}
element ::= INTEGER(A).											{Line.AddCommand("INTEGER",A.ToString());}
element ::= REAL(A).											{Line.AddCommand("REAL",A.ToString());}
element ::= STRING(A).											{Line.AddCommand("STRING",A.ToString());}
element ::= IDENTIFIER(A) LEFT_PAREN RIGHT_PAREN.				{Line.AddCommand("FUNCTION",A.ToString());}
element ::= IDENTIFIER(A) LEFT_PAREN argument_list RIGHT_PAREN.	{Line.AddCommand("FUNCTION",A.ToString());}

element ::= LEFT_PAREN expression RIGHT_PAREN.
element ::= UNARY_AMPERSAND element.					{Line.AddCommand("UNARY_AMPERSAND");}
element ::= UNARY_AT element.							{Line.AddCommand("UNARY_AT");}
element ::= UNARY_CARET element.						{Line.AddCommand("UNARY_CARET");}
element ::= UNARY_DOLLAR element.						{Line.AddCommand("UNARY_DOLLAR");}
element ::= UNARY_EXCLAMATION element.					{Line.AddCommand("UNARY_EXCLAMATION");}
element ::= UNARY_HASH element.							{Line.AddCommand("UNARY_HASH");}
element ::= UNARY_MINUS element.						{Line.AddCommand("UNARY_MINUS");}
element ::= UNARY_PERCENT element.						{Line.AddCommand("UNARY_PERCENT");}
element ::= UNARY_PERIOD element.						{Line.AddCommand("UNARY_PERIOD");}
element ::= UNARY_PIPE element.							{Line.AddCommand("UNARY_PIPE");}
element ::= UNARY_PLUS element.							{Line.AddCommand("UNARY_PLUS");}
element ::= UNARY_QUESTION element.						{Line.AddCommand("UNARY_QUESTION");}
element ::= UNARY_SLASH element.						{Line.AddCommand("UNARY_SLASH");}
element ::= UNARY_STAR element.							{Line.AddCommand("UNARY_STAR");}
element ::= UNARY_TILDE element.						{Line.AddCommand("UNARY_TILDE");}

reference ::= LEFT_SQUARE_BRACKET argument_list RIGHT_SQUARE_BRACKET.
reference ::= LEFT_ANGLE_BRACKET argument_list RIGHT_ANGLE_BRACKET.
reference ::= reference LEFT_SQUARE_BRACKET argument_list RIGHT_SQUARE_BRACKET.
reference ::= reference LEFT_ANGLE_BRACKET argument_list RIGHT_ANGLE_BRACKET.

argument_list ::= expression.								
argument_list ::= argument_list COMMA expression.

goto ::= LEFT_PAREN expression RIGHT_PAREN.					{Line.AddCommand("GOTO");}
goto_failure ::= F LEFT_PAREN expression RIGHT_PAREN.		{Line.AddCommand("FGOTO");}
goto_success ::= S LEFT_PAREN expression RIGHT_PAREN.		{Line.AddCommand("SGOTO");}

