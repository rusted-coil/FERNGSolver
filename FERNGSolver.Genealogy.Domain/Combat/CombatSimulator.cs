using FERNGSolver.Genealogy.Domain.Combat.Service;

namespace FERNGSolver.Genealogy.Domain.Combat
{
    public static class CombatSimulator
    {
        public sealed class Result
        {
            public int AttackerHp { get; }
            public int DefenderHp { get; }
            public int RoundCount { get; }

            public Result(int attackerHp, int defenderHp, int roundCount)
            {
                AttackerHp = attackerHp;
                DefenderHp = defenderHp;
                RoundCount = roundCount;
            }
        }

        // 残作業
        //・お互いが突撃を持っていた時の発動判定は？
        //・突撃発動時の2ラウンド目での待ち伏せの発動判定は？
        //・怒りに乱数消費はある？
        //・マップ上戦闘（連戦時）の祈りの挙動確認

        /// <summary>
        /// RNGを進め、戦闘をシミュレートした結果を得ます。
        /// </summary>
        public static Result Simulate(ICombatRngService rngService, ICombatUnit attacker, ICombatUnit defender, bool isArena, bool isOpponentFirst)
        {
            // ここでいうattacker,defenderとは、ツールで入力した「攻撃側」「防御側」のこと
            // 待ち伏せやisOpponentFirstによって、defenderから先に攻撃することもある
            var attackerUnit = new Unit(attacker, UnitSide.Player);
            var defenderUnit = new Unit(defender, UnitSide.Enemy);

            // 攻撃側→防御側の順でPhaseCountがなくなるまで交互に行動を行う
            // どちらかが死んだら終わり
            int roundIndex = 0;
            for(roundIndex = 0; ; ++roundIndex) // 1ラウンドごとのループ
            {
                // システム上の先攻後攻を仮決め
                var prior = isOpponentFirst ? defenderUnit : attackerUnit;
                var follower = isOpponentFirst ? attackerUnit : defenderUnit;

                // 仮決めした後攻側が待ち伏せを発動できる場合はさらに入れ替え
                // 闘技場では初回ラウンドのみ
                if ((!isArena || roundIndex == 0)
                   && (follower.CombatUnit.StatusDetail.HasVantage && follower.CurrentHp <= follower.CombatUnit.StatusDetail.MaxHp / 2))
                {
                    var temp = prior;
                    prior = follower;
                    follower = temp;
                }

                int p = 0, f = 0;
                bool isFinished = false;
                while (p < prior.CombatUnit.PhaseCount || f < follower.CombatUnit.PhaseCount)
                {
                    if (p < prior.CombatUnit.PhaseCount)
                    {
                        if (!ExecutePhase(rngService, prior, follower, roundIndex))
                        {
                            isFinished = true;
                            break;
                        }
                        ++p;
                    }
                    if (f < follower.CombatUnit.PhaseCount)
                    {
                        if (!ExecutePhase(rngService, follower, prior, roundIndex))
                        {
                            isFinished = true;
                            break;
                        }
                        ++f;
                    }
                }
                if (isFinished)
                {
                    break;
                }

                if (!isArena)
                {
                    // 突撃判定
                    // 闘技場では突撃は判定しない
                    bool isAssaultActive = CheckAssaultActive(rngService, attackerUnit, defenderUnit, roundIndex);
                    if (!isAssaultActive)
                    {
                        break;
                    }
                }

                // 闘技場の場合、戦闘が終了していなければラウンドを続行
            }

            return new Result(attackerUnit.CurrentHp, defenderUnit.CurrentHp, roundIndex + 1);
        }

        private class Unit
        {
            public ICombatUnit CombatUnit { get; }
            public int CurrentHp { get; set; }
            public UnitSide UnitSide { get; set; }
            public bool IsPrayReady { get; set; }

            public Unit(ICombatUnit combatUnit, UnitSide unitSide)
            {
                CombatUnit = combatUnit;
                CurrentHp = combatUnit.Hp;
                UnitSide = unitSide;
                IsPrayReady = combatUnit.StatusDetail.HasPray && combatUnit.Hp >= 11; // 祈りは戦闘開始時のHPが11以上で発動可能
            }
        }

        private static bool CheckAssaultActive(ICombatRngService rngService, Unit attackerSide, Unit defenderSide, int roundIndex)
        {
            if (attackerSide.CombatUnit.StatusDetail.HasAssault && attackerSide.CurrentHp >= 25)
            {
                return rngService.CheckActivateAssault(attackerSide.CombatUnit.StatusDetail.AttackSpeed, defenderSide.CombatUnit.StatusDetail.AttackSpeed, attackerSide.CurrentHp, attackerSide.UnitSide, roundIndex);
            }
            return false;
        }

        // ユニットの攻撃を実行し、戦闘が終了したらfalseを返す
        private static bool ExecutePhase(ICombatRngService rngService, Unit attackerSide, Unit defenderSide, int roundIndex)
        {
            int attackCount = 1;
            bool isLunaActive = false;
            bool isSolActive = false;

            // 流星剣判定
            if (attackerSide.CombatUnit.StatusDetail.HasAstra && rngService.CheckActivateAstra(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide, roundIndex))
            {
                attackCount = (attackerSide.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Brave ? 10 : 5);
            }
            else
            {
                // 月光剣判定
                if (attackerSide.CombatUnit.StatusDetail.HasLuna && rngService.CheckActivateLuna(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide, roundIndex))
                {
                    isLunaActive = true;
                }
                // 太陽剣判定
                if (attackerSide.CombatUnit.StatusDetail.HasSol && rngService.CheckActivateSol(attackerSide.CombatUnit.StatusDetail.Tec, attackerSide.UnitSide, roundIndex))
                {
                    isSolActive = true;
                }
                // 連続判定
                if (attackerSide.CombatUnit.StatusDetail.HasContinuation && rngService.CheckActivateContinuation(attackerSide.CombatUnit.StatusDetail.AttackSpeed, attackerSide.UnitSide, roundIndex))
                {
                    attackCount = 2;
                }
                // 勇者武器(勇者武器かつ連続を持っている場合は連続判定が行われるが、結局2回攻撃となる)
                if (attackerSide.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Brave)
                {
                    attackCount = 2;
                }
            }

            // 攻撃を行う
            for (int i = 0; i < attackCount; ++i)
            {
                bool isHit = true;
                int hitRate = attackerSide.CombatUnit.HitRate;

                // 祈り判定
                if (defenderSide.IsPrayReady && defenderSide.CurrentHp <= 10)
                {
                    // HPが10以下の時、(11-HP)×10%を回避率に加算
                    hitRate = Math.Max(0, hitRate - (11 - defenderSide.CurrentHp) * 10);
                }

                // 命中判定
                // 月光剣か太陽剣が発動していたら命中判定は成功扱い
                if (!isLunaActive && !isSolActive && !rngService.CheckHit(attackerSide.CombatUnit.HitRate, attackerSide.UnitSide, roundIndex))
                {
                    isHit = false;
                }
                // 大盾判定
                if (isHit && defenderSide.CombatUnit.StatusDetail.HasGreatShield
                    && attackerSide.CombatUnit.StatusDetail.WeaponType != Const.WeaponType.Absorb // 吸収武器に対しては大盾は発動しない(太陽剣に対しては発動する)
                    && rngService.CheckActivateGreatShield(defenderSide.CombatUnit.StatusDetail.Level, defenderSide.UnitSide, roundIndex))
                {
                    isHit = false;
                }

                if (isHit)
                {
                    int damage = isLunaActive ? attackerSide.CombatUnit.Attack : attackerSide.CombatUnit.Attack - defenderSide.CombatUnit.Defense;

                    // 必殺判定
                    int criticalRate = attackerSide.CombatUnit.CriticalRate;
                    if (attackerSide.CombatUnit.StatusDetail.HasWrath && attackerSide.CurrentHp <= attackerSide.CombatUnit.StatusDetail.MaxHp / 2 + 1)
                    {
                        criticalRate = 100; // 怒りが発動している場合、必殺率は100%
                    }
                    if (criticalRate > 0 && rngService.CheckCritical(criticalRate, attackerSide.UnitSide, roundIndex))
                    {
                        damage += attackerSide.CombatUnit.Attack; // 必殺は攻撃力を2倍にする
                    }

                    if (isSolActive || attackerSide.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Absorb)
                    {
                        attackerSide.CurrentHp = Math.Min(
                            attackerSide.CombatUnit.StatusDetail.MaxHp,
                            attackerSide.CurrentHp + Math.Min(defenderSide.CurrentHp, damage));
                    }
                    defenderSide.CurrentHp -= damage;

                    // 状態変化判定
                    if (attackerSide.CombatUnit.StatusDetail.WeaponType == Const.WeaponType.Sleep)
                    {
                        int sleepRate = 30 - attackerSide.CombatUnit.StatusDetail.OpponentMdf;
                        if (sleepRate < 0)
                        {
                            sleepRate = 100; // 負の場合は100%になる
                        }
                        if (rngService.CheckSleep(sleepRate, attackerSide.UnitSide, roundIndex))
                        {
                            return false; // 状態異常にかかったら戦闘終了
                        }
                    }
                }

                if (attackerSide.CurrentHp <= 0)
                {
                    attackerSide.CurrentHp = 0;
                    return false;
                }
                if (defenderSide.CurrentHp <= 0)
                {
                    defenderSide.CurrentHp = 0;
                    return false;
                }
            }

            return true;
        }
    }
}
