using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStoneLang
{
    /// <summary>
    /// 文字列トークン
    /// </summary>
    public class StrToken : Token
    {
        private string literal;

        public override bool IsString => true;

        public override string Text => literal;

        public StrToken(int line, string str) : base(line)
        {
            literal = str;
        }
    }
}
