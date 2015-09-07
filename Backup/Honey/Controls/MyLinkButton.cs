using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Honey.Controls
{
    public class MyLinkButton:LinkButton,ISecuredControl
    {
        public override bool Visible
        {
            get
            {
                bool visible = base.Visible;
                if (Secured)
                {
                    return HttpContext.Current.User.Identity.IsAuthenticated;
                }
                return visible;
            }
            set
            {
                base.Visible = value;
            }
        }
        #region ISecuredControl Members

        public bool Secured { get; set; }
        
        #endregion
    }
}
