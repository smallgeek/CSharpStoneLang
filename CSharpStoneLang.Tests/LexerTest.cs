using System.Text;

namespace CSharpStoneLang.Tests
{
    [TestClass]
    public class LexerTest
    {
        [TestMethod]
        public void 変数への代入をテストする()
        {
            string code = "i = 10";
            using MemoryStream stream = new(Encoding.UTF8.GetBytes(code));

            Lexer target = new(stream);

            Assert.AreEqual("i", target.Read().Text);
            Assert.AreEqual("=", target.Read().Text);
            Assert.AreEqual("10", target.Read().Text);
        }
    }
}
