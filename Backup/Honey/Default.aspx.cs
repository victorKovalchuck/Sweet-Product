using System;
using System.Web.UI;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace Honey
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PostingCRUD postingCrud = new PostingCRUD();
            List<Posting> postings = postingCrud.GetList()
                .Where(x => x.Show == true)
                .OrderByDescending(x => x.PostedDate)
                .Take(5)
                .ToList();
            rptData.DataSource = postings;
            rptData.DataBind();
           

            List<string> images = Directory.GetFiles(Server.MapPath("~/Pictures"), "*.jpeg")
               .Select(x => Path.Combine("~/Pictures", Path.GetFileName(x)))
               .OrderBy(x => x.Length)
               .ToList();

            Panel panel = (Panel)this.Master.FindControl("ContentPlaceHolder1").FindControl("pnlImages");
            for (int i = 0; i < 5; i++)
            {
                Image image = new Image();
                image.ImageUrl = images[i];
                image.ID = images[i];
                image.Attributes["class"] = "Image";
                panel.Controls.Add(image);
            }
        }
    }
}
