﻿using System;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using WingtipToys.Models;

namespace WingtipToys
{
	public partial class ProductDetails : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		// The id parameter should match the DataKeyNames value set on the control
		// or be decorated with a value provider attribute, e.g. [QueryString]int id
		public IQueryable<Product> GetProduct([QueryString("productId")] int? productId)
		{
			var query = new ProductContext().Products.AsQueryable();

			if (productId.HasValue && productId > 0)
			{
				query = query.Where(p => p.ProductId == productId);
			}
			else
			{
				query = null;
			}
			return query;
		}
	}
}