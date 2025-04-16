using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class PrimaryExpr : ASTList
    {
        public PrimaryExpr(IList<ASTree> source) : base(source)
        {
        }

        public static ASTree Create(List<ASTree> children)
        {
            return children.Count == 1 ? children[0] : new PrimaryExpr(children);
        }
    }
}
