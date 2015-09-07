using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Honey.Controls
{
    public partial class JqueryLightBoxControl : System.Web.UI.UserControl
    {
        public string SetUrl {

            get
            {
                return hplnkShowLightBox.NavigateUrl;            
            }
            
            
            set 
            {
                hplnkShowLightBox.NavigateUrl = value;           
            }
        
        }
        public string Title
        {

            get
            {
                return imgEye.Attributes["title"];
            }


            set
            {
                imgEye.Attributes["title"] = value;
            }

        }      

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}