using System;
using System.Linq;
using System.Web.UI;
using System.Web.ModelBinding;
using WingtipToys.Models;

namespace WingtipToys
{
	public partial class ProductList : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// The method to set as the SelectMethod ListView property.
		/// </summary>
		public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
		{
			var query = new ProductContext().Products.AsQueryable();

			if (categoryId.HasValue && categoryId > 0)
			{
				query = query.Where(p => p.CategoryId == categoryId);
			}
			return query;
		}
	}
}