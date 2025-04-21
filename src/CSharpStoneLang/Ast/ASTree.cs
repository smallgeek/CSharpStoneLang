using System.Collections;

namespace CSharpStoneLang.Ast
{
    public abstract class ASTree : IEnumerable<ASTree>
    {
        public const int TRUE = 1;
        public const int FALSE = 0;

        /// <summary>
        /// 子の数
        /// </summary>
        /// <returns></returns>
        public abstract int NumChildren { get; }

        /// <summary>
        /// 子要素一覧
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<ASTree> Children { get; }

        /// <summary>
        /// 節のプログラム内での位置を表す文字列
        /// </summary>
        /// <returns></returns>
        public abstract string Location { get; }

        /// <summary>
        /// 指定された位置の子を返す
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public abstract ASTree Child(int i);

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public abstract object Eval(IEnviroment env);

        public abstract IEnumerator<ASTree> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
