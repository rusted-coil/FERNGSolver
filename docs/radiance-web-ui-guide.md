# 蒼炎の軌跡 Web版（Blazor WASM）UI調整ガイド

「見た目や配置、項目を調整したいとき、どのファイルを触ればいいか」の早見表です。
対象は `FERNGSolver.Radiance.Web`（ホストアプリ）と `FERNGSolver.Radiance.UI.Blazor`（画面部品）です。

## 1. 全体構成

```
FERNGSolver.Radiance.Web/            ← ホスト（起動プロジェクト。ページの入れ物）
  Pages/Home.razor                     - トップページ（中身は1行、実体は下記コンポーネント）
  Layout/MainLayout.razor              - 全画面共通のヘッダー・MudBlazorの各Providerの初期化
  wwwroot/index.html                   - HTML雛形、<title>やフォント等の読み込み
  wwwroot/css/app.css                  - サイト全体に効くグローバルCSS
  Program.cs                           - DI登録（MudBlazor, Presenter等）

FERNGSolver.Radiance.UI.Blazor/      ← 画面部品（Razor Class Library）。UI調整の中心はここ
  RadianceSearchForm.razor             - 画面全体の組み立て役（メインコンポーネント）
  RadianceSearchForm.razor.css         - 画面全体のレイアウト（PC/スマホの切り替えグリッド）
  FalconKnightConditionPanel.razor     - 「ファルコンナイト法」条件アコーディオンの中身
  CombatConditionPanel.razor           - 「戦闘条件」アコーディオンの中身（詳細設定ダイアログ起動あり）
  GrowthConditionPanel.razor           - 「レベルアップ条件」アコーディオンの中身（自動入力あり）
  UnitStatusDetailDialog.razor         - スキル詳細設定のMudDialog（攻撃側/防御側共通）
  RngViewCard.razor                    - 乱数ビューアの1枚のカード
  RngViewCard.razor.css                - 乱数ビューアの見た目（○×表示、色分け等）
  Internal/*ConditionState.cs          - 各パネルの入力値を保持するだけの状態クラス（UIローカル）
  Internal/UnitStatusDetailState.cs    - スキル詳細設定の状態クラス＋要約文字列(ToString)
  Internal/SearchMode.cs               - 検索方法の切り替え用enum
  Internal/RandomNumberUsageDisplayExtensions.cs - 乱数の用途表示文字列の変換

FERNGSolver.Common.UI.Blazor/        ← 全タイトル共通の部品（Radiance以外にもGba/Genealogy等で使用）
  ResultsTable.razor                   - 検索結果テーブルの共通コンポーネント
```

ポイント：**「検索ロジックそのもの」は `FERNGSolver.Radiance.Presentation`/`Application`/`Domain` にあり、
UI.Blazor側は基本的に見た目と入力値の受け渡しだけを担当します。** 検索結果の計算方法を変えたい場合は
UI.Blazorではなく Presentation/Application/Domain 側を触ってください。

## 2. 「〇〇を変えたい」早見表

| やりたいこと | 触るファイル |
|---|---|
| ページタイトル、favicon、フォント読み込み | `FERNGSolver.Radiance.Web/wwwroot/index.html` |
| ヘッダー（アプリバー）の見た目・全体テーマ色 | `FERNGSolver.Radiance.Web/Layout/MainLayout.razor` |
| サイト全体に効くCSS（フォントサイズ等） | `FERNGSolver.Radiance.Web/wwwroot/css/app.css` |
| 画面見出し文言（「蒼炎の軌跡 乱数調整ツール…」） | `RadianceSearchForm.razor` の `<MudText Typo="Typo.h4">` |
| PC/スマホでのエリア配置（条件・結果・乱数ビューアの並び順） | `RadianceSearchForm.razor.css` の `grid-template-areas` |
| 消費数・オフセットの入力欄 | `RadianceSearchForm.razor` 冒頭の `MudNumericField` 群 |
| 検索方法の選択肢・ラベル文言 | `RadianceSearchForm.razor` の `s_SearchModeLabels`（`@code`内） |
| 「ファルコンナイト法」条件の入力項目 | `FalconKnightConditionPanel.razor` + `Internal/FalconKnightConditionState.cs` |
| 「戦闘条件」の入力項目（HP・威力・命中・必殺等） | `CombatConditionPanel.razor` + `Internal/CombatConditionState.cs` |
| 攻撃側/防御側の「詳細設定」ダイアログの中身（スキル・武器種） | `UnitStatusDetailDialog.razor` + `Internal/UnitStatusDetailState.cs` |
| 「詳細設定」ボタン横の要約文字列（`[天空(10%)]`等の表示） | `Internal/UnitStatusDetailState.cs` の `ToString()` |
| 「レベルアップ条件」の入力項目、成長率の直接入力欄 | `GrowthConditionPanel.razor` + `Internal/GrowthConditionState.cs` |
| キャラクター選択・腕輪チェックによる成長率自動入力 | `GrowthConditionPanel.razor` の `RefreshGrowthRate()`（キャラ一覧は`FERNGSolver.Radiance.Domain.Repository.Stub.StubCharacterRepository`） |
| 検索結果テーブルの列・見た目（Radiance以外にも影響） | `FERNGSolver.Common.UI.Blazor/ResultsTable.razor` |
| 検索結果テーブルの列定義そのもの（何を表示するか） | `FERNGSolver.Radiance.Presentation` 側の ViewModel/Column定義（UI.Blazorではない） |
| 乱数ビューアの1カードの見た目・レイアウト | `RngViewCard.razor` + `RngViewCard.razor.css` |
| 乱数ビューアの「テーブル番号」「消費数」入力欄 | `RngViewCard.razor` 冒頭の `MudNumericField` |
| MudBlazorのテーマ（配色・ダークモード等）を変えたい | `Layout/MainLayout.razor` の `<MudThemeProvider />` に `Theme` パラメータを追加 |

## 3. 各コンポーネントの役割（詳細）

- **`RadianceSearchForm.razor`**
  画面全体のコンポジションルート。`IExtendedMainFormView`/`IRngViewListView` を実装し、
  検索方法(`SearchMode`)に応じて表示するアコーディオンパネルを出し分けるだけで、
  各パネルの中身には関与しません。レイアウトの左右/上下切り替えは一切C#側に書かず、
  すべて`RadianceSearchForm.razor.css`のCSS Gridに任せる方針です。

- **`*ConditionPanel.razor` + `Internal/*ConditionState.cs`**
  各アコーディオンパネルは「表示用の`.razor`」と「値を保持するだけの`State`クラス」の
  ペアになっています。`State`はRadianceSearchForm側のフィールドとして生成され、
  `[Parameter, EditorRequired]`で参照渡しされるため、パネル側で`State.Xxx`を書き換えれば
  そのままRadianceSearchForm側にも反映されます（双方向バインディングのための特別な仕組みは不要）。

- **`UnitStatusDetailDialog.razor`**
  MudBlazorの`MudDialog`。`CombatConditionPanel.razor`から
  `IDialogService.ShowAsync<UnitStatusDetailDialog>(...)`で呼び出され、
  編集中はキャンセル時に元の値へ影響しないよう複製(`UnitStatusDetailState.Clone()`)を使います。
  スキル項目や武器種を増やしたい場合は、`Internal/UnitStatusDetailState.cs`（プロパティ追加＋
  `ToString()`の表示ロジック）と、Domain側の`IUnitStatusDetail`インターフェース
  （`FERNGSolver.Radiance.Domain/Combat/IUnitStatusDetail.cs`）の両方に手を入れる必要があります。

- **`GrowthConditionPanel.razor`**
  キャラクター選択・腕輪チェックボックスはこのファイル内だけで完結するUI専用の一時状態
  （`Internal/GrowthConditionState.cs`には保持しない）。選択・チェック変更のたびに
  `RefreshGrowthRate()`が`ICharacter.Boost(...)`を呼び出し、結果をStateへ直接上書きします。

- **`ResultsTable.razor`（`FERNGSolver.Common.UI.Blazor`）**
  Radiance以外（Gba/Genealogy等）でも共有されるテーブル部品です。ここを変更すると
  他タイトルのWeb版にも影響するため、Radiance固有の見た目を変えたい場合は基本的に
  `RadianceSearchForm.razor`側の`Columns`/`Rows`の渡し方や、Presentation側の
  ViewModel定義を調整してください。

## 4. 編集時の注意点（過去にハマった点）

- **日本語を含むファイルの一括置換にPowerShellの`Get-Content`/`Set-Content`は使わない。**
  エンコーディング不一致で文字化け（mojibake）します。エディタでの直接編集、または
  文字列置換ツールを使ってください。
- **`[Parameter]`を持つクラス/プロパティは`public`にする。** `internal`のままだとBlazorの
  コンポーネントパラメータとして正しく機能しないことがあります。
- **`MudTable`に`OnRowClick`等のメソッドグループを渡すと`T`の型推論に失敗することがある。**
  `<MudTable T="object" ...>`のように明示的に型を指定すると解消します（`ResultsTable.razor`で対応済み）。
- **`@bind-Value:after="Method"`** を使うと、値変更後に副作用（再計算など）を簡潔に呼び出せます
  （`GrowthConditionPanel.razor`の成長率自動入力で使用）。
- **MudDialogの基本パターン：**
  呼び出し側は`@inject IDialogService DialogService` →
  `var reference = await DialogService.ShowAsync<TDialog>(title, parameters, options);`→
  `var result = await reference.Result;` で `result.Canceled`/`result.Data` を判定。
  ダイアログ側は`[CascadingParameter] IMudDialogInstance MudDialog`を受け取り、
  `MudDialog.Close(DialogResult.Ok(value))` / `MudDialog.Cancel()` で閉じます。
- **`MudNumericField`の`ValueChanged`は、フォーカスを外す（Tab/blur）までUI上の再計算結果が
  反映されないことがあります。** 手動確認時は値を入れたあとTabキーで確定してから見た目を確認してください。

## 5. ローカルで見た目を確認する

```powershell
dotnet run --project FERNGSolver.Radiance.Web\FERNGSolver.Radiance.Web.csproj --urls http://localhost:5299
```

上記コマンドでビルド後、ブラウザで `http://localhost:5299` を開いて確認します。
スマホでの見た目確認や本番反映の手順（`gh-pages`へのデプロイ）は別途デプロイ担当者に確認してください。
