using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class UsersList : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			lv_users.DataSource = dm.UsersList();
			lv_users.DataBind();
		}

        protected void lv_users_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
			if (e.CommandName=="change")
			{
				int id = Convert.ToInt32(e.CommandArgument);
				dm.UserStatusChange(id);

			}
            lv_users.DataSource = dm.UsersList();
            lv_users.DataBind();
        }
    }
}