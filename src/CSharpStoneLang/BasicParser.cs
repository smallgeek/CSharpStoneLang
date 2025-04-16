using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;
using CSharpStoneLang.Parsers;
using static CSharpStoneLang.Parser;

namespace CSharpStoneLang
{
    public class BasicParser
    {
        private HashSet<string> reserved = new();
        private Operators operators = new();

        /*
         * primary   ::= "(" expr ")" | NUMBER | IDENTIFIER | STRING
           factor    ::= "-" primary | primary
           expr      ::= factor { OP factor }
           block     ::= "{" [ statement ] {(";" | EOL) [ statement ]} "}"
           simple    ::= expr
           statement ::= " if" expr block [ "else" block ] | "while" expr block | simple
           program   ::= [ statement ] (";" | EOL)
         */

        private Parser expr0;
        private Parser primary;
        private Parser factor;
        private Parser expr;
        private Parser statement0;
        private Parser block;
        private Parser simple;
        private Parser statement;
        private Parser program;

        public BasicParser()
        {
            expr0 = Rule();

            // primary ::= "(" expr ")" | NUMBER | IDENTIFIER | STRING
            primary = Rule(typeof(PrimaryExpr))
                .Or(Rule().Separator("(").Ast(expr0).Separator(")"),
                    Rule().Number(typeof(NumberLiteral)),
                    Rule().Identifier(typeof(Name), reserved),
                    Rule().String(typeof(StringLiteral)));

            // factor ::= "-" primary | primary
            factor = Rule().Or(Rule(typeof(NegativeExpr)).Separator("-").Ast(primary), primary);
            // expr ::= factor { OP factor }
            expr = expr0.Expression(typeof(BinaryExpr), factor, operators);

            statement0 = Rule();

            // block ::= "{" [ statement ] {(";" | EOL) [ statement ]} "}"
            block = Rule(typeof(BlockStmnt))
                .Separator("{")
                .Option(statement0)
                .Repeat(Rule().Separator(";", Token.EOL).Option(statement0))
                .Separator("}");

            // simple ::= expr
            simple = Rule(typeof(PrimaryExpr)).Ast(expr);

            // statement ::= " if" expr block [ "else" block ] | "while" expr block | simple
            statement = statement0
                .Or(Rule(typeof(IfStmnt)).Separator("if").Ast(expr).Ast(block).Option(Rule().Separator("else").Ast(block)),
                    Rule(typeof(WhileStmnt)).Separator("while").Ast(expr).Ast(block),
                    simple);

            // program ::= [ statement ] (";" | EOL)
            program = Rule().Or(statement, Rule(typeof(NullStmnt)).Separator(";", Token.EOL));

            // 終端文字の登録
            reserved.Add(";");
            reserved.Add("}");
            reserved.Add(Token.EOL);

            // 演算子の登録
            operators.Add("=" , 1, Operators.RIGHT);
            operators.Add("==", 2, Operators.LEFT);
            operators.Add(">",  2, Operators.LEFT);
            operators.Add("<",  2, Operators.LEFT);
            operators.Add("+",  3, Operators.LEFT);
            operators.Add("-",  3, Operators.LEFT);
            operators.Add("*",  4, Operators.LEFT);
            operators.Add("/",  4, Operators.LEFT);
            operators.Add("%",  4, Operators.LEFT);
        }

        public ASTree Parse(Lexer lexer)
        {
            return program.Parse(lexer);
        }
    }
}
