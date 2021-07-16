using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.Data
{
    public class ApplicationDbContext : /*DbContext*/IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adding new tables
        public DbSet<ProductDataDictionary> Products { get; set; }

    }
}
