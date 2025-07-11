using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class CategoriesList : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			lv_categories.DataSource = dm.CategoryList();
			lv_categories.DataBind();
		}

        protected void lv_categories_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
			if (e.CommandName=="change")
			{
				int id = Convert.ToInt32(e.CommandArgument);
				dm.CategoryStatusChange(id);
			}
            lv_categories.DataSource = dm.CategoryList();
            lv_categories.DataBind();
        }
    }
}