# GitHub Actions Custom Action Sample

このリポジトリは、入力メッセージを表示するだけのシンプルなカスタム GitHub Action を提供します。

## 📌 概要
- `with: message` で渡された文字列をログに出力します。
- 他のリポジトリから呼び出して利用できます。

## 🚀 使用方法

任意のリポジトリの workflow で以下のように設定します。

```yaml
jobs:
  test_custom_action:
    runs-on: ubuntu-latest
    steps:
      - name: Use custom action
        uses: your-username/gh-actions-custom-action-sample@main
        with:
          message: "Hello from another repository!"
```

## ✅ 実行結果

GitHub Actions のログに以下のように表示されます。

```
Received message: Hello from another repository!
```

## 📂 リポジトリ構成

```
gh-actions-custom-action-sample/
├── action.yml      # アクションのメタデータ
├── entrypoint.sh   # 実行されるスクリプト
└── README.md
```

## 📝 カスタマイズ

`entrypoint.sh` を編集することで、アクションの動作を自由に変更できます。
