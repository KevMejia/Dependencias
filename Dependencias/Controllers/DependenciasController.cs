using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dependencias.Models;
using System.Web.Routing;

namespace Dependencias.Controllers
{
    public class DependenciasController : Controller
    {
        private DB2Conn db = new DB2Conn();

        // GET: /Dependencias/
        [Authorize]
        public ActionResult Index()
        {
            ViewData["DepGral"] = db.DepGral.ToList();
            return View();
        }

        // GET: /Dependencias/DependenciasAuxiliares
        [Authorize]
        public ActionResult DependenciasAuxiliares()
        {
            ViewData["DepAux"] = db.DepAux.ToList();
            return View();
        }

        [Authorize]
        public ActionResult DependenciasMunicipios()
        {
            ViewData["DepMun"] = db.DepMun.ToList();          
            return View();
        }

        /* 
         * 
         * MODIFICAR
         * 
         */

        [Authorize]
        public ActionResult ModificarDepGral(string id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarDepGral([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,NOMBREDEPENDENCIAGENERAL,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASGENERALES dependenciasgenerales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependenciasgenerales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dependenciasgenerales);
        }

        [Authorize]
        public ActionResult ModificarDepAux(string id)
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

        // POST: /Dependencias/ModificarDepAux/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarDepAux([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAAUXILIAR,NOMBREDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASAUXILIARES dependenciasauxiliares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependenciasauxiliares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DependenciasAuxiliares");
            }
                return View(dependenciasauxiliares);   
        }

        //GET /Dependencias/ModificarDepMun/5
        [Authorize]
        public ActionResult ModificarDepMun(string id, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.FirstOrDefault(i => i.CLAVEDEPENDENCIAGENERAL == id && i.CLAVEDEPENDENCIAAUXILIAR == id2);
            if (dependenciasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasmunicipios);
        }

        // POST: /Dependencias/ModificarDepAux/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarDepMun([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,CLAVEDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASMUNICIPIOS dependenciasmunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dependenciasmunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DependenciasMunicipios");
            }
            return View(dependenciasmunicipios);
        }

        /*
         * 
         * CREAR
         * 
         */
        [Authorize]
        public ActionResult NuevoDepGral()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoDepGral([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,NOMBREDEPENDENCIAGENERAL,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASGENERALES dependenciasgenerales)
        {
            if (ModelState.IsValid)
            {
                db.DepGral.Add(dependenciasgenerales);
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(new { controller="Dependencias", action="Index"}));
            }
            return View(dependenciasgenerales);
            
        }

        [Authorize]
        public ActionResult NuevoDepAux()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoDepAux([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAAUXILIAR,NOMBREDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASAUXILIARES dependenciasauxiliares)
        {
            if (ModelState.IsValid)
            {
                db.DepAux.Add(dependenciasauxiliares);
                db.SaveChanges();
                return RedirectToAction("DependenciasAuxiliares");
            }
            return View(dependenciasauxiliares);
        }

        [Authorize]
        public ActionResult NuevoDepMun()
        {
            return View();
        }
        
        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoDepMun([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,CLAVEDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASMUNICIPIOS dependenciasmunicipios)
        {
            if (ModelState.IsValid)
            {
                db.DepMun.Add(dependenciasmunicipios);
                db.SaveChanges();
                return RedirectToAction("DependenciasMunicipios");
            }
            return View(dependenciasmunicipios);
        }
       

        /*
         * 
         * ELIMINAR 
         * 
         */

        // GET: /Dependencias/DepGral/EliminarDepGral/5
        [Authorize]
        public ActionResult EliminarDepGral(string id)
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

        // POST: /Dependencias/DepGral/EliminarDepGral/5
        [HttpPost, ActionName("EliminarDepGral")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,NOMBREDEPENDENCIAGENERAL,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")]DEPENDENCIASGENERALES dependenciasgenerales)
        {
            string id = dependenciasgenerales.CLAVEDEPENDENCIAGENERAL.ToString();
            DEPENDENCIASGENERALES dep = db.DepGral.Find(id);
            db.DepGral.Remove(dep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Dependencias/DepGral/EliminarDepAux/5
        [Authorize]
        public ActionResult EliminarDepAux(string id)
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

        // POST: /Dependencias/DepAux/EliminarDepAux/5
        [HttpPost, ActionName("EliminarDepAux")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedDepAux([Bind(Include="CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAAUXILIAR,NOMBREDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASAUXILIARES dependenciasauxiliares)
        {
            string id = dependenciasauxiliares.CLAVEDEPENDENCIAAUXILIAR.ToString();
            DEPENDENCIASAUXILIARES depAux = db.DepAux.Find(id);
            db.DepAux.Remove(depAux);
            db.SaveChanges();
            return RedirectToAction("DependenciasAuxiliares");
        }

        // GET: /Dependencias/DepMun/EliminarDepMun/5,2
        [Authorize]
        public ActionResult EliminarDepMun(string id, string id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.FirstOrDefault(i => i.CLAVEDEPENDENCIAGENERAL == id && i.CLAVEDEPENDENCIAAUXILIAR == id2);
            if (dependenciasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasmunicipios);
        }

        // POST: /Dependencias/DepAux/EliminarDepAux/5
        [HttpPost, ActionName("EliminarDepMun")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedDepMun([Bind(Include = "CLAVEDEPENDENCIA,ANIOOPERACION,CLAVEDEPENDENCIAGENERAL,CLAVEDEPENDENCIAAUXILIAR,USUARIOCAPTURA,FECHACAPTURA,STATUSDEPENDENCIASGENERALES")] DEPENDENCIASMUNICIPIOS dependenciasmunicipios)
        {
            string id = dependenciasmunicipios.CLAVEDEPENDENCIAGENERAL.ToString();
            string id2 = dependenciasmunicipios.CLAVEDEPENDENCIAAUXILIAR.ToString();
            DEPENDENCIASMUNICIPIOS depMun = db.DepMun.Where(i => i.CLAVEDEPENDENCIAGENERAL == id && i.CLAVEDEPENDENCIAAUXILIAR == id2).FirstOrDefault();
            db.DepMun.Remove(depMun);
            db.SaveChanges();
            return RedirectToAction("DependenciasMunicipios");
        }


        /*
         * 
         * DETALLES 
         * 
         */

        // GET: /Dependencias/DetallesDepGral/5
        [Authorize]
        public ActionResult DetallesDepGral(string id)
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

        // GET: /Dependencias/DetallesDepAux/5
        [Authorize]
        public ActionResult DetallesDepAux(string id)
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

        // GET: /Dependencias/DetallesDepAux/5
        [Authorize]
        public ActionResult DetallesDepMun(string id, string id2)
        {
            if (id == null || id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPENDENCIASMUNICIPIOS dependenciasmunicipios = db.DepMun.FirstOrDefault(i => i.CLAVEDEPENDENCIAGENERAL == id && i.CLAVEDEPENDENCIAAUXILIAR == id2);
            if (dependenciasmunicipios == null)
            {
                return HttpNotFound();
            }
            return View(dependenciasmunicipios);
        }
    }
}