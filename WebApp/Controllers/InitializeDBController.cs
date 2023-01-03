using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Menu;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class InitializeDBController : Controller
    {
        public ActionResult InitializeDBFromProgram() {
            Menu.Program.InitialiseDatabase();
            return RedirectToAction("Index", "Candidates");
        }

        public ActionResult InitialiseDB() {
            return View();
        }
    }
}
