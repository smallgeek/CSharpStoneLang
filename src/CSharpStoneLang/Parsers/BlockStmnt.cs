using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class BlockStmnt : ASTList
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public BlockStmnt(IList<ASTree> source) : base(source)
        {
        }

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public override object Eval(IEnviroment env)
        {
            object result = 0;
            foreach (ASTree t in this)
            {
                if (t is not NullStmnt)
                {
                    result = t.Eval(env);
                }
            }
            return result;
        }
    }
}
