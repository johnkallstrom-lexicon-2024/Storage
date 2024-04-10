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

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Under Falling Skies",
                    Price = 299,
                    Category = "Entertainment",
                    Shelf = "A15",
                    Count = 10,
                    Description = "A boardgame about fighting invading alien ships!"
                },
                new Product
                {
                    Id = 2,
                    Name = "Hanwag Hiking Boots",
                    Price = 1099,
                    Category = "Outdoors",
                    Shelf = "B07",
                    Count = 3,
                    Description = "A sturdy pair of hiking boots."
                },
                new Product
                {
                    Id = 3,
                    Name = "Moccamaster",
                    Price = 1499,
                    Category = "Kitchen",
                    Shelf = "C19",
                    Count = 5,
                    Description = "Great coffee machine."
                },
                new Product
                {
                    Id = 4,
                    Name = "Monstera Delicsiosa",
                    Price = 199,
                    Category = "Plants",
                    Shelf = "D01",
                    Count = 15,
                    Description = "An easy to care for plant that fits most homes!"
                },
                new Product
                {
                    Id = 5,
                    Name = "Zelda: Breath of the Wild",
                    Price = 699,
                    Category = "Entertainment",
                    Shelf = "A08",
                    Count = 15,
                    Description = "An awesome videogame!"
                }
            };

            builder.HasData(products);
        }
    }
}
