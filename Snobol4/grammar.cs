// Machine Generated C# Parsing File

namespace Snobol4;

public partial class Parser
{

    // Token Constants

    public readonly int BINARY_AMPERSAND = 1;
    public readonly int BINARY_AT = 2;
    public readonly int BINARY_CARET = 3;
    public readonly int BINARY_CONCAT = 4;
    public readonly int BINARY_DOLLAR = 5;
    public readonly int BINARY_EQUAL = 6;
    public readonly int BINARY_HASH = 7;
    public readonly int BINARY_MINUS = 8;
    public readonly int BINARY_PERCENT = 9;
    public readonly int BINARY_PERIOD = 10;
    public readonly int BINARY_PIPE = 11;
    public readonly int BINARY_PLUS = 12;
    public readonly int BINARY_QUESTION = 13;
    public readonly int BINARY_SLASH = 14;
    public readonly int BINARY_STAR = 15;
    public readonly int BINARY_TILDE = 16;
    public readonly int COLON = 17;
    public readonly int COMMA = 18;
    public readonly int ERROR = 19;
    public readonly int IDENTIFIER = 20;
    public readonly int INTEGER = 21;
    public readonly int L_ANGLE = 22;
    public readonly int L_ANGLE_FAILURE = 23;
    public readonly int L_ANGLE_SUCCESS = 24;
    public readonly int L_PAREN = 25;
    public readonly int L_PAREN_FAILURE = 26;
    public readonly int L_PAREN_SUCCESS = 27;
    public readonly int L_PAREN_WS = 28;
    public readonly int L_SQUARE = 29;
    public readonly int LABEL = 30;
    public readonly int MATCH_DELETE = 31;
    public readonly int MATCH_ONLY = 32;
    public readonly int MATCH_REPLACE = 33;
    public readonly int NULL = 34;
    public readonly int OBJECT_DELETE = 35;
    public readonly int OBJECT_REPLACE = 36;
    public readonly int R_ANGLE = 37;
    public readonly int R_PAREN = 38;
    public readonly int R_SQUARE = 39;
    public readonly int REAL = 40;
    public readonly int SPACE = 41;
    public readonly int STRING = 42;
    public readonly int UNARY = 43;
    public readonly int UNARY_EQUAL = 44;

    // Parser Control Constants

    public int YYWILDCARD = 0;
    public bool YYFALLBACK = false;
    public int YYERRORSYMBOL = -1;
    public bool YYNOERRORRECOVERY = false;
    public bool NDEBUG = true;
    private readonly int YYNOCODE = 56;
    private readonly int YYSTACKDEPTH = 100;
    private readonly int YYNSTATE = 84;
    private readonly int YYNRULE = 55;
    private readonly int YYNTOKEN = 45;
    private readonly int YY_MAX_SHIFT = 83;
    private readonly int YY_MIN_SHIFTREDUCE = 108;
    private readonly int YY_MAX_SHIFTREDUCE = 162;
    private readonly int YY_ERROR_ACTION = 163;
    private readonly int YY_ACCEPT_ACTION = 164;
    private readonly int YY_NO_ACTION = 165;
    private readonly int YY_MIN_REDUCE = 166;
    private readonly int YY_MAX_REDUCE = 220;
    private readonly int YY_ACTTAB_COUNT = 408;
    private readonly int YY_SHIFT_COUNT = 83;
    private readonly int YY_SHIFT_MIN = 0;
    private readonly int YY_SHIFT_MAX = 369;
    private readonly int YY_REDUCE_COUNT = 41;
    private readonly int YY_REDUCE_MIN = -46;
    private readonly int YY_REDUCE_MAX = 337;

    // Parse Tables Constants

