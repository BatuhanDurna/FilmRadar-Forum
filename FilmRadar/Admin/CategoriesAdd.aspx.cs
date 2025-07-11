using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class CategoriesAdd : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(tb_name.Text.Trim()))
			{
				if (dm.DataControl("Categories", "Name", tb_name.Text.Trim()))
				{
					Categories cat = new Categories();
					cat.Name = tb_name.Text;
					cat.Status = cb_status.Checked;
					if (dm.CategoryAdd(cat))
					{
                        pnl_successful.Visible = true;
                        pnl_unsuccessful.Visible = false;
                    }
					else
					{
                        pnl_successful.Visible = false;
                        pnl_unsuccessful.Visible = true;
						lbl_message.Text = "Kategori Eklenirken Bir Hata Oluştu";
                    }

				}
				else
				{
                    pnl_successful.Visible = false;
                    pnl_unsuccessful.Visible = true;
                    lbl_message.Text = "Kategori Daha Önce Eklenmiş";
                }
			}
			else
			{
				pnl_successful.Visible = false;
				pnl_unsuccessful.Visible = true;
				lbl_message.Text = "Kategori Adı Boş Bırakılamaz";
			}
        }
    }
}