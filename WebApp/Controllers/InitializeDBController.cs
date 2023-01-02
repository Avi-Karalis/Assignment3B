using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Menu;

namespace WebApp.Controllers
{
    public class InitializeDBController : Controller
    {
        public ActionResult InitializeDBFromProgram() {
            Menu.Program.InitialiseDatabase();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
