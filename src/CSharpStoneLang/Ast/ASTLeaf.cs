namespace CSharpStoneLang.Ast
{
    /// <summary>
    /// 抽象構文木の葉
    /// </summary>
    public class ASTLeaf : ASTree
    {
        private static readonly List<ASTree> empty = new();

        protected Token token;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public ASTLeaf(Token t)
        {
            token = t;
        }

        /// <summary>
        /// 字句解析トークン
        /// </summary>
        public Token Token => token;

        /// <summary>
        /// 子の数
        /// </summary>
        public override int NumChildren => 0;

        /// <summary>
        /// 子要素一覧
        /// </summary>
        public override IEnumerable<ASTree> Children => empty;

        /// <summary>
        /// 節のプログラム内での位置を表す文字列
        /// </summary>
        public override string Location => "at line " + token.LineNumber;

        /// <summary>
        /// 指定された位置の子を返す
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public override ASTree Child(int i) => throw new IndexOutOfRangeException();

        public override IEnumerator<ASTree> GetEnumerator() => empty.GetEnumerator();
    }
}
