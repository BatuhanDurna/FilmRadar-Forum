using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class FilmEdit : System.Web.UI.Page
	{
		DataModel dm = new DataModel();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ddl_cat.DataTextField = "Name";
				ddl_cat.DataValueField = "ID";
				ddl_cat.DataSource = dm.CategoryList();
				ddl_cat.DataBind();
				int id = Convert.ToInt32(Request.QueryString["fID"]);
				Films film = dm.GetFilm(id);
				if (film != null && film.FilmName != null)
				{
					tb_filmName.Text = film.FilmName;
					tb_imdbRating.Text = film.IMDB.ToString();
					ddl_cat.SelectedValue = film.Category_ID.ToString();
					img_pictures.ImageUrl = "../Pictures/" + film.Photo;
					tb_summary.Text = film.Summary;
					tb_topic.Text = film.Topic;
					cb_status.Checked = film.Status;
                }
				else
				{
					Response.Redirect("FilmList.aspx");
				}
			}
		}

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
			Films film = dm.GetFilm(Convert.ToInt32(Request.QueryString["fID"]))
			film.ID = Convert.ToInt32(Request.QueryString["fID"]);
			film.FilmName = tb_filmName.Text;
			film.IMDB = Convert.ToDecimal(tb_imdbRating.Text);
			film.Category_ID = Convert.ToInt32(ddl_cat.SelectedItem.Value);
			film.Summary = tb_summary.Text;
			film.Topic = tb_topic.Text;
			if (fu_pictures.HasFile)
			{
				FileInfo fi = new FileInfo(fu_pictures.FileName);
				if (fi.Extension == ".jpeg" || fi.Extension == ".png" || fi.Extension == ".jpg")
				{
					string extension = fi.Extension;
					string name = Guid.NewGuid().ToString();
					film.Photo = name + extension;
					fu_pictures.SaveAs(Server.MapPath("~/Pictures/" + name + extension));
				}
				else
				{
					pnl_successful.Visible = false;
					pnl_unsuccessful.Visible = true;
					lbl_message.Text = "Resim uzantısı jpeg,png veya jpg olmalıdır";
				}
			}
			if (dm.FilmEdit(film))
			{
				tb_filmName.Text = "";
				tb_imdbRating.Text = "";
				ddl_cat.SelectedItem.Value = "";
				img_pictures.ImageUrl = "";
				tb_summary.Text = "";
				tb_topic.Text = "";
				cb_status.Checked = false;

            }
        }
    }
}
