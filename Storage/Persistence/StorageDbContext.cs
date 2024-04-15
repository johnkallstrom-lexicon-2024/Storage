namespace Storagge.Persistence
{
    public class StorageDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
