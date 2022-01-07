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
    public class CaoDonoController : Controller
    {
        private Context.Context db = new Context.Context();

        private CaoDono caodono = new CaoDono();
        private Cao cao = new Cao();
        private Dono dono = new Dono();
        private Raca raca = new Raca();

        // GET: CaoDono
        public ActionResult Index(int? Escolhido)
        {
            List<CaoDono> CaoDonoLista = db.CaoDono.ToList();

            foreach (CaoDono i in CaoDonoLista)
            {
                var TempCao = db.Cao.Where(x => x.IdCao == i.IdCao).FirstOrDefault();
                var TempDono = db.Dono.Where(x => x.IdDono == i.IdDono).FirstOrDefault();
                i.IdRaca = TempCao.IdRaca;

                var TempRaca = db.Raca.Where(x => x.IdRaca == i.IdRaca).FirstOrDefault();

                i.NomeDono = TempDono.NomeDono;
                i.NomeCao = TempCao.NomeCao;
                i.NomeRaca = TempRaca.NomeRaca;


            }
            List<Raca> ListaRaca = db.Raca.ToList();
            ViewBag.ListaRaca = ListaRaca;


            if (Escolhido != null)
            {
                List<CaoDono> ListRaca = db.CaoDono.ToList();

                ListRaca = ListRaca.Where(t => t.IdRaca == Escolhido).ToList();

                foreach (CaoDono item in ListRaca)
                {
                    var BaseCao = db.Cao.Where(t => t.IdCao == item.IdCao).FirstOrDefault();
                    var BaseDono = db.Dono.Where(t => t.IdDono == item.IdDono).FirstOrDefault();

                    item.IdRaca = BaseCao.IdRaca;

                    var BaseRaca = db.Raca.Where(t => t.IdRaca == item.IdRaca).FirstOrDefault();

                    item.NomeDono = BaseDono.NomeDono;
                    item.NomeCao = BaseCao.NomeCao;
                    item.NomeRaca = BaseRaca.NomeRaca;
                }
                return View(ListRaca);

            }
            return View(CaoDonoLista);



        }

        // GET: CaoDono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaoDono caoDono = db.CaoDono.Find(id);
            if (caoDono == null)
            {
                return HttpNotFound();
            }
            return View(caoDono);
        }

        // GET: CaoDono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaoDono/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDono,IdCao,IdRaca")] CaoDono caoDono)
        {
            if (ModelState.IsValid)
            {
                db.CaoDono.Add(caoDono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caoDono);
        }

        // GET: CaoDono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaoDono caoDono = db.CaoDono.Find(id);
            if (caoDono == null)
            {
                return HttpNotFound();
            }
            return View(caoDono);
        }

        // POST: CaoDono/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDono,IdCao,IdRaca")] CaoDono caoDono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caoDono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caoDono);
        }

        // GET: CaoDono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaoDono caoDono = db.CaoDono.Find(id);
            if (caoDono == null)
            {
                return HttpNotFound();
            }
            return View(caoDono);
        }

        // POST: CaoDono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaoDono caoDono = db.CaoDono.Find(id);
            db.CaoDono.Remove(caoDono);
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
