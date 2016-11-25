using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jober.Models;

namespace Jober.Data
{
    public class CitiesRepository : ICitiesRepository
    {
        private AppDB db;
        public CitiesRepository(AppDB db)
        {
            this.db = db;
        }
        public void Add(City item)
        {
            db.Cities.Add(item);
            db.SaveChanges();
        }

        public City Find(int id)
        {
            return db.Cities.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            return db.Cities.AsEnumerable();
        }
    }
}
