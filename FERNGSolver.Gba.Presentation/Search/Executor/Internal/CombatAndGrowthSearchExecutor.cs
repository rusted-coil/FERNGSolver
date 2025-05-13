using FERNGSolver.Common.Interfaces;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
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
                rng, mainFormView.OffsetMin, mainFormView.OffsetMax,
                StrategyFactory.CreateSequentialStrategy(strategies.ToArray()));
        }

        private static ISearchStrategy CreateCombatStrategy(IExtendedMainFormView mainFormView)
        {
            return StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs
            {
                Attacker = new CombatUnit
                {
                    Hp = mainFormView.AttackerHp,
                    Power = mainFormView.AttackerPower,
                    HitRate = mainFormView.AttackerHitRate,
                    CriticalRate = mainFormView.AttackerCriticalRate,
                    PhaseCount = mainFormView.AttackerPhaseCount,
                    IsDoubleAttack = mainFormView.IsAttackerDoubleAttack,
                },
                Defender = new CombatUnit
                {
                    Hp = mainFormView.DefenderHp,
                    Power = mainFormView.DefenderPower,
                    HitRate = mainFormView.DefenderHitRate,
                    CriticalRate = mainFormView.DefenderCriticalRate,
                    PhaseCount = mainFormView.DefenderPhaseCount,
                    IsDoubleAttack = mainFormView.IsDefenderDoubleAttack,
                },
                AttackerHpPostconditionMin = mainFormView.AttackerHpPostconditionMin,
                AttackerHpPostconditionMax = mainFormView.AttackerHpPostconditionMax,
                DefenderHpPostconditionMin = mainFormView.DefenderHpPostconditionMin,
                DefenderHpPostconditionMax = mainFormView.DefenderHpPostconditionMax,
            });
        }

        private static ISearchStrategy CreateGrowthStrategy(IExtendedMainFormView mainFormView)
        {
            return StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
            {
                HpGrowthRate = mainFormView.HpGrowthRate,
                AtkGrowthRate = mainFormView.AtkGrowthRate,
                TecGrowthRate = mainFormView.TecGrowthRate,
                SpdGrowthRate = mainFormView.SpdGrowthRate,
                DefGrowthRate = mainFormView.DefGrowthRate,
                MdfGrowthRate = mainFormView.MdfGrowthRate,
                LucGrowthRate = mainFormView.LucGrowthRate,
            });
        }

        private static void ShowResults(IExtendedMainFormView mainFormView, IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new CombatAndGrowthSearchResultItemViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = CreateResultItemViewModel(mainFormView.CurrentPosition, results[i].Position - mainFormView.CurrentPosition, 8);
            }
            mainFormView.ShowSearchResults(CreateResultColumns(), typeof(CombatAndGrowthSearchResultItemViewModel), viewModels);
        }

        private static IReadOnlyList<ITableColumn> CreateResultColumns()
        {
            return [
                new SearchResultTableColumn("消費数", "Position"){ Width = 50 },
                new SearchResultTableColumn("Offset", "Offset"){ Width = 50 },
                new SearchResultTableColumn("F法消費回数", "FalconKnightMethodConsume"){ Width = 160 },
            ];
        }

        private static CombatAndGrowthSearchResultItemViewModel CreateResultItemViewModel(int currentPosition, int offset, int falconMove)
        {
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

            return new CombatAndGrowthSearchResultItemViewModel(
                currentPosition + offset, offset,
                hc, h, vc, v);
        }
    }
}