    private readonly int[] yy_action =
    {
        /*     0 */   195,   22,   25,   32,   24,   34,   21,   28,   26,   31,
        /*    10 */    33,   23,   27,   70,   29,   30,   35,   22,   25,   32,
        /*    20 */    24,   34,   21,   28,   26,   31,   33,   23,   27,   71,
        /*    30 */    29,   30,   35,   25,   32,   24,   34,  124,   28,   26,
        /*    40 */    31,   33,   23,   27,  219,   29,   30,   35,   10,   14,
        /*    50 */    12,   11,   15,   13,  123,  218,   22,   25,   32,   24,
        /*    60 */    34,   21,   28,   26,   31,   33,   23,   27,   80,   29,
        /*    70 */    30,   35,   22,   25,   32,   24,   34,   21,   28,   26,
        /*    80 */    31,   33,   23,   27,  214,   29,   30,   35,   25,   32,
        /*    90 */    24,   34,  126,   28,   26,   31,   33,  212,   27,   35,
        /*   100 */    29,   30,   35,   57,   67,  164,   41,   79,  165,  125,
        /*   110 */   165,   22,   25,   32,   24,   34,   21,   28,   26,   31,
        /*   120 */    33,   23,   27,  165,   29,   30,   35,   22,   25,   32,
        /*   130 */    24,   34,   21,   28,   26,   31,   33,   23,   27,  165,
        /*   140 */    29,   30,   35,   25,   32,  165,   34,  128,   28,   26,
        /*   150 */    31,   33,   32,   27,   34,   29,   30,   35,   31,   33,
        /*   160 */    52,   52,   42,   42,  127,   35,   22,   25,   32,   24,
        /*   170 */    34,   21,   28,   26,   31,   33,   23,   27,    9,   29,
        /*   180 */    30,   35,   22,   25,   32,   24,   34,   21,   28,   26,
        /*   190 */    31,   33,   23,   27,  165,   29,   30,   35,  144,   32,
        /*   200 */   131,   34,  165,   28,  165,   31,   33,  215,   40,   39,
        /*   210 */    29,   30,   35,   43,   43,   44,   44,   18,  165,   22,
        /*   220 */    25,   32,   24,   34,   21,   28,   26,   31,   33,   23,
        /*   230 */    27,  165,   29,   30,   35,  165,   32,    3,   34,   12,
        /*   240 */    38,  133,   13,   33,   32,    8,   34,   38,  133,   35,
        /*   250 */    31,   33,    8,  165,   38,  133,   30,   35,  165,    8,
        /*   260 */   134,  147,  135,   36,  165,  165,  165,  134,  149,  135,
        /*   270 */    36,   55,   55,   32,  134,   34,  135,   36,   20,   31,
        /*   280 */    33,   75,   38,  133,   29,   30,   35,    8,   17,   16,
        /*   290 */    19,   54,   54,   55,   55,   45,   45,   54,   54,  143,
        /*   300 */    73,  129,  134,   72,  135,   36,   74,   14,   54,   54,
        /*   310 */    15,  165,  165,   54,   54,  165,  165,   76,   54,   54,
        /*   320 */   165,    5,   77,    7,    1,   20,    2,   78,    4,  165,
        /*   330 */     6,   46,   46,   47,   47,   50,   50,   48,   48,   51,
        /*   340 */    51,   49,   49,   53,   53,  213,  146,   56,   56,   58,
        /*   350 */    58,   59,   59,  165,   60,   60,  165,  165,  165,   61,
        /*   360 */    61,  165,    3,   62,   62,   63,   63,   64,   64,   65,
        /*   370 */    65,   20,   66,   66,   68,   68,   69,   69,   81,   81,
        /*   380 */    82,   82,   83,   83,    9,  165,   20,   20,  165,  165,
        /*   390 */   142,  165,  165,  165,  165,  165,  165,  165,  165,  165,
        /*   400 */   165,  165,  165,  165,  141,  145,  165,   37,
    };

