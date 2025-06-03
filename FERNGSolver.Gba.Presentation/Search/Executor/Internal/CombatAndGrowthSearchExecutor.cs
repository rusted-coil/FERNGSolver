using FERNGSolver.Common.Application.Interfaces;
using FERNGSolver.Common.Presentation.Interfaces;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.Combat;
using FERNGSolver.Gba.Domain.Growth;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.Search.Internal;
using FERNGSolver.Gba.Presentation.ViewContracts;

namespace FERNGSolver.Gba.Presentation.Search.Executor.Internal
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
            IRng rng = RngFactory.CreateDefault();

            List<ISearchStrategy> strategies = new List<ISearchStrategy>();
            if (mainFormView.ContainsCombat)
            {
                strategies.Add(CreateCombatStrategy(mainFormView));
            }
            if (mainFormView.ContainsGrowth)
            {
                strategies.Add(CreateGrowthStrategy(mainFormView));
            }

            return Searcher.Search(
                rng, mainFormView.CurrentPosition + mainFormView.OffsetMin, mainFormView.CurrentPosition + mainFormView.OffsetMax,
                StrategyFactory.CreateSequentialStrategy(strategies.ToArray()));
        }

        private static ISearchStrategy CreateCombatStrategy(ICombatSettingsView view)
        {
            return StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs
            {
                IsBindingBlade = view.IsBindingBlade,
                Attacker = CreateAttackerUnitFromView(view),
                Defender = CreateDefenderUnitFromView(view),
                AttackerHpPostconditionMin = view.AttackerHpPostconditionMin,
                AttackerHpPostconditionMax = view.AttackerHpPostconditionMax,
                DefenderHpPostconditionMin = view.DefenderHpPostconditionMin,
                DefenderHpPostconditionMax = view.DefenderHpPostconditionMax,
            });
        }

        private static ICombatUnit CreateAttackerUnitFromView(ICombatSettingsView view)
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

        private static ICombatUnit CreateDefenderUnitFromView(ICombatSettingsView view)
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
                AtkGrowthRate = view.AtkGrowthRate,
                TecGrowthRate = view.TecGrowthRate,
                SpdGrowthRate = view.SpdGrowthRate,
                DefGrowthRate = view.DefGrowthRate,
                MdfGrowthRate = view.MdfGrowthRate,
                LucGrowthRate = view.LucGrowthRate,
                HpSearchType = view.HpSearchType,
                AtkSearchType = view.AtkSearchType,
                TecSearchType = view.TecSearchType,
                SpdSearchType = view.SpdSearchType,
                DefSearchType = view.DefSearchType,
                MdfSearchType = view.MdfSearchType,
                LucSearchType = view.LucSearchType,
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
                columns.Add(new SearchResultTableColumn("レベルアップ結果", "GrowthResult") { Width = 310 });
            }

            return columns;
        }

        private static CombatAndGrowthSearchResultItemViewModel CreateResultItemViewModel(IExtendedMainFormView mainFormView, ISearchResult result)
        {
            int currentPosition = mainFormView.CurrentPosition;
            int offset = result.Position - currentPosition;
            int falconMove = mainFormView.FalconKnightMethodMove;

            // 結果表示用RNG処理 重かったら何か考える
            var rng = RngFactory.CreateDefault();
            rng.Advance(currentPosition);

            // F法横は✕で止まる、F法縦は◯で止まる
            // 1回のF法消費は最大でも falconMove - 1 まで
            int v = 0, h = 0;
            int vc = 0, hc = 0;
            for (int i = 0; i < offset; ++i)
            {
                if (rng.Next().ToCx())
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
                currentPosition + offset, offset,
                hc, h, vc, v);

            if (mainFormView.ContainsCombat)
            {
                var combatResult = CombatSimulator.Simulate(rng, CreateAttackerUnitFromView(mainFormView), CreateDefenderUnitFromView(mainFormView), mainFormView.IsBindingBlade);
                viewModel.SetCombatResult(combatResult);
            }

            if (mainFormView.ContainsGrowth)
            {
                var growthResult = GrowthSimulator.Simulate(rng, mainFormView.HpGrowthRate, mainFormView.AtkGrowthRate, mainFormView.TecGrowthRate, mainFormView.SpdGrowthRate, mainFormView.DefGrowthRate, mainFormView.MdfGrowthRate, mainFormView.LucGrowthRate);
                viewModel.SetGrowthResult(growthResult);
            }

            return viewModel;
        }
    }
}
