using System.Data.Entity;

namespace WingtipToys.Models
{
	public class ProductContext : DbContext
	{
		public ProductContext() : base("WingtipToys")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Capitalize "ID" in the DB column names.
			modelBuilder.Entity<Product>()
				.Property(p => p.ProductId)
				.HasColumnName("ProductID");

			modelBuilder.Entity<Category>()
				.Property(p => p.CategoryId)
				.HasColumnName("CategoryID");
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }
	}
}