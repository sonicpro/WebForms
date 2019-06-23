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

			modelBuilder.Entity<CartItem>()
				.Property(i => i.ItemId)
				.HasColumnName("ItemID");

			modelBuilder.Entity<CartItem>()
				.Property(i => i.CartId)
				.HasColumnName("CartID");

			modelBuilder.Entity<CartItem>()
				.Property(i => i.ProductId)
				.HasColumnName("ProductID");
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<CartItem> ShoppingCartItems { get; set; }
	}
}