namespace CSharpStoneLang
{
    /// <summary>
    /// 変数の名前と値を管理するデータ構造
    /// </summary>
    public class BasicEnviroment : IEnviroment
    {
        private readonly Dictionary<string, object> values = new();

        /// <summary>
        /// 変数を追加
        /// </summary>
        /// <param name="name">変数名</param>
        /// <param name="value"></param>
        public void Put(string name, object value)
        {
            values.Add(name, value);
        }

        /// <summary>
        /// 変数の値を取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Get(string name)
        {
            return values[name];
        }
    }
}
