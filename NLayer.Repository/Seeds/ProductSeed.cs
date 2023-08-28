using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, CategoryId = 1, Name = "Arçelik B1", Price = 5000, CreatedDate = DateTime.Now, Stock = 30 },
                            new Product { Id = 2, CategoryId = 1, Name = "Arçelik B2", Price = 5100, CreatedDate = DateTime.Now, Stock = 32 },
                            new Product { Id = 3, CategoryId = 2, Name = "Arçelik T1", Price = 5500, CreatedDate = DateTime.Now, Stock = 42 },
                            new Product { Id = 4, CategoryId = 2, Name = "Arçelik T2", Price = 5700, CreatedDate = DateTime.Now, Stock = 40 },
                            new Product { Id = 5, CategoryId = 3, Name = "Arçelik Ç1", Price = 6100, CreatedDate = DateTime.Now, Stock = 38 },
                            new Product { Id = 6, CategoryId = 3, Name = "Arçelik Ç2", Price = 6200, CreatedDate = DateTime.Now, Stock = 35 });
        }
    }
}
