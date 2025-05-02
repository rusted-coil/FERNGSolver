using FERNGSolver.FalconKnightTool.Application.Path;
using FERNGSolver.FalconKnightTool.Common.Interfaces;
using FERNGSolver.Gba.Application.FalconKnight;
using FERNGSolver.Gba.Domain.RNG;
using FERNGSolver.Gba.Presentation.ViewContracts;
using System.Diagnostics;

namespace FERNGSolver.Gba.Presentation.FalconKnight.Internal
{
    internal sealed class SearchStrategy : IFalconKnightToolSearchStrategy
    {
        private readonly IFalconKnightToolSearchConditionView m_View;

        public SearchStrategy(IFalconKnightToolSearchConditionView view)
        {
            m_View = view;
        }

        public void ExecuteSearch(string cxString)
        {
            IRng rng = RngFactory.CreateDefault();
            var result = PatternSearcher.Search(rng, 0, 10000, CxStringConverter.CxStringToBools(cxString));
            Debug.WriteLine($"検索結果: {result.Count}個 先頭: {result.First()}");
        }
    }
}
