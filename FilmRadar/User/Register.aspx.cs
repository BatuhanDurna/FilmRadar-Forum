using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.User
{
	public partial class Register : System.Web.UI.Page
	{
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
		{
            this.Form.DefaultButton = this.lbtn_register.UniqueID;
        }

        protected void lbtn_register_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text) && !string.IsNullOrEmpty(tb_surname.Text) && !string.IsNullOrEmpty(tb_username.Text) && !string.IsNullOrEmpty(tb_dateTime.Text) && !string.IsNullOrEmpty(tb_password.Text))
            {
                if (dm.DataControl("Users", "Username", tb_username.Text.Trim()))
                {
                    Users us = new Users();
                    us.Name = tb_name.Text;
                    us.Surname = tb_surname.Text;
                    us.FavoriteFilm = tb_Favoritefilm.Text;
                    us.Occupation = tb_occupation.Text;
                    us.Username = tb_username.Text;
                    us.DateTime = DateTime.Parse(tb_dateTime.Text);
                    us.Password = tb_password.Text;
                    if (dm.Register(us))
                    {
                        pnl_verifyRegister.Visible = true;
                        pnl_registerMessage.Visible = false;
                    }
                    else
                    {
                        pnl_verifyRegister.Visible = false;
                        pnl_registerMessage.Visible = true;
                        lbl_message.Text = "Kayıt İşlemi Başarısız Oldu Lütfen Tekrar Deneyin";
                    }
                }
                else
                {
                    pnl_verifyRegister.Visible = false;
                    pnl_registerMessage.Visible = true;
                    lbl_message.Text = "Kullanıcı Adı Daha Önce Alınmış";
                }
            }
            else 
            {
                pnl_verifyRegister.Visible = false;
                pnl_registerMessage.Visible = true;
                lbl_message.Text = "Lütfen Gerekli Boşlukları Doldurun";
            }
        }

        protected void lbtn_directLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}