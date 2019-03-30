using Microsoft.EntityFrameworkCore;
using SC.Domain.Models;
using SC.Infrastructure.Mappings;

namespace SC.Infrastructure
{
    public class SCContext: DbContext
    {
        public SCContext(DbContextOptions<SCContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Sale> Sales { get;  set; }
        public DbSet<SaleDetail> SalesDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PlaylistMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
            modelBuilder.ApplyConfiguration(new SaleDetailMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}