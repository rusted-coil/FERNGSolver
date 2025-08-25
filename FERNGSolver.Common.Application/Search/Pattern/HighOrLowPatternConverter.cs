namespace FERNGSolver.Common.Application.Search.Pattern
{
    public static class HighOrLowPatternConverter
    {
        /// <summary>
        /// 文字列からHighOrLowPatternのリストに変換します。
        /// <para> * 文字列は,区切りで「(数値)+」「(数値)-」「x」のいずれかを連結したもの</para>
        /// <para> * 末尾に,を含んでもよく、その場合は自動的に読み飛ばす</para>
        /// <para> * 「(数値)+」は目標値の判定に失敗したことを示すため(数値, false)に変換</para>
        /// <para> * 「(数値)-」は目標値の判定に成功したことを示すため(数値, true)に変換</para>
        /// <para> * 「x」はチェックを行わない(あらゆる判定に成功する)ことを示すため(99, true)に変換</para>
        /// </summary>
        public static IReadOnlyList<(ushort, bool)> ConvertFromString(string pattern)
        {
            var elements = pattern.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new (ushort, bool)[elements.Length];
            for (int i = 0; i < elements.Length; ++i)
            {
                var element = elements[i].Trim();
                if (element == "x" || element == "X")
                {
                    result[i] = (99, true);
                }
                else if (element.EndsWith('+'))
                {
                    if (ushort.TryParse(element[..^1], out var value))
                    {
                        result[i] = (value, false);
                    }
                    else
                    {
                        throw new FormatException($"HighOrLowPatternのパースに失敗しました。'{element}'は不正な形式です。");
                    }
                }
                else if (element.EndsWith('-'))
                {
                    if (ushort.TryParse(element[..^1], out var value))
                    {
                        result[i] = (value, true);
                    }
                    else
                    {
                        throw new FormatException($"HighOrLowPatternのパースに失敗しました。'{element}'は不正な形式です。");
                    }
                }
                else
                {
                    throw new FormatException($"HighOrLowPatternのパースに失敗しました。'{element}'は不正な形式です。");
                }
            }
            return result;
        }
    }
}
