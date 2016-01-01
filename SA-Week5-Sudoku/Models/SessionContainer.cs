using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Week5_Sudoku.Models
{
    public class SessionContainer
    {
        // private constructor
        private SessionContainer()
        {
            // Set it while construction the page.
            if (SES_ASPBoard == null)
            {
                SES_ASPBoard = null;
            }
        }

        // Gets the current session.
        public static SessionContainer Current
        {
            get
            {
                SessionContainer session =
                    (SessionContainer)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new SessionContainer();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        public ASPBoard SES_ASPBoard { get; set; }
        public bool     SES_SolveGame { get; set; }
        public bool     SES_ResetGame { get; set; }

    }
}