using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.Models;
using Olympics.Services;
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
        private CountryDBService _countryDBService;
        private ParticipantDBService _participantsDBService;
        private SportDBService _sportDBService;

        public AthleteController(AthleteDBService athlete, CountryDBService countryDBService, ParticipantDBService participantsDBService, SportDBService sportDBService)
        {
            _athlete = athlete;
            _countryDBService = countryDBService;
            _participantsDBService = participantsDBService;
            _sportDBService = sportDBService;
        }

        public ActionResult Index()
        {
            return View(_participantsDBService.AllParticipants());
        }
        // GET: AthleteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public IActionResult FilteredIndex(ParticipantsModel model)
        {
            var dbModel = _participantsDBService.AllParticipants();

            if (model.SortFilter.FilterSport != "")
            {
                dbModel.Athletes = dbModel.Athletes.Where(a => a.SportName == model.SortFilter.FilterSport).ToList();
            }
            if (model.SortFilter.FilterCountry != "")
            {
                dbModel.Athletes = dbModel.Athletes.Where(c => c.CountryName == model.SortFilter.FilterCountry).ToList();
            }

            return View("Index", dbModel);
        }

        // GET: AthleteController/Create
        public ActionResult Create()
        {
            ParticipantsModel participants = new()
            {
                Countries = _countryDBService.AllCountries(),
                Sports = _sportDBService.AllSports()

            };
            return View(participants);
        }

        // POST: AthleteController/Create
        [HttpPost]

        public ActionResult Create(ParticipantsModel participants)
        {
            _athlete.AddNewAthlete(participants);

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
