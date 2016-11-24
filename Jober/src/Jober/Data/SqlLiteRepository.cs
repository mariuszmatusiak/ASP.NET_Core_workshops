using System.Collections.Generic;
using System.Linq;
using Jober.Models;

namespace Jober.Data
{
    public class SqlLiteRepository : IJobsRepository
    {
        private AppDB db;

        public SqlLiteRepository(AppDB db)
        {
            this.db = db;
           
        }

        public void Add(Job item)
        {
            db.Jobs.Add(item);
            db.SaveChanges();
        }

        public IEnumerable<Job> GetAll()
        {
            return db.Jobs.AsEnumerable();
        }
    }
}