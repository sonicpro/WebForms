using System;
using System.Linq;
using System.Web.UI;
using WingtipToys.Models;

namespace WingtipToys
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public IQueryable<Category> GetCategories()
		{
			var db = new ProductContext();
			return db.Categories;
		}
	}
}