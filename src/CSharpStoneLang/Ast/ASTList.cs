using System.Text;

namespace CSharpStoneLang.Ast
{
    /// <summary>
    /// 抽象構文木の節
    /// </summary>
    public class ASTList : ASTree
    {
        protected IList<ASTree> children;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public ASTList(IList<ASTree> source)
        {
            children = source;
        }

        /// <summary>
        /// 子の数
        /// </summary>
        public override int NumChildren => children.Count;

        /// <summary>
        /// 子要素一覧
        /// </summary>
        public override IEnumerable<ASTree> Children => children;

        /// <summary>
        /// 節のプログラム内での位置を表す文字列
        /// </summary>
        public override string Location
        {
            get
            {
                foreach (var t in children)
                {
                    string s = t.Location;
                    if (s != null)
                    {
                        return s;
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 指定された位置の子を返す
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override ASTree Child(int i) => children[i];

        public override IEnumerator<ASTree> GetEnumerator() => children.GetEnumerator();

        /// <summary>
        /// 節を表す文字列を返す
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append('(');

            // 子をスペース区切りで並べる
            string sep = "";
            foreach (var t in children)
            {
                builder.Append(sep);
                sep = " ";
                builder.Append(t.ToString());
            }
            return builder.Append(')').ToString();
        }
    }
}
