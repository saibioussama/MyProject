using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication22.Controllers
{
    public class ProjetsController : Controller
    {
        // GET: Projets
        public ActionResult Index()
        {
            return View(DAL.Projet.Projets().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DAL.Projet projet)
        {
            DAL.Projet.InsertProjet(projet);
            return RedirectToAction("index");
        }

        public ActionResult Details(string id)
        {
            return View(DAL.Projet.GetProjet(id));
        }

        public ActionResult Delete(string id)
        {
            DAL.Projet.DeleteProjet(id);
            return RedirectToAction("index");
        }

        public ActionResult Edite(string id)
        {
            return View(DAL.Projet.GetProjet(id));
        }

        [HttpPost]
        public ActionResult Edite(DAL.Projet projet)
        {
            DAL.Projet.UpdateProjet(projet);
            return RedirectToAction("index");
        }

    }
}