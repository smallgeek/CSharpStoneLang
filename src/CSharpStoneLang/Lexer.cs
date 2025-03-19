using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpStoneLang
{
    /// <summary>
    /// 字句解析器
    /// </summary>
    public class Lexer
    {
        /// <summary>
        /// 字句解析の正規表現パターン。
        /// </summary>
        public static readonly string RegexPat = "\\s*((//.*)|([0-9]+)|(\"(\\\\\"|\\\\\\\\|\\\\n|[^\"])*\")"
          + "|[A-Z_a-z][A-Z_a-z0-9]*|==|<=|>=|&&|\\|\\||[!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~])?";

        private Regex regex = new(RegexPat, RegexOptions.Compiled);
        private List<Token> queue = new();
        private bool hasMore;
        private int lineNo;
        private StreamReader reader;

        public Lexer(Stream stream)
        {
            hasMore = true;
            reader = new StreamReader(stream);
        }

        /// <summary>
        /// トークンを読み込み返す。末端まで読み終えている場合は EOF を返す。
        /// </summary>
        /// <returns></returns>
        public Token Read()
        {
            if (FillQueue(0))
            {
                var token = queue[0];
                queue.Remove(token);
                return token;
            }
            else
            {
                return Token.EOF;
            }
        }

        /// <summary>
        /// トークンの先読み
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Token Peek(int i)
        {
            if (FillQueue(i))
            {
                return queue[i];
            }
            else
            {
                return Token.EOF;
            }
        }

        private bool FillQueue(int i)
        {
            while (i >= queue.Count)
            {
                if (hasMore)
                {
                    ReadLine();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        protected void ReadLine()
        {
            string? line;
            try
            {
                line = reader.ReadLine();
            }
            catch (Exception ex)
            {
                throw new ParseException(ex);
            }

            if (line == null)
            {
                hasMore = false;
                return;
            }

            lineNo++;

            int pos = 0;
            int endPos = line.Length;
            while (pos < endPos)
            {
                Match match = regex.Match(line, pos, endPos - pos);

                if (match.Success)
                {
                    AddToken(lineNo, match);
                    pos += match.Captures[0].Length;
                }
                else
                {
                    throw new ParseException("bad token ad line " + lineNo);
                }
            }

            queue.Add(new IdToken(lineNo, Token.EOL));
        }

        protected void AddToken(int lineNo, Match match)
        {
            string m = match.Groups[1].Value;

            // スペースではない
            if (!string.IsNullOrEmpty(m))
            {
                // コメントではない
                if (string.IsNullOrEmpty(match.Groups[2].Value))
                {
                    Token token;
                    if (!string.IsNullOrEmpty(match.Groups[3].Value))
                    {
                        token = new NumToken(lineNo, int.Parse(m));
                    }
                    else if (!string.IsNullOrEmpty(match.Groups[4].Value))
                    {
                        token = new StrToken(lineNo, ToStringLiteral(m));
                    }
                    else
                    {
                        token = new IdToken(lineNo, m);
                    }
                    queue.Add(token);
                }
            }
        }

        protected string ToStringLiteral(string s)
        {
            StringBuilder sb = new();
            int len = s.Length - 1;
            for (int i = 1; i < len; i++)
            {
                char c = s[i];
                if (c == '\\' && i + 1 < len)
                {
                    int c2 = s[i + 1];
                    if (c2 == '"' || c2 == '\\')
                    {
                        c = s[++i];
                    }
                    else if (c2 == 'n')
                    {
                        ++i;
                        c = '\n';
                    }
                }
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
