using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// 文字列リテラル
    /// </summary>
    public class StringLiteral : ASTLeaf
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public StringLiteral(Token t) : base(t)
        {
        }

        /// <summary>
        /// 文字列
        /// </summary>
        public string Value => token.Text;

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public override object Eval(IEnviroment env)
        {
            return Value;
        }
    }
}
