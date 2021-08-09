using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olympics.Services;
using OlympicsDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Controllers
{
    public class SportController : Controller
    {
        private SportDBService _sportDB;

        public SportController(SportDBService sportDB)
        {
            _sportDB = sportDB;
        }
        // GET: SportController
        public ActionResult Index()
        {
            return View(_sportDB.AllSports());
        }

        // GET: SportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportController/Create
        [HttpPost]
        public ActionResult Create(SportModel sport)
        {
            _sportDB.AddSport(sport);

            return RedirectToAction("Index");
        }

        // GET: SportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SportController/Edit/5
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

        // GET: SportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportController/Delete/5
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