    private readonly int[] yy_lookahead =
    {
        /*     0 */    46,    1,    2,    3,    4,    5,    6,    7,    8,    9,
        /*    10 */    10,   11,   12,   53,   14,   15,   16,    1,    2,    3,
        /*    20 */     4,    5,    6,    7,    8,    9,   10,   11,   12,   53,
        /*    30 */    14,   15,   16,    2,    3,    4,    5,   37,    7,    8,
        /*    40 */     9,   10,   11,   12,   51,   14,   15,   16,   22,   23,
        /*    50 */    24,   25,   26,   27,   38,   52,    1,    2,    3,    4,
        /*    60 */     5,    6,    7,    8,    9,   10,   11,   12,   49,   14,
        /*    70 */    15,   16,    1,    2,    3,    4,    5,    6,    7,    8,
        /*    80 */     9,   10,   11,   12,    0,   14,   15,   16,    2,    3,
        /*    90 */     4,    5,   37,    7,    8,    9,   10,    0,   12,   16,
        /*   100 */    14,   15,   16,   45,   46,   47,   48,   49,   56,   38,
        /*   110 */    56,    1,    2,    3,    4,    5,    6,    7,    8,    9,
        /*   120 */    10,   11,   12,   56,   14,   15,   16,    1,    2,    3,
        /*   130 */     4,    5,    6,    7,    8,    9,   10,   11,   12,   56,
        /*   140 */    14,   15,   16,    2,    3,   56,    5,   37,    7,    8,
        /*   150 */     9,   10,    3,   12,    5,   14,   15,   16,    9,   10,
        /*   160 */    45,   46,   45,   46,   38,   16,    1,    2,    3,    4,
        /*   170 */     5,    6,    7,    8,    9,   10,   11,   12,   18,   14,
        /*   180 */    15,   16,    1,    2,    3,    4,    5,    6,    7,    8,
        /*   190 */     9,   10,   11,   12,   56,   14,   15,   16,   38,    3,
        /*   200 */    35,    5,   56,    7,   56,    9,   10,   50,   51,   52,
        /*   210 */    14,   15,   16,   45,   46,   45,   46,   36,   56,    1,
        /*   220 */     2,    3,    4,    5,    6,    7,    8,    9,   10,   11,
        /*   230 */    12,   56,   14,   15,   16,   56,    3,   17,    5,   24,
        /*   240 */    20,   21,   27,   10,    3,   25,    5,   20,   21,   16,
        /*   250 */     9,   10,   25,   56,   20,   21,   15,   16,   56,   25,
        /*   260 */    40,   34,   42,   43,   56,   56,   56,   40,   34,   42,
        /*   270 */    43,   45,   46,    3,   40,    5,   42,   43,   18,    9,
        /*   280 */    10,   55,   20,   21,   14,   15,   16,   25,   31,   32,
        /*   290 */    33,   45,   46,   45,   46,   45,   46,   45,   46,   39,
        /*   300 */    54,   44,   40,   55,   42,   43,   54,   23,   45,   46,
        /*   310 */    26,   56,   56,   45,   46,   56,   56,   54,   45,   46,
        /*   320 */    56,   22,   54,   22,   25,   18,   25,   54,   29,   56,
        /*   330 */    29,   45,   46,   45,   46,   45,   46,   45,   46,   45,
        /*   340 */    46,   45,   46,   45,   46,    0,   39,   45,   46,   45,
        /*   350 */    46,   45,   46,   56,   45,   46,   56,   56,   56,   45,
        /*   360 */    46,   56,   17,   45,   46,   45,   46,   45,   46,   45,
        /*   370 */    46,   18,   45,   46,   45,   46,   45,   46,   45,   46,
        /*   380 */    45,   46,   45,   46,   18,   56,   18,   18,   56,   56,
        /*   390 */    37,   56,   56,   56,   56,   56,   56,   56,   56,   56,
        /*   400 */    56,   56,   56,   56,   38,   37,   56,   38,   56,   56,
        /*   410 */    56,   56,   56,   56,   56,   56,   56,   56,   56,   56,
        /*   420 */    56,   56,   56,   56,   56,   56,   56,   56,   56,   56,
        /*   430 */    56,   56,   56,
    };

    private readonly int[] yy_shift_ofst =
    {
        /*     0 */   220,  227,  227,   26,  262,  262,  262,  262,  262,  234,
        /*    10 */   262,  262,  262,  262,  262,  262,  262,  262,  262,  262,
        /*    20 */   262,  262,  262,  262,  262,  262,  262,  262,  262,  262,
        /*    30 */   262,  262,  262,  262,  262,  262,  262,  299,  299,  215,
        /*    40 */   284,  345,    0,   16,   55,   71,  110,  126,  165,  181,
        /*    50 */   218,  218,  218,  218,  218,  218,  218,  218,   31,   31,
        /*    60 */    86,  141,  196,  196,  270,  241,  149,  257,  233,  233,
        /*    70 */   301,  301,  160,  260,  353,  366,  307,  368,  369,   84,
        /*    80 */    97,   83,   83,   83,
    };

