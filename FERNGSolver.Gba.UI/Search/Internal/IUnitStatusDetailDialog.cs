namespace FERNGSolver.Gba.UI.Search.Internal
{
    internal interface IUnitStatusDetailDialog : IDisposable
    {
        /// <summary>
        /// このダイアログのフォームを取得します。
        /// </summary>
        Form Form { get; }

        /// <summary>
        /// 変更可能なUnitStatusDetailにフォーム内容の書き戻しを行います。
        /// </summary>
        void WriteToUnitStatusDetail(UnitStatusDetail unitStatusDetail);
    }
}
