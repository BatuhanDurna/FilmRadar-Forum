using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class UserTypeEdit : System.Web.UI.Page
	{
        DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["userTypeID"]);
                UserType userType = dm.GetUserType(id);
                if (userType != null && userType.Name != null)
                {
                    tb_name.Text = userType.Name;
                    cb_status.Checked = userType.Status;
                }
                else
                {
                    Response.Redirect("UserTypeList.aspx");
                }

            }
        }

        protected void lbtn_edit_Click(object sender, EventArgs e)
        {
            UserType userType = new UserType();
            userType.ID = Convert.ToInt32(Request.QueryString["userTypeID"]);
            userType.Name = tb_name.Text;
            userType.Status = cb_status.Checked;
            if (dm.UserTypeEdit(userType))
            {
                pnl_successful.Visible = true;
                pnl_unsuccessful.Visible = false;
            }
            else
            {
                pnl_successful.Visible = false;
                pnl_unsuccessful.Visible = true;
                lbl_message.Text = "Kullanıcı Tür Güncelleme İşlemi Başarısız";
            }
        }
    }
}