using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Honey
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Request.QueryString["aspxerrorpath"];
            ((UserMaster)this.Page.Master).ShowError("Validator error in "+path);
        }
    }
}