/*
** 2000-05-29
**
** The author disclaims copyright to this source code.  In place of
** a legal notice, here is a blessing:
**
**    May you do good and not evil.
**    May you find forgiveness for yourself and forgive others.
**    May you share freely, never taking more than you give.
**
*************************************************************************
** Driver template for the LEMON parser generator.
**
** The "lemon" program processes an LALR(1) input grammar file, then uses
** this template to construct a parser.  The "lemon" program inserts text
** at each "%%" line.  Also, any "P-a-r-s-e" identifer prefix (without the
** interstitial "-" characters) contained in this template is changed into
** the value of the %name directive from the grammar.  Otherwise, the content
** of this template is copied straight through into the generate parser
** source file.
**
** The following is the concatenation of all %include directives from the
** input grammar file:
*/
#include <stdio.h>
#include <assert.h>
/************ Begin %include sections from the grammar ************************/
/**************** End of %include directives **********************************/
/* These constants specify the various numeric values for terminal symbols
** in a format understandable to "makeheaders".  This section is blank unless
** "lemon" is run with the "-m" command-line option.
***************** Begin makeheaders token definitions *************************/
/**************** End makeheaders token definitions ***************************/

/* The next sections is a series of control #defines.
** various aspects of the generated parser.
**    YYCODETYPE         is the data type used to store the integer codes
**                       that represent terminal and non-terminal symbols.
**                       "unsigned char" is used if there are fewer than
**                       256 symbols.  Larger types otherwise.
**    YYNOCODE           is a number of type YYCODETYPE that is not used for
**                       any terminal or nonterminal symbol.
**    YYFALLBACK         If defined, this indicates that one or more tokens
**                       (also known as: "terminal symbols") have fall-back
**                       values which should be used if the original symbol
**                       would not parse.  This permits keywords to sometimes
**                       be used as identifiers, for example.
**    YYACTIONTYPE       is the data type used for "action codes" - numbers
**                       that indicate what to do in response to the next
**                       token.
**    ParseTOKENTYPE     is the data type used for minor type for terminal
**                       symbols.  Background: A "minor type" is a semantic
**                       value associated with a terminal or non-terminal
**                       symbols.  For example, for an "ID" terminal symbol,
**                       the minor type might be the name of the identifier.
**                       Each non-terminal can have a different minor type.
**                       Terminal symbols all have the same minor type, though.
**                       This macros defines the minor type for terminal 
**                       symbols.
**    YYMINORTYPE        is the data type used for all minor types.
**                       This is typically a union of many types, one of
**                       which is ParseTOKENTYPE.  The entry in the union
**                       for terminal symbols is called "yy0".
**    YYSTACKDEPTH       is the maximum depth of the parser's stack.  If
**                       zero the stack is dynamically sized using realloc()
**    ParseARG_SDECL     A static variable declaration for the %extra_argument
**    ParseARG_PDECL     A parameter declaration for the %extra_argument
**    ParseARG_PARAM     Code to pass %extra_argument as a subroutine parameter
**    ParseARG_STORE     Code to store %extra_argument into yypParser
**    ParseARG_FETCH     Code to extract %extra_argument from yypParser
**    ParseCTX_*         As ParseARG_ except for %extra_context
**    YYERRORSYMBOL      is the code number of the error symbol.  If not
**                       defined, then do no error processing.
**    YYNSTATE           the combined number of states.
**    YYNRULE            the number of rules in the grammar
**    YYNTOKEN           Number of terminal symbols
**    YY_MAX_SHIFT       Maximum value for shift actions
**    YY_MIN_SHIFTREDUCE Minimum value for shift-reduce actions
**    YY_MAX_SHIFTREDUCE Maximum value for shift-reduce actions
**    YY_ERROR_ACTION    The yy_action[] code for syntax error
**    YY_ACCEPT_ACTION   The yy_action[] code for accept
**    YY_NO_ACTION       The yy_action[] code for no-op
**    YY_MIN_REDUCE      Minimum value for reduce actions
**    YY_MAX_REDUCE      Maximum value for reduce actions
*/
#ifndef INTERFACE
# define INTERFACE 1
#endif
/************* Begin control #defines *****************************************/
#define YYCODETYPE unsigned char
#define YYNOCODE 56
#define YYACTIONTYPE unsigned char
#define ParseTOKENTYPE  Token 
typedef union {
  int yyinit;
  ParseTOKENTYPE yy0;
} YYMINORTYPE;
#ifndef YYSTACKDEPTH
#define YYSTACKDEPTH 100
#endif
#define ParseARG_SDECL
#define ParseARG_PDECL
#define ParseARG_PARAM
#define ParseARG_FETCH
#define ParseARG_STORE
#define ParseCTX_SDECL
#define ParseCTX_PDECL
#define ParseCTX_PARAM
#define ParseCTX_FETCH
#define ParseCTX_STORE
#define YYNSTATE             84
#define YYNRULE              55
#define YYNTOKEN             45
#define YY_MAX_SHIFT         83
#define YY_MIN_SHIFTREDUCE   108
#define YY_MAX_SHIFTREDUCE   162
#define YY_ERROR_ACTION      163
#define YY_ACCEPT_ACTION     164
#define YY_NO_ACTION         165
#define YY_MIN_REDUCE        166
#define YY_MAX_REDUCE        220
/************* End control #defines *******************************************/

/* Define the yytestcase() macro to be a no-op if is not already defined
** otherwise.
**
** Applications can choose to define yytestcase() in the %include section
** to a macro that can assist in verifying code coverage.  For production
** code the yytestcase() macro should be turned off.  But it is useful
** for testing.
*/
#ifndef yytestcase
# define yytestcase(X)
#endif


