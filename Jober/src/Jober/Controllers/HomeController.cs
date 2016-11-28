using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jober.Controllers
{
    public class HomeController : Controller
    {
        private Data.IJobsRepository jobsRepository;
        private Data.ICitiesRepository citiesRepository;
        private IMemoryCache memoryCache;
        ILogger<HomeController> logger;

        public HomeController(
            Data.IJobsRepository jobsRepository,
            Data.ICitiesRepository citiesRepository,
            IMemoryCache memoryCache,
            ILogger<HomeController> logger)
        {
            this.jobsRepository = jobsRepository;
            this.citiesRepository = citiesRepository;
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        public IActionResult Index(string searchValue, int? CityId)
        {
            var cities = new List<Models.City>();

            if (memoryCache.TryGetValue<List<Models.City>>("Cities", out cities))
            {
                logger.LogInformation("Cities retrieved from cache.");
            }            
            else
            {
                cities = citiesRepository.GetAll().ToList();
                memoryCache.Set<List<Models.City>>(
                    "Cities",
                    cities,
                    new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
                logger.LogInformation("Cities updated from DB.");
            }

            ViewBag.Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cities, "CityId", "Name");


            if (!string.IsNullOrWhiteSpace(searchValue) || CityId.HasValue)
            {
                return View(jobsRepository.Search(searchValue, CityId));
            }

            var jobs = new List<Models.Job>();

            if (memoryCache.TryGetValue<List<Models.Job>>("Jobs", out jobs))
            {
                logger.LogInformation("Jobs retrieved from cache.");
            }
            else
            {
                jobs = jobsRepository.GetAll().ToList();
                memoryCache.Set<List<Models.Job>>(
                    "Jobs",
                    jobs,
                    new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
                logger.LogInformation("Jobs updated from DB.");
            }

            return View(jobs);
        }

        public IActionResult Create()
        {
            ViewBag.Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(citiesRepository.GetAll(), "CityId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Job item)
        {
            jobsRepository.Add(item);
            memoryCache.Remove("Jobs");
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}