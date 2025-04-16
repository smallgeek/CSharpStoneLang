using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class IfStmnt : ASTList
    {
        public IfStmnt(IList<ASTree> source) : base(source)
        {
        }

        public ASTree Condition => children[0];
        public ASTree ThenBlock => children[1];
        public ASTree? ElseBlock => NumChildren > 2 ? children[2] : null;

        public override string ToString()
        {
            return "(if " + Condition + " " + ThenBlock + " else " + ElseBlock + ")";
        }
    }
}
