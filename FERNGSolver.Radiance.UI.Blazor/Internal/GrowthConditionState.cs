namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// レベルアップ条件の入力値を保持します。
    /// <para> * RadianceSearchFormとGrowthConditionPanelの間で共有される可変状態です。</para>
    /// <para> * キャラクター選択による成長率の自動入力（腕輪等の補正含む）はGrowthConditionPanel内で完結するUI操作であり、
    /// 結果として算出された成長率がここに書き込まれます。</para>
    /// </summary>
    public sealed class GrowthConditionState
    {
        public int HpGrowthRate { get; set; }
        public int StrGrowthRate { get; set; }
        public int MgcGrowthRate { get; set; }
        public int TecGrowthRate { get; set; }
        public int SpdGrowthRate { get; set; }
        public int LucGrowthRate { get; set; }
        public int DefGrowthRate { get; set; }
        public int MdfGrowthRate { get; set; }

        // Windows版と同様、既定では全ての能力の上昇を必須とする。
        public bool RequiresHpUp { get; set; } = true;
        public bool RequiresStrUp { get; set; } = true;
        public bool RequiresMgcUp { get; set; } = true;
        public bool RequiresTecUp { get; set; } = true;
        public bool RequiresSpdUp { get; set; } = true;
        public bool RequiresLucUp { get; set; } = true;
        public bool RequiresDefUp { get; set; } = true;
        public bool RequiresMdfUp { get; set; } = true;
    }
}
