namespace Storagge.Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.OrderDate).HasColumnName("OrderDate").HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Category).HasColumnName("Category");
            builder.Property(p => p.Shelf).HasColumnName("Shelf");
            builder.Property(p => p.Count).HasColumnName("Count");
            builder.Property(p => p.Description).HasColumnName("Description");
        }
    }
}
