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

        public IActionResult Index()
        {
            return View(jobsRepository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Cities = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(citiesRepository.GetAll(), "Id", "Name");
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