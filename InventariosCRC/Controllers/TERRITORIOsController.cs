using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventariosCRC.Models;

namespace InventariosCRC.Controllers
{
    public class TERRITORIOsController : Controller
    {
        private CRUZROJAINVEntities db = new CRUZROJAINVEntities();

        // GET: TERRITORIOs
        public ActionResult Index()
        {
            return View(db.TERRITORIOS.ToList());
        }

        // GET: TERRITORIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIO = db.TERRITORIOS.Find(id);
            if (tERRITORIO == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIO);
        }

        // GET: TERRITORIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TERRITORIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTerritorio,Comite,Provincia,Region")] TERRITORIO tERRITORIO)
        {
            if (ModelState.IsValid)
            {
                db.TERRITORIOS.Add(tERRITORIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tERRITORIO);
        }

        // GET: TERRITORIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIO = db.TERRITORIOS.Find(id);
            if (tERRITORIO == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIO);
        }

        // POST: TERRITORIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTerritorio,Comite,Provincia,Region")] TERRITORIO tERRITORIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tERRITORIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tERRITORIO);
        }

        // GET: TERRITORIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIO = db.TERRITORIOS.Find(id);
            if (tERRITORIO == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIO);
        }

        // POST: TERRITORIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TERRITORIO tERRITORIO = db.TERRITORIOS.Find(id);
            db.TERRITORIOS.Remove(tERRITORIO);
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
