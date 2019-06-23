using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using WingtipToys.Logic;

namespace WingtipToys
{
	// Intermediary page (aka "Controller"). Calls to ShoppingCartActions.AddToCart(id).
	public partial class AddToCart : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string rawId = Request.QueryString["ProductId"];
			int productId;
			if (!string.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
			{
				using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
				{
					usersShoppingCart.AddToCart(Convert.ToInt32(rawId));
				}
			}
			else
			{
				Debug.Fail("Error : We should never get to AddToCart.aspx without a ProductId.");
				throw new Exception("Error : It is illegal to load AddToCart.aspx without setting a ProductId.");
			}
			Response.Redirect("ShoppingCart.aspx");
		}
	}
}