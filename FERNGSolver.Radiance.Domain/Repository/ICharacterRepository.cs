using FERNGSolver.Radiance.Domain.Character;

namespace FERNGSolver.Radiance.Domain.Repository
{
    /// <summary>
    /// キャラデータのリポジトリインターフェースです。
    /// </summary>
    public interface ICharacterRepository
    {
        /// <summary>
        /// 全キャラクターのリストを取得します。
        /// </summary>
        IReadOnlyList<ICharacter> AllCharacters { get; }
    }
}
