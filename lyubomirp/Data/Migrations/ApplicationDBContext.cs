using System;
using System.Collections.Generic;
using System.Text;
using lyubomirp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Project> Projects { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public DbSet<lyubomirp.Models.Summary> Summary { get; set; }


        public DbSet<lyubomirp.Models.ProgramsList> ProgramsList { get; set; }
    }
}
