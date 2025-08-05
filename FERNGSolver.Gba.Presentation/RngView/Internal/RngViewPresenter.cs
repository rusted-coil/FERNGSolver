using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Gba.Application.RNG;
using FERNGSolver.Gba.Domain.Combat;
using FERNGSolver.Gba.Domain.Combat.Service;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.RngView.ViewContracts;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Gba.Presentation.RngView.Internal
{
    internal sealed class RngViewPresenter : IRngViewPresenter
    {
        private readonly IExtendedMainFormView m_MainFormView;
        private readonly IRngView m_View;

        private readonly CompositeDisposable m_Disposables = new CompositeDisposable();

        public RngViewPresenter(IExtendedMainFormView mainFormView, IRngView view)
        {
            m_MainFormView = mainFormView;
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

            public Domain.Combat.Const.SkillType SkillType => throw new NotImplementedException();

            public Domain.Combat.Const.BossType BossType => throw new NotImplementedException();

            public int Luck => throw new NotImplementedException();

            public int OpponentDefense => throw new NotImplementedException();
        }

        private void PositionChanged(int position)
        {
            var rng = RngFactory.CreateDefault();
            rng.Advance(position);
            var previewRng = rng.Clone();

            // rngを回して乱数の使用用途を計算し、previewRngで実際の乱数値を取得する

            if (!m_MainFormView.UsesFalconKnightMethod)
            {
                // 契機をシミュレート
                var recordingService = new Combat.Internal.RecordingCombatRngService(CombatRngServiceFactory.Create(rng));
            }

            int usageCount = 0;

            List<RandomNumberViewModel> viewModels = new List<RandomNumberViewModel>();
            for (int i = 0; i < 40; ++i) // 乱数の表示個数は外部から変えられるようにしたい
            {
                if (i >= usageCount)
                {
                    viewModels.Add(new RandomNumberViewModel
                    {
                        Value = previewRng.Next(),
                        Usage = RandomNumberUsage.None,
                        IsOk = false,
                    });
                }
            }

//            if()

            // 契機をシミュレート
            /*
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

            var growth = GrowthSimulator.Simulate(rng, 110, 50, 5, 50, 30, 40, 40, 5);*/

            /*
            foreach (var pair in recordingService.UsedRandomNumbers)
            {
                viewModels.Add(new RandomNumberViewModel {
                    Value = previewRng.Next(),
                    Usage = pair.Usage,
                    IsOk = pair.IsOk,
                });
            }*/
            for (int i = viewModels.Count, c = 0; i < 30; ++i, ++c)
            {

                    /*
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
                    */
            }

            m_View.SetRandomNumbers(viewModels);
        }
    }
}
