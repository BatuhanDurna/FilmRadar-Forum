using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.User
{
	public partial class Login : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Form.DefaultButton = lbtn_login.UniqueID;
		}

        protected void lbtn_login_Click(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(tb_username.Text) && !string.IsNullOrEmpty(tb_password.Text))
			{
				Users user = dm.CheckAuthorization(tb_username.Text, tb_password.Text);
				if (user != null)
				{
					Session["user"] = user;
					Response.Redirect("Default.aspx");
				}
            }
					
			else
			{
				pnl_loginMessage.Visible = true;
				lbl_message.Text = "Lütfen Boş Bırakmayınız";
			}
        }

        protected void lbtn_signup_Click(object sender, EventArgs e)
        {
			Response.Redirect("Register.aspx");
        }
    }
}