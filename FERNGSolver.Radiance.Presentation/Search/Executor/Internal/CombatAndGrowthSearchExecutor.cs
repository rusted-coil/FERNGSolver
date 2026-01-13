using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Application.Search.Strategy;
using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Radiance.Application.Search;
using FERNGSolver.Radiance.Application.Search.Strategy;
using FERNGSolver.Radiance.Domain.Combat;
using FERNGSolver.Radiance.Domain.Combat.Service;
using FERNGSolver.Radiance.Domain.Growth;
using FERNGSolver.Radiance.Domain.RNG;
using FERNGSolver.Radiance.Presentation.Search.Internal;
using FERNGSolver.Radiance.Presentation.ViewContracts;

namespace FERNGSolver.Radiance.Presentation.Search.Executor.Internal
{
    /// <summary>
    /// 検索処理のうち、戦闘とレベルアップに関する検索を担当するクラスです。
    /// </summary>
    internal static class CombatAndGrowthSearchExecutor
    {
        public static void ExecuteSearch(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            var result = ExecuteSearchCore(mainFormView, errorNotifier);
            ShowResults(mainFormView, result);
        }

        private static IReadOnlyList<ISearchResult> ExecuteSearchCore(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            List<ISearchResult> results = new List<ISearchResult>();

            List<ISearchStrategy> strategies = new List<ISearchStrategy>();
            if (mainFormView.ContainsCombat)
            {
                strategies.Add(CreateCombatStrategy(mainFormView));
            }
            if (mainFormView.ContainsGrowth)
            {
                strategies.Add(CreateGrowthStrategy(mainFormView));
            }

            var strategy = CommonStrategyFactory.CreateSequentialStrategy(strategies.ToArray());

            for (int i = 0; i < Domain.RNG.Const.TableCount; ++i)
            {
                if (mainFormView.SearchTableIndex != null && mainFormView.SearchTableIndex.Value != i)
                {
                    continue;
                }

                var rng = RngFactory.Create(i);
                results.AddRange(Searcher.Search(
                    i, rng, mainFormView.CurrentPosition + mainFormView.OffsetMin, mainFormView.CurrentPosition + mainFormView.OffsetMax,
                    strategy));
            }
            return results;
        }

        private static ISearchStrategy CreateCombatStrategy(ICombatSettingsView view)
        {
            return StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs
            {
                Attacker = CreateAttackerUnitFromView(view),
                Defender = CreateDefenderUnitFromView(view),
                AttackerHpPostconditionMin = view.AttackerHpPostconditionMin,
                AttackerHpPostconditionMax = view.AttackerHpPostconditionMax,
                DefenderHpPostconditionMin = view.DefenderHpPostconditionMin,
                DefenderHpPostconditionMax = view.DefenderHpPostconditionMax,
            });
        }

        internal static ICombatUnit CreateAttackerUnitFromView(ICombatSettingsView view)
        {
            return new CombatUnit
            {
                Hp = view.AttackerHp,
                Power = view.AttackerPower,
                HitRate = view.AttackerHitRate,
                CriticalRate = view.AttackerCriticalRate,
                PhaseCount = view.AttackerPhaseCount,
                StatusDetail = view.AttackerStatusDetail,
            };
        }

        internal static ICombatUnit CreateDefenderUnitFromView(ICombatSettingsView view)
        {
            return new CombatUnit
            {
                Hp = view.DefenderHp,
                Power = view.DefenderPower,
                HitRate = view.DefenderHitRate,
                CriticalRate = view.DefenderCriticalRate,
                PhaseCount = view.DefenderPhaseCount,
                StatusDetail = view.DefenderStatusDetail,
            };
        }

        private static ISearchStrategy CreateGrowthStrategy(IGrowthSettingsView view)
        {
            return StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
            {
                HpGrowthRate = view.HpGrowthRate,
                StrGrowthRate = view.StrGrowthRate,
                MgcGrowthRate = view.MgcGrowthRate,
                TecGrowthRate = view.TecGrowthRate,
                SpdGrowthRate = view.SpdGrowthRate,
                LucGrowthRate = view.LucGrowthRate,
                DefGrowthRate = view.DefGrowthRate,
                MdfGrowthRate = view.MdfGrowthRate,
                HpSearchType = view.HpSearchType,
                StrSearchType = view.StrSearchType,
                MgcSearchType = view.MgcSearchType,
                TecSearchType = view.TecSearchType,
                SpdSearchType = view.SpdSearchType,
                LucSearchType = view.LucSearchType,
                DefSearchType = view.DefSearchType,
                MdfSearchType = view.MdfSearchType,
            });
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new CombatAndGrowthSearchResultItemViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = CreateResultItemViewModel(mainFormView, results[i]);
            }
            mainFormView.ShowSearchResults(CreateResultColumns(mainFormView), typeof(CombatAndGrowthSearchResultItemViewModel), viewModels);
        }

        private static IReadOnlyList<ITableColumn> CreateResultColumns(IExtendedMainFormView mainFormView)
        {
            var columns = new List<ITableColumn> {
                new SearchResultTableColumn("テーブル", "TableIndex") { Width = 50 },
                new SearchResultTableColumn("消費数", "Position"){ Width = 50 },
                new SearchResultTableColumn("Offset", "Offset"){ Width = 50 },
                new SearchResultTableColumn("F法消費回数", "FalconKnightMethodConsume"){ Width = 160 },
            };

            if (mainFormView.ContainsCombat)
            {
                columns.Add(new SearchResultTableColumn("戦闘結果", "CombatResult") { Width = 120 });
            }

            if (mainFormView.ContainsGrowth)
            {
                columns.Add(new SearchResultTableColumn("レベルアップ結果", "GrowthResult") { Width = 360 });
            }

            return columns;
        }

        private static CombatAndGrowthSearchResultItemViewModel CreateResultItemViewModel(IExtendedMainFormView mainFormView, ISearchResult result)
        {
            int currentPosition = mainFormView.CurrentPosition;
            int offset = result.Position - currentPosition;
            int falconMove = mainFormView.FalconKnightMethodMove;

            // 結果表示用RNG処理 重かったら何か考える
            var rng = RngFactory.Create(result.TableIndex);
            rng.Advance(currentPosition);

            // F法横は✕で止まる、F法縦は◯で止まる
            // 1回のF法消費は最大でも falconMove - 1 まで
            int v = 0, h = 0;
            int vc = 0, hc = 0;
            for (int i = 0; i < offset; ++i)
            {
                if (Domain.RNG.Util.IsRngValueOk(rng.Next()))
                {
                    ++h;
                    if (h == falconMove - 1)
                    {
                        h = 0;
                        hc++;
                    }

                    v = 0;
                    vc++;
                }
                else
                {
                    ++v;
                    if (v == falconMove - 1)
                    {
                        v = 0;
                        vc++;
                    }

                    h = 0;
                    hc++;
                }
            }

            var viewModel = new CombatAndGrowthSearchResultItemViewModel(
                result.TableIndex,
                currentPosition + offset, offset,
                hc, h, vc, v);

            if (mainFormView.ContainsCombat)
            {
                var combatResult = CombatSimulator.Simulate(CombatRngServiceFactory.Create(rng), CreateAttackerUnitFromView(mainFormView), CreateDefenderUnitFromView(mainFormView));
                viewModel.SetCombatResult(combatResult);
            }

            if (mainFormView.ContainsGrowth)
            {
                var growthResult = GrowthSimulator.Simulate(rng, mainFormView.HpGrowthRate, mainFormView.StrGrowthRate, mainFormView.MgcGrowthRate, mainFormView.TecGrowthRate, mainFormView.SpdGrowthRate, mainFormView.LucGrowthRate, mainFormView.DefGrowthRate, mainFormView.MdfGrowthRate);
                viewModel.SetGrowthResult(growthResult);
            }

            return viewModel;
        }
    }
}
