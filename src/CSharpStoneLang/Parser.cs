using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CSharpStoneLang.Ast;
using CSharpStoneLang.Parsers;

namespace CSharpStoneLang
{
    /// <summary>
    /// パーサ・コンビネーター。文法規則のパターンを表す
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Parserオブジェクトを作る
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Parser Rule()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parserオブジェクトを作る
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Parser Rule(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 構文解析する
        /// </summary>
        /// <param name="lexer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ASTree Parse(Lexer lexer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 整数リテラルを規則に追加する
        /// </summary>
        /// <returns></returns>
        public Parser Number()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 整数リテラルを規則に追加する
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Parser Number(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 終端記号(予約語rを除く識別子)を規則に追加する
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Identifier(HashSet<string> r)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 終端記号(予約語rを除く識別子)を規則に追加する
        /// </summary>
        /// <param name="type"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Identifier(Type type, HashSet<string> r)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 終端記号(文字列リテラル)を規則に追加する
        /// </summary>
        /// <returns></returns>
        public Parser String()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 終端記号(文字列リテラル)を規則に追加する
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Parser String(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 終端記号(patに合致する識別子)を規則に追加する
        /// </summary>
        /// <param name="pat"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Token(params string[] pat)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 抽象構文木に含めない終端記号(patに合致する識別子を規則に追加する)
        /// </summary>
        /// <param name="pat"></param>
        /// <returns></returns>
        public Parser Separator(params string[] pat)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 非終端記号pを規則に追加する
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Parser Ast(Parser p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 省略可能な非終端記号pを規則に追加する
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Parser Option(Parser p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 省略可能な非終端記号pを規則に追加する(省略時には根だけの抽象構文木とする)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Maybe(Parser p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 非終端記号のorを規則に追加する
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Or(params Parser[] p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 非終端記号pの0回以上の繰り返しを規則に追加する
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Repeat(Parser p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 2項演算式の規則を追加する
        /// </summary>
        /// <param name="p"></param>
        /// <param name="op"></param>
        public Parser Expression(Parser p, Operators op)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 2項演算式の規則を追加する
        /// </summary>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <param name="op"></param>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Expression(Type t, Parser p, Operators op)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 文法規則を空にする
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 文法規則を空にし、節のクラスをtypeにする
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Parser Reset(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 文法規則の先頭のorに新たな選択肢を挿入する
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Parser InsertChoice(Parser p)
        {
            throw new NotImplementedException();
        }
    }
}
