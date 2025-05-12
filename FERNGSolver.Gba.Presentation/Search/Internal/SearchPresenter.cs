using FERNGSolver.Common.Extensions;
using FERNGSolver.Common.ViewContracts;
using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.Gba.Application.Search;
using FERNGSolver.Gba.Application.Search.Strategy;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.Presentation.Search.Internal
{
    internal sealed class SearchPresenter : ISearchPresenter
    {
        private readonly IExtendedMainFormView m_MainFormView;
        private readonly IErrorNotifier m_ErrorNotifier;

        CompositeDisposable m_Disposables = new CompositeDisposable();

        public SearchPresenter(IExtendedMainFormView mainFormView, IErrorNotifier errorNotifier)
        {
            m_MainFormView = mainFormView;
            m_ErrorNotifier = errorNotifier;
            mainFormView.SearchButtonClicked.Subscribe(_ => ExecuteSearch()).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void ExecuteSearch()
        {
            if (!ValidateView())
            {
                return;
            }

            var result = ExecuteSearchCore();
            ShowResults(result);
        }

        private bool ValidateView()
        {
            if (!m_MainFormView.UsesFalconKnightMethod && !m_MainFormView.ContainsCombat && !m_MainFormView.ContainsGrowth)
            {
                m_ErrorNotifier.NotifyError("検索条件が選択されていません。");
                return false;
            }
            return true;
        }

        private IReadOnlyList<ISearchResult> ExecuteSearchCore()
        {
            IRng rng = RngFactory.CreateDefault();
            ISearchStrategy strategy;

            if (m_MainFormView.UsesFalconKnightMethod)
            {
                IReadOnlyList<bool> cxPattern;
                try
                {
                    cxPattern = CxStringConverter.CxStringToBools(m_MainFormView.CxString);
                }
                catch (Exception e)
                {
                    m_ErrorNotifier.NotifyError($"cx列のパースに失敗しました。\n-----\n{e.ToString()}");
                    return Array.Empty<ISearchResult>();
                }
                strategy = StrategyFactory.CreateFalconKnightPatternStrategy(cxPattern);
            }
            else
            {
                List<ISearchStrategy> strategies = new List<ISearchStrategy>();
                if (m_MainFormView.ContainsCombat)
                {
                    strategies.Add(CreateCombatStrategy());
                }
                if (m_MainFormView.ContainsGrowth)
                {
                    strategies.Add(CreateGrowthStrategy());
                }

                strategy = StrategyFactory.CreateSequentialStrategy(strategies.ToArray());
            }
            return Searcher.Search(rng, m_MainFormView.OffsetMin, m_MainFormView.OffsetMax, strategy);
        }

        private ISearchStrategy CreateCombatStrategy()
        {
            return StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs {
                Attacker = new CombatUnit {
                    Hp = m_MainFormView.AttackerHp,
                    Power = m_MainFormView.AttackerPower,
                    HitRate = m_MainFormView.AttackerHitRate,
                    CriticalRate = m_MainFormView.AttackerCriticalRate,
                    PhaseCount = m_MainFormView.AttackerPhaseCount,
                    IsDoubleAttack = m_MainFormView.IsAttackerDoubleAttack,
                },
                Defender = new CombatUnit {
                    Hp = m_MainFormView.DefenderHp,
                    Power = m_MainFormView.DefenderPower,
                    HitRate = m_MainFormView.DefenderHitRate,
                    CriticalRate = m_MainFormView.DefenderCriticalRate,
                    PhaseCount = m_MainFormView.DefenderPhaseCount,
                    IsDoubleAttack = m_MainFormView.IsDefenderDoubleAttack,
                },
                AttackerHpPostconditionMin = m_MainFormView.AttackerHpPostconditionMin,
                AttackerHpPostconditionMax = m_MainFormView.AttackerHpPostconditionMax,
                DefenderHpPostconditionMin = m_MainFormView.DefenderHpPostconditionMin,
                DefenderHpPostconditionMax = m_MainFormView.DefenderHpPostconditionMax,
            });
        }

        private ISearchStrategy CreateGrowthStrategy()
        {
            return StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs {
                HpGrowthRate = m_MainFormView.HpGrowthRate,
                AtkGrowthRate = m_MainFormView.AtkGrowthRate,
                TecGrowthRate = m_MainFormView.TecGrowthRate,
                SpdGrowthRate = m_MainFormView.SpdGrowthRate,
                DefGrowthRate = m_MainFormView.DefGrowthRate,
                MdfGrowthRate = m_MainFormView.MdfGrowthRate,
                LucGrowthRate = m_MainFormView.LucGrowthRate,
            });
        }

        private void ShowResults(IReadOnlyList<ISearchResult> results)
        {
            var viewModels = new SearchResultItemViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = CreateResultItemViewModel(m_MainFormView.CurrentPosition, results[i].Position - m_MainFormView.CurrentPosition, 8);
            }
            m_MainFormView.ShowSearchResults(typeof(SearchResultItemViewModel), viewModels);
        }

        private static SearchResultItemViewModel CreateResultItemViewModel(int currentPosition, int offset, int falconMove)
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

            return new SearchResultItemViewModel(
                currentPosition + offset, offset,
                hc, h, vc, v);
        }
    }
}
