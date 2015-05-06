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
    public class DependenciasGeneralesController : Controller
    {
        private DB2Conn db = new DB2Conn();

        public ActionResult Tabs()
        {
            return View();
        }

        // GET: /DependenciasGenerales/
        public ActionResult Index()
        {
            return View(db.DepGral.ToList());
        }

        // GET: /Dependencias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASGENERALES dependenciasgenerales = db.DepGral.Find(id);
            if (dependenciasgenerales == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasgenerales);
        }

        // GET: /Dependencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Dependencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,NOMBREDEPENDENCIAGENERAL,USUARIOCAPTURA,FECHACAPTURA")] DEPENDENCIASGENERALES dependenciasgenerales)
        {
            if (ModelState.IsValid)
            {
                db.DepGral.Add(dependenciasgenerales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dependenciasgenerales);
        }

        // GET: /DependenciasGenerales/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASGENERALES dependenciasgenerales = db.DepGral.Find(id);
            if (dependenciasgenerales == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasgenerales);
        }

        // POST: /DependenciasGenerales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,NOMBREDEPENDENCIAGENERAL,USUARIOCAPTURA,FECHACAPTURA")] DEPENDENCIASGENERALES dependenciasgenerales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependenciasgenerales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dependenciasgenerales);
        }

        // GET: /DependenciasGenerales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASGENERALES dependenciasgenerales = db.DepGral.Find(id);
            if (dependenciasgenerales == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasgenerales);
        }

        // POST: /DependenciasGenerales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPENDENCIASGENERALES dependenciasgenerales = db.DepGral.Find(id);
            db.DepGral.Remove(dependenciasgenerales);
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
