using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options) 
            : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                 .HasData(
                new City("New York City")
                {
                    Id = 1,
                    Description = "The one with that big park."
                },
                new City("Antwerp")
                {
                    Id = 2,
                    Description = "The one with the Cathedral that was never really finished."
                },
                new City("Thika")
                {
                    Id = 3,
                    Description = "Kiambu County first city with an industrial park."
                },
                new City("Kisumu City")
                {
                    Id = 4,
                    Description = "The City at the lake side."
                }
                );
            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Central Park")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "The most visited urban park in the united states"
                },
                new PointOfInterest("Empire State Building")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "A 102 - Story skyscraper located in midtown ManHattan"
                },
                 new PointOfInterest("Central Park")
                 {
                     Id = 3,
                     CityId = 2,
                     Description = "The most visited urban park in the united states"
                 },
                new PointOfInterest("Cathedral")
                {
                    Id = 4,
                    CityId = 2,
                    Description = "A 102 - Story skyscraper located in midtown ManHattan"
                },
                 new PointOfInterest("DelMontty")
                 {
                     Id = 5,
                     CityId = 3,
                     Description = "The most visited urban park in the united states"
                 },
                new PointOfInterest("Thika Road")
                {
                    Id = 6,
                    CityId = 3,
                    Description = "A 102 - Story skyscraper located in midtown ManHattan"
                },
                 new PointOfInterest("River Nile")
                 {
                     Id = 7,
                     CityId = 4,
                     Description = "The most visited urban park in the united states"
                 },
                new PointOfInterest("Lake Victoria")
                {
                    Id = 8,
                    CityId = 4,
                    Description = "A 102 - Story skyscraper located in midtown ManHattan"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
