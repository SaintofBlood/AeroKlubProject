using AreoKlub.Domain.Entities;
using System.Data.Entity;

namespace AreoKlub.Domain.Concrate
{
    public class EFDbContext : DbContext
    {
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services {get;set;}


    }
}
