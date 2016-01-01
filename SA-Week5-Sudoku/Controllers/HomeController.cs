using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA_Week4_Sudoku.View;
using SA_Week5_Sudoku.Models;

namespace SA_Week5_Sudoku.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            // Make the board and give it as model to the view
            if (SessionContainer.Current.SES_ASPBoard == null)
            {
                SessionContainer.Current.SES_ASPBoard = new ASPBoard();
            }
            return View(SessionContainer.Current.SES_ASPBoard);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void ChangeValue()
        {
            int col     = Int32.Parse(Request.QueryString["col"]);
            int row     = Int32.Parse(Request.QueryString["row"]);
            int value   = Int32.Parse(Request.QueryString["val"]);

            // PUT HERE THE VALIDATION OF THE USERS INPUT.
            foreach (var item in SessionContainer.Current.SES_ASPBoard.board.GridRows)
            {
                //
                //if (item[row][col].IsValid())
                //{
                    
                //}
            }
            //System.Diagnostics.Debug.WriteLine("Col: " + col + " , Row: " + row);

            Index();
        }

        public void SolveGame()
        {
            SessionContainer.Current.SES_ASPBoard.board.Solve();
            Index();
        }
        public void NewGame()
        {
            SessionContainer.Current.SES_ASPBoard = new ASPBoard();
            Index();
        }
    }
}