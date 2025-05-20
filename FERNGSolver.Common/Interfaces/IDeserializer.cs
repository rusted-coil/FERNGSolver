namespace FERNGSolver.Common.Interfaces
{
    public interface IDeserializer
    {
        /// <summary>
        /// 指定したパスからファイルを読み込み、T型のデータを返します。
        /// <para> * 読み込みに失敗した場合は単にnewしたものを返します。</para>
        /// </summary>
        T Deserialize<T>(string filePath) where T : new();
    }
}
