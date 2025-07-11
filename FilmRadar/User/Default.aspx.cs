using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.User
{
	public partial class Default : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["catID"]!=null)
				{
					int catID = Convert.ToInt32(Request.QueryString["catID"]);
					rp_Listfilm.DataSource = dm.FilmsList(catID);
				}
				else
				{
					rp_Listfilm.DataSource = dm.FilmsList(true);
				}
				rp_Listfilm.DataBind();
			}
		}
	}
}