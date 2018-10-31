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
        private CRUZROJAINVEntities1 db = new CRUZROJAINVEntities1();

        public CRUZROJAINVEntities1 Db { get => db; set => db = value; }

        // GET: PERSONAS
        public ActionResult Index()
        {
            var pERSONAS = Db.PERSONAS.Include(p => p.TERRITORIO);
            return View(pERSONAS.ToList());
        }

        // GET: PERSONAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONAS = Db.PERSONAS.Find(id);
            if (pERSONAS == null)
            {
                return HttpNotFound();
            }
            return View(pERSONAS);
        }

        // GET: PERSONAS/Create
        public ActionResult Create()
        {
            ViewBag.IDTerritorio = new SelectList(Db.TERRITORIOS, "IDTerritorio", "Comite");
            return View();
        }

        // POST: PERSONAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPersona,Nombre,Apellido1,Apellido2,Telefono,Email,Rol,IDTerritorio")] PERSONA pERSONAS)
        {
            if (ModelState.IsValid)
            {
                Db.PERSONAS.Add(pERSONAS);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTerritorio = new SelectList(Db.TERRITORIOS, "IDTerritorio", "Comite", pERSONAS.IDTerritorio);
            return View(pERSONAS);
        }

        // GET: PERSONAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONAS = Db.PERSONAS.Find(id);
            if (pERSONAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTerritorio = new SelectList(Db.TERRITORIOS, "IDTerritorio", "Comite", pERSONAS.IDTerritorio);
            return View(pERSONAS);
        }

        // POST: PERSONAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPersona,Nombre,Apellido1,Apellido2,Telefono,Email,Rol,IDTerritorio")] PERSONA pERSONAS)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(pERSONAS).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTerritorio = new SelectList(Db.TERRITORIOS, "IDTerritorio", "Comite", pERSONAS.IDTerritorio);
            return View(pERSONAS);
        }

        // GET: PERSONAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONAS = Db.PERSONAS.Find(id);
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
            PERSONA pERSONAS = Db.PERSONAS.Find(id);
            Db.PERSONAS.Remove(pERSONAS);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
