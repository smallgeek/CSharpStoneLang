
namespace CSharpStoneLang
{
    [Serializable]
    internal class StoneException : Exception
    {
        public StoneException()
        {
        }

        public StoneException(string? message) : base(message)
        {
        }
    }
}
