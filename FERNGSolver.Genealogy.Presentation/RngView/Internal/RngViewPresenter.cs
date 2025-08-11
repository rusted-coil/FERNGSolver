using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Genealogy.Application.RNG;
using FERNGSolver.Genealogy.Domain.Combat;
using FERNGSolver.Genealogy.Domain.Combat.Service;
using FERNGSolver.Genealogy.Domain.Growth;
using FERNGSolver.Genealogy.Domain.RNG;
using FERNGSolver.Genealogy.Presentation.RngView.ViewContracts;
using FERNGSolver.Genealogy.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Genealogy.Presentation.RngView.Internal
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

        private void PositionChanged(int position)
        {
            var rng = RngFactory.Create();
            rng.Advance(position);
            var previewRng = rng.Clone();

            // rngを回して乱数の使用用途を計算し、previewRngで実際の乱数値を取得する

            List<RandomNumberViewModel> viewModels = new List<RandomNumberViewModel>();

            // 契機をシミュレート

            var recordingService = new Combat.Internal.RecordingCombatRngService(CombatRngServiceFactory.Create(rng));

            if (m_MainFormView.ContainsCombat)
            {
                CombatSimulator.Simulate(recordingService,
                    Search.Executor.Internal.CombatAndGrowthSearchExecutor.CreateAttackerUnitFromView(m_MainFormView),
                    Search.Executor.Internal.CombatAndGrowthSearchExecutor.CreateDefenderUnitFromView(m_MainFormView));

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
                    m_MainFormView.StrGrowthRate,
                    m_MainFormView.MgcGrowthRate,
                    m_MainFormView.TecGrowthRate,
                    m_MainFormView.SpdGrowthRate,
                    m_MainFormView.LucGrowthRate,
                    m_MainFormView.DefGrowthRate,
                    m_MainFormView.MdfGrowthRate);

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

            const int displayCount = 40; // 乱数の表示個数は外部から変えられるようにしたい
            for (int i = viewModels.Count; i < displayCount; ++i)
            {
                viewModels.Add(new RandomNumberViewModel
                {
                    Value = previewRng.Next(),
                    Usage = RandomNumberUsage.None,
                    IsOk = null,
                });
            }

            m_View.SetRandomNumbers(viewModels);
        }
    }
}
