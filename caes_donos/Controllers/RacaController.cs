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
    public class RacaController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Raca
        public ActionResult Index()
        {
            return View(db.Raca.ToList());
        }

        // GET: Raca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Raca.Find(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        // GET: Raca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raca/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRaca,NomeRaca")] Raca raca)
        {
            if (ModelState.IsValid)
            {
                db.Raca.Add(raca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raca);
        }

        // GET: Raca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Raca.Find(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        // POST: Raca/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRaca,NomeRaca")] Raca raca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raca);
        }

        // GET: Raca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Raca.Find(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        // POST: Raca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raca raca = db.Raca.Find(id);
            db.Raca.Remove(raca);
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
