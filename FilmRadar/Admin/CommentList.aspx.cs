using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class CommentList : System.Web.UI.Page
	{
        DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
            DataList();
		}

        protected void lbtn_allcommentList_Click(object sender, EventArgs e)
        {
            lv_allComment.Visible = true;
            lv_activeComment.Visible = false;
            lv_passiveComment.Visible = false;
            
        }

        protected void lbtn_activecommentList_Click(object sender, EventArgs e)
        {
            lv_allComment.Visible = false;
            lv_activeComment.Visible = true;
            lv_passiveComment.Visible = false;
        }

        protected void lbtn_passivecommentList_Click(object sender, EventArgs e)
        {
            lv_allComment.Visible = false;
            lv_activeComment.Visible = false;
            lv_passiveComment.Visible = true;
        }

        protected void lv_allComment_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName=="change")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.CommentStatusChange(id);
            }
            DataList();
        }
        public void DataList()
        {
            lv_allComment.DataSource = dm.AllCommentsList();
            lv_allComment.DataBind();
            lv_activeComment.DataSource = dm.ActiveCommentsList();
            lv_activeComment.DataBind();
            lv_passiveComment.DataSource = dm.PassiveCommentsList();
            lv_passiveComment.DataBind();
        }
    }
}