using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayer.Repository
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductFeature> ProductFeatures { get; set; }

		public override int SaveChanges()
		{
			foreach (var item in ChangeTracker.Entries())
			{
				if (item.Entity is BaseEntity entityReference)
				{
					switch (item.State)
					{
						case EntityState.Added:
							{
								entityReference.CreatedDate = DateTime.Now;
								break;
							}
						case EntityState.Modified:
							{
								entityReference.UpdatedDate = DateTime.Now;
								break;
							}
					}
				}
			}
			return base.SaveChanges();
		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var item in ChangeTracker.Entries())
			{
				if (item.Entity is BaseEntity entityReference)
				{
					switch (item.State)
					{
						case EntityState.Added:
							{
								entityReference.CreatedDate = DateTime.Now;
								break;
							}
						case EntityState.Modified:
							{
								Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
								entityReference.UpdatedDate = DateTime.Now;
								break;
							}
					}
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			// Normalde Entity ayarlarımızı attribute vererek yapabiliriz ama burada yapmak daha sağlıklı.Fakat best practise olarak ayrı bir classta bunu yapmalıyız.

			//modelBuilder.Entity<Category>().HasKey(c => c.Id);


			// burada tüm configurasyonları uyguluyoruz
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			// burada single configurasyon veya istediklerimizi ekliyoruz.
			//modelBuilder.ApplyConfiguration(new ProductConfiguration());
			//modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());

			//bunu seed olarak data yapabilirdik fakat buradaki yapılış yöntemi için de buraya ekledik.
			modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature() { Id = 1, Color = "Kırmızı", Height = 200, Width = 300, ProductId = 1 },
														  new ProductFeature() { Id = 2, Color = "Mavi", Height = 250, Width = 320, ProductId = 2 },
														  new ProductFeature() { Id = 3, Color = "Sarı", Height = 180, Width = 300, ProductId = 3 },
														  new ProductFeature() { Id = 4, Color = "Yeşil", Height = 190, Width = 500, ProductId = 4 });
			base.OnModelCreating(modelBuilder);
		}
	}
}
