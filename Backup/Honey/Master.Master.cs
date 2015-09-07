using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Honey.Controls;
using System.Web.Security;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;

namespace Honey
{
    public enum MessageType{Success, Error}
    public partial class UserMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCRUD productCRUD = new ProductCRUD();
            int price = productCRUD.GetList()
                .Where(x=>x.IsDefault==true)
                .FirstOrDefault()
                .Cost;
            dvPrice.InnerText=price.ToString("c")+"/л";                            
        }

        public void ShowError(string message)
        {
            ShowMessage(MessageType.Error, message);
        }

        public void ShowSuccess(string message)
        {
            ShowMessage(MessageType.Success, message);
        }

        private void ShowMessage(MessageType type, string message)
        {
            lblMessage.Visible = true;
            lblMessage.InnerText = message;
            lblMessage.Attributes["class"] = type == MessageType.Error ? "Error" : "Success";
        }
        public void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
        }      
       
    }
}
