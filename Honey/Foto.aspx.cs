using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using Honey.MetaTagsBase;
namespace Honey
{
    public partial class Foto : MetaTagsBase.MetaTagsBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> paths=GetImagePaths();
            List<string> names = GetImageNames();

            Panel panel = (Panel)this.Master.FindControl("ContentPlaceHolder1").FindControl("pnlImages");
            for (int i = 0; i < paths.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div.Attributes["class"] = "Frame";
               
                Image image = new Image();
                image.ImageUrl = paths[i];                              
                image.Attributes["class"] = "Image";               
                image.Attributes["title"] = names[i];

                HyperLink hyperlik = new HyperLink();
                hyperlik.NavigateUrl = paths[i];
                hyperlik.Controls.Add(image);

              //  System.Web.UI.HtmlControls.HtmlGenericControl span = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
               // span.InnerText = names[i];
                div.Controls.Add(hyperlik);
              //  div.Controls.Add(span);
                panel.Controls.Add(div);                
            }
           
        }
        public List<string> GetImagePaths()
        {
            List<string> paths = Directory.GetFiles(Server.MapPath("~/Pictures"), "*.jpeg")
                  .Select(x => Path.Combine("~/Pictures", Path.GetFileName(x)))
                  .OrderBy(x => x.Length)
                  .ToList();
            return paths;
        }


        public List<string> GetImageNames()
        {
            List<string> names = Directory.GetFiles(Server.MapPath("~/Pictures"), "*.jpeg")
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .OrderBy(x => x.Length)
                .ToList();
            return names;        
        }
    }
}
