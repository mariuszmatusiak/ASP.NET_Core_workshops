using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jober.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var jobsRepository = new Data.DummyJobsRepository();
            return View(jobsRepository.GetAll());
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
