using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReDo_Expenditure.Models;

namespace ReDo_Expenditure.Controllers
{
    public class ExpendituresController : Controller
    {
        private Entities db = new Entities();

        // GET: Expenditures
        public ActionResult Index()
        {
            var model = db.Expenditures.ToList();
            return View(model);
        }

        // GET: Expenditures/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Expenditures.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenditure expenditure = db.Expenditures.Find(id);
            if (expenditure == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Expenditures/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Expenditures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expenditure model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Today;
                db.Expenditures.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create",model);
        }

       

        // GET: Expenditures/Edit/5
        public ActionResult Edit(int id)
        {

            var model = db.Expenditures.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Edit",model);
        }

        // POST: Expenditures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expenditure model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private void ValidateExpenditure(Expenditure model)
        {
            if (model.Amount <= 0)
                ModelState.AddModelError("Amount", "Số tiền quá ít!");
        }

        // GET: Expenditures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenditure expenditure = db.Expenditures.Find(id);
            if (expenditure == null)
            {
                return HttpNotFound();
            }
            return View(expenditure);
        }

        // POST: Expenditures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expenditure expenditure = db.Expenditures.Find(id);
            db.Expenditures.Remove(expenditure);
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
