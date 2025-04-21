namespace CSharpStoneLang
{
    /// <summary>
    /// 変数の名前と値を管理するデータ構造
    /// </summary>
    public interface IEnviroment
    {
        /// <summary>
        /// 変数を追加
        /// </summary>
        /// <param name="name">変数名</param>
        /// <param name="value"></param>
        void Put(string name, object value);

        /// <summary>
        /// 変数の値を取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object Get(string name);
    }
}
