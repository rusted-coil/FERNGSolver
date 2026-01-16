@echo off
setlocal enabledelayedexpansion

rem --- スクリプトの場所をルートとして扱う ---
pushd "%~dp0"
set "SCRIPT_DIR=%CD%"

rem --- 設定（必要ならここを編集） ---
set "PROJECT_PATH=%SCRIPT_DIR%\FERNGSolver\FERNGSolver.csproj"
set "OUTPUT_DIR=%SCRIPT_DIR%\publish\win-x64"
set "TMP_DIR=%SCRIPT_DIR%\_publish_tmp"

rem --- Publish 実行 ---
echo ==================================================
echo Publishing project: "%PROJECT_PATH%"
echo Output directory: "%OUTPUT_DIR%"
echo ==================================================
dotnet publish "%PROJECT_PATH%" -c Release -r win-x64 /p:PublishSingleFile=true /p:SelfContained=false /p:PublishTrimmed=false -o "%OUTPUT_DIR%"
if errorlevel 1 (
  echo.
  echo ★ Publish に失敗しました。出力ログを確認してください。
  popd
  endlocal
  exit /b 1
)

rem --- 出力フォルダ存在確認 ---
if not exist "%OUTPUT_DIR%" (
  echo.
  echo ★ 出力フォルダが見つかりません: "%OUTPUT_DIR%"
  popd
  endlocal
  exit /b 1
)

rem --- 一時フォルダ作成（既存なら削除） ---
if exist "%TMP_DIR%" rd /s /q "%TMP_DIR%"
mkdir "%TMP_DIR%"

rem --- exe を一時退避（存在しなくても続行） ---
echo Preserving .exe files...
move /Y "%OUTPUT_DIR%\*.exe" "%TMP_DIR%\" >nul 2>&1

rem --- 出力フォルダの完全クリーン ---
echo Cleaning output directory...
rd /s /q "%OUTPUT_DIR%"
mkdir "%OUTPUT_DIR%"

rem --- exe を戻す ---
echo Restoring .exe files...
move /Y "%TMP_DIR%\*.exe" "%OUTPUT_DIR%\" >nul 2>&1

rem --- 一時フォルダ削除 ---
if exist "%TMP_DIR%" rd /s /q "%TMP_DIR%"

echo.
echo 完了: 単一 exe は次の場所にあります:
for %%F in ("%OUTPUT_DIR%\*.exe") do echo    %%~fF
echo ==================================================

popd
endlocal
exit /b 0