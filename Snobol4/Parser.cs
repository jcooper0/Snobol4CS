namespace Snobol4
{
    public partial class Parser
    {

        internal ShiftReduceStack ParserStack;
        internal int yyerrcnt { get; set; } = -1;

        public SourceLine Line
        {
            get; set;
        }

        public Parser()
        {
            ParserStack = new ShiftReduceStack();
            ParserStack.Push(0, 0, new YYMINORTYPE());
        }

        public void Reset()
        {
            ParserStack.Clear();
            ParserStack.Push(0, 0, new YYMINORTYPE());
            yyerrcnt = -1;
        }

        public void Parse(int yymajor, YYMINORTYPE yyminor)
        {
            bool yyerrorhit = false;   /* True if yymajor has invoked an error */
            bool yyendofinput = yymajor == 0;
            int yyact = ParserStack.yytos.stateno;

            if (!NDEBUG)
            {
                if (yyact < YY_MIN_REDUCE)
                {
                    Console.WriteLine("Input " + yymajor + " (" + yyTokenName[yymajor] + ") in state " + yyact);
                }
                else
                {
                    Console.WriteLine("Input " + yymajor + " (" + yyTokenName[yymajor] + ") with pending reduce " + (yyact - YY_MIN_REDUCE));
                }
            } //(!NDEBUG)

            do
            {
                yyact = FindShiftAction(yymajor, yyact);
                if (yyact >= YY_MIN_REDUCE)
                {
                    yyact = Reduce(yyact - YY_MIN_REDUCE, yymajor, yyminor);
                }
                else if (yyact <= YY_MAX_SHIFTREDUCE)
                {
                    Shift(yyact, yymajor, yyminor);
                    if (!YYNOERRORRECOVERY)
                    {
                        yyerrcnt--;
                    }
                    break;
                }
                else if (yyact == YY_ACCEPT_ACTION)
                {
                    ParserStack.Pop();
                    Accept();
                    return;
                }
                else
                {
                    int yymx;
                    if (!NDEBUG)
                    {
                        Console.WriteLine("Syntax Error!");
                    } // (!NDEBUG)
                    if (YYERRORSYMBOL > 0)
                    {
                        // A syntax error has occurred
                        if (yyerrcnt <= 0)
                        {
                            SyntaxError(yymajor, yyminor);
                        }
                        yyerrcnt = 3;
                        yymx = ParserStack.yytos.major;
                        if (yymx == YYERRORSYMBOL || yyerrorhit)
                        {
                            if (!NDEBUG)
                            {
                                Console.WriteLine("Discard input token: " + yymajor + " (" + yyTokenName[yymajor] + ")");
                            }
                            yymajor = YYNOCODE;
                        }
                        else
                        {
                            while (ParserStack.Count > 0
                                && yymx != YYERRORSYMBOL
                                && (yyact = FindReduceAction(ParserStack.yytos.stateno, YYERRORSYMBOL)) >= YY_MIN_REDUCE)
                            {
                                ParserStack.Pop();
                            }
                            if (ParserStack.Count > 0 || yymajor == 0)
                            {
                                ParseFailed();
                                if (!YYNOERRORRECOVERY)
                                {
                                    yyerrcnt = -1;
                                }
                                yymajor = YYNOCODE;
                            }
                            else if (yymx != YYERRORSYMBOL)
                            {
                                Shift(yyact, YYERRORSYMBOL, yyminor);
                            }
                        }
                        yyerrcnt = 3;
                        yyerrorhit = true;
                        if (yymajor == YYNOCODE)
                            break;
                        yyact = ParserStack.yytos.stateno;
                        if (YYNOERRORRECOVERY)
                        {
                            SyntaxError(yymajor, yyminor);
                            break;
                        } // (YYNOERRORRECOVERY)
                    }
                    else //(YYERRORSYMBOL <= 0)
                    {
                        if (yyerrcnt <= 0)
                        {
                            SyntaxError(yymajor, yyminor);
                        }
                        yyerrcnt = 3;
                        if (yyendofinput)
                        {
                            ParseFailed();
                            Reset();
                            if (!YYNOERRORRECOVERY)
                            {
                                yyerrcnt = -1;
                            }
                        }
                        break;
                    } //(YYERRORSYMBOL <= 0)
                }
            } while (ParserStack.Count > 0);
            if (!NDEBUG)
            {
                Console.WriteLine(ParserStack);
            } // (!NDEBUG)
        }

        internal int FindShiftAction(int iLookAhead, int stateno)
        {
            if (!NDEBUG)
            {
                Console.WriteLine("FindShiftAction:Look ahead ID:" + iLookAhead + "  State: " + stateno);
            }
            if (stateno > YY_MAX_SHIFT)
                return stateno;
            while (true)
            {
                int i = yy_shift_ofst[stateno] + iLookAhead;
                return (yy_lookahead[i] != iLookAhead) ? yy_default[stateno] : yy_action[i];
            }
        }

        internal void Shift(int yyNewState, int yyMajor, YYMINORTYPE yyMinor)
        {
            if (!NDEBUG)
            {
                Console.WriteLine("Shift: New state:" + yyNewState + "  Token ID: " + yyMajor + "  Value: " + yyMinor);
            }
            if (yyNewState > YY_MAX_SHIFT)
            {
                yyNewState += YY_MIN_REDUCE - YY_MIN_SHIFTREDUCE;
            }
            if (!NDEBUG)
            {
                Console.WriteLine("Pushing: New state:" + yyNewState + "  Token ID: " + yyMajor + " Value: " + yyMinor);
                Console.WriteLine("ParserStack:\r\n" + ParserStack);
            }
            ParserStack.Push(yyNewState, yyMajor, yyMinor);
        }

        protected int Reduce(int yyruleno, int yyLookahead, YYMINORTYPE yyminor)
        {
            if (!NDEBUG)
            {
                Console.WriteLine("Reduce: Rule No:" + yyruleno + "  Lookahead Token ID: " + yyLookahead + "  Value: " + yyminor);
            }
            int yygoto;                     /* The next state */
            int yyact;                      /* The next action */
            int yysize;                     /* Amount to pop the stack */

            YYMINORTYPE result = ExecuteReductions(yyruleno);

            yygoto = yyRuleInfo[yyruleno].lhs;
            yysize = -yyRuleInfo[yyruleno].nrhs;
            for (int i = 0; i < yysize; ++i)
                ParserStack.Pop();
            //yyact = FindReduceAction(ParserStack.yytos.stateno, yygoto);

            if (!NDEBUG)
            {
                Console.WriteLine("Popping " + yysize + " times.");
                Console.WriteLine("ParserStack:\r\n" + ParserStack);
            }

            yyact = FindReduceAction(ParserStack.yytos.stateno, yygoto);

            if (!NDEBUG)
            {
                Console.WriteLine("Pushing: State:" + yyact + "  Go To ID: " + yygoto + "  Value: " + result);
                Console.WriteLine("ParserStack:\r\n" + ParserStack);
            }

            ParserStack.Push(yyact, yygoto, result);
            return yyact;
        }

        internal int FindReduceAction(int stateno, int iLookAhead)
        {

            if (YYERRORSYMBOL > 0)
            {
                if (stateno > YY_REDUCE_COUNT)
                {
                    return yy_default[stateno];
                }
            }

            int i = yy_reduce_ofst[stateno];
            i += iLookAhead;

            if (YYERRORSYMBOL > 0)
            {
                if (i < 0 || i >= YY_ACTTAB_COUNT || yy_lookahead[i] != iLookAhead)
                {
                    return yy_default[stateno];
                }
            }

            if (!NDEBUG)
            {
                Console.WriteLine("FindReduceAction: State:" + stateno + "  Look ahead ID: " + yy_action[i]);
            }

            return yy_action[i];
        }

        public void End()
        {
            Parse(0, null);
        }

    } // End class Parser

    internal class ShiftReduceStack : Stack<ParserStackEntry>
    {
        internal ParserStackEntry yytos => Peek();

        internal void Push(int state, int sym, YYMINORTYPE v)
        {
            Push(new ParserStackEntry(state, sym, v));
        }

        public ParserStackEntry this[int key]
        {
            get => this.ElementAt(-key);
            set => this.ElementAt(-key);
        }

        public override string ToString()
        {
            int i = 0;
            return this.Aggregate("", (current, entry) => current + ("\r\n[" + i++ + "] " + entry));
        }
    }

    internal class ParserStackEntry
    {
        internal int stateno { get; set; } = 0;
        internal int major { get; set; } = 0;
        internal YYMINORTYPE minor
        {
            get; set;
        }

        internal ParserStackEntry(int state, int sym, YYMINORTYPE y)
        {
            stateno = state;
            major = sym;
            minor = y;
        }

        public override string ToString()
        {
            return "{" + stateno + "," + major + "," + minor + "}";
        }

    }

    internal class Rule
    {
        internal int lhs;       /* Symbol on the left-hand side of the rule */
        internal int nrhs;     /* Negative of the number of RHS symbols in the rule */

        internal Rule(int left, int right)
        {
            lhs = left;
            nrhs = right;
        }

        public override string ToString()
        {
            return "{" + lhs + "," + nrhs + "}";
        }

    }

}
