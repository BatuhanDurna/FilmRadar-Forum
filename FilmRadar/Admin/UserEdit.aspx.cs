using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class UserEdit : System.Web.UI.Page
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
				int id = Convert.ToInt32(Request.QueryString["userID"]);
				Users user = dm.GetUser(id);
				if (user != null && user.Name != null)
				{
					tb_name.Text = user.Name;
					tb_surname.Text = user.Surname;
					tb_favoriteFilm.Text = user.FavoriteFilm;
					tb_occupation.Text = user.Occupation;
					ddl_userType.SelectedValue = user.UserTypeStr.ToString();
					tb_username.Text = user.Username;
					cb_status.Checked = user.Status;
				}
				else
				{
					Response.Redirect("UsersList.aspx");
				}

			}
		}

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
			int id = Convert.ToInt32(Request.QueryString["userID"]);

			Users user = dm.GetUser(id);
			user.Name = tb_name.Text;
			user.Surname = tb_surname.Text;
			user.FavoriteFilm = tb_favoriteFilm.Text;
			user.Occupation = tb_occupation.Text;
			user.UserType_ID = Convert.ToInt32(ddl_userType.SelectedItem.Value);
			user.Username = tb_username.Text;
			user.Status = cb_status.Checked;
			if (dm.UserEdit(user))
			{
				pnl_successful.Visible = true;
				pnl_unsuccessful.Visible = false;
				tb_name.Text = "";
				tb_surname.Text = "";
				tb_favoriteFilm.Text = "";
				tb_occupation.Text = "";
				ddl_userType.SelectedValue = "0";
				tb_username.Text = "";
				cb_status.Checked = false;
			}
			else
			{
                pnl_successful.Visible = false;
                pnl_unsuccessful.Visible = true;
				lbl_message.Text = "Kullanıcı Düzenleme Başarısız";
            }
        }
    }
}