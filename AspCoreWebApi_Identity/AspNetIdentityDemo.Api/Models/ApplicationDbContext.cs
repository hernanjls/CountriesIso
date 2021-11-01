using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentityDemo.Api.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<SubRegion> SubRegions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
            new Country
            {
                CountryID = 1,
                Alpha2Code = "CN",
                Alpha3Code = "CHN",
                FullName = "the People's Republic of China",
                ShortName = "China",
                NumericCode = "156"
            },
            new Country
            {
                CountryID = 2,
                Alpha2Code = "ES",
                Alpha3Code = "ESP",
                FullName = "the Kingdom of Spain",
                ShortName = "SPAIN",
                NumericCode = "724"
            },
            new Country
            {
                CountryID = 3,
                Alpha2Code = "EE",
                Alpha3Code = "EST",
                FullName = "the Republic of Estonia",
                ShortName = "ESTONIA",
                NumericCode = "233"
            });
        }


    }
}
