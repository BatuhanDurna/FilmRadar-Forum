using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class UserTypeList : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
            lv_userType.DataSource = dm.UserTypeList();
            lv_userType.DataBind();
        }

        protected void lv_userType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "change")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.UserTypeStatusChange(id);
            }
            lv_userType.DataSource = dm.UserTypeList();
            lv_userType.DataBind();
        }
    }
}