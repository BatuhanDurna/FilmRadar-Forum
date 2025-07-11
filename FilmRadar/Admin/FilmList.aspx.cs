using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class FilmList : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			lv_films.DataSource = dm.FilmsList();
			lv_films.DataBind();
		}

        protected void lv_films_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.FilmStatusChange(id);
            }
            lv_films.DataSource = dm.FilmsList();
            lv_films.DataBind();
        }
    }
}