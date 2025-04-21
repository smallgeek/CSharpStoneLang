using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// while文
    /// </summary>
    public class WhileStmnt : ASTList
    {
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="source"></param>
        public WhileStmnt(IList<ASTree> source) : base(source)
        {
        }

        /// <summary>
        /// 条件
        /// </summary>
        public ASTree Condition => children[0];

        /// <summary>
        /// ループ処理
        /// </summary>
        public ASTree Body => children[1];

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public override object Eval(IEnviroment env)
        {
            object result = 0;

            while (true)
            {
                object c = Condition.Eval(env);
                if (c is int value && value == FALSE)
                {
                    return result;
                }
                result = Body.Eval(env);
            }
        }

        public override string ToString()
        {
            return "(while " + Condition + " " + Body + ")";
        }
    }
}
