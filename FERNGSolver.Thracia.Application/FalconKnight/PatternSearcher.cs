using FERNGSolver.Thracia.Domain.RNG;

namespace FERNGSolver.Thracia.Application.FalconKnight
{
    public static class PatternSearcher
    {
        /// <summary>
        /// ファルコンナイト法のパターンに一致する消費数を全て検索します。
        /// <para> * 受け取ったRNGは進めません。</para>
        /// </summary>
        public static IReadOnlyList<int> Search(IRng currentRng, int offsetMin, int offsetMax, IReadOnlyList<bool> falconKnightPattern)
        {
            var result = new List<int>();

            var startRng = RngFactory.CreateFromRng(currentRng);
            for (int i = 0; i < offsetMin; ++i)
            {
                startRng.Next();
            }

            for (int i = 0; i <= offsetMax - offsetMin; ++i)
            {
                var tempRng = RngFactory.CreateFromRng(startRng);

                bool isOk = true;
                foreach (var pattern in falconKnightPattern)
                {
                    if (pattern != tempRng.Next().ToCx())
                    {
                        isOk = false;
                        break;
                    }
                }

                if (isOk)
                {
                    result.Add(offsetMin + i);
                }

                startRng.Next();
            }
            return result;
        }
    }
}
