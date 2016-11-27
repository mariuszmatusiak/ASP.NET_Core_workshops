using Jober.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jober.Controllers
{
    public class HelperController : Controller
    {
        private AppDB db;
        private List<string> cities = new List<string>() { "Warszawa", "Kraków", "Łódź", "Wrocław", "Gdynia" };
        private List<string> jobs = new List<string>() { "ASP.NET Core", ".NET WPF + WCF", "Entity Framework expert", "Java EE", "Java SE", "C# Beginer" };
        public HelperController(AppDB db)
        {
            this.db = db;
        }
        public string Cities()
        {
            foreach (var item in cities)
            {
                if (!db.Cities.Any(x => x.Name == item))
                {
                    db.Cities.Add(new Models.City() { Name = item });
                    db.SaveChanges();
                }

            }
            return "Cities generation is Done.";
        }

        public string Jobs()
        {
            foreach (var item in cities)
            {
                var city = db.Cities.First(x=>x.Name == item);
                foreach (var job in jobs)
                {
                    db.Jobs.Add(new Models.Job() { Title = job, Description = job, CityId = city.CityId, Added = DateTime.Now });
                    db.SaveChanges();
                }
            }


                return "Jobs generation is Done.";
        }
    }
}
