using FERNGSolver.Common.Presentation.Extensions;
using FERNGSolver.Genealogy.Domain.Growth;
using FERNGSolver.Genealogy.Domain.RNG;
using FERNGSolver.Genealogy.Presentation.RngList.RngView.ViewContracts;
using System.Reactive.Disposables;
using FERNGSolver.Genealogy.Application.RNG;

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

        private void PositionChanged(int position)
        {
            var rng = RngFactory.Create();
            rng.Advance(position);

            var previewRng = rng.Clone();

            // 契機をシミュレート
            var growth = GrowthSimulator.Simulate(rng, 100, 100, 100, 100, 100, 100, 100);

            m_View.SetRandomNumbers(Enumerable.Range(0, 20).Select(i => {
                if (i < growth.Count)
                {
                    return new RandomNumberViewModel
                    {
                        Value = previewRng.Next(),
                        Usage = RandomNumberUsage.GrowthStart + i,
                        IsOk = growth[i] > 0,
                    };
                }
                return new RandomNumberViewModel
                {
                    Value = previewRng.Next(),
                    Usage = RandomNumberUsage.None,
                    IsOk = false,
                };
            }).ToArray());
        }
    }
}
