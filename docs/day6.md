# インタプリタによる実行

インタプリタでは抽象構文木の節をたどりプログラムを実行する。節の子のevalメソッドを再帰的に呼び出し、戻り値を集めてから自身の戻り値を計算し、呼び出しもとに返す。


Stone言語では変数が使用できるため、引数の環境オブジェクトを渡して参照できるようにする。

```csharp
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
```