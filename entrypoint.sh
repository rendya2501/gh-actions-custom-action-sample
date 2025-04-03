#!/bin/bash
set -e  # エラー発生時にスクリプトを終了
MESSAGE=$1
echo "Received message: $MESSAGE"

# GitHub Actions の output (outputs に渡す)
echo "script_result=Script Processed: $MESSAGE" >> "$GITHUB_OUTPUT"

# GitHub Actions の環境変数 (環境変数に設定)
# echo "env_result=Env Processed: $1" >> "$GITHUB_ENV"
