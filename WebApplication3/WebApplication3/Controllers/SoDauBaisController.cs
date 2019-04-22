using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class SoDauBaisController : Controller
    {
        private Entities db = new Entities();

        // GET: SoDauBais
        
        public ActionResult Index()
        {
            return View(db.SoDauBais.ToList());
        }

        // GET: SoDauBais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai model = db.SoDauBais.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: SoDauBais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SoDauBais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SoDauBai model)
        {
            model.Ngay = DateTime.Now;
            model.GiangVien = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.SoDauBais.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
                


            }

            return View(model);
        }

        // GET: SoDauBais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai soDauBai = db.SoDauBais.Find(id);
            if (soDauBai == null)
            {
                return HttpNotFound();
            }
            return View(soDauBai);
        }

        // POST: SoDauBais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ngay,NoiDung,GiangVien,NhanXet,DeXuat")] SoDauBai soDauBai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soDauBai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soDauBai);
        }

        // GET: SoDauBais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai soDauBai = db.SoDauBais.Find(id);
            if (soDauBai == null)
            {
                return HttpNotFound();
            }
            return View(soDauBai);
        }

        // POST: SoDauBais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoDauBai soDauBai = db.SoDauBais.Find(id);
            db.SoDauBais.Remove(soDauBai);
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
