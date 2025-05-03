
namespace FERNGSolver.Thracia.Domain.RNG.Internal
{
    internal sealed class Rng : IRng
    {
        public IReadOnlyList<int> States => m_Table;
        public int CurrentIndex => m_Cursor;

        private int[] m_Table = new int[55];
        private int m_Cursor = 0; // 最初に読む乱数はテーブルの[1]

        public Rng(IEnumerable<int> initialValues, int initialCursor = 0)
        {
            m_Table = initialValues.ToArray();
            m_Cursor = initialCursor;
        }

        void RefreshTable()
        {
            for (int i = 54; i >= 0; i--)
            {
                int idx = (i + 24) % 55;
                m_Table[idx] = (99 + m_Table[idx] - m_Table[i]) % 100 + 1;
            }

            for (int i = 0; i < 7; i++)
            {
                int idx = i + 48;
                m_Table[idx] = (m_Table[idx] + m_Table[i] - 1) % 100 + 1;
            }

            m_Cursor = 0; // 次に読む時はテーブルの[0]から読み出す
        }

        public int Next()
        {
            ++m_Cursor;
            if (m_Cursor >= m_Table.Length)
            {
                RefreshTable();
            }
            return m_Table[m_Cursor] - 1; // 乱数表上は1～100なので0～99に直す
        }
    }
}
