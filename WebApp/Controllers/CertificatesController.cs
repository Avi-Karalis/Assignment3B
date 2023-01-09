using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;

namespace WebApp
{
    public class CertificatesController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Certificates
    

        // GET: Certificates/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Using low tier tricks to break my code such as using 'null' values.";
                return RedirectToAction("Index", "Home");
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found.";
                return RedirectToAction("Index", "Home");
            }
            return View(certificate);
        }

        // GET: Certificates/Create
        public ActionResult Create()
        {
            ViewBag.CandidateNumber = new SelectList(db.Candidates, "CandidateNumber", "FirstName");
            ViewBag.Title = new SelectList(db.CertificateTitles, "Title", "Title");
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CertificateId,Title,CandidateNumber,AssessmentTestCode,ExaminationDate,ScoreReportDate,CandidateScore,MaximumScore,AssessmentResultLabel,PercentageScore")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                db.Certificates.Add(certificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateNumber = new SelectList(db.Candidates, "CandidateNumber", "FirstName", certificate.CandidateNumber);
            ViewBag.Title = new SelectList(db.CertificateTitles, "Title", "Title", certificate.Title);
            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateNumber = new SelectList(db.Candidates, "CandidateNumber", "FirstName", certificate.CandidateNumber);
            ViewBag.Title = new SelectList(db.CertificateTitles, "Title", "Title", certificate.Title);
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CertificateId,Title,CandidateNumber,AssessmentTestCode,ExaminationDate,ScoreReportDate,CandidateScore,MaximumScore,AssessmentResultLabel,PercentageScore")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateNumber = new SelectList(db.Candidates, "CandidateNumber", "FirstName", certificate.CandidateNumber);
            ViewBag.Title = new SelectList(db.CertificateTitles, "Title", "Title", certificate.Title);
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certificate certificate = db.Certificates.Find(id);
            db.Certificates.Remove(certificate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
