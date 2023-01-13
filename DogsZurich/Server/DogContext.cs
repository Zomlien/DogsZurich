using Microsoft.EntityFrameworkCore;
using DogsZurich.Shared;

namespace DogsZurich.Server
{
    public class DogContext : DbContext
    {
        public DogContext(DbContextOptions<DogContext> options) : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Ageclass> Ageclass { get; set; }
        public DbSet<Breed> Breed { get; set; }
        public DbSet<Breedstatus> Breedstatus { get; set; }
        public DbSet<Breedtype> Breedtype { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Quartier> Quartier { get; set; }
        public DbSet<Kreis> Kreis { get; set; }
        public DbSet<Sex> Sex { get; set; }

    }
}
