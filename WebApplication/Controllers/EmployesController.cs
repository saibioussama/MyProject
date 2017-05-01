using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class EmployesController : Controller
    {
        // GET: Employes
        //[OutputCache(Duration =30,VaryByParam ="none",Location = System.Web.UI.OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {
            return View(DAL.Employe.Employes().ToList());
        }

        public ActionResult Edite(int id)
        {
            var employe = DAL.Employe.Employes().SingleOrDefault(p => p.Matr == id);
            if (employe == null)
                return HttpNotFound();
            return View(employe);
        }

        [HttpPost]
        public ActionResult Edite(DAL.Employe employe)
        {
            DAL.Employe.UpdateEmploye(employe);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            DAL.Employe.DeleteEmploye(id);
            return RedirectToAction("index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DAL.Employe employe)
        {
            DAL.Employe.InsertEmploye(employe);
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var employe = DAL.Employe.Employes().SingleOrDefault(p=>p.Matr == id);
            if (employe == null)
                return HttpNotFound();
            else return View(employe);
        }
    }
}