using Jober.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jober.Data
{
    public interface ICitiesRepository
    {
        void Add(City item);
        City Find(int id);
        IEnumerable<City> GetAll();
    }
}
