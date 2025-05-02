using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.FalconKnight
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

            for (int offset = offsetMin; offset <= offsetMax; ++offset)
            {
                var cloneRng = RngFactory.CreateFromRng(currentRng);
                for (int a = 0; a < offset; ++a)
                {
                    cloneRng.Next();
                }

                bool isOk = true;
                foreach(var pattern in falconKnightPattern)
                {
                    if (pattern != (cloneRng.Next() <= 49))
                    {
                        isOk = false;
                        break;
                    }
                }

                if (isOk)
                {
                    result.Add(offset);
                }
            }

            return result;
        }
    }
}