    private readonly int[] yy_reduce_ofst =
    {
        /*     0 */    58,  226,  248,  157,  246,  252,  263,  268,  273,  115,
        /*    10 */   117,  168,  170,  250,  286,  288,  290,  292,  294,  296,
        /*    20 */   298,  302,  304,  306,  309,  314,  318,  320,  322,  324,
        /*    30 */   327,  329,  331,  333,  335,  337,  -46,  -40,  -24,   -7,
        /*    40 */     3,   19,
    };

    private readonly int[] yy_default =
    {
        /*     0 */   163,  163,  163,  163,  163,  163,  163,  163,  163,  163,
        /*    10 */   163,  163,  163,  163,  163,  163,  163,  163,  163,  163,
        /*    20 */   163,  163,  163,  163,  163,  163,  163,  163,  163,  163,
        /*    30 */   163,  163,  163,  163,  163,  163,  163,  197,  194,  217,
        /*    40 */   216,  163,  163,  163,  163,  163,  163,  163,  163,  163,
        /*    50 */   190,  188,  208,  210,  209,  206,  180,  220,  179,  178,
        /*    60 */   177,  176,  175,  174,  173,  172,  171,  211,  170,  169,
        /*    70 */   198,  196,  163,  163,  163,  163,  163,  163,  163,  163,
        /*    80 */   163,  168,  167,  166,
    };

    private readonly int[] yyFallback =
    {
    };

    private readonly string[] yyTokenName =
    {
        /*    0 */ "$",
        /*    1 */ "BINARY_AMPERSAND",
        /*    2 */ "BINARY_AT",
        /*    3 */ "BINARY_CARET",
        /*    4 */ "BINARY_CONCAT",
        /*    5 */ "BINARY_DOLLAR",
        /*    6 */ "BINARY_EQUAL",
        /*    7 */ "BINARY_HASH",
        /*    8 */ "BINARY_MINUS",
        /*    9 */ "BINARY_PERCENT",
        /*   10 */ "BINARY_PERIOD",
        /*   11 */ "BINARY_PIPE",
        /*   12 */ "BINARY_PLUS",
        /*   13 */ "BINARY_QUESTION",
        /*   14 */ "BINARY_SLASH",
        /*   15 */ "BINARY_STAR",
        /*   16 */ "BINARY_TILDE",
        /*   17 */ "COLON",
        /*   18 */ "COMMA",
        /*   19 */ "ERROR",
        /*   20 */ "IDENTIFIER",
        /*   21 */ "INTEGER",
        /*   22 */ "L_ANGLE",
        /*   23 */ "L_ANGLE_FAILURE",
        /*   24 */ "L_ANGLE_SUCCESS",
        /*   25 */ "L_PAREN",
        /*   26 */ "L_PAREN_FAILURE",
        /*   27 */ "L_PAREN_SUCCESS",
        /*   28 */ "L_PAREN_WS",
        /*   29 */ "L_SQUARE",
        /*   30 */ "LABEL",
        /*   31 */ "MATCH_DELETE",
        /*   32 */ "MATCH_ONLY",
        /*   33 */ "MATCH_REPLACE",
        /*   34 */ "NULL",
        /*   35 */ "OBJECT_DELETE",
        /*   36 */ "OBJECT_REPLACE",
        /*   37 */ "R_ANGLE",
        /*   38 */ "R_PAREN",
        /*   39 */ "R_SQUARE",
        /*   40 */ "REAL",
        /*   41 */ "SPACE",
        /*   42 */ "STRING",
        /*   43 */ "UNARY",
        /*   44 */ "UNARY_EQUAL",
        /*   45 */ "expression",
        /*   46 */ "element",
        /*   47 */ "program_line",
        /*   48 */ "statement_field",
        /*   49 */ "goto_field",
        /*   50 */ "unconditional_goto",
        /*   51 */ "success_goto",
        /*   52 */ "failure_goto",
        /*   53 */ "index",
        /*   54 */ "arguments",
        /*   55 */ "func_arguments",
    };

    private readonly string[] yyRuleName =
    {
        /*   0 */ "expression ::= expression BINARY_TILDE expression",
        /*   1 */ "expression ::= expression BINARY_DOLLAR expression",
        /*   2 */ "expression ::= expression BINARY_PERIOD expression",
        /*   3 */ "expression ::= expression BINARY_CARET expression",
        /*   4 */ "expression ::= expression BINARY_PERCENT expression",
        /*   5 */ "expression ::= expression BINARY_STAR expression",
        /*   6 */ "expression ::= expression BINARY_SLASH expression",
        /*   7 */ "expression ::= expression BINARY_HASH expression",
        /*   8 */ "expression ::= expression BINARY_PLUS expression",
        /*   9 */ "expression ::= expression BINARY_MINUS expression",
        /*  10 */ "expression ::= expression BINARY_AT expression",
        /*  11 */ "expression ::= expression BINARY_CONCAT expression",
        /*  12 */ "expression ::= expression BINARY_PIPE expression",
        /*  13 */ "expression ::= expression BINARY_AMPERSAND expression",
        /*  14 */ "expression ::= expression BINARY_EQUAL expression",
        /*  15 */ "unconditional_goto ::= L_PAREN expression R_PAREN",
        /*  16 */ "unconditional_goto ::= L_ANGLE expression R_ANGLE",
        /*  17 */ "success_goto ::= L_PAREN_SUCCESS expression R_PAREN",
        /*  18 */ "success_goto ::= L_ANGLE_SUCCESS expression R_ANGLE",
        /*  19 */ "failure_goto ::= L_PAREN_FAILURE expression R_PAREN",
        /*  20 */ "failure_goto ::= L_ANGLE_FAILURE expression R_ANGLE",
        /*  21 */ "statement_field ::= element UNARY_EQUAL",
        /*  22 */ "statement_field ::= element MATCH_REPLACE expression OBJECT_REPLACE expression",
        /*  23 */ "statement_field ::= element MATCH_DELETE expression OBJECT_DELETE",
        /*  24 */ "statement_field ::= element MATCH_ONLY expression",
        /*  25 */ "element ::= INTEGER",
        /*  26 */ "element ::= REAL",
        /*  27 */ "element ::= STRING",
        /*  28 */ "element ::= IDENTIFIER",
        /*  29 */ "element ::= UNARY element",
        /*  30 */ "element ::= IDENTIFIER index",
        /*  31 */ "element ::= L_PAREN arguments R_PAREN",
        /*  32 */ "element ::= L_PAREN arguments R_PAREN index",
        /*  33 */ "index ::= L_PAREN func_arguments R_PAREN",
        /*  34 */ "index ::= L_ANGLE arguments R_ANGLE",
        /*  35 */ "index ::= L_SQUARE arguments R_SQUARE",
        /*  36 */ "index ::= index L_PAREN func_arguments R_PAREN",
        /*  37 */ "index ::= index L_ANGLE arguments R_ANGLE",
        /*  38 */ "index ::= index L_SQUARE arguments R_SQUARE",
        /*  39 */ "func_arguments ::= NULL",
        /*  40 */ "func_arguments ::= expression",
        /*  41 */ "func_arguments ::= func_arguments COMMA NULL",
        /*  42 */ "func_arguments ::= func_arguments COMMA expression",
        /*  43 */ "arguments ::= expression",
        /*  44 */ "arguments ::= arguments COMMA expression",
        /*  45 */ "expression ::= element",
        /*  46 */ "program_line ::= statement_field goto_field",
        /*  47 */ "program_line ::= statement_field",
        /*  48 */ "program_line ::= goto_field",
        /*  49 */ "goto_field ::= COLON unconditional_goto",
        /*  50 */ "goto_field ::= COLON success_goto",
        /*  51 */ "goto_field ::= COLON failure_goto",
        /*  52 */ "goto_field ::= COLON success_goto failure_goto",
        /*  53 */ "goto_field ::= COLON failure_goto success_goto",
        /*  54 */ "statement_field ::= expression",
    };

