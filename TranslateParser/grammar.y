%token_type { Token }

%token              BINARY_AMPERSAND.
%token              BINARY_AT.
%token              BINARY_CARET.
%token              BINARY_CONCAT.
%token              BINARY_DOLLAR.
%token              BINARY_EQUAL.
%token              BINARY_HASH.
%token              BINARY_MINUS.
%token              BINARY_PERCENT.
%token              BINARY_PERIOD.
%token              BINARY_PIPE.
%token              BINARY_PLUS.
%token              BINARY_QUESTION.
%token              BINARY_SLASH.
%token              BINARY_STAR.
%token              BINARY_TILDE.
%token              COLON.
%token              COMMA.
%token              ERROR.
%token              IDENTIFIER.
%token              INTEGER.
%token              L_ANGLE.
%token              L_ANGLE_FAILURE.
%token              L_ANGLE_SUCCESS.
%token              L_PAREN.
%token              L_PAREN_FAILURE.
%token              L_PAREN_SUCCESS.
%token              L_PAREN_WS.
%token              L_SQUARE.
%token              LABEL.
%token              MATCH_DELETE.
%token              MATCH_ONLY.
%token              MATCH_REPLACE.
%token              NULL.
%token              OBJECT_DELETE.
%token              OBJECT_REPLACE.
%token              R_ANGLE.
%token              R_PAREN.
%token              R_SQUARE.
%token              REAL.
%token              SPACE.
%token              STRING.
%token              UNARY.
%token              UNARY_EQUAL.


// Low to high precedence

%right    BINARY_EQUAL.								// 0
%left     MATCH_ONLY MATCH_DELETE MATCH_REPLACE.	// 1
%left     BINARY_AMPERSAND.							// 2
%right    BINARY_PIPE.								// 3
%right    BINARY_CONCAT.							// 4
%right    BINARY_AT.								// 5
%left     BINARY_MINUS BINARY_PLUS.					// 6
%left     BINARY_HASH.								// 7
%left     BINARY_SLASH.								// 8
%left     BINARY_STAR.								// 9
%left     BINARY_PERCENT.							// 10
%right    BINARY_CARET.								// 11
%left     BINARY_PERIOD BINARY_DOLLAR.				// 12
%right    BINARY_TILDE.								// 13
  
%syntax_error { throw new syntaxError();  }

%start_symbol program_line

expression ::= expression BINARY_TILDE expression.					{Line.AddCommand("BINARY_TILDE");}
expression ::= expression BINARY_DOLLAR expression.					{Line.AddCommand("BINARY_DOLLAR");}
expression ::= expression BINARY_PERIOD expression.					{Line.AddCommand("BINARY_PERIOD");}
expression ::= expression BINARY_CARET expression.					{Line.AddCommand("BINARY_CARET");}
expression ::= expression BINARY_PERCENT expression.				{Line.AddCommand("BINARY_PERCENT");}
expression ::= expression BINARY_STAR expression.					{Line.AddCommand("BINARY_STAR");}
expression ::= expression BINARY_SLASH expression.					{Line.AddCommand("BINARY_SLASH");}
expression ::= expression BINARY_HASH expression.					{Line.AddCommand("BINARY_HASH");}
expression ::= expression BINARY_PLUS expression.				    {Line.AddCommand("BINARY_PLUS");}
expression ::= expression BINARY_MINUS expression.					{Line.AddCommand("BINARY_MINUS");}
expression ::= expression BINARY_AT expression.						{Line.AddCommand("BINARY_AT");}
expression ::= expression BINARY_CONCAT expression.					{Line.AddCommand("BINARY_CONCAT");}
expression ::= expression BINARY_PIPE expression.					{Line.AddCommand("BINARY_PIPE");}
expression ::= expression BINARY_AMPERSAND expression.				{Line.AddCommand("BINARY_AMPERSAND");}
expression ::= expression BINARY_EQUAL expression.					{Line.AddCommand("BINARY_EQUAL");}
expression ::= element.

program_line ::= statement_field goto_field.
program_line ::= statement_field.
program_line ::= goto_field.

goto_field ::= COLON unconditional_goto.
goto_field ::= COLON success_goto.
goto_field ::= COLON failure_goto.
goto_field ::= COLON success_goto failure_goto.
goto_field ::= COLON failure_goto success_goto.

unconditional_goto ::= L_PAREN expression R_PAREN.					{Line.AddCommand("UGOTO");}
unconditional_goto ::= L_ANGLE expression R_ANGLE.					{Line.AddCommand("UGOTO");}
success_goto ::= L_PAREN_SUCCESS expression R_PAREN.				{Line.AddCommand("SGOTO");}
success_goto ::= L_ANGLE_SUCCESS expression R_ANGLE.				{Line.AddCommand("SGOTO");}
failure_goto ::= L_PAREN_FAILURE expression R_PAREN.				{Line.AddCommand("FGOTO");}
failure_goto ::= L_ANGLE_FAILURE expression R_ANGLE.				{Line.AddCommand("FGOTO");}

statement_field ::= element UNARY_EQUAL.							{Line.AddCommand("UNARY_EQUAL");}
statement_field ::= element MATCH_REPLACE expression 
	OBJECT_REPLACE expression.										{Line.AddCommand("MATCH_REPLACE");}
statement_field ::= element MATCH_DELETE expression 
	OBJECT_DELETE.													{Line.AddCommand("MATCH_DELETE");}
statement_field ::= element MATCH_ONLY expression.					{Line.AddCommand("MATCH_ONLY");}
statement_field ::= expression.

element ::= INTEGER(A).												{Line.AddCommand("INTEGER",A.ToString());}
element ::= REAL(A).												{Line.AddCommand("REAL",A.ToString());}
element ::= STRING(A).												{Line.AddCommand("STRING",A.ToString());}
element ::= IDENTIFIER(A).											{Line.AddCommand("IDENTIFIER",A.ToString());}
element ::= UNARY(A) element.										{Line.AddCommand("UNARY",A.ToString());}
element ::= IDENTIFIER(A) index.									{Line.AddCommand("FUNCTION",A.ToString());}
element ::= L_PAREN arguments R_PAREN.								{Line.AddCommand("SELECTION");}
element ::= L_PAREN arguments R_PAREN index.						{Line.AddCommand("FUNCTION");}

index ::= L_PAREN func_arguments R_PAREN.							{Line.AddCommand("INDEX");}
index ::= L_ANGLE arguments R_ANGLE.								{Line.AddCommand("INDEX");}
index ::= L_SQUARE arguments R_SQUARE.								{Line.AddCommand("INDEX");}
index ::= index L_PAREN func_arguments R_PAREN.						{Line.AddCommand("INDEX");}
index ::= index L_ANGLE arguments R_ANGLE.							{Line.AddCommand("INDEX");}
index ::= index L_SQUARE arguments R_SQUARE.						{Line.AddCommand("INDEX");}

func_arguments ::= NULL.											{Line.AddCommand("ARGUMENT_NULL");}
func_arguments ::= expression.										{Line.AddCommand("ARGUMENT");}
func_arguments ::= func_arguments COMMA NULL.						{Line.AddCommand("ARGUMENT_NUll");}
func_arguments ::= func_arguments COMMA expression.					{Line.AddCommand("ARGUMENT_COMMA");}

arguments ::= expression.											{Line.AddCommand("ARGUMENT");}
arguments ::= arguments COMMA expression.							{Line.AddCommand("ARGUMENT_COMMA");}

