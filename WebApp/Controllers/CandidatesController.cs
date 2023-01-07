using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;

namespace WebApp
{
    public class CandidatesController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Candidates
        public ActionResult Index()
        {
            return View(db.Candidates.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Using low tier tricks to break my code such as using 'null' values.";
                return RedirectToAction("Index");
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Dr. Pasparakis do not underestimate my low tier Brain.";
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateNumber,FirstName,MiddleName,LastName,Gender,NativeLanguage,CountryOfResidence,Birthdate,Email,LandLineNumber,MobileNumber,Address1,Address2,PostalCode,Town,Province,PhotoIdType,PhotoIdNumber,PhotoIdDate")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                TempData["messageSuccess"] = $"Candidate with ID {candidate.CandidateNumber} was Summoned successfuly";
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Using low tier tricks to break my code such as using 'null' values.";
                return RedirectToAction("Index");
            }
            var candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Dr. Pasparakis do not underestimate my low tier Brain.";
                return RedirectToAction("Index");
            }
            var viewModel = new Candidate();
            viewModel.PhotoIdDate = candidate.PhotoIdDate;
            viewModel.Birthdate = candidate.Birthdate;

            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateNumber,FirstName,MiddleName,LastName,Gender,NativeLanguage,CountryOfResidence,Birthdate,Email,LandLineNumber,MobileNumber,Address1,Address2,PostalCode,Town,Province,PhotoIdType,PhotoIdNumber,PhotoIdDate")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["messageSuccess"] = $"Candidate with ID {candidate.CandidateNumber} was Updated successfuly";
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Using low tier tricks to break my code such as using 'null' values.";
                return RedirectToAction("Index");
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                TempData["messageError"] = $"Error: Candidate with id {id} was not found. Dr. Pasparakis do not underestimate my low tier Brain.";
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            TempData["messageError"] = $"Candidate with id {id} was succesfully Assassinated";
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