    private readonly Rule[] yyRuleInfo =
    {
        new Rule(   45,   -3 ), /* (0) expression ::= expression BINARY_TILDE expression */
        new Rule(   45,   -3 ), /* (1) expression ::= expression BINARY_DOLLAR expression */
        new Rule(   45,   -3 ), /* (2) expression ::= expression BINARY_PERIOD expression */
        new Rule(   45,   -3 ), /* (3) expression ::= expression BINARY_CARET expression */
        new Rule(   45,   -3 ), /* (4) expression ::= expression BINARY_PERCENT expression */
        new Rule(   45,   -3 ), /* (5) expression ::= expression BINARY_STAR expression */
        new Rule(   45,   -3 ), /* (6) expression ::= expression BINARY_SLASH expression */
        new Rule(   45,   -3 ), /* (7) expression ::= expression BINARY_HASH expression */
        new Rule(   45,   -3 ), /* (8) expression ::= expression BINARY_PLUS expression */
        new Rule(   45,   -3 ), /* (9) expression ::= expression BINARY_MINUS expression */
        new Rule(   45,   -3 ), /* (10) expression ::= expression BINARY_AT expression */
        new Rule(   45,   -3 ), /* (11) expression ::= expression BINARY_CONCAT expression */
        new Rule(   45,   -3 ), /* (12) expression ::= expression BINARY_PIPE expression */
        new Rule(   45,   -3 ), /* (13) expression ::= expression BINARY_AMPERSAND expression */
        new Rule(   45,   -3 ), /* (14) expression ::= expression BINARY_EQUAL expression */
        new Rule(   50,   -3 ), /* (15) unconditional_goto ::= L_PAREN expression R_PAREN */
        new Rule(   50,   -3 ), /* (16) unconditional_goto ::= L_ANGLE expression R_ANGLE */
        new Rule(   51,   -3 ), /* (17) success_goto ::= L_PAREN_SUCCESS expression R_PAREN */
        new Rule(   51,   -3 ), /* (18) success_goto ::= L_ANGLE_SUCCESS expression R_ANGLE */
        new Rule(   52,   -3 ), /* (19) failure_goto ::= L_PAREN_FAILURE expression R_PAREN */
        new Rule(   52,   -3 ), /* (20) failure_goto ::= L_ANGLE_FAILURE expression R_ANGLE */
        new Rule(   48,   -2 ), /* (21) statement_field ::= element UNARY_EQUAL */
        new Rule(   48,   -5 ), /* (22) statement_field ::= element MATCH_REPLACE expression OBJECT_REPLACE expression */
        new Rule(   48,   -4 ), /* (23) statement_field ::= element MATCH_DELETE expression OBJECT_DELETE */
        new Rule(   48,   -3 ), /* (24) statement_field ::= element MATCH_ONLY expression */
        new Rule(   46,   -1 ), /* (25) element ::= INTEGER */
        new Rule(   46,   -1 ), /* (26) element ::= REAL */
        new Rule(   46,   -1 ), /* (27) element ::= STRING */
        new Rule(   46,   -1 ), /* (28) element ::= IDENTIFIER */
        new Rule(   46,   -2 ), /* (29) element ::= UNARY element */
        new Rule(   46,   -2 ), /* (30) element ::= IDENTIFIER index */
        new Rule(   46,   -3 ), /* (31) element ::= L_PAREN arguments R_PAREN */
        new Rule(   46,   -4 ), /* (32) element ::= L_PAREN arguments R_PAREN index */
        new Rule(   53,   -3 ), /* (33) index ::= L_PAREN func_arguments R_PAREN */
        new Rule(   53,   -3 ), /* (34) index ::= L_ANGLE arguments R_ANGLE */
        new Rule(   53,   -3 ), /* (35) index ::= L_SQUARE arguments R_SQUARE */
        new Rule(   53,   -4 ), /* (36) index ::= index L_PAREN func_arguments R_PAREN */
        new Rule(   53,   -4 ), /* (37) index ::= index L_ANGLE arguments R_ANGLE */
        new Rule(   53,   -4 ), /* (38) index ::= index L_SQUARE arguments R_SQUARE */
        new Rule(   55,   -1 ), /* (39) func_arguments ::= NULL */
        new Rule(   55,   -1 ), /* (40) func_arguments ::= expression */
        new Rule(   55,   -3 ), /* (41) func_arguments ::= func_arguments COMMA NULL */
        new Rule(   55,   -3 ), /* (42) func_arguments ::= func_arguments COMMA expression */
        new Rule(   54,   -1 ), /* (43) arguments ::= expression */
        new Rule(   54,   -3 ), /* (44) arguments ::= arguments COMMA expression */
        new Rule(   45,   -1 ), /* (45) expression ::= element */
        new Rule(   47,   -2 ), /* (46) program_line ::= statement_field goto_field */
        new Rule(   47,   -1 ), /* (47) program_line ::= statement_field */
        new Rule(   47,   -1 ), /* (48) program_line ::= goto_field */
        new Rule(   49,   -2 ), /* (49) goto_field ::= COLON unconditional_goto */
        new Rule(   49,   -2 ), /* (50) goto_field ::= COLON success_goto */
        new Rule(   49,   -2 ), /* (51) goto_field ::= COLON failure_goto */
        new Rule(   49,   -3 ), /* (52) goto_field ::= COLON success_goto failure_goto */
        new Rule(   49,   -3 ), /* (53) goto_field ::= COLON failure_goto success_goto */
        new Rule(   48,   -1 ), /* (54) statement_field ::= expression */
    };

