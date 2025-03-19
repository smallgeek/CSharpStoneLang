using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStoneLang
{
    public class ParseException : Exception
    {
        public ParseException(Token token) : this("", token)
        {
        }

        public ParseException(string message, Token token)
            : base("syntax error around " + Location(token) + ". " + message)
        {
        }
        public ParseException(string message) : base(message)
        {
        }

        public ParseException(Exception ex) : base(ex.Message, ex)
        {
        }

        private static string Location(Token token)
        {
            if (token == Token.EOF)
            {
                return "the last line";
            }
            else
            {
                return "\"" + token.Text + "\" at line " + token.LineNumber;
            }
        }
    }
}
