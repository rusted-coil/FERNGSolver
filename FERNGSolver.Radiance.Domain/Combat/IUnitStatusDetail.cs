namespace FERNGSolver.Radiance.Domain.Combat
{
	public interface IUnitStatusDetail
	{
        /// <summary>
        /// 武器タイプを取得します。
        /// </summary>
        Const.WeaponType WeaponType { get; }

        /// <summary>
        /// スキルを取得します。
        /// </summary>
        Const.SkillType SkillType { get; }

        /// <summary>
        /// ボス属性を取得します。
        /// </summary>
        Const.BossType BossType { get; }

        /// <summary>
        /// レベルを取得します。
        /// </summary>
        int Level { get; }

        /// <summary>
        /// 最大HPを取得します。
        /// </summary>
        int MaxHp { get; }

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