    // Reduce Actions

    internal YYMINORTYPE ExecuteReductions(int ruleno)
    {
        YYMINORTYPE yylhsminor = new();
        switch (ruleno)
        {
            case 0: /* expression ::= expression BINARY_TILDE expression */
                {
                    Line.AddCommand("BINARY_TILDE");
                }
                break;
            case 1: /* expression ::= expression BINARY_DOLLAR expression */
                {
                    Line.AddCommand("BINARY_DOLLAR");
                }
                break;
            case 2: /* expression ::= expression BINARY_PERIOD expression */
                {
                    Line.AddCommand("BINARY_PERIOD");
                }
                break;
            case 3: /* expression ::= expression BINARY_CARET expression */
                {
                    Line.AddCommand("BINARY_CARET");
                }
                break;
            case 4: /* expression ::= expression BINARY_PERCENT expression */
                {
                    Line.AddCommand("BINARY_PERCENT");
                }
                break;
            case 5: /* expression ::= expression BINARY_STAR expression */
                {
                    Line.AddCommand("BINARY_STAR");
                }
                break;
            case 6: /* expression ::= expression BINARY_SLASH expression */
                {
                    Line.AddCommand("BINARY_SLASH");
                }
                break;
            case 7: /* expression ::= expression BINARY_HASH expression */
                {
                    Line.AddCommand("BINARY_HASH");
                }
                break;
            case 8: /* expression ::= expression BINARY_PLUS expression */
                {
                    Line.AddCommand("BINARY_PLUS");
                }
                break;
            case 9: /* expression ::= expression BINARY_MINUS expression */
                {
                    Line.AddCommand("BINARY_MINUS");
                }
                break;
            case 10: /* expression ::= expression BINARY_AT expression */
                {
                    Line.AddCommand("BINARY_AT");
                }
                break;
            case 11: /* expression ::= expression BINARY_CONCAT expression */
                {
                    Line.AddCommand("BINARY_CONCAT");
                }
                break;
            case 12: /* expression ::= expression BINARY_PIPE expression */
                {
                    Line.AddCommand("BINARY_PIPE");
                }
                break;
            case 13: /* expression ::= expression BINARY_AMPERSAND expression */
                {
                    Line.AddCommand("BINARY_AMPERSAND");
                }
                break;
            case 14: /* expression ::= expression BINARY_EQUAL expression */
                {
                    Line.AddCommand("BINARY_EQUAL");
                }
                break;
            case 15: /* unconditional_goto ::= L_PAREN expression R_PAREN */
            case 16: /* unconditional_goto ::= L_ANGLE expression R_ANGLE */
                {
                    Line.AddCommand("UGOTO");
                }
                break;
            case 17: /* success_goto ::= L_PAREN_SUCCESS expression R_PAREN */
            case 18: /* success_goto ::= L_ANGLE_SUCCESS expression R_ANGLE */
                {
                    Line.AddCommand("SUCCESS_GOTO");
                }
                break;
            case 19: /* failure_goto ::= L_PAREN_FAILURE expression R_PAREN */
            case 20: /* failure_goto ::= L_ANGLE_FAILURE expression R_ANGLE */
                {
                    Line.AddCommand("FAILURE_GOTO");
                }
                break;
            case 21: /* statement_field ::= element UNARY_EQUAL */
                {
                    Line.AddCommand("UNARY_EQUAL");
                }
                break;
            case 22: /* statement_field ::= element MATCH_REPLACE expression OBJECT_REPLACE expression */
                {
                    Line.AddCommand("MATCH_REPLACE");
                }
                break;
            case 23: /* statement_field ::= element MATCH_DELETE expression OBJECT_DELETE */
                {
                    Line.AddCommand("MATCH_DELETE");
                }
                break;
            case 24: /* statement_field ::= element MATCH_ONLY expression */
                {
                    Line.AddCommand("MATCH_ONLY");
                }
                break;
            case 25: /* element ::= INTEGER */
                {
                    Line.AddCommand("INTEGER", ParserStack[0].minor.ToString());
                }
                break;
            case 26: /* element ::= REAL */
                {
                    Line.AddCommand("REAL", ParserStack[0].minor.ToString());
                }
                break;
            case 27: /* element ::= STRING */
                {
                    Line.AddCommand("STRING", ParserStack[0].minor.ToString());
                }
                break;
            case 28: /* element ::= IDENTIFIER */
                {
                    Line.AddCommand("IDENTIFIER", ParserStack[0].minor.ToString());
                }
                break;
            case 29: /* element ::= UNARY element */
                {
                    Line.AddCommand("UNARY", ParserStack[-1].minor.ToString());
                }
                break;
            case 30: /* element ::= IDENTIFIER index */
                {
                    Line.AddCommand("FUNCTION", ParserStack[-1].minor.ToString());
                }
                break;
            case 31: /* element ::= L_PAREN arguments R_PAREN */
                {
                    Line.AddCommand("SELECTION");
                }
                break;
            case 32: /* element ::= L_PAREN arguments R_PAREN index */
                {
                    Line.AddCommand("FUNCTION");
                }
                break;
            case 33: /* index ::= L_PAREN func_arguments R_PAREN */
            case 34: /* index ::= L_ANGLE arguments R_ANGLE */
            case 35: /* index ::= L_SQUARE arguments R_SQUARE */
            case 36: /* index ::= index L_PAREN func_arguments R_PAREN */
            case 37: /* index ::= index L_ANGLE arguments R_ANGLE */
            case 38: /* index ::= index L_SQUARE arguments R_SQUARE */
                {
                    Line.AddCommand("INDEX");
                }
                break;
            case 39: /* func_arguments ::= NULL */
                {
                    Line.AddCommand("ARGUMENT_NULL");
                }
                break;
            case 40: /* func_arguments ::= expression */
            case 43: /* arguments ::= expression */
                {
                    Line.AddCommand("ARGUMENT");
                }
                break;
            case 41: /* func_arguments ::= func_arguments COMMA NULL */
                {
                    Line.AddCommand("ARGUMENT_NUll");
                }
                break;
            case 42: /* func_arguments ::= func_arguments COMMA expression */
            case 44: /* arguments ::= arguments COMMA expression */
                {
                    Line.AddCommand("ARGUMENT_COMMA");
                }
                break;
        }
        return yylhsminor;
    }

    internal void syntaxError(int yymajor, YYMINORTYPE yyminor)
    {
        throw new SyntaxError(0);
    }

    internal void Accept()
    {
    }

    internal void ParseFailed()
    {
    }
}