﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilmRadar.Admin
{
	public partial class AdminMaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void lbtn_adminexit_Click(object sender, EventArgs e)
        {
			Session["user"] = null;
			if (Session["user"] == null)
			{
				Response.Redirect("../User/Default.aspx");
			}
        }
    }
}