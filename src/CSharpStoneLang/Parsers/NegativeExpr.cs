using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class NegativeExpr : ASTList
    {
        public NegativeExpr(IList<ASTree> source) : base(source)
        {
        }

        public ASTree Operand => children[0];

        public override string ToString()
        {
            return "-" + Operand;
        }
    }
}
