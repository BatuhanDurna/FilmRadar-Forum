using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_categories.DataSource = dm.CategoryList(true);
            rp_categories.DataBind();
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    pnl_hasnotLogin.Visible = true;
                    pnl_hasLogin.Visible = false;
                }
                else
                {
                    pnl_hasnotLogin.Visible = false;
                    pnl_hasLogin.Visible = true;

                    Users user = (Users)Session["user"];
                    if (user != null && user.UserType_ID == 1 || user.UserType_ID == 2)
                    {
                        pnl_directadmin.Visible = true;
                    }
                    else
                    {
                        pnl_directadmin.Visible = false;
                    }
                }

            }
            
        }

        protected void allCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void rp_categories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectCategory")
            {
                int catID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("../User/Default.aspx?catID=" + catID);
            }
        }

        protected void lbtn_directadmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/CommentList.aspx");
        }

        protected void lbtn_exit_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            if (Session["user"] == null)
            {
                pnl_hasLogin.Visible = false;
                pnl_hasnotLogin.Visible = true;                
            }
            if (Session["Link"] == null) 
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect(Session["Link"].ToString());
            }
        }
    }
}