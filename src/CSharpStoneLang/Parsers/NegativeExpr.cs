using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// マイナス
    /// </summary>
    public class NegativeExpr : ASTList
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public NegativeExpr(IList<ASTree> source) : base(source)
        {
        }

        /// <summary>
        /// 演算子
        /// </summary>
        public ASTree Operand => children[0];

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        /// <exception cref="StoneException"></exception>
        public override object Eval(IEnviroment env)
        {
            object v = Operand.Eval(env);
            if (v is int n)
            {
                return n * -1;
            }
            throw new StoneException("bad type for -");
        }

        public override string ToString()
        {
            return "-" + Operand;
        }
    }
}