/* Next are the tables used to determine what action to take based on the
** current state and lookahead token.  These tables are used to implement
** functions that take a state number and lookahead value and return an
** action integer.  
**
** Suppose the action integer is N.  Then the action is determined as
** follows
**
**   0 <= N <= YY_MAX_SHIFT             Shift N.  That is, push the lookahead
**                                      token onto the stack and goto state N.
**
**   N between YY_MIN_SHIFTREDUCE       Shift to an arbitrary state then
**     and YY_MAX_SHIFTREDUCE           reduce by rule N-YY_MIN_SHIFTREDUCE.
**
**   N == YY_ERROR_ACTION               A syntax error has occurred.
**
**   N == YY_ACCEPT_ACTION              The parser accepts its input.
**
**   N == YY_NO_ACTION                  No such action.  Denotes unused
**                                      slots in the yy_action[] table.
**
**   N between YY_MIN_REDUCE            Reduce by rule N-YY_MIN_REDUCE
**     and YY_MAX_REDUCE
**
** The action table is constructed as a single large table named yy_action[].
** Given state S and lookahead X, the action is computed as either:
**
**    (A)   N = yy_action[ yy_shift_ofst[S] + X ]
**    (B)   N = yy_default[S]
**
** The (A) formula is preferred.  The B formula is used instead if
** yy_lookahead[yy_shift_ofst[S]+X] is not equal to X.
**
** The formulas above are for computing the action when the lookahead is
** a terminal symbol.  If the lookahead is a non-terminal (as occurs after
** a reduce action) then the yy_reduce_ofst[] array is used in place of
** the yy_shift_ofst[] array.
**
** The following are the tables generated in this section:
**
**  yy_action[]        A single table containing all actions.
**  yy_lookahead[]     A table containing the lookahead for each entry in
**                     yy_action.  Used to detect hash collisions.
**  yy_shift_ofst[]    For each state, the offset into yy_action for
**                     shifting terminals.
**  yy_reduce_ofst[]   For each state, the offset into yy_action for
**                     shifting non-terminals after a reduce.
**  yy_default[]       Default action for each state.
**
*********** Begin parsing tables **********************************************/
#define YY_ACTTAB_COUNT (408)
static const YYACTIONTYPE yy_action[] = {
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
static const YYCODETYPE yy_lookahead[] = {
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
#define YY_SHIFT_COUNT    (83)
#define YY_SHIFT_MIN      (0)
#define YY_SHIFT_MAX      (369)
static const unsigned short int yy_shift_ofst[] = {
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
#define YY_REDUCE_COUNT (41)
#define YY_REDUCE_MIN   (-46)
#define YY_REDUCE_MAX   (337)
static const short yy_reduce_ofst[] = {
 /*     0 */    58,  226,  248,  157,  246,  252,  263,  268,  273,  115,
 /*    10 */   117,  168,  170,  250,  286,  288,  290,  292,  294,  296,
 /*    20 */   298,  302,  304,  306,  309,  314,  318,  320,  322,  324,
 /*    30 */   327,  329,  331,  333,  335,  337,  -46,  -40,  -24,   -7,
 /*    40 */     3,   19,
};
static const YYACTIONTYPE yy_default[] = {
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
/********** End of lemon-generated parsing tables *****************************/

/* The next table maps tokens (terminal symbols) into fallback tokens.  
** If a construct like the following:
** 
**      %fallback ID X Y Z.
**
** appears in the grammar, then ID becomes a fallback token for X, Y,
** and Z.  Whenever one of the tokens X, Y, or Z is input to the parser
** but it does not parse, the type of the token is changed to ID and
** the parse is retried before an error is thrown.
**
** This feature can be used, for example, to cause some keywords in a language
** to revert to identifiers if they keyword does not apply in the context where
** it appears.
*/
#ifdef YYFALLBACK
static const YYCODETYPE yyFallback[] = {
};
#endif /* YYFALLBACK */

/* The following structure represents a single element of the
** parser's stack.  Information stored includes:
**
**   +  The state number for the parser at this level of the stack.
**
**   +  The value of the token stored at this level of the stack.
**      (In other words, the "major" token.)
**
**   +  The semantic value stored at this level of the stack.  This is
**      the information used by the action routines in the grammar.
**      It is sometimes called the "minor" token.
**
** After the "shift" half of a SHIFTREDUCE action, the stateno field
** actually contains the reduce action for the second half of the
** SHIFTREDUCE.
*/
struct yyStackEntry {
  YYACTIONTYPE stateno;  /* The state-number, or reduce action in SHIFTREDUCE */
  YYCODETYPE major;      /* The major token value.  This is the code
                         ** number for the token at this stack level */
  YYMINORTYPE minor;     /* The user-supplied minor token value.  This
                         ** is the value of the token  */
};
typedef struct yyStackEntry yyStackEntry;

/* The state of the parser is completely contained in an instance of
** the following structure */
struct yyParser {
  yyStackEntry *yytos;          /* Pointer to top element of the stack */
#ifdef YYTRACKMAXSTACKDEPTH
  int yyhwm;                    /* High-water mark of the stack */
#endif
#ifndef YYNOERRORRECOVERY
  int yyerrcnt;                 /* Shifts left before out of the error */
#endif
  ParseARG_SDECL                /* A place to hold %extra_argument */
  ParseCTX_SDECL                /* A place to hold %extra_context */
#if YYSTACKDEPTH<=0
  int yystksz;                  /* Current side of the stack */
  yyStackEntry *yystack;        /* The parser's stack */
  yyStackEntry yystk0;          /* First stack entry */
#else
  yyStackEntry yystack[YYSTACKDEPTH];  /* The parser's stack */
  yyStackEntry *yystackEnd;            /* Last entry in the stack */
#endif
};
typedef struct yyParser yyParser;

#ifndef NDEBUG
#include <stdio.h>
static FILE *yyTraceFILE = 0;
static char *yyTracePrompt = 0;
#endif /* NDEBUG */

#ifndef NDEBUG
/* 
** Turn parser tracing on by giving a stream to which to write the trace
** and a prompt to preface each trace message.  Tracing is turned off
** by making either argument NULL 
**
** Inputs:
** <ul>
** <li> A FILE* to which trace output should be written.
**      If NULL, then tracing is turned off.
** <li> A prefix string written at the beginning of every
**      line of trace output.  If NULL, then tracing is
**      turned off.
** </ul>
**
** Outputs:
** None.
*/
void ParseTrace(FILE *TraceFILE, char *zTracePrompt){
  yyTraceFILE = TraceFILE;
  yyTracePrompt = zTracePrompt;
  if( yyTraceFILE==0 ) yyTracePrompt = 0;
  else if( yyTracePrompt==0 ) yyTraceFILE = 0;
}
#endif /* NDEBUG */

#if defined(YYCOVERAGE) || !defined(NDEBUG)
/* For tracing shifts, the names of all terminals and nonterminals
** are required.  The following table supplies these names */
static const char *const yyTokenName[] = { 
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
#endif /* defined(YYCOVERAGE) || !defined(NDEBUG) */

#ifndef NDEBUG
/* For tracing reduce actions, the names of all rules are required.
*/
static const char *const yyRuleName[] = {
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
#endif /* NDEBUG */


#if YYSTACKDEPTH<=0
/*
** Try to increase the size of the parser stack.  Return the number
** of errors.  Return 0 on success.
*/
static int yyGrowStack(yyParser *p){
  int newSize;
  int idx;
  yyStackEntry *pNew;

  newSize = p->yystksz*2 + 100;
  idx = p->yytos ? (int)(p->yytos - p->yystack) : 0;
  if( p->yystack==&p->yystk0 ){
    pNew = malloc(newSize*sizeof(pNew[0]));
    if( pNew ) pNew[0] = p->yystk0;
  }else{
    pNew = realloc(p->yystack, newSize*sizeof(pNew[0]));
  }
  if( pNew ){
    p->yystack = pNew;
    p->yytos = &p->yystack[idx];
#ifndef NDEBUG
    if( yyTraceFILE ){
      fprintf(yyTraceFILE,"%sStack grows from %d to %d entries.\n",
              yyTracePrompt, p->yystksz, newSize);
    }
#endif
    p->yystksz = newSize;
  }
  return pNew==0; 
}
#endif

/* Datatype of the argument to the memory allocated passed as the
** second argument to ParseAlloc() below.  This can be changed by
** putting an appropriate #define in the %include section of the input
** grammar.
*/
#ifndef YYMALLOCARGTYPE
# define YYMALLOCARGTYPE size_t
#endif

/* Initialize a new parser that has already been allocated.
*/
void ParseInit(void *yypRawParser ParseCTX_PDECL){
  yyParser *yypParser = (yyParser*)yypRawParser;
  ParseCTX_STORE
#ifdef YYTRACKMAXSTACKDEPTH
  yypParser->yyhwm = 0;
#endif
#if YYSTACKDEPTH<=0
  yypParser->yytos = NULL;
  yypParser->yystack = NULL;
  yypParser->yystksz = 0;
  if( yyGrowStack(yypParser) ){
    yypParser->yystack = &yypParser->yystk0;
    yypParser->yystksz = 1;
  }
#endif
#ifndef YYNOERRORRECOVERY
  yypParser->yyerrcnt = -1;
#endif
  yypParser->yytos = yypParser->yystack;
  yypParser->yystack[0].stateno = 0;
  yypParser->yystack[0].major = 0;
#if YYSTACKDEPTH>0
  yypParser->yystackEnd = &yypParser->yystack[YYSTACKDEPTH-1];
#endif
}

#ifndef Parse_ENGINEALWAYSONSTACK
/* 
** This function allocates a new parser.
** The only argument is a pointer to a function which works like
** malloc.
**
** Inputs:
** A pointer to the function used to allocate memory.
**
** Outputs:
** A pointer to a parser.  This pointer is used in subsequent calls
** to Parse and ParseFree.
*/
void *ParseAlloc(void *(*mallocProc)(YYMALLOCARGTYPE) ParseCTX_PDECL){
  yyParser *yypParser;
  yypParser = (yyParser*)(*mallocProc)( (YYMALLOCARGTYPE)sizeof(yyParser) );
  if( yypParser ){
    ParseCTX_STORE
    ParseInit(yypParser ParseCTX_PARAM);
  }
  return (void*)yypParser;
}
#endif /* Parse_ENGINEALWAYSONSTACK */


/* The following function deletes the "minor type" or semantic value
** associated with a symbol.  The symbol can be either a terminal
** or nonterminal. "yymajor" is the symbol code, and "yypminor" is
** a pointer to the value to be deleted.  The code used to do the 
** deletions is derived from the %destructor and/or %token_destructor
** directives of the input grammar.
*/
static void yy_destructor(
  yyParser *yypParser,    /* The parser */
  YYCODETYPE yymajor,     /* Type code for object to destroy */
  YYMINORTYPE *yypminor   /* The object to be destroyed */
){
  ParseARG_FETCH
  ParseCTX_FETCH
  switch( yymajor ){
    /* Here is inserted the actions which take place when a
    ** terminal or non-terminal is destroyed.  This can happen
    ** when the symbol is popped from the stack during a
    ** reduce or during error processing or when a parser is 
    ** being destroyed before it is finished parsing.
    **
    ** Note: during a reduce, the only symbols destroyed are those
    ** which appear on the RHS of the rule, but which are *not* used
    ** inside the C code.
    */
/********* Begin destructor definitions ***************************************/
/********* End destructor definitions *****************************************/
    default:  break;   /* If no destructor action specified: do nothing */
  }
}

/*
** Pop the parser's stack once.
**
** If there is a destructor routine associated with the token which
** is popped from the stack, then call it.
*/
static void yy_pop_parser_stack(yyParser *pParser){
  yyStackEntry *yytos;
  assert( pParser->yytos!=0 );
  assert( pParser->yytos > pParser->yystack );
  yytos = pParser->yytos--;
#ifndef NDEBUG
  if( yyTraceFILE ){
    fprintf(yyTraceFILE,"%sPopping %s\n",
      yyTracePrompt,
      yyTokenName[yytos->major]);
  }
#endif
  yy_destructor(pParser, yytos->major, &yytos->minor);
}

/*
** Clear all secondary memory allocations from the parser
*/
void ParseFinalize(void *p){
  yyParser *pParser = (yyParser*)p;
  while( pParser->yytos>pParser->yystack ) yy_pop_parser_stack(pParser);
#if YYSTACKDEPTH<=0
  if( pParser->yystack!=&pParser->yystk0 ) free(pParser->yystack);
#endif
}

#ifndef Parse_ENGINEALWAYSONSTACK
/* 
** Deallocate and destroy a parser.  Destructors are called for
** all stack elements before shutting the parser down.
**
** If the YYPARSEFREENEVERNULL macro exists (for example because it
** is defined in a %include section of the input grammar) then it is
** assumed that the input pointer is never NULL.
*/
void ParseFree(
  void *p,                    /* The parser to be deleted */
  void (*freeProc)(void*)     /* Function used to reclaim memory */
){
#ifndef YYPARSEFREENEVERNULL
  if( p==0 ) return;
#endif
  ParseFinalize(p);
  (*freeProc)(p);
}
#endif /* Parse_ENGINEALWAYSONSTACK */

/*
** Return the peak depth of the stack for a parser.
*/
#ifdef YYTRACKMAXSTACKDEPTH
int ParseStackPeak(void *p){
  yyParser *pParser = (yyParser*)p;
  return pParser->yyhwm;
}
#endif

/* This array of booleans keeps track of the parser statement
** coverage.  The element yycoverage[X][Y] is set when the parser
** is in state X and has a lookahead token Y.  In a well-tested
** systems, every element of this matrix should end up being set.
*/
#if defined(YYCOVERAGE)
static unsigned char yycoverage[YYNSTATE][YYNTOKEN];
#endif

/*
** Write into out a description of every state/lookahead combination that
**
**   (1)  has not been used by the parser, and
**   (2)  is not a syntax error.
**
** Return the number of missed state/lookahead combinations.
*/
#if defined(YYCOVERAGE)
int ParseCoverage(FILE *out){
  int stateno, iLookAhead, i;
  int nMissed = 0;
  for(stateno=0; stateno<YYNSTATE; stateno++){
    i = yy_shift_ofst[stateno];
    for(iLookAhead=0; iLookAhead<YYNTOKEN; iLookAhead++){
      if( yy_lookahead[i+iLookAhead]!=iLookAhead ) continue;
      if( yycoverage[stateno][iLookAhead]==0 ) nMissed++;
      if( out ){
        fprintf(out,"State %d lookahead %s %s\n", stateno,
                yyTokenName[iLookAhead],
                yycoverage[stateno][iLookAhead] ? "ok" : "missed");
      }
    }
  }
  return nMissed;
}
#endif

/*
** Find the appropriate action for a parser given the terminal
** look-ahead token iLookAhead.
*/
static YYACTIONTYPE yy_find_shift_action(
  YYCODETYPE iLookAhead,    /* The look-ahead token */
  YYACTIONTYPE stateno      /* Current state number */
){
  int i;

  if( stateno>YY_MAX_SHIFT ) return stateno;
  assert( stateno <= YY_SHIFT_COUNT );
#if defined(YYCOVERAGE)
  yycoverage[stateno][iLookAhead] = 1;
#endif
  do{
    i = yy_shift_ofst[stateno];
    assert( i>=0 );
    assert( i+YYNTOKEN<=(int)sizeof(yy_lookahead)/sizeof(yy_lookahead[0]) );
    assert( iLookAhead!=YYNOCODE );
    assert( iLookAhead < YYNTOKEN );
    i += iLookAhead;
    if( yy_lookahead[i]!=iLookAhead ){
#ifdef YYFALLBACK
      YYCODETYPE iFallback;            /* Fallback token */
      if( iLookAhead<sizeof(yyFallback)/sizeof(yyFallback[0])
             && (iFallback = yyFallback[iLookAhead])!=0 ){
#ifndef NDEBUG
        if( yyTraceFILE ){
          fprintf(yyTraceFILE, "%sFALLBACK %s => %s\n",
             yyTracePrompt, yyTokenName[iLookAhead], yyTokenName[iFallback]);
        }
#endif
        assert( yyFallback[iFallback]==0 ); /* Fallback loop must terminate */
        iLookAhead = iFallback;
        continue;
      }
#endif
#ifdef YYWILDCARD
      {
        int j = i - iLookAhead + YYWILDCARD;
        if( 
#if YY_SHIFT_MIN+YYWILDCARD<0
          j>=0 &&
#endif
#if YY_SHIFT_MAX+YYWILDCARD>=YY_ACTTAB_COUNT
          j<YY_ACTTAB_COUNT &&
#endif
          yy_lookahead[j]==YYWILDCARD && iLookAhead>0
        ){
#ifndef NDEBUG
          if( yyTraceFILE ){
            fprintf(yyTraceFILE, "%sWILDCARD %s => %s\n",
               yyTracePrompt, yyTokenName[iLookAhead],
               yyTokenName[YYWILDCARD]);
          }
#endif /* NDEBUG */
          return yy_action[j];
        }
      }
#endif /* YYWILDCARD */
      return yy_default[stateno];
    }else{
      return yy_action[i];
    }
  }while(1);
}

/*
** Find the appropriate action for a parser given the non-terminal
** look-ahead token iLookAhead.
*/
static int yy_find_reduce_action(
  YYACTIONTYPE stateno,     /* Current state number */
  YYCODETYPE iLookAhead     /* The look-ahead token */
){
  int i;
#ifdef YYERRORSYMBOL
  if( stateno>YY_REDUCE_COUNT ){
    return yy_default[stateno];
  }
#else
  assert( stateno<=YY_REDUCE_COUNT );
#endif
  i = yy_reduce_ofst[stateno];
  assert( iLookAhead!=YYNOCODE );
  i += iLookAhead;
#ifdef YYERRORSYMBOL
  if( i<0 || i>=YY_ACTTAB_COUNT || yy_lookahead[i]!=iLookAhead ){
    return yy_default[stateno];
  }
#else
  assert( i>=0 && i<YY_ACTTAB_COUNT );
  assert( yy_lookahead[i]==iLookAhead );
#endif
  return yy_action[i];
}

/*
** The following routine is called if the stack overflows.
*/
static void yyStackOverflow(yyParser *yypParser){
   ParseARG_FETCH
   ParseCTX_FETCH
#ifndef NDEBUG
   if( yyTraceFILE ){
     fprintf(yyTraceFILE,"%sStack Overflow!\n",yyTracePrompt);
   }
#endif
   while( yypParser->yytos>yypParser->yystack ) yy_pop_parser_stack(yypParser);
   /* Here code is inserted which will execute if the parser
   ** stack every overflows */
/******** Begin %stack_overflow code ******************************************/
/******** End %stack_overflow code ********************************************/
   ParseARG_STORE /* Suppress warning about unused %extra_argument var */
   ParseCTX_STORE
}

/*
** Print tracing information for a SHIFT action
*/
#ifndef NDEBUG
static void yyTraceShift(yyParser *yypParser, int yyNewState, const char *zTag){
  if( yyTraceFILE ){
    if( yyNewState<YYNSTATE ){
      fprintf(yyTraceFILE,"%s%s '%s', go to state %d\n",
         yyTracePrompt, zTag, yyTokenName[yypParser->yytos->major],
         yyNewState);
    }else{
      fprintf(yyTraceFILE,"%s%s '%s', pending reduce %d\n",
         yyTracePrompt, zTag, yyTokenName[yypParser->yytos->major],
         yyNewState - YY_MIN_REDUCE);
    }
  }
}
#else
# define yyTraceShift(X,Y,Z)
#endif

/*
** Perform a shift action.
*/
static void yy_shift(
  yyParser *yypParser,          /* The parser to be shifted */
  YYACTIONTYPE yyNewState,      /* The new state to shift in */
  YYCODETYPE yyMajor,           /* The major token to shift in */
  ParseTOKENTYPE yyMinor        /* The minor token to shift in */
){
  yyStackEntry *yytos;
  yypParser->yytos++;
#ifdef YYTRACKMAXSTACKDEPTH
  if( (int)(yypParser->yytos - yypParser->yystack)>yypParser->yyhwm ){
    yypParser->yyhwm++;
    assert( yypParser->yyhwm == (int)(yypParser->yytos - yypParser->yystack) );
  }
#endif
#if YYSTACKDEPTH>0 
  if( yypParser->yytos>yypParser->yystackEnd ){
    yypParser->yytos--;
    yyStackOverflow(yypParser);
    return;
  }
#else
  if( yypParser->yytos>=&yypParser->yystack[yypParser->yystksz] ){
    if( yyGrowStack(yypParser) ){
      yypParser->yytos--;
      yyStackOverflow(yypParser);
      return;
    }
  }
#endif
  if( yyNewState > YY_MAX_SHIFT ){
    yyNewState += YY_MIN_REDUCE - YY_MIN_SHIFTREDUCE;
  }
  yytos = yypParser->yytos;
  yytos->stateno = yyNewState;
  yytos->major = yyMajor;
  yytos->minor.yy0 = yyMinor;
  yyTraceShift(yypParser, yyNewState, "Shift");
}

/* The following table contains information about every rule that
** is used during the reduce.
*/
static const struct {
  YYCODETYPE lhs;       /* Symbol on the left-hand side of the rule */
  signed char nrhs;     /* Negative of the number of RHS symbols in the rule */
} yyRuleInfo[] = {
  {   45,   -3 }, /* (0) expression ::= expression BINARY_TILDE expression */
  {   45,   -3 }, /* (1) expression ::= expression BINARY_DOLLAR expression */
  {   45,   -3 }, /* (2) expression ::= expression BINARY_PERIOD expression */
  {   45,   -3 }, /* (3) expression ::= expression BINARY_CARET expression */
  {   45,   -3 }, /* (4) expression ::= expression BINARY_PERCENT expression */
  {   45,   -3 }, /* (5) expression ::= expression BINARY_STAR expression */
  {   45,   -3 }, /* (6) expression ::= expression BINARY_SLASH expression */
  {   45,   -3 }, /* (7) expression ::= expression BINARY_HASH expression */
  {   45,   -3 }, /* (8) expression ::= expression BINARY_PLUS expression */
  {   45,   -3 }, /* (9) expression ::= expression BINARY_MINUS expression */
  {   45,   -3 }, /* (10) expression ::= expression BINARY_AT expression */
  {   45,   -3 }, /* (11) expression ::= expression BINARY_CONCAT expression */
  {   45,   -3 }, /* (12) expression ::= expression BINARY_PIPE expression */
  {   45,   -3 }, /* (13) expression ::= expression BINARY_AMPERSAND expression */
  {   45,   -3 }, /* (14) expression ::= expression BINARY_EQUAL expression */
  {   50,   -3 }, /* (15) unconditional_goto ::= L_PAREN expression R_PAREN */
  {   50,   -3 }, /* (16) unconditional_goto ::= L_ANGLE expression R_ANGLE */
  {   51,   -3 }, /* (17) success_goto ::= L_PAREN_SUCCESS expression R_PAREN */
  {   51,   -3 }, /* (18) success_goto ::= L_ANGLE_SUCCESS expression R_ANGLE */
  {   52,   -3 }, /* (19) failure_goto ::= L_PAREN_FAILURE expression R_PAREN */
  {   52,   -3 }, /* (20) failure_goto ::= L_ANGLE_FAILURE expression R_ANGLE */
  {   48,   -2 }, /* (21) statement_field ::= element UNARY_EQUAL */
  {   48,   -5 }, /* (22) statement_field ::= element MATCH_REPLACE expression OBJECT_REPLACE expression */
  {   48,   -4 }, /* (23) statement_field ::= element MATCH_DELETE expression OBJECT_DELETE */
  {   48,   -3 }, /* (24) statement_field ::= element MATCH_ONLY expression */
  {   46,   -1 }, /* (25) element ::= INTEGER */
  {   46,   -1 }, /* (26) element ::= REAL */
  {   46,   -1 }, /* (27) element ::= STRING */
  {   46,   -1 }, /* (28) element ::= IDENTIFIER */
  {   46,   -2 }, /* (29) element ::= UNARY element */
  {   46,   -2 }, /* (30) element ::= IDENTIFIER index */
  {   46,   -3 }, /* (31) element ::= L_PAREN arguments R_PAREN */
  {   46,   -4 }, /* (32) element ::= L_PAREN arguments R_PAREN index */
  {   53,   -3 }, /* (33) index ::= L_PAREN func_arguments R_PAREN */
  {   53,   -3 }, /* (34) index ::= L_ANGLE arguments R_ANGLE */
  {   53,   -3 }, /* (35) index ::= L_SQUARE arguments R_SQUARE */
  {   53,   -4 }, /* (36) index ::= index L_PAREN func_arguments R_PAREN */
  {   53,   -4 }, /* (37) index ::= index L_ANGLE arguments R_ANGLE */
  {   53,   -4 }, /* (38) index ::= index L_SQUARE arguments R_SQUARE */
  {   55,   -1 }, /* (39) func_arguments ::= NULL */
  {   55,   -1 }, /* (40) func_arguments ::= expression */
  {   55,   -3 }, /* (41) func_arguments ::= func_arguments COMMA NULL */
  {   55,   -3 }, /* (42) func_arguments ::= func_arguments COMMA expression */
  {   54,   -1 }, /* (43) arguments ::= expression */
  {   54,   -3 }, /* (44) arguments ::= arguments COMMA expression */
  {   45,   -1 }, /* (45) expression ::= element */
  {   47,   -2 }, /* (46) program_line ::= statement_field goto_field */
  {   47,   -1 }, /* (47) program_line ::= statement_field */
  {   47,   -1 }, /* (48) program_line ::= goto_field */
  {   49,   -2 }, /* (49) goto_field ::= COLON unconditional_goto */
  {   49,   -2 }, /* (50) goto_field ::= COLON success_goto */
  {   49,   -2 }, /* (51) goto_field ::= COLON failure_goto */
  {   49,   -3 }, /* (52) goto_field ::= COLON success_goto failure_goto */
  {   49,   -3 }, /* (53) goto_field ::= COLON failure_goto success_goto */
  {   48,   -1 }, /* (54) statement_field ::= expression */
};

static void yy_accept(yyParser*);  /* Forward Declaration */

/*
** Perform a reduce action and the shift that must immediately
** follow the reduce.
**
** The yyLookahead and yyLookaheadToken parameters provide reduce actions
** access to the lookahead token (if any).  The yyLookahead will be YYNOCODE
** if the lookahead token has already been consumed.  As this procedure is
** only called from one place, optimizing compilers will in-line it, which
** means that the extra parameters have no performance impact.
*/
static YYACTIONTYPE yy_reduce(
  yyParser *yypParser,         /* The parser */
  unsigned int yyruleno,       /* Number of the rule by which to reduce */
  int yyLookahead,             /* Lookahead token, or YYNOCODE if none */
  ParseTOKENTYPE yyLookaheadToken  /* Value of the lookahead token */
  ParseCTX_PDECL                   /* %extra_context */
){
  int yygoto;                     /* The next state */
  int yyact;                      /* The next action */
  yyStackEntry *yymsp;            /* The top of the parser's stack */
  int yysize;                     /* Amount to pop the stack */
  ParseARG_FETCH
  (void)yyLookahead;
  (void)yyLookaheadToken;
  yymsp = yypParser->yytos;
#ifndef NDEBUG
  if( yyTraceFILE && yyruleno<(int)(sizeof(yyRuleName)/sizeof(yyRuleName[0])) ){
    yysize = yyRuleInfo[yyruleno].nrhs;
    if( yysize ){
      fprintf(yyTraceFILE, "%sReduce %d [%s], go to state %d.\n",
        yyTracePrompt,
        yyruleno, yyRuleName[yyruleno], yymsp[yysize].stateno);
    }else{
      fprintf(yyTraceFILE, "%sReduce %d [%s].\n",
        yyTracePrompt, yyruleno, yyRuleName[yyruleno]);
    }
  }
#endif /* NDEBUG */

  /* Check that the stack is large enough to grow by a single entry
  ** if the RHS of the rule is empty.  This ensures that there is room
  ** enough on the stack to push the LHS value */
  if( yyRuleInfo[yyruleno].nrhs==0 ){
#ifdef YYTRACKMAXSTACKDEPTH
    if( (int)(yypParser->yytos - yypParser->yystack)>yypParser->yyhwm ){
      yypParser->yyhwm++;
      assert( yypParser->yyhwm == (int)(yypParser->yytos - yypParser->yystack));
    }
#endif
#if YYSTACKDEPTH>0 
    if( yypParser->yytos>=yypParser->yystackEnd ){
      yyStackOverflow(yypParser);
      /* The call to yyStackOverflow() above pops the stack until it is
      ** empty, causing the main parser loop to exit.  So the return value
      ** is never used and does not matter. */
      return 0;
    }
#else
    if( yypParser->yytos>=&yypParser->yystack[yypParser->yystksz-1] ){
      if( yyGrowStack(yypParser) ){
        yyStackOverflow(yypParser);
        /* The call to yyStackOverflow() above pops the stack until it is
        ** empty, causing the main parser loop to exit.  So the return value
        ** is never used and does not matter. */
        return 0;
      }
      yymsp = yypParser->yytos;
    }
#endif
  }

  switch( yyruleno ){
  /* Beginning here are the reduction cases.  A typical example
  ** follows:
  **   case 0:
  **  #line <lineno> <grammarfile>
  **     { ... }           // User supplied code
  **  #line <lineno> <thisfile>
  **     break;
  */
/********** Begin reduce actions **********************************************/
      case 0: /* expression ::= expression BINARY_TILDE expression */
{Line.AddCommand("BINARY_TILDE");}
        break;
      case 1: /* expression ::= expression BINARY_DOLLAR expression */
{Line.AddCommand("BINARY_DOLLAR");}
        break;
      case 2: /* expression ::= expression BINARY_PERIOD expression */
{Line.AddCommand("BINARY_PERIOD");}
        break;
      case 3: /* expression ::= expression BINARY_CARET expression */
{Line.AddCommand("BINARY_CARET");}
        break;
      case 4: /* expression ::= expression BINARY_PERCENT expression */
{Line.AddCommand("BINARY_PERCENT");}
        break;
      case 5: /* expression ::= expression BINARY_STAR expression */
{Line.AddCommand("BINARY_STAR");}
        break;
      case 6: /* expression ::= expression BINARY_SLASH expression */
{Line.AddCommand("BINARY_SLASH");}
        break;
      case 7: /* expression ::= expression BINARY_HASH expression */
{Line.AddCommand("BINARY_HASH");}
        break;
      case 8: /* expression ::= expression BINARY_PLUS expression */
{Line.AddCommand("BINARY_PLUS");}
        break;
      case 9: /* expression ::= expression BINARY_MINUS expression */
{Line.AddCommand("BINARY_MINUS");}
        break;
      case 10: /* expression ::= expression BINARY_AT expression */
{Line.AddCommand("BINARY_AT");}
        break;
      case 11: /* expression ::= expression BINARY_CONCAT expression */
{Line.AddCommand("BINARY_CONCAT");}
        break;
      case 12: /* expression ::= expression BINARY_PIPE expression */
{Line.AddCommand("BINARY_PIPE");}
        break;
      case 13: /* expression ::= expression BINARY_AMPERSAND expression */
{Line.AddCommand("BINARY_AMPERSAND");}
        break;
      case 14: /* expression ::= expression BINARY_EQUAL expression */
{Line.AddCommand("BINARY_EQUAL");}
        break;
      case 15: /* unconditional_goto ::= L_PAREN expression R_PAREN */
      case 16: /* unconditional_goto ::= L_ANGLE expression R_ANGLE */ yytestcase(yyruleno==16);
{Line.AddCommand("UGOTO");}
        break;
      case 17: /* success_goto ::= L_PAREN_SUCCESS expression R_PAREN */
      case 18: /* success_goto ::= L_ANGLE_SUCCESS expression R_ANGLE */ yytestcase(yyruleno==18);
{Line.AddCommand("SGOTO");}
        break;
      case 19: /* failure_goto ::= L_PAREN_FAILURE expression R_PAREN */
      case 20: /* failure_goto ::= L_ANGLE_FAILURE expression R_ANGLE */ yytestcase(yyruleno==20);
{Line.AddCommand("FGOTO");}
        break;
      case 21: /* statement_field ::= element UNARY_EQUAL */
{Line.AddCommand("UNARY_EQUAL");}
        break;
      case 22: /* statement_field ::= element MATCH_REPLACE expression OBJECT_REPLACE expression */
{Line.AddCommand("MATCH_REPLACE");}
        break;
      case 23: /* statement_field ::= element MATCH_DELETE expression OBJECT_DELETE */
{Line.AddCommand("MATCH_DELETE");}
        break;
      case 24: /* statement_field ::= element MATCH_ONLY expression */
{Line.AddCommand("MATCH_ONLY");}
        break;
      case 25: /* element ::= INTEGER */
{Line.AddCommand("INTEGER",yymsp[0].minor.yy0.ToString());}
        break;
      case 26: /* element ::= REAL */
{Line.AddCommand("REAL",yymsp[0].minor.yy0.ToString());}
        break;
      case 27: /* element ::= STRING */
{Line.AddCommand("STRING",yymsp[0].minor.yy0.ToString());}
        break;
      case 28: /* element ::= IDENTIFIER */
{Line.AddCommand("IDENTIFIER",yymsp[0].minor.yy0.ToString());}
        break;
      case 29: /* element ::= UNARY element */
{Line.AddCommand("UNARY",yymsp[-1].minor.yy0.ToString());}
        break;
      case 30: /* element ::= IDENTIFIER index */
{Line.AddCommand("FUNCTION",yymsp[-1].minor.yy0.ToString());}
        break;
      case 31: /* element ::= L_PAREN arguments R_PAREN */
{Line.AddCommand("SELECTION");}
        break;
      case 32: /* element ::= L_PAREN arguments R_PAREN index */
{Line.AddCommand("FUNCTION");}
        break;
      case 33: /* index ::= L_PAREN func_arguments R_PAREN */
      case 34: /* index ::= L_ANGLE arguments R_ANGLE */ yytestcase(yyruleno==34);
      case 35: /* index ::= L_SQUARE arguments R_SQUARE */ yytestcase(yyruleno==35);
      case 36: /* index ::= index L_PAREN func_arguments R_PAREN */ yytestcase(yyruleno==36);
      case 37: /* index ::= index L_ANGLE arguments R_ANGLE */ yytestcase(yyruleno==37);
      case 38: /* index ::= index L_SQUARE arguments R_SQUARE */ yytestcase(yyruleno==38);
{Line.AddCommand("INDEX");}
        break;
      case 39: /* func_arguments ::= NULL */
{Line.AddCommand("ARGUMENT_NULL");}
        break;
      case 40: /* func_arguments ::= expression */
      case 43: /* arguments ::= expression */ yytestcase(yyruleno==43);
{Line.AddCommand("ARGUMENT");}
        break;
      case 41: /* func_arguments ::= func_arguments COMMA NULL */
{Line.AddCommand("ARGUMENT_NUll");}
        break;
      case 42: /* func_arguments ::= func_arguments COMMA expression */
      case 44: /* arguments ::= arguments COMMA expression */ yytestcase(yyruleno==44);
{Line.AddCommand("ARGUMENT_COMMA");}
        break;
      default:
      /* (45) expression ::= element */ yytestcase(yyruleno==45);
      /* (46) program_line ::= statement_field goto_field */ yytestcase(yyruleno==46);
      /* (47) program_line ::= statement_field */ yytestcase(yyruleno==47);
      /* (48) program_line ::= goto_field */ yytestcase(yyruleno==48);
      /* (49) goto_field ::= COLON unconditional_goto */ yytestcase(yyruleno==49);
      /* (50) goto_field ::= COLON success_goto */ yytestcase(yyruleno==50);
      /* (51) goto_field ::= COLON failure_goto */ yytestcase(yyruleno==51);
      /* (52) goto_field ::= COLON success_goto failure_goto */ yytestcase(yyruleno==52);
      /* (53) goto_field ::= COLON failure_goto success_goto */ yytestcase(yyruleno==53);
      /* (54) statement_field ::= expression */ yytestcase(yyruleno==54);
        break;
/********** End reduce actions ************************************************/
  };
  assert( yyruleno<sizeof(yyRuleInfo)/sizeof(yyRuleInfo[0]) );
  yygoto = yyRuleInfo[yyruleno].lhs;
  yysize = yyRuleInfo[yyruleno].nrhs;
  yyact = yy_find_reduce_action(yymsp[yysize].stateno,(YYCODETYPE)yygoto);

  /* There are no SHIFTREDUCE actions on nonterminals because the table
  ** generator has simplified them to pure REDUCE actions. */
  assert( !(yyact>YY_MAX_SHIFT && yyact<=YY_MAX_SHIFTREDUCE) );

  /* It is not possible for a REDUCE to be followed by an error */
  assert( yyact!=YY_ERROR_ACTION );

  yymsp += yysize+1;
  yypParser->yytos = yymsp;
  yymsp->stateno = (YYACTIONTYPE)yyact;
  yymsp->major = (YYCODETYPE)yygoto;
  yyTraceShift(yypParser, yyact, "... then shift");
  return yyact;
}

/*
** The following code executes when the parse fails
*/
#ifndef YYNOERRORRECOVERY
static void yy_parse_failed(
  yyParser *yypParser           /* The parser */
){
  ParseARG_FETCH
  ParseCTX_FETCH
#ifndef NDEBUG
  if( yyTraceFILE ){
    fprintf(yyTraceFILE,"%sFail!\n",yyTracePrompt);
  }
#endif
  while( yypParser->yytos>yypParser->yystack ) yy_pop_parser_stack(yypParser);
  /* Here code is inserted which will be executed whenever the
  ** parser fails */
/************ Begin %parse_failure code ***************************************/
/************ End %parse_failure code *****************************************/
  ParseARG_STORE /* Suppress warning about unused %extra_argument variable */
  ParseCTX_STORE
}
#endif /* YYNOERRORRECOVERY */

/*
** The following code executes when a syntax error first occurs.
*/
static void yy_syntax_error(
  yyParser *yypParser,           /* The parser */
  int yymajor,                   /* The major type of the error token */
  ParseTOKENTYPE yyminor         /* The minor type of the error token */
){
  ParseARG_FETCH
  ParseCTX_FETCH
#define TOKEN yyminor
/************ Begin %syntax_error code ****************************************/
 throw new syntaxError();  
/************ End %syntax_error code ******************************************/
  ParseARG_STORE /* Suppress warning about unused %extra_argument variable */
  ParseCTX_STORE
}

/*
** The following is executed when the parser accepts
*/
static void yy_accept(
  yyParser *yypParser           /* The parser */
){
  ParseARG_FETCH
  ParseCTX_FETCH
#ifndef NDEBUG
  if( yyTraceFILE ){
    fprintf(yyTraceFILE,"%sAccept!\n",yyTracePrompt);
  }
#endif
#ifndef YYNOERRORRECOVERY
  yypParser->yyerrcnt = -1;
#endif
  assert( yypParser->yytos==yypParser->yystack );
  /* Here code is inserted which will be executed whenever the
  ** parser accepts */
/*********** Begin %parse_accept code *****************************************/
/*********** End %parse_accept code *******************************************/
  ParseARG_STORE /* Suppress warning about unused %extra_argument variable */
  ParseCTX_STORE
}

/* The main parser program.
** The first argument is a pointer to a structure obtained from
** "ParseAlloc" which describes the current state of the parser.
** The second argument is the major token number.  The third is
** the minor token.  The fourth optional argument is whatever the
** user wants (and specified in the grammar) and is available for
** use by the action routines.
**
** Inputs:
** <ul>
** <li> A pointer to the parser (an opaque structure.)
** <li> The major token number.
** <li> The minor token number.
** <li> An option argument of a grammar-specified type.
** </ul>
**
** Outputs:
** None.
*/
void Parse(
  void *yyp,                   /* The parser */
  int yymajor,                 /* The major token code number */
  ParseTOKENTYPE yyminor       /* The value for the token */
  ParseARG_PDECL               /* Optional %extra_argument parameter */
){
  YYMINORTYPE yyminorunion;
  YYACTIONTYPE yyact;   /* The parser action. */
#if !defined(YYERRORSYMBOL) && !defined(YYNOERRORRECOVERY)
  int yyendofinput;     /* True if we are at the end of input */
#endif
#ifdef YYERRORSYMBOL
  int yyerrorhit = 0;   /* True if yymajor has invoked an error */
#endif
  yyParser *yypParser = (yyParser*)yyp;  /* The parser */
  ParseCTX_FETCH
  ParseARG_STORE

  assert( yypParser->yytos!=0 );
#if !defined(YYERRORSYMBOL) && !defined(YYNOERRORRECOVERY)
  yyendofinput = (yymajor==0);
#endif

  yyact = yypParser->yytos->stateno;
#ifndef NDEBUG
  if( yyTraceFILE ){
    if( yyact < YY_MIN_REDUCE ){
      fprintf(yyTraceFILE,"%sInput '%s' in state %d\n",
              yyTracePrompt,yyTokenName[yymajor],yyact);
    }else{
      fprintf(yyTraceFILE,"%sInput '%s' with pending reduce %d\n",
              yyTracePrompt,yyTokenName[yymajor],yyact-YY_MIN_REDUCE);
    }
  }
#endif

  do{
    assert( yyact==yypParser->yytos->stateno );
    yyact = yy_find_shift_action(yymajor,yyact);
    if( yyact >= YY_MIN_REDUCE ){
      yyact = yy_reduce(yypParser,yyact-YY_MIN_REDUCE,yymajor,
                        yyminor ParseCTX_PARAM);
    }else if( yyact <= YY_MAX_SHIFTREDUCE ){
      yy_shift(yypParser,yyact,yymajor,yyminor);
#ifndef YYNOERRORRECOVERY
      yypParser->yyerrcnt--;
#endif
      break;
    }else if( yyact==YY_ACCEPT_ACTION ){
      yypParser->yytos--;
      yy_accept(yypParser);
      return;
    }else{
      assert( yyact == YY_ERROR_ACTION );
      yyminorunion.yy0 = yyminor;
#ifdef YYERRORSYMBOL
      int yymx;
#endif
#ifndef NDEBUG
      if( yyTraceFILE ){
        fprintf(yyTraceFILE,"%ssyntax Error!\n",yyTracePrompt);
      }
#endif
#ifdef YYERRORSYMBOL
      /* A syntax error has occurred.
      ** The response to an error depends upon whether or not the
      ** grammar defines an error token "ERROR".  
      **
      ** This is what we do if the grammar does define ERROR:
      **
      **  * Call the %syntax_error function.
      **
      **  * Begin popping the stack until we enter a state where
      **    it is legal to shift the error symbol, then shift
      **    the error symbol.
      **
      **  * Set the error count to three.
      **
      **  * Begin accepting and shifting new tokens.  No new error
      **    processing will occur until three tokens have been
      **    shifted successfully.
      **
      */
      if( yypParser->yyerrcnt<0 ){
        yy_syntax_error(yypParser,yymajor,yyminor);
      }
      yymx = yypParser->yytos->major;
      if( yymx==YYERRORSYMBOL || yyerrorhit ){
#ifndef NDEBUG
        if( yyTraceFILE ){
          fprintf(yyTraceFILE,"%sDiscard input token %s\n",
             yyTracePrompt,yyTokenName[yymajor]);
        }
#endif
        yy_destructor(yypParser, (YYCODETYPE)yymajor, &yyminorunion);
        yymajor = YYNOCODE;
      }else{
        while( yypParser->yytos >= yypParser->yystack
            && yymx != YYERRORSYMBOL
            && (yyact = yy_find_reduce_action(
                        yypParser->yytos->stateno,
                        YYERRORSYMBOL)) >= YY_MIN_REDUCE
        ){
          yy_pop_parser_stack(yypParser);
        }
        if( yypParser->yytos < yypParser->yystack || yymajor==0 ){
          yy_destructor(yypParser,(YYCODETYPE)yymajor,&yyminorunion);
          yy_parse_failed(yypParser);
#ifndef YYNOERRORRECOVERY
          yypParser->yyerrcnt = -1;
#endif
          yymajor = YYNOCODE;
        }else if( yymx!=YYERRORSYMBOL ){
          yy_shift(yypParser,yyact,YYERRORSYMBOL,yyminor);
        }
      }
      yypParser->yyerrcnt = 3;
      yyerrorhit = 1;
      if( yymajor==YYNOCODE ) break;
      yyact = yypParser->yytos->stateno;
#elif defined(YYNOERRORRECOVERY)
      /* If the YYNOERRORRECOVERY macro is defined, then do not attempt to
      ** do any kind of error recovery.  Instead, simply invoke the syntax
      ** error routine and continue going as if nothing had happened.
      **
      ** Applications can set this macro (for example inside %include) if
      ** they intend to abandon the parse upon the first syntax error seen.
      */
      yy_syntax_error(yypParser,yymajor, yyminor);
      yy_destructor(yypParser,(YYCODETYPE)yymajor,&yyminorunion);
      break;
#else  /* YYERRORSYMBOL is not defined */
      /* This is what we do if the grammar does not define ERROR:
      **
      **  * Report an error message, and throw away the input token.
      **
      **  * If the input token is $, then fail the parse.
      **
      ** As before, subsequent error messages are suppressed until
      ** three input tokens have been successfully shifted.
      */
      if( yypParser->yyerrcnt<=0 ){
        yy_syntax_error(yypParser,yymajor, yyminor);
      }
      yypParser->yyerrcnt = 3;
      yy_destructor(yypParser,(YYCODETYPE)yymajor,&yyminorunion);
      if( yyendofinput ){
        yy_parse_failed(yypParser);
#ifndef YYNOERRORRECOVERY
        yypParser->yyerrcnt = -1;
#endif
      }
      break;
#endif
    }
  }while( yypParser->yytos>yypParser->yystack );
#ifndef NDEBUG
  if( yyTraceFILE ){
    yyStackEntry *i;
    char cDiv = '[';
    fprintf(yyTraceFILE,"%sReturn. Stack=",yyTracePrompt);
    for(i=&yypParser->yystack[1]; i<=yypParser->yytos; i++){
      fprintf(yyTraceFILE,"%c%s", cDiv, yyTokenName[i->major]);
      cDiv = ' ';
    }
    fprintf(yyTraceFILE,"]\n");
  }
#endif
  return;
}
