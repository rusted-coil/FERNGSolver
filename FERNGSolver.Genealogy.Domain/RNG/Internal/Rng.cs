using FERNGSolver.Common.Domain.RNG;

namespace FERNGSolver.Genealogy.Domain.RNG.Internal
{
    internal sealed class Rng : ICloneableRng
    {
        private ushort[] m_Table = new ushort[55];
        private int m_Cursor = 0; // 最初に読む乱数はテーブルの[1]

        public Rng(IEnumerable<ushort> initialValues, int initialCursor = 0)
        {
            m_Table = initialValues.ToArray();
            m_Cursor = initialCursor;
        }

        void RefreshTable()
        {
            for (int i = 54; i >= 0; i--)
            {
                int idx = (i + 24) % 55;
                m_Table[idx] = (ushort)((99 + m_Table[idx] - m_Table[i]) % 100 + 1);
            }

            for (int i = 0; i < 7; i++)
            {
                int idx = i + 48;
                m_Table[idx] = (ushort)((m_Table[idx] + m_Table[i] - 1) % 100 + 1);
            }

            m_Cursor = 0; // 次に読む時はテーブルの[0]から読み出す
        }

        public ushort Next()
        {
            ++m_Cursor;
            if (m_Cursor >= m_Table.Length)
            {
                RefreshTable();
            }
            return (ushort)(m_Table[m_Cursor] - 1); // 乱数表上は1～100なので0～99に直す
        }

        public ICloneableRng Clone()
        {
            return new Rng(m_Table, m_Cursor);
        }
    }
}
