using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    /// <summary>
    /// 名称
    /// </summary>
    public class Name : ASTLeaf
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public Name(Token t) : base(t)
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Value => token.Text;

        /// <summary>
        /// 抽象構文木を評価する
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        /// <exception cref="StoneException"></exception>
        public override object Eval(IEnviroment env)
        {
            object value = env.Get(Value);
            return value == null ? throw new StoneException("undefined name: " + Value) : value;
        }
    }
}
