using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ParticipationsController : Controller
    {
        // GET: Participations
        public ActionResult Index()
        {
            return View(DAL.Participation.Participations().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DAL.Participation participation)
        {
            DAL.Participation.InsertParticipation(participation);
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            return View(DAL.Participation.GetParticipation(id));
        }

        public ActionResult Delete(int id)
        {
            DAL.Participation.DeleteParticipation(id);
            return RedirectToAction("index");
        }

        public ActionResult Edite(int id)
        {
            return View(DAL.Participation.GetParticipation(id));
        }

        [HttpPost]
        public ActionResult Edite(DAL.Participation participation)
        {
            DAL.Participation.UpdateParticipation(participation);
            return RedirectToAction("index");
        }

    }
}