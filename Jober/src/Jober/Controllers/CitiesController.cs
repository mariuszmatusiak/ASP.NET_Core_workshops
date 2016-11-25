using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jober.Controllers
{
    public class CitiesController: Controller
    {
        private Data.ICitiesRepository citiesRepository;
        public CitiesController(Data.ICitiesRepository citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public IActionResult Index()
        {
            return View(citiesRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.City item)
        {
            citiesRepository.Add(item);
            return RedirectToAction("Index");
        }
    }
}
