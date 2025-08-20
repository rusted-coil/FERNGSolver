using FERNGSolver.Genealogy.Domain.Character;

namespace FERNGSolver.Genealogy.Domain.Repository
{
    /// <summary>
    /// キャラデータのリポジトリインターフェースです。
    /// </summary>
    public interface ICharacterRepository
    {
        /// <summary>
        /// キャラクターのベースリストを取得します。
        /// <para> * 親を必要としないキャラクターはこのデータをそのまま使うことができます。</para>
        /// </summary>
        IReadOnlyList<ICharacter> BaseCharacters { get; }

        /// <summary>
        /// キャラクターデータを指定し、そのキャラクターの父親候補のリストを取得します。
        /// <para> * 親を必要としないキャラクターの場合は空のリストを返します。</para>
        /// </summary>
        IReadOnlyList<string> GetFatherCandidates(ICharacter child);

        /// <summary>
        /// 父親を指定して子供のデータを取得します。
        /// </summary>
        ICharacter GetChild(ICharacter childBase, string fatherName);

        /// <summary>
        /// 全キャラクターのリストを取得します。
        /// </summary>
        IReadOnlyList<ICharacter> AllCharacters { get; }
    }
}
