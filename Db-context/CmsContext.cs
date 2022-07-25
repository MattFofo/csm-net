using CSM_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CSM_NET.Db_context
{
    public class CMSContext : DbContext
    {
        public DbSet<Page> pages { get; set; }
        public DbSet<Component> components { get; set; }
        public DbSet<ComponentDefinition> componentDefinitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CMS-net-db;Integrated Security=True");
        }

    }
}
