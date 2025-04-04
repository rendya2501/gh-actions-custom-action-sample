# GitHub Actions Customr Action Sample

このリポジトリでは、**任意のメッセージを出力するカスタム GitHub Composite Action** を定義しています。  
外部リポジトリから呼び出すことで、再利用可能なメッセージ出力処理を提供します。

## 📌 概要

- Aリポジトリ（[`gh-actions-runner-sample`](https://github.com/rendya2501/gh-actions-runner-sample)）のワークフロー実行側から呼び出されます  
- `with:` で渡されたメッセージをログに出力  
- `GITHUB_OUTPUT` に値を設定し、呼び出し元のワークフローで参照可能  

## 🗙 `action.yml`

```yaml
name: "Hello World Custom Action"
description: "Outputs a custom message"

inputs:
  message:
    description: "Message to print"
    required: false
    default: "Hello World"

outputs:
  script_result:
    description: "Output from script"
    value: ${{ steps.process_message.outputs.script_result }}
  echo_result:
    description: "Output from echo"
    value: ${{ steps.set-result.outputs.echo_result }}

runs:
  using: "composite"
  steps:
    - name: Process message
      id: process_message
      run: bash ${{ github.action_path }}/entrypoint.sh "${{ inputs.message }}"
      shell: bash

    - name: Return message
      id: set-result
      run: echo "echo_result=Echo Processed: ${{ inputs.message }} (hogehoge)" >> $GITHUB_OUTPUT
      shell: bash
```

## 🖋 `entrypoint.sh`

```bash
#!/bin/bash
set -e

MESSAGE=$1

echo "Received message: $MESSAGE"

echo "script_result=Script Processed: $MESSAGE" >> "$GITHUB_OUTPUT"
```

## ✅ 出力内容

カスタムアクションの呼び出し元では、次のように出力を取得できます：

- `script_result`: スクリプト内で処理された結果  
- `echo_result`: echo によって加工されたメッセージ  

## 🔍 注意点

- `echo "key=value" >> $GITHUB_OUTPUT` で値を渡す形式は、Composite Action での出力定義に必須です。  
- `${{ }}` の中で変数展開を行う場合、`"` ダブルクォートで囲む必要があります。

## 💡 利用例

別リポジトリから次のように呼び出します：

```yaml
uses: rendya2501/gh-actions-custom-action-sample@main
with:
  message: "Hello from another repository!"
```
