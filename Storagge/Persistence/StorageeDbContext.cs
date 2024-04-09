namespace Storagge.Persistence
{
    public class StorageeDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageeDbContext(DbContextOptions<StorageeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
