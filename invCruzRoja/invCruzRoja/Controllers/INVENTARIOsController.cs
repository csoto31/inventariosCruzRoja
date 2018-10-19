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
    public class INVENTARIOsController : Controller
    {
        private CRUZROJAINVEntities1 db = new CRUZROJAINVEntities1();

        // GET: INVENTARIOs
        public ActionResult Index()
        {
            var iNVENTARIO = db.INVENTARIOs.Include(i => i.PERSONA).Include(i => i.TERRITORIO);
            return View(iNVENTARIO.ToList());
        }

        // GET: INVENTARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO iNVENTARIO = db.INVENTARIOs.Find(id);
            if (iNVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO);
        }

        // GET: INVENTARIOs/Create
        public ActionResult Create()
        {
            ViewBag.IDEmpleado = new SelectList(db.PERSONAS, "IDPersona", "Nombre");
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite");
            return View();
        }

        // POST: INVENTARIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDInventario,Marca,Modelo,NumSerie,Estado,IDEmpleado,IDTerritorio,FechaAsignado,FechaRetiro,Descripcion,TipoActivo,MACAddress,Propietario")] INVENTARIO iNVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.INVENTARIOs.Add(iNVENTARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEmpleado = new SelectList(db.PERSONAS, "IDPersona", "Nombre", iNVENTARIO.IDEmpleado);
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite", iNVENTARIO.IDTerritorio);
            return View(iNVENTARIO);
        }

        // GET: INVENTARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO iNVENTARIO = db.INVENTARIOs.Find(id);
            if (iNVENTARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEmpleado = new SelectList(db.PERSONAS, "IDPersona", "Nombre", iNVENTARIO.IDEmpleado);
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite", iNVENTARIO.IDTerritorio);
            return View(iNVENTARIO);
        }

        // POST: INVENTARIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDInventario,Marca,Modelo,NumSerie,Estado,IDEmpleado,IDTerritorio,FechaAsignado,FechaRetiro,Descripcion,TipoActivo,MACAddress,Propietario")] INVENTARIO iNVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEmpleado = new SelectList(db.PERSONAS, "IDPersona", "Nombre", iNVENTARIO.IDEmpleado);
            ViewBag.IDTerritorio = new SelectList(db.TERRITORIOS, "IDTerritorio", "Comite", iNVENTARIO.IDTerritorio);
            return View(iNVENTARIO);
        }

        // GET: INVENTARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO iNVENTARIO = db.INVENTARIOs.Find(id);
            if (iNVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO);
        }

        // POST: INVENTARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVENTARIO iNVENTARIO = db.INVENTARIOs.Find(id);
            db.INVENTARIOs.Remove(iNVENTARIO);
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
