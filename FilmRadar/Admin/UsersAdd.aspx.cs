using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class UsersAdd : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ddl_userType.DataTextField = "Name";
				ddl_userType.DataValueField = "ID";
				ddl_userType.DataSource = dm.UserTypeList();
				ddl_userType.DataBind();
			}
		}

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
			if (Convert.ToInt32(ddl_userType.SelectedItem.Value) != 0)
			{
				if (dm.DataControl("Users","Username",tb_username.Text.Trim()))
				{
					Users us = new Users();
					us.Name = tb_name.Text;
					us.Surname = tb_surname.Text;
					us.FavoriteFilm = tb_favoriteFilm.Text;
					us.Occupation = tb_occupation.Text;
					us.UserType_ID = Convert.ToInt32(ddl_userType.SelectedItem.Value);
					us.Username = tb_username.Text;
					us.DateTime = DateTime.Parse(tb_dateTime.Text);
					us.Password = tb_password.Text;
					us.Status = cb_status.Checked;
					if (dm.UserAdd(us))
					{
						pnl_successful.Visible = true;
						pnl_unsuccessful.Visible = false;
					}
					else
					{
                        pnl_successful.Visible = false;
                        pnl_unsuccessful.Visible = true;
						lbl_message.Text = "Kullanıcı Ekleme Başarısız";
                    }
				}

			}
			else
			{
				pnl_successful.Visible = false;
				pnl_unsuccessful.Visible = true;
				lbl_message.Text = "Kullanıcı Tür Seçilmelidir";
			}
        }
    }
}