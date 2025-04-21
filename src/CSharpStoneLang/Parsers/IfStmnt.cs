using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// IF文
    /// </summary>
    public class IfStmnt : ASTList
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public IfStmnt(IList<ASTree> source) : base(source)
        {
        }

        /// <summary>
        /// 条件
        /// </summary>
        public ASTree Condition => children[0];

        /// <summary>
        /// 真の場合
        /// </summary>
        public ASTree ThenBlock => children[1];

        /// <summary>
        /// 偽の場合
        /// </summary>
        public ASTree? ElseBlock => NumChildren > 2 ? children[2] : null;

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public override object Eval(IEnviroment env)
        {
            object cond = Condition.Eval(env);

            if (cond is int c && c == FALSE)
            {
                return ThenBlock.Eval(env);
            }
            ASTree? b = ElseBlock;
            if (b == null)
            {
                return 0;
            }

            return b.Eval(env);
        }

        public override string ToString()
        {
            return "(if " + Condition + " " + ThenBlock + " else " + ElseBlock + ")";
        }
    }
}
