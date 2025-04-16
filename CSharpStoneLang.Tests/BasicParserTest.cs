using System.Text;
using CSharpStoneLang.Ast;

namespace CSharpStoneLang.Tests;

[TestClass]
public class BasicParserTest
{
    [TestMethod]
    public void コード1行の構文解析をテストする()
    {
        string code = "even = 0";
        using MemoryStream stream = new(Encoding.UTF8.GetBytes(code));

        Lexer target = new(stream);

        BasicParser parser = new();
        ASTree ast = parser.Parse(target);

        Assert.AreEqual("(even = 0)", ast.ToString());
    }
}
