using FERNGSolver.FalconKnightTool.Domain.Path;

namespace FERNGSolver.FalconKnightTool.Presentation.ViewContracts
{
    public interface IFalconKnightToolEntry
    {
        /// <summary>
        /// 作品のタイトルを取得します。
        /// </summary>
        string Title { get; }

        /// <summary>
        /// パスコンバータを取得します。
        /// </summary>
        IPathConverter PathConverter { get; }

        /// <summary>
        /// 指定したcx列の文字列を追加する処理を取得します。
        /// </summary>
        void AddCxString(string cxString);
    }
}
