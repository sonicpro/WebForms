using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;

namespace WingtipToys.Logic
{
	public class ShoppingCartActions : IDisposable
	{
		private ProductContext db = new ProductContext();

		public const string CartSessionKey = "CartId";

		public string ShoppingCartId { get; set; }

		#region Public Methods

		public void AddToCart(int id)
		{
			ShoppingCartId = GetCartId();

			var cartItem = db.ShoppingCartItems.SingleOrDefault(
					i => i.CartId == ShoppingCartId && i.ProductId == id);

			if (cartItem == null)
			{
				cartItem = new CartItem
				{
					ItemId = Guid.NewGuid().ToString(),
					ProductId = id,
					CartId = ShoppingCartId,
					Product = db.Products.SingleOrDefault(p => p.ProductId == id),
					Quantity = 1,
					DateCreated = DateTime.Now
				};

				db.ShoppingCartItems.Add(cartItem);
			}
			else
			{
				cartItem.Quantity++;
			}
			db.SaveChanges();
		}

		public List<CartItem> GetCartItems()
		{
			ShoppingCartId = GetCartId();
			return db.ShoppingCartItems
				.Where(i => i.CartId == ShoppingCartId)
				.ToList();
		}

		#endregion

		#region Helper Methods

		private string GetCartId()
		{
			if (HttpContext.Current.Session[CartSessionKey] == null)
			{
				if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
				{
					HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
				}
				else
				{
					// Generate a GUID
					Guid tempCardId = Guid.NewGuid();
					HttpContext.Current.Session[CartSessionKey] = tempCardId.ToString();
				}
			}
			return HttpContext.Current.Session[CartSessionKey].ToString();
		}

		#endregion

		public void Dispose()
		{
			if (db != null)
			{
				db.Dispose();
				db = null;
			}
		}
	}
}