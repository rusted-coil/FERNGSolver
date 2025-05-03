using FERNGSolver.Gba.Domain.RNG;

namespace FERNGSolver.Gba.Application.FalconKnight
{
    public static class PatternSearcher
    {
        /// <summary>
        /// ファルコンナイト法のパターンに一致する消費数を全て検索します。
        /// <para> * 受け取ったRNGは進めません。</para>
        /// </summary>
        public static IReadOnlyList<(int, ushort[])> Search(IRng currentRng, int offsetMin, int offsetMax, IReadOnlyList<bool> falconKnightPattern)
        {
            var result = new List<(int, ushort[])>();

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
                    if (pattern != (tempRng.Next() <= 49))
                    {
                        isOk = false;
                        break;
                    }
                }

                if (isOk)
                {
                    result.Add((offsetMin + i, [startRng.States[0], startRng.States[1], startRng.States[2]]));
                }

                startRng.Next();
            }

            return result;
        }
    }
}
