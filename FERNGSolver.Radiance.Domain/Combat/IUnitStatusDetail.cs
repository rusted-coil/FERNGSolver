namespace FERNGSolver.Radiance.Domain.Combat
{
	public interface IUnitStatusDetail
	{
        /// <summary>
        /// 武器タイプを取得します。
        /// </summary>
        Const.WeaponType WeaponType { get; }

        /// <summary>
        /// 待ち伏せを所持しているかどうかを取得します。
        /// </summary>
        bool HasVantage { get; }

        /// <summary>
        /// 連続を所持しているかどうかを取得します。
        /// </summary>
        bool HasAdept { get; }

        /// <summary>
        /// 怒りを所持しているかどうかを取得します。
        /// </summary>
        bool HasWrath { get; }

        /// <summary>
        /// 祈りを所持しているかどうかを取得します。
        /// </summary>
        bool HasMiracle { get; }

        /// <summary>
        /// 勇将を所持しているかどうかを取得します。
        /// </summary>
        bool HasResolve { get; }

        /// <summary>
        /// カウンターを所持しているかどうかを取得します。
        /// </summary>
        bool HasCounter { get; }

        /// <summary>
        /// キャンセルを所持しているかどうかを取得します。
        /// </summary>
        bool HasGuard { get; }

        /// <summary>
        /// 武器破壊を所持しているかどうかを取得します。
        /// </summary>
        bool HasCorrode { get; }

        /// <summary>
        /// 天空を所持しているかどうかを取得します。
        /// </summary>
        bool HasAether { get; }

        /// <summary>
        /// 流星を所持しているかどうかを取得します。
        /// </summary>
        bool HasAstra { get; }

        /// <summary>
        /// 月光を所持しているかどうかを取得します。
        /// </summary>
        bool HasLuna { get; }

        /// <summary>
        /// 太陽を所持しているかどうかを取得します。
        /// </summary>
        bool HasSol { get; }

        /// <summary>
        /// 陽光を所持しているかどうかを取得します。
        /// </summary>
        bool HasFlare { get; }

        /// <summary>
        /// 衝撃を所持しているかどうかを取得します。
        /// </summary>
        bool HasStun { get; }

        /// <summary>
        /// 鳴動を所持しているかどうかを取得します。
        /// </summary>
        bool HasColossus { get; }

        /// <summary>
        /// 狙撃を所持しているかどうかを取得します。
        /// </summary>
        bool HasDeadeye { get; }

        /// <summary>
        /// 瞬殺を所持しているかどうかを取得します。
        /// </summary>
        bool HasLethality { get; }

        /// <summary>
        /// 翼の守護を所持しているかどうかを取得します。
        /// </summary>
        bool HasCancel { get; }

        /// <summary>
        /// ボス属性を取得します。
        /// </summary>
        Const.BossType BossType { get; }

        /// <summary>
        /// 武器の残り使用回数を取得します。
        /// </summary>
        int WeaponUses { get; }

        /// <summary>
        /// レベルを取得します。
        /// </summary>
        int Level { get; }

        /// <summary>
        /// 最大HPを取得します。
        /// </summary>
        int MaxHp { get; }

        /// <summary>
        /// 技を取得します。
        /// </summary>
        int Tech { get; }

        /// <summary>
        /// 幸運を取得します。
        /// </summary>
        int Luck { get; }

        /// <summary>
        /// 敵の守備を取得します。
        /// </summary>
        int OpponentDefense { get; }
    }
}
