using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class NumberLiteral : ASTLeaf
    {
        public NumberLiteral(Token t) : base(t)
        {
        }
    }
}
