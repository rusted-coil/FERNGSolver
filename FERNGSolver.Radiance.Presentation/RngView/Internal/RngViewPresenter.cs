using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Radiance.Application.RNG;
using FERNGSolver.Radiance.Domain.Combat;
using FERNGSolver.Radiance.Domain.Combat.Service;
using FERNGSolver.Radiance.Domain.Growth;
using FERNGSolver.Radiance.Domain.RNG;
using FERNGSolver.Radiance.Presentation.RngView.ViewContracts;
using FERNGSolver.Radiance.Presentation.ViewContracts;
using System.Reactive.Disposables;

namespace FERNGSolver.Radiance.Presentation.RngView.Internal
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

            mainFormView.SearchConditionChanged.Subscribe(_ => PositionChanged(m_View.TableIndex, m_View.CurrentPosition)).AddTo(m_Disposables);
            view.PositionChanged.Subscribe(arg => PositionChanged(arg.Item1, arg.Item2)).AddTo(m_Disposables);
        }

        public void Dispose()
        {
            m_Disposables.Dispose();
        }

        private void PositionChanged(int tableIndex, int position)
        {
            var rng = RngFactory.Create(tableIndex);
            rng.Advance(position);
            var previewRng = rng.Clone();

            // rngを回して乱数の使用用途を計算し、previewRngで実際の乱数値を取得する

            List<RandomNumberViewModel> viewModels = new List<RandomNumberViewModel>();

            // 契機をシミュレート
            // 乱数ビュー側はファルコンナイト法のチェックにかかわらず常に表示する

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
