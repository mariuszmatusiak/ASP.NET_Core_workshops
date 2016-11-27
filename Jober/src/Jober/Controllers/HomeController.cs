using Microsoft.AspNetCore.Mvc;

namespace Jober.Controllers
{
    public class HomeController : Controller
    {
        private Data.IJobsRepository jobsRepository;
        private Data.ICitiesRepository citiesRepository;
        public HomeController(Data.IJobsRepository jobsRepository, Data.ICitiesRepository citiesRepository)
        {
            this.jobsRepository = jobsRepository;
            this.citiesRepository = citiesRepository;
        }
       
        public IActionResult Index(string searchValue, int? CityId)
        {
            ViewBag.Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(citiesRepository.GetAll(), "CityId", "Name");

            if (!string.IsNullOrWhiteSpace(searchValue)||CityId.HasValue)
            {
                return View(jobsRepository.Search(searchValue, CityId));
            }
            return View(jobsRepository.GetAll());
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
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}