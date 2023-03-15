﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APOD.Models;

namespace APOD.Data
{
    public class APODContext : DbContext
    {
        public APODContext (DbContextOptions<APODContext> options)
            : base(options)
        {
        }

        public DbSet<APOD.Models.APODModel> APOD { get; set; } = default!;
    }
}
