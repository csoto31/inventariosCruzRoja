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
    public class PERSONASController : Controller
    {
        private CRUZROJACRINVEntities db = new CRUZROJACRINVEntities();

        // GET: PERSONAS
        public ActionResult Index()
        {
            var pERSONAS = db.PERSONAS.Include(p => p.TERRITORIOS);
            return View(pERSONAS.ToList());
        }

        // GET: PERSONAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONAS pERSONAS = db.PERSONAS.Find(id);
            if (pERSONAS == null)
            {
                return HttpNotFound();
            }
            return View(pERSONAS);
        }

        // GET: PERSONAS/Create
        public ActionResult Create()
        {
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite");
            return View();
        }

        // POST: PERSONAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPersona,Nombre,Apellido1,Apellido2,Telefono,Email,Rol,IDTerritorio")] PERSONAS pERSONAS)
        {
            if (ModelState.IsValid)
            {
                db.PERSONAS.Add(pERSONAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite", pERSONAS.IDTerritorio);
            return View(pERSONAS);
        }

        // GET: PERSONAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONAS pERSONAS = db.PERSONAS.Find(id);
            if (pERSONAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite", pERSONAS.IDTerritorio);
            return View(pERSONAS);
        }

        // POST: PERSONAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPersona,Nombre,Apellido1,Apellido2,Telefono,Email,Rol,IDTerritorio")] PERSONAS pERSONAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite", pERSONAS.IDTerritorio);
            return View(pERSONAS);
        }

        // GET: PERSONAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONAS pERSONAS = db.PERSONAS.Find(id);
            if (pERSONAS == null)
            {
                return HttpNotFound();
            }
            return View(pERSONAS);
        }

        // POST: PERSONAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONAS pERSONAS = db.PERSONAS.Find(id);
            db.PERSONAS.Remove(pERSONAS);
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
