using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using invCruzRoja.Models;

namespace invCruzRoja.Controllers
{
    public class TERRITORIOSController : Controller
    {
        private CRUZROJAINVEntities1 db = new CRUZROJAINVEntities1();

        // GET: TERRITORIOS
        public ActionResult Index()
        {
            return View(db.TERRITORIOS.ToList());
        }

        // GET: TERRITORIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIOS = db.TERRITORIOS.Find(id);
            if (tERRITORIOS == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIOS);
        }

        // GET: TERRITORIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TERRITORIOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTerritorio,Comite,Provincia,Region")] TERRITORIO tERRITORIOS)
        {
            if (ModelState.IsValid)
            {
                db.TERRITORIOS.Add(tERRITORIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tERRITORIOS);
        }

        // GET: TERRITORIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIOS = db.TERRITORIOS.Find(id);
            if (tERRITORIOS == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIOS);
        }

        // POST: TERRITORIOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTerritorio,Comite,Provincia,Region")] TERRITORIO tERRITORIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tERRITORIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tERRITORIOS);
        }

        // GET: TERRITORIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TERRITORIO tERRITORIOS = db.TERRITORIOS.Find(id);
            if (tERRITORIOS == null)
            {
                return HttpNotFound();
            }
            return View(tERRITORIOS);
        }

        // POST: TERRITORIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TERRITORIO tERRITORIOS = db.TERRITORIOS.Find(id);
            db.TERRITORIOS.Remove(tERRITORIOS);
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
