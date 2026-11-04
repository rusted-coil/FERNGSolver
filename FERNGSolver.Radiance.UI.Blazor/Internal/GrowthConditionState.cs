using FERNGSolver.Radiance.Domain.Character;
using FERNGSolver.Radiance.Domain.Character.Extensions;
using FERNGSolver.Radiance.Domain.Repository.Stub;

namespace FERNGSolver.Radiance.UI.Blazor.Internal
{
    /// <summary>
    /// レベルアップ条件の入力値を保持します。
    /// <para> * RadianceSearchFormとGrowthConditionPanelの間で共有される可変状態です。</para>
    /// <para> * パネルの再生成時にもキャラクター・装備の選択と手入力した成長率を保持します。</para>
    /// </summary>
    public sealed class GrowthConditionState
    {
        public IReadOnlyList<ICharacter> Characters { get; } = new StubCharacterRepository().AllCharacters;
        public int SelectedCharacterIndex { get; set; }
        public bool HasSwordBand { get; set; }
        public bool HasFighterBand { get; set; }
        public bool HasArcherBand { get; set; }
        public bool HasKnightBand { get; set; }
        public bool HasPaladinBand { get; set; }
        public bool HasPegasusBand { get; set; }
        public bool HasWyvernBand { get; set; }
        public bool HasMageBand { get; set; }
        public bool HasPriestBand { get; set; }
        public bool HasThiefBand { get; set; }
        public bool HasKnightWard { get; set; }

        public GrowthConditionState()
        {
            RefreshGrowthRates();
        }

        // 初期化時とキャラクター・装備の変更時だけ自動入力する。
        // コンポーネントの再描画や再生成では手入力した成長率を上書きしない。
        public void RefreshGrowthRates()
        {
            if (SelectedCharacterIndex < 0 || SelectedCharacterIndex >= Characters.Count)
            {
                return;
            }

            var boosted = Characters[SelectedCharacterIndex].Boost(new ICharacterExtensions.BoostArgs
            {
                HasSwordBand = HasSwordBand,
                HasFighterBand = HasFighterBand,
                HasArcherBand = HasArcherBand,
                HasKnightBand = HasKnightBand,
                HasPaladinBand = HasPaladinBand,
                HasPegasusBand = HasPegasusBand,
                HasWyvernBand = HasWyvernBand,
                HasMageBand = HasMageBand,
                HasPriestBand = HasPriestBand,
                HasThiefBand = HasThiefBand,
                HasKnightWard = HasKnightWard,
            });

            HpGrowthRate = boosted.HpGrowthRate;
            StrGrowthRate = boosted.StrGrowthRate;
            MgcGrowthRate = boosted.MgcGrowthRate;
            TecGrowthRate = boosted.TecGrowthRate;
            SpdGrowthRate = boosted.SpdGrowthRate;
            LucGrowthRate = boosted.LucGrowthRate;
            DefGrowthRate = boosted.DefGrowthRate;
            MdfGrowthRate = boosted.MdfGrowthRate;
        }

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
