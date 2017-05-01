using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication33.Controllers
{
    public class ProjetsController : Controller
    {
        // GET: Projets
        public ActionResult Index()
        {
            return View(DAL.Projet.Projets());
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

    }
}