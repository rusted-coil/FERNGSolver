using FERNGSolver.Gba.Domain.Character;

namespace FERNGSolver.Gba.Domain.Repository
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
