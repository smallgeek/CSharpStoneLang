namespace CSharpStoneLang.Ast
{
    /// <summary>
    /// 2項演算
    /// </summary>
    public class ASTBinaryExpr : ASTList
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public ASTBinaryExpr(IList<ASTree> source) : base(source)
        {
        }

        /// <summary>
        /// 左の項
        /// </summary>
        public ASTree Left => children[0];

        /// <summary>
        /// 右の項
        /// </summary>
        public ASTree Right => children[1];
    }
}
