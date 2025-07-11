using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class CategoriesEdit : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				int id = Convert.ToInt32(Request.QueryString["catID"]);
				Categories cat = dm.GetCategory(id);
				if (cat!=null&&cat.Name!=null)
				{
					tb_name.Text = cat.Name;
					cb_status.Checked = cat.Status;
				}
				else
				{
					Response.Redirect("CategoriesList.aspx");
				}

			}
		}

        protected void lbtn_edit_Click(object sender, EventArgs e)
        {
			Categories cat = new Categories();
			cat.ID = Convert.ToInt32(Request.QueryString["catID"]);
			cat.Name = tb_name.Text;
			cat.Status = cb_status.Checked;
			if (dm.CategoryEdit(cat))
			{
				pnl_successful.Visible = true;
				pnl_unsuccessful.Visible = false;				
			}
			else
			{
                pnl_successful.Visible = false;
                pnl_unsuccessful.Visible = true;
				lbl_message.Text = "Kategori Güncelleme İşlemi Başarısız";
            }
        }
    }
}