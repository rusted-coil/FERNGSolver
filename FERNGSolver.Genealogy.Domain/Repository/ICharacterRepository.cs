using FERNGSolver.Genealogy.Domain.Character;

namespace FERNGSolver.Genealogy.Domain.Repository
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
