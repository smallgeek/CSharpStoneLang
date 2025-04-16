using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Parsers
{
    public class BlockStmnt : ASTList
    {
        public BlockStmnt(IList<ASTree> source) : base(source)
        {
        }
    }
}
