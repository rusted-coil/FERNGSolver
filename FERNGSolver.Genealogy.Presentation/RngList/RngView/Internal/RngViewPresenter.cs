using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Genealogy.Application.RNG;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Domain.Combat.Service;
using FERNGSolver.Genealogy.Domain.Growth;
using FERNGSolver.Genealogy.Domain.RNG;
using FERNGSolver.Genealogy.Presentation.Combat.Internal;
using FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts;
using FERNGSolver.Genealogy.Presentation.Search.Internal;
using System.Reactive.Disposables;

namespace FERNGSolver.Genealogy.Presentation.RngList.RngView.Internal
{
    internal sealed class RngViewPresenter : IRngViewPresenter
    {
        private readonly IRngView m_View;

        private readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public RngViewPresenter(IRngView view)
        {
            m_View = view;
            m_View.PositionChanged.Subscribe(PositionChanged).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        // 仮
        class UnitStatusDetail : IUnitStatusDetail
        {
            public Domain.Combat.Const.WeaponType WeaponType { get; set; }
            public bool HasVantage { get; set; }
            public bool HasAstra { get; set; }
            public bool HasLuna { get; set; }
            public bool HasSol { get; set; }
            public bool HasContinuation { get; set; }
            public bool HasAssault { get; set; }
            public bool HasGreatShield { get; set; }
            public int Level { get; set; }
            public int MaxHp { get; set; }
            public int Tec { get; set; }
            public int AttackSpeed { get; set; }
        }

        private void PositionChanged(int position)
        {
            var rng = RngFactory.Create();
            rng.Advance(position);

            var previewRng = rng.Clone();

            // 契機をシミュレート
            var defaultService = CombatRngServiceFactory.Create(rng);
            var recordingService = new RecordingCombatRngService(defaultService);
            CombatSimulator.Simulate(recordingService,
                new CombatUnit {
                    Hp = 40,
                    Attack = 15,
                    Defense = 5,
                    HitRate = 80,
                    CriticalRate = 0,
                    PhaseCount = 2,

                    StatusDetail = new UnitStatusDetail {
                        WeaponType = Domain.Combat.Const.WeaponType.Normal,
                        HasVantage = false,
                        HasAstra = false,
                        HasLuna = false,
                        HasSol = false,
                        HasContinuation = false,
                        HasAssault = false,
                        HasGreatShield = false,
                        Level = 1,
                        MaxHp = 40,
                        Tec = 10,
                        AttackSpeed = 5,
                    },
                },
                new CombatUnit {
                    Hp = 40,
                    Attack = 15,
                    Defense = 5,
                    HitRate = 80,
                    CriticalRate = 0,
                    PhaseCount = 2,

                    StatusDetail = new UnitStatusDetail {
                        WeaponType = Domain.Combat.Const.WeaponType.Normal,
                        HasVantage = false,
                        HasAstra = false,
                        HasLuna = false,
                        HasSol = false,
                        HasContinuation = false,
                        HasAssault = false,
                        HasGreatShield = false,
                        Level = 1,
                        MaxHp = 40,
                        Tec = 10,
                        AttackSpeed = 5,
                    },
                });

            var growth = GrowthSimulator.Simulate(rng, 110, 50, 5, 50, 30, 40, 40, 5);

            List<RandomNumberViewModel> viewModels = new List<RandomNumberViewModel>();
            foreach (var pair in recordingService.UsedRandomNumbers)
            {
                viewModels.Add(new RandomNumberViewModel {
                    Value = previewRng.Next(),
                    Usage = pair.Usage,
                    IsOk = pair.IsOk,
                });
            }
            for (int i = viewModels.Count, c = 0; i < 30; ++i, ++c)
            {
                if (c < growth.Count)
                {
                    viewModels.Add(new RandomNumberViewModel {
                        Value = previewRng.Next(),
                        Usage = RandomNumberUsage.GrowthStart + c,
                        IsOk = growth[c] > 0,
                    });
                }
                else
                {
                    viewModels.Add(new RandomNumberViewModel {
                        Value = previewRng.Next(),
                        Usage = RandomNumberUsage.None,
                        IsOk = false,
                    });
                }
            }

            m_View.SetRandomNumbers(viewModels);
        }
    }
}
