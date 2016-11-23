using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jober.Models;

namespace Jober.Data
{
    public class DummyJobsRepository : IJobsRepository
    {
        private List<Job> jobs;
        public DummyJobsRepository()
        {
            jobs = new List<Job>();
            jobs.Add(new Models.Job() { Added = DateTime.Now, Description = "You will be working with fun!", Title = "Fun job!", Id = 1 });
            jobs.Add(new Models.Job() { Added = DateTime.Now, Description = "Only for brave, DANGER JOB!", Title = "Danger job!", Id = 2 });

        }
        public void Add(Job item)
        {
            jobs.Add(item);
        }

        public IEnumerable<Job> GetAll()
        {
            return jobs;
        }
    }
}
