using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace FilmRadar.Admin
{
	public partial class FilmAdd : System.Web.UI.Page
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
			}
		}

        protected void lbtn_add_Click(object sender, EventArgs e)
        {
			if (Convert.ToInt32(ddl_cat.SelectedItem.Value)!=0)
			{
				Films film = new Films();
				film.FilmName = tb_filmName.Text;
				if (film.FilmName.Trim()!=null)
				{
					if (dm.DataControl("Films", "FilmName", film.FilmName))
					{
						film.Category_ID = Convert.ToInt32(ddl_cat.SelectedItem.Value);
						film.IMDB = Convert.ToDecimal(tb_imdbRating.Text);
						film.Summary = tb_summary.Text;
						film.Topic = tb_topic.Text;
						if (fu_pictures.HasFile)
						{
							FileInfo fi = new FileInfo(fu_pictures.FileName);
							if (fi.Extension==".jpeg" || fi.Extension == ".png" || fi.Extension == ".jpg")
							{
								string extension = fi.Extension;
								string name = Guid.NewGuid().ToString();
								film.Photo = name + extension;
								fu_pictures.SaveAs(Server.MapPath("~/Pictures/" + name + extension));
								if (dm.FilmAdd(film))
								{
                                    pnl_successful.Visible = true;
                                    pnl_unsuccessful.Visible = false;
                                }
								else
								{
                                    pnl_successful.Visible = false;
                                    pnl_unsuccessful.Visible = true;
                                    lbl_message.Text = "Resim uzantısı jpeg, png veya jpg olmalıdır";
                                }
							}
							else
							{
                                pnl_successful.Visible = false;
                                pnl_unsuccessful.Visible = true;
                                lbl_message.Text = "Resim uzantısı jpeg, png veya jpg olmalıdır";
                            }
						}
						else
						{
							film.Photo = "default.jpg";
							if (dm.FilmAdd(film))
							{
                                pnl_successful.Visible = true;
                                pnl_unsuccessful.Visible = false;
                            }
							else
							{
                                pnl_successful.Visible = false;
                                pnl_unsuccessful.Visible = true;
                                lbl_message.Text = "Film Ekleme Başarısız";
                            }

                        }
					}
					else
					{
                        pnl_successful.Visible = false;
                        pnl_unsuccessful.Visible = true;
                        lbl_message.Text = "Bu Filmin İsimi Mevcut";
                    }
				}
				else
				{
                    pnl_successful.Visible = false;
                    pnl_unsuccessful.Visible = true;
                    lbl_message.Text = "Lütfen Filmin İsimini Giriniz";
                }
			}
			else
			{
				pnl_successful.Visible = false;
				pnl_unsuccessful.Visible = true;
				lbl_message.Text = "Lütfen Kategori Seçiniz";
			}
        }
    }
}