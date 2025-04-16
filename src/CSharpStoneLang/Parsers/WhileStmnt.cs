using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class WhileStmnt : ASTList
    {
        public WhileStmnt(IList<ASTree> source) : base(source)
        {
        }

        public ASTree Condition => children[0];
        public ASTree Body => children[1];
        public override string ToString()
        {
            return "(while " + Condition + " " + Body + ")";
        }
    }
}
