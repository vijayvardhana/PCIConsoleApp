using Microsoft.EntityFrameworkCore;

namespace PCIApplication
{
    public class PCIDbContext: DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Projection> Projections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "pcidb");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EAUS9KT;Initial Catalog=pcidb;Integrated Security=true");
        }
    }
}
