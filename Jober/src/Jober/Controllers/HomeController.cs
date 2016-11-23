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

        public IActionResult Error()
        {
            return View();
        }
    }
}