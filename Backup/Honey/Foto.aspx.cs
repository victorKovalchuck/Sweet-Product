using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;

namespace Honey
{
    public partial class Foto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> images= Directory.GetFiles(Server.MapPath("~/Pictures"),"*.jpeg")
                .Select(x=>Path.Combine("~/Pictures",Path.GetFileName(x)))                
                .OrderBy(x=>x.Length)
                .ToList();

            Panel panel = (Panel)this.Master.FindControl("ContentPlaceHolder1").FindControl("pnlImages");
            for (int i = 0; i < images.Count; i++)
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
