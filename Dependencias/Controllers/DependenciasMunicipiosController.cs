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
    public class DependenciasMunicipiosController : Controller
    {
        private DB2Conn db = new DB2Conn();

        // GET: /DependenciasMunicipios/
        public ActionResult Index()
        {
            return View(db.DepMun.Take(10).ToList());
        }

        // GET: /DependenciasMunicipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.Find(id);
            if (dependenciasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasmunicipios);
        }

        // GET: /DependenciasMunicipios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DependenciasMunicipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,CLAVEDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA")] DEPENDENCIASMUNICIPIOS dependenciasmunicipios)
        {
            if (ModelState.IsValid)
            {
                db.DepMun.Add(dependenciasmunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dependenciasmunicipios);
        }

        // GET: /DependenciasMunicipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.Find(id);
            if (dependenciasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasmunicipios);
        }

        // POST: /DependenciasMunicipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,CLAVEDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA")] DEPENDENCIASMUNICIPIOS dependenciasmunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependenciasmunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dependenciasmunicipios);
        }

        // GET: /DependenciasMunicipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.Find(id);
            if (dependenciasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasmunicipios);
        }

        // POST: /DependenciasMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.Find(id);
            db.DepMun.Remove(dependenciasmunicipios);
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
