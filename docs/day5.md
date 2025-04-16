# 構文解析器を作る

## Stone言語の文法定義

```
NUMBER...整数リテラル
IDENTIFIER...識別子
STRING...文字列リテラル
OP...2項演算子
EOL...終端記号

primary   ::= "(" expr ")" | NUMBER | IDENTIFIER | STRING
factor    ::= "-" primary | primary
expr      ::= factor { OP factor }
block     ::= "{" [ statement ] {(";" | EOL) [ statement ]} "}"
simple    ::= expr
statement ::= " if" expr block [ "else" block ] | "while" expr block | simple
program   ::= [ statement ] (";" | EOL)
```