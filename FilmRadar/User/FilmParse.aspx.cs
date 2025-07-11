using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.User
{
	public partial class FilmParse : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			Session["Link"] = "FilmParse.aspx?fid=" + Request.QueryString["fid"];
			if (Request.QueryString.Count != 0)
			{
				int id = Convert.ToInt32(Request.QueryString["fid"]);
				Films f = dm.GetFilm(id);
				rpt_commentList.DataSource = dm.ActiveCommentsList(id);
				rpt_commentList.DataBind();
                ltrl_title.Text = f.FilmName;
                img_picture.ImageUrl = "../Pictures/" + f.Photo;
                ltrl_category.Text = f.CategoryStr;
				ltrl_imdbrate.Text = Convert.ToString(f.IMDB);
				ltrl_topic.Text = f.Topic;
				ltrl_summary.Text = f.Summary;
				if (Session["user"] != null)
				{
					pnl_loginOK.Visible = true;
					pnl_loginnotOK.Visible = false;
				}
				else
				{
					pnl_loginnotOK.Visible = true;
					pnl_loginOK.Visible = false;
				}
			}
			else
			{
				Response.Redirect("Default.aspx");
			}
		}

        protected void lbtn_directLogin_Click(object sender, EventArgs e)
        {
			Session["Link"] = "FilmParse.aspx?fid=" + Request.QueryString["fid"];
			Response.Redirect("Login.aspx");
        }

        protected void lbtn_postComment_button_Click(object sender, EventArgs e)
        {
			Comments comment = new Comments();
			Users user = (Users)Session["user"];
			int userid = user.ID;
			int fid = Convert.ToInt32(Request.QueryString["fid"]);

			comment.User_ID = userid;
			comment.Status = true;
			comment.CommentTime = DateTime.Now;
			comment.Viewcomment = 0;
			comment.Topic = tb_writeComment.Text;
			comment.Films_ID = fid;
			comment.Name = user.Name;
			if (dm.PostComment(comment))
			{
				Response.Redirect(Session["Link"].ToString());
			}
        }
    }
}