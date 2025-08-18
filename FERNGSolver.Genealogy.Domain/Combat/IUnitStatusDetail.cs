namespace FERNGSolver.Genealogy.Domain.Combat
{
    /// <summary>
    /// 1ユニットの詳細情報を取得するためのインターフェースです。
    /// </summary>
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
        /// 流星剣を所持しているかどうかを取得します。
        /// </summary>
        bool HasAstra { get; }

        /// <summary>
        /// 月光剣を所持しているかどうかを取得します。
        /// </summary>
        bool HasLuna { get; }

        /// <summary>
        /// 太陽剣を所持しているかどうかを取得します。
        /// </summary>
        bool HasSol { get; }

        /// <summary>
        /// 連続を所持しているかどうかを取得します。
        /// </summary>
        bool HasContinuation { get; }

        /// <summary>
        /// 突撃を所持しているかどうかを取得します。
        /// </summary>
        bool HasAssault { get; }

        /// <summary>
        /// 大盾を所持しているかどうかを取得します。
        /// </summary>
        bool HasGreatShield { get; }

        /// <summary>
        /// 怒りを所持しているかどうかを取得します。
        /// </summary>
        bool HasWrath { get; }

        /// <summary>
        /// 祈りを所持しているかどうかを取得します。
        /// </summary>
        bool HasPray { get; }

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
        int Tec { get; }

        /// <summary>
        /// 攻速を取得します。
        /// </summary>
        int AttackSpeed { get; }

        /// <summary>
        /// 相手の攻速を取得します。
        /// <para> * ※スキルフラグと集約するために、このユニットの突撃にはこちらの値を使用します。</para>
        /// </summary>
        int OpponentAttackSpeed { get; }

        /// <summary>
        /// 相手の魔防を取得します。
        /// <para> * ※武器フラグと集約するために、このユニットの状態異常武器判定にはこの値を使用します。</para>
        /// </summary>
        int OpponentMdf { get; }
    }
}
