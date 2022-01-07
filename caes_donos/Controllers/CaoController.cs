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
    public class CaoController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Cao
        public ActionResult Index()
        {
            List<Cao> ListaCao = db.Cao.ToList();
            foreach (Cao i in ListaCao)
            {
                var TempRaca = db.Raca.Where(x => x.IdRaca == i.IdRaca).FirstOrDefault();
                i.NomeRaca = TempRaca.NomeRaca;
            }
            return View(ListaCao);
        }

        // GET: Cao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cao cao = db.Cao.Find(id);
            if (cao == null)
            {
                return HttpNotFound();
            }
            return View(cao);
        }

        // GET: Cao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCao,NomeCao,IdRaca,NomeRaca")] Cao cao)
        {
            if (ModelState.IsValid)
            {
                db.Cao.Add(cao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cao);
        }

        // GET: Cao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cao cao = db.Cao.Find(id);
            if (cao == null)
            {
                return HttpNotFound();
            }
            return View(cao);
        }

        // POST: Cao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCao,NomeCao,IdRaca,NomeRaca")] Cao cao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cao);
        }

        // GET: Cao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cao cao = db.Cao.Find(id);
            if (cao == null)
            {
                return HttpNotFound();
            }
            return View(cao);
        }

        // POST: Cao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cao cao = db.Cao.Find(id);
            db.Cao.Remove(cao);
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
