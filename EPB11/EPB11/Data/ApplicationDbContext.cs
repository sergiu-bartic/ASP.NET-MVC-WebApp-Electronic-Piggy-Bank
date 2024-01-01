using EPB11.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EPB11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SoldModel> Sold { get; set; }
        public DbSet<VenitModel> Venit { get; set; }
        public DbSet<AchizitieModel> Achizitie { get; set; }
        public DbSet<ObiectivModel> Obiectiv { get; set; }
    }
}
