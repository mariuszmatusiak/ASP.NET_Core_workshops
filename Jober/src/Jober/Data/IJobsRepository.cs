using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jober.Models;

namespace Jober.Data
{
    public interface IJobsRepository
    {
        void Add(Job item);
        IEnumerable<Job> GetAll();
        IEnumerable<Job> Search(string searchValue, int? CityId);   
    }
}
