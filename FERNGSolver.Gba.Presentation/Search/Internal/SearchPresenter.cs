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

        private IReadOnlyList<(int, ushort[])> ExecuteSearchCore()
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
                    return Array.Empty<(int, ushort[])>();
                }
                strategy = StrategyFactory.CreateFalconKnightPatternStrategy(cxPattern);
            }
            else
            {
                List<ISearchStrategy> strategies = new List<ISearchStrategy>();
                if (m_MainFormView.ContainsCombat)
                {
                    strategies.Add(StrategyFactory.CreateCombatStrategy(new CombatStrategyArgs {
                        Attacker = new CombatUnitInfo {
                            Hp = m_MainFormView.AttackerHp,
                            Power = m_MainFormView.AttackerPower,
                            HitRate = m_MainFormView.AttackerHitRate,
                            CriticalRate = m_MainFormView.AttackerCriticalRate,
                            PhaseCount = m_MainFormView.AttackerPhaseCount,
                            IsDoubleAttack = m_MainFormView.IsAttackerDoubleAttack,
                        },
                        Defender = new CombatUnitInfo {
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
                    }));
                }
                if (m_MainFormView.ContainsGrowth)
                {
                    strategies.Add(StrategyFactory.CreateGrowthStrategy(new GrowthStrategyArgs
                    {
                        HpGrowthRate = m_MainFormView.HpGrowthRate,
                        AtkGrowthRate = m_MainFormView.AtkGrowthRate,
                        TecGrowthRate = m_MainFormView.TecGrowthRate,
                        SpdGrowthRate = m_MainFormView.SpdGrowthRate,
                        DefGrowthRate = m_MainFormView.DefGrowthRate,
                        MdfGrowthRate = m_MainFormView.MdfGrowthRate,
                        LucGrowthRate = m_MainFormView.LucGrowthRate,
                    }));
                }

                strategy = StrategyFactory.CreateSequentialStrategy(strategies.ToArray());
            }
            return Searcher.Search(rng, m_MainFormView.OffsetMin, m_MainFormView.OffsetMax, strategy);
        }

        private void ShowResults(IReadOnlyList<(int, ushort[])> results)
        {
            var viewModels = new SearchResultItemViewModel[results.Count];
            for (int i = 0; i < viewModels.Length && i < 100; ++i)
            {
                viewModels[i] = new SearchResultItemViewModel(results[i].Item1);
            }
            m_MainFormView.ShowSearchResults(typeof(SearchResultItemViewModel), viewModels);
        }
    }
}
