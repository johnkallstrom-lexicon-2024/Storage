namespace Storagge.Persistence
{
    public class StorageeDbContext : DbContext
    {
        public StorageeDbContext(DbContextOptions<StorageeDbContext> options) : base(options)
        {
        }
    }
}
