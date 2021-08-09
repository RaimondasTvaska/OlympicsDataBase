using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.Models;
using Olympics.Services;
using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Controllers
{
    public class AthleteController : Controller
    {
        // GET: AthleteController
        private AthleteDBService _athlete;
        public AthleteController (AthleteDBService athletes)
        {
            _athlete = athletes;
        }
        public IActionResult Index()
        {
            return View(_athlete.All());
        }
        // GET: AthleteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AthleteController/Create
        public IActionResult Create()
        {
            ParticipantModel newAthlete = new();
            {
                athletes = new List<AthleteModel>() { new AthleteModel()}
            }
            return View(newAthlete);
        }

        // POST: AthleteController/Create
        [HttpPost]
        
        public IActionResult Create(List<AthleteModel> athletes)
        {
            _athlete.AddNewAthlete(athletes);

            return RedirectToAction("Index");

        }

        // GET: AthleteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AthleteController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AthleteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AthleteController/Delete/5
        [HttpPost]
        
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
