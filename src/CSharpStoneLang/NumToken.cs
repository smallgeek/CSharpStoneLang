using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStoneLang
{
    /// <summary>
    /// 数値トークン
    /// </summary>
    public class NumToken : Token
    {
        private int value;

        public override bool IsNumber => true;
        public override string Text => value.ToString();
        public override int Number => value;

        public NumToken(int line, int v) : base(line)
        {
            value = v;
        }
    }
}
