using CSharpStoneLang.Ast;
using CSharpStoneLang.Parsers;

namespace CSharpStoneLang
{
    /// <summary>
    /// Stone言語のインタプリタ
    /// </summary>
    public class BasicInterpreter
    {
        public static void Run(Stream stream, BasicParser parser, IEnviroment env)
        {
            Lexer lexer = new(stream);

            while (lexer.Peek(0) != Token.EOF)
            {
                ASTree t = parser.Parse(lexer);
                if (t is not NullStmnt)
                {
                    object r = t.Eval(env);
                    Console.WriteLine("=> " + r);
                }
            }
        }
    }
}
