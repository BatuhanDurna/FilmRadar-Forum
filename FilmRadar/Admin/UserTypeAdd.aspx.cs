using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
    public partial class UserTypeAdd : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text.Trim()))
            {
                if (dm.DataControl("UserType", "Name", tb_name.Text.Trim()))
                {
                    UserType userType = new UserType();
                    userType.Name = tb_name.Text;
                    userType.Status = cb_status.Checked;
                    if (dm.UserTypeAdd(userType))
                    {
                        pnl_successful.Visible = true;
                        pnl_unsuccessful.Visible = false;
                    }
                    else
                    {
                        pnl_successful.Visible = false;
                        pnl_unsuccessful.Visible = true;
                        lbl_message.Text = "Kullanıcı Tür Eklenirken Bir Hata Oluştu";
                    }

                }
                else
                {
                    pnl_successful.Visible = false;
                    pnl_unsuccessful.Visible = true;
                    lbl_message.Text = "Kullanıcı Tür Daha Önce Eklenmiş";
                }
            }
            else
            {
                pnl_successful.Visible = false;
                pnl_unsuccessful.Visible = true;
                lbl_message.Text = "Kullanıcı Tür Adı Boş Bırakılamaz";
            }
        }
    }
}