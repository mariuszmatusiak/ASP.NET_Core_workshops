﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jober.Models;
using Microsoft.EntityFrameworkCore;

namespace Jober.Data
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
