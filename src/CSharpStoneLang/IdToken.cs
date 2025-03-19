using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStoneLang
{
    /// <summary>
    /// 識別子トークン
    /// </summary>
    public class IdToken : Token
    {
        private string text;

        public override bool IsIdentifier => true;

        public override string Text => text;

        public IdToken(int line, string id) : base(line)
        {
            text = id;
        }
    }
}
