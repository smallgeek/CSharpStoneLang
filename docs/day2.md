# あいまいさのない言語

言語をデザインするときは、あいまいな文法を生まないようにする。あいまいな文法の例として *dangling-else問題* がある。

## dangling-else問題
C# では if や for ステートメントで中かっこを省略できるため、以下の記述が可能となる。

```csharp
var input = Console.ReadLine();
string result = "???";

if (input.StartsWith("'"))
    if (input.EndsWith("'"))
        result = "yes";
else
    result = "no";

Console.WriteLine(result);
```

このとき入力された文字列の文頭が区切り文字ではないの結果に no を期待するが、実際には ??? が返ってくる。上記コードは本来

```csharp
var input = Console.ReadLine();
string result = "???";

if (input.StartsWith("'"))
{
    if (input.EndsWith("'"))
    {
        result = "yes";
    }
    else
    {
        result = "no";
    }
}

Console.WriteLine(result);
```

と同じである。変数に再代入せず結果を関数として返すようにすることでコンパイラでエラー検知できる。

```csharp
// エラー: 値を返さないコード パスがあります
private static string Analyze(string input)
{
    if (input.StartsWith("'"))
    {
        if (input.EndsWith("'"))
        {
            return "yes";
        }
    }
    else
    {
        return "no";
    }
}
```

いずれにしても、制御構文での中かっこ省略は避けるようにしたい。
