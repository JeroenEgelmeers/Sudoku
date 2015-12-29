using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SA_Week4_Sudoku.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Show();
        }
        
        void NewGameClicked(object sender, RoutedEventArgs e)
        {
            Board.GameBoard = new Board(9);
            Board.GameBoard.GenerateGame(79);
        }



        void QuitClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
