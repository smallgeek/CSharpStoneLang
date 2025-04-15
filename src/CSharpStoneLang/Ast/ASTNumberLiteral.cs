namespace CSharpStoneLang.Ast
{
    /// <summary>
    /// 数値リテラル
    /// </summary>
    /// <example>1、256、12000</example>
    public class ASTNumberLiteral : ASTLeaf
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public ASTNumberLiteral(Token t)
            : base(t)
        {
        }

        /// <summary>
        /// 数値
        /// </summary>
        public int Value => token.Number;
    }
}
