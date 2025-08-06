using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Gba.Application.RNG;
using FERNGSolver.Gba.Domain.Combat;
using FERNGSolver.Gba.Domain.Combat.Service;
using FERNGSolver.Gba.Domain.Growth;
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

            mainFormView.SearchConditionChanged.Subscribe(_ => PositionChanged(m_View.CurrentPosition)).AddTo(m_Disposables);
            view.PositionChanged.Subscribe(PositionChanged).AddTo(m_Disposables);
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

            List<RandomNumberViewModel> viewModels = new List<RandomNumberViewModel>();

            if (!m_MainFormView.UsesFalconKnightMethod)
            {
                // 契機をシミュレート
                var recordingService = new Combat.Internal.RecordingCombatRngService(CombatRngServiceFactory.Create(rng));

                if (m_MainFormView.ContainsCombat)
                {
                    CombatSimulator.Simulate(recordingService,
                        Search.Executor.Internal.CombatAndGrowthSearchExecutor.CreateAttackerUnitFromView(m_MainFormView),
                        Search.Executor.Internal.CombatAndGrowthSearchExecutor.CreateDefenderUnitFromView(m_MainFormView),
                        m_MainFormView.IsBindingBlade);

                    // 戦闘に使用した乱数をViewModel化
                    foreach (var pair in recordingService.UsedRandomNumbers)
                    {
                        viewModels.Add(new RandomNumberViewModel
                        {
                            Value = previewRng.Next(),
                            Usage = pair.Usage,
                            IsOk = pair.IsOk,
                        });
                    }
                }

                if (m_MainFormView.ContainsGrowth)
                {
                    var growth = GrowthSimulator.Simulate(rng,
                        m_MainFormView.HpGrowthRate,
                        m_MainFormView.AtkGrowthRate,
                        m_MainFormView.TecGrowthRate,
                        m_MainFormView.SpdGrowthRate,
                        m_MainFormView.DefGrowthRate,
                        m_MainFormView.MdfGrowthRate,
                        m_MainFormView.LucGrowthRate);

                    for (int i = 0; i < growth.Count; ++i)
                    {
                        viewModels.Add(new RandomNumberViewModel
                        {
                            Value = previewRng.Next(),
                            Usage = RandomNumberUsage.GrowthStart + i,
                            IsOk = growth[i] > 0,
                        });
                    }
                }
            }

            const int displayCount = 40; // 乱数の表示個数は外部から変えられるようにしたい
            for (int i = viewModels.Count; i < displayCount; ++i)
            {
                viewModels.Add(new RandomNumberViewModel
                {
                    Value = previewRng.Next(),
                    Usage = RandomNumberUsage.None,
                    IsOk = false,
                });
            }

            m_View.SetRandomNumbers(viewModels);
        }
    }
}
