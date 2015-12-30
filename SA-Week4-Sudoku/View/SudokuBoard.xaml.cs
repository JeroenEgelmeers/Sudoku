using System.Windows;
using System.Windows.Controls;

namespace SA_Week4_Sudoku.View
{
    /// <summary>
    /// Interaction logic for SudokuBoard.xaml
    /// </summary>
    public partial class SudokuBoard : UserControl
    {
        public Board GameBoard
        {
            get
            {
                return MainList.DataContext as Board;
            }

            set
            {
                MainList.DataContext = value;
            }
        }

        public SudokuBoard()
        {
            InitializeComponent();
            this.GameBoard = new Board(9);
        }
    }
}
