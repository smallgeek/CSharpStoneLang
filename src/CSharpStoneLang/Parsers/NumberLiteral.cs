using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// 数値リテラル
    /// </summary>
    public class NumberLiteral : ASTLeaf
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public NumberLiteral(Token t) : base(t)
        {
        }

        /// <summary>
        /// 数値
        /// </summary>
        public int Value => token.Number;

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public override object Eval(IEnviroment env) => Value;
    }
}
