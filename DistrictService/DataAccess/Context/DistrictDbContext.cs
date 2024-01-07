using DistrictService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DistrictService.DataAccess.Context
{
    public class DistrictDbContext : DbContext
    {
        public DbSet<District> Districts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}