using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using caes_donos.Context;
using caes_donos.Models;

namespace caes_donos.Controllers
{
    public class DonoController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Dono
        public ActionResult Index()
        {
            return View(db.Dono.ToList());
        }

        // GET: Dono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dono dono = db.Dono.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // GET: Dono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dono/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDono,NomeDono,TelefoneDono")] Dono dono)
        {
            if (ModelState.IsValid)
            {
                db.Dono.Add(dono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dono);
        }

        // GET: Dono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dono dono = db.Dono.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // POST: Dono/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDono,NomeDono,TelefoneDono")] Dono dono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dono);
        }

        // GET: Dono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dono dono = db.Dono.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // POST: Dono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dono dono = db.Dono.Find(id);
            db.Dono.Remove(dono);
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
