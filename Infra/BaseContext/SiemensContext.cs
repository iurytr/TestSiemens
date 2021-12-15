using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.BaseContext
{
    public class SiemensContext : DbContext
    {
        public SiemensContext(DbContextOptions<SiemensContext> options) : base(options)
        {
        }

        public DbSet<City> City { get; set; }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
        }
    }
}
