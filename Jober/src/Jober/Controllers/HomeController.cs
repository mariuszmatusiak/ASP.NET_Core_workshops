using Microsoft.AspNetCore.Mvc;

namespace Jober.Controllers
{
    public class HomeController : Controller
    {
        private Data.IJobsRepository jobsRepository;
        public HomeController(Data.IJobsRepository jobsRepository)
        {
            this.jobsRepository = jobsRepository;
        }

        public IActionResult Index()
        {
            return View(jobsRepository.GetAll());
        }

        public IActionResult Create()
        {
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