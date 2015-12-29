using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;

namespace SudokuBasis
{
    public class SudokuWrapper
    {
        private Sudoku.Game sudoku;
        public SudokuWrapper()
        {
            sudoku = new Sudoku.Game();

            int canWrite;
            sudoku.create();
            sudoku.write(out canWrite);

        }

        public bool set(int col, int row, int val)
        {
            int suc;
            col = col + 1;
            row = row + 1;
            sudoku.set((short)col, (short)row, (short)val, out suc);

            if (suc == 1)
            {
                return true;
            }

            return false;
        }

        public int get(int col, int row)
        {
            short val;
            col = col + 1;
            row = row + 1;
            sudoku.get((short)col, (short)row, out val);

            return val;
        }

        public bool getHint(ref short col, ref short row, ref short value)
        {
            bool validHint = false;
            while (validHint != true)
            {
                int suc;
                sudoku.hint(out col, out row, out value, out suc);

                if (col == -1 || row == -1 || value == -1)
                {
                    return false;
                }

                short val;
                sudoku.get(col, row, out val);
                System.Diagnostics.Debug.WriteLine("Col: " + col + ", Row: " + row + ", Value: " + value + ", existing value: " + val);

                if (suc == 1 && val == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Set success");
                    validHint = true;
                }
            }

            col = (short)(col - 1);
            row = (short)(row - 1);

            return true;
        }
    }
}
