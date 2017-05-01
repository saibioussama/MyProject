using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication33.Controllers
{
    public class EmployesController : Controller
    {
        // GET: Employes
        public ActionResult Index()
        {
            return View(Employe.Employes());
        }

        public ActionResult Ajout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajout(Employe employe)
        {
            DAL.Employe.InsertEmploye(employe);

            return RedirectToAction("index");
        }
    }
}