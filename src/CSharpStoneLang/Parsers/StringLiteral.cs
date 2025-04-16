using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class StringLiteral : ASTLeaf
    {
        public StringLiteral(Token t) : base(t)
        {
        }

        public string Value => token.Text;
    }
}
