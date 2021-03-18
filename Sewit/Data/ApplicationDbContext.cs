using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sewit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dress> Dresses { get; set; }
        public DbSet<TopComponent> TopComponents { get; set; }
        public DbSet<SkirtComponent> SkirtComponents { get; set; }
        public DbSet<SleeveComponent> SleeveComponents { get; set; }
    }
}
