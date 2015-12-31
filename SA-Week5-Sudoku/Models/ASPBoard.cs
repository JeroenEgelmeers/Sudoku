using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using SA_Week4_Sudoku.View;

namespace SA_Week5_Sudoku.Models
{
    public class ASPBoard
    {
        public Board board;

        public ASPBoard()
        {
            board = new Board(9);
        }

    }
}