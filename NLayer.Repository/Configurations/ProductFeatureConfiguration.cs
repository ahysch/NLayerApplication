using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        /// <summary>
        /// Bunu örnek olarak yaptık.Diğer Entityler de bu şekilde configure edilebilir.Appdbcontext classında onmodelcreating kısmındaki karışıklığı bu şekilde çözebiliriz.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("ProductFeatures");
            // Bir Productfeature'un bir product'ı olur ve bir product'ın bir feature'u olur ve fk'i ProductFeaturedaki productid dir.
            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x=>x.ProductId);
        }
    }
}
