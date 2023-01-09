using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;


namespace WebApp.Controllers {
    public class HomeController : Controller {
        private WebDbContext db = new WebDbContext();
        public ActionResult Index() {

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Rick() {
            return Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model) {
            int id = 0;
            if ( model.Username.Equals("admin") && model.Password == "admin") {
                return RedirectToAction("Index", "Candidates");
            } else if (int.TryParse(model.Username, out id) && model.Password == "password" && db.Candidates.Find(id)!=null) {
                return RedirectToAction("Details", "Certificates", new { id = id });
            } else {
                return RedirectToAction("Index", "Home");
            }

        }

    }
}