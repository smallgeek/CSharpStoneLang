namespace CSharpStoneLang.Ast
{
    /// <summary>
    /// 名前付きの抽象構文木の葉
    /// </summary>
    public class ASTName : ASTLeaf
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public ASTName(Token t)
            : base(t)
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name => token.Text;
    }
}
