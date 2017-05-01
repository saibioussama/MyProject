using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class DepartementsController : Controller
    {
        // GET: Departements
        public ActionResult Index()
        {
            return View(DAL.Departement.Departements().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DAL.Departement departement)
        {
            DAL.Departement.InsertDepartement(departement);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            DAL.Departement.DeleteDepartement(id);
            return RedirectToAction("index");
        }

        public ActionResult Edite(int id)
        {
            return View(DAL.Departement.GetDepartement(id));
        }

        [HttpPost]
        public ActionResult Edite(DAL.Departement departement)
        {
            DAL.Departement.UpdateDepatement(departement);
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            return View(DAL.Departement.GetDepartement(id));
        }


    }
}