using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using appagenda.Models;

namespace appagenda.Controllers
{
    public class TelefonoController : Controller
    {
        private AgendaContext db = new AgendaContext();

        // GET: Telefono
        public ActionResult Index()
        {
            var telefonos = db.Telefonos.Include(t => t.contacto);
            return View(telefonos.ToList());
        }

        // GET: Telefono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonos.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: Telefono/Create
        public ActionResult Create()
        {
            ViewBag.contactoId = new SelectList(db.Contactos, "Id", "nombre");
            return View();
        }

        // POST: Telefono/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,numero,descripcion,contactoId")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Telefonos.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactoId = new SelectList(db.Contactos, "Id", "nombre", telefono.contactoId);
            return View(telefono);
        }

        // GET: Telefono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonos.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactoId = new SelectList(db.Contactos, "Id", "nombre", telefono.contactoId);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,numero,descripcion,contactoId")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactoId = new SelectList(db.Contactos, "Id", "nombre", telefono.contactoId);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonos.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefonos.Find(id);
            db.Telefonos.Remove(telefono);
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
