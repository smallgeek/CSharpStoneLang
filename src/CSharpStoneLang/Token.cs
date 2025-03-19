namespace CSharpStoneLang
{
    /// <summary>
    /// 字句解析の結果を表すトークン。
    /// </summary>
    public class Token(int line)
    {
        public int LineNumber => line;

        /// <summary>
        /// トークンが識別子かどうか
        /// </summary>
        public virtual bool IsIdentifier => false;

        /// <summary>
        /// トークンが整数リテラルかどうか
        /// </summary>
        public virtual bool IsNumber => false;

        /// <summary>
        /// トークンが文字列リテラルかどうか
        /// </summary>
        public virtual bool IsString => false;

        /// <summary>
        /// 文字
        /// </summary>
        public virtual string Text { get; }

        /// <summary>
        /// 数値
        /// </summary>
        public virtual int Number { get; }

        /// <summary>
        /// end of file
        /// </summary>
        public static readonly Token EOF = new Token(-1);

        /// <summary>
        /// end of line
        /// </summary>
        public static readonly string EOL = "\\n";
    }
}
