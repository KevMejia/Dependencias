using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dependencias.Models;

namespace Dependencias.Controllers
{
    public class DependenciasAuxController : Controller
    {
        private DB2Conn db = new DB2Conn();

        // GET: /DependenciasAux/
        public ActionResult Index()
        {
            return View(db.DepAux.Take(10).ToList());
        }

        // GET: /DependenciasAux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASAUXILIARES dependenciasauxiliares = db.DepAux.Find(id);
            if (dependenciasauxiliares == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasauxiliares);
        }

        // GET: /DependenciasAux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DependenciasAux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAAUXILIAR,NOMBREDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA")] DEPENDENCIASAUXILIARES dependenciasauxiliares)
        {
            if (ModelState.IsValid)
            {
                db.DepAux.Add(dependenciasauxiliares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dependenciasauxiliares);
        }

        // GET: /DependenciasAux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASAUXILIARES dependenciasauxiliares = db.DepAux.Find(id);
            if (dependenciasauxiliares == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasauxiliares);
        }

        // POST: /DependenciasAux/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAAUXILIAR,NOMBREDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA")] DEPENDENCIASAUXILIARES dependenciasauxiliares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependenciasauxiliares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dependenciasauxiliares);
        }

        // GET: /DependenciasAux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASAUXILIARES dependenciasauxiliares = db.DepAux.Find(id);
            if (dependenciasauxiliares == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasauxiliares);
        }

        // POST: /DependenciasAux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DEPENDENCIASAUXILIARES dependenciasauxiliares = db.DepAux.Find(id);
            db.DepAux.Remove(dependenciasauxiliares);
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
