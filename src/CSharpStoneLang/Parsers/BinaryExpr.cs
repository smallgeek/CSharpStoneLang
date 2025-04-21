using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// 二項演算式
    /// </summary>
    public class BinaryExpr : ASTList
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public BinaryExpr(IList<ASTree> source) : base(source)
        {
        }

        /// <summary>
        /// 左の項
        /// </summary>
        public ASTree Left => children[0];

        /// <summary>
        /// 演算子
        /// </summary>
        public string Operator => ((ASTLeaf)children[1]).Token.Text;

        /// <summary>
        /// 右の項
        /// </summary>
        public ASTree Right => children[2];

        public override object Eval(IEnviroment env)
        {
            string op = Operator;

            if (op == "=")
            {
                object right = Right.Eval(env);
                return ComputeAssign(env, right);
            }
            else
            {
                object left = Left.Eval(env);
                object right = Right.Eval(env);
                return ComputeOp(left, op, right);
            }
        }

        /// <summary>
        /// 代入
        /// </summary>
        /// <param name="env"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="StoneException"></exception>
        private object ComputeAssign(IEnviroment env, object right)
        {
            if (Left is Name name)
            {
                env.Put(name.Value, right);
                return right;
            }
            throw new StoneException("bad assignment");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="op"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private object ComputeOp(object left, string op, object right)
        {
            if (left is int lv && right is int rv)
            {
                return ComputeNumber(lv, op, rv);
            }

            if (op == "+")
            {
                return left.ToString() + right.ToString();
            }

            if (op == "==")
            {
                if (left == null)
                {
                    return right == null ? TRUE : FALSE;
                }
                else
                {
                    return left.Equals(right) ? TRUE : FALSE;
                }
            }

            throw new StoneException("bad type");
        }

        private object ComputeNumber(int lv, string op, int rv)
        {
            if (op == "+")
            {
                return lv + rv;
            }
            if (op == "-")
            {
                return lv - rv;
            }
            if (op == "*")
            {
                return lv * rv;
            }
            if (op == "/")
            {
                return lv / rv;
            }
            if (op == "%")
            {
                return lv % rv;
            }
            if (op == "==")
            {
                return lv == rv ? TRUE : FALSE;
            }
            if (op == ">")
            {
                return lv > rv ? TRUE : FALSE;
            }
            if (op == "<")
            {
                return lv < rv ? TRUE : FALSE;
            }

            throw new StoneException("bad operator");
        }
    }
}
