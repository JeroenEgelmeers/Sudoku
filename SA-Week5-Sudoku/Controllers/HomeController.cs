using System;
using System.Collections.Generic;
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
            ASPBoard ASPBoard = new ASPBoard();

            return View(ASPBoard);
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
    }
}