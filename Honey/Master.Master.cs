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
using System.Web.Services;
using System.Web.Script.Serialization;
namespace Honey
{
    public enum MessageType{Success, Error}
    public partial class UserMaster : MasterPage
    {
        List<Product> products = new List<Product>();
        ProductCRUD productCrud = new ProductCRUD();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCRUD productCRUD = new ProductCRUD();            
            products = productCrud.GetList();
            if (!IsPostBack)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    ListItem listItemName = new ListItem(products[i].Name, products[i].Id.ToString());
                    drpHoney.Items.Add(listItemName);
                }
            }                           
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
        public void btnReserve_Click(object sender, EventArgs e)
        {          
            ProductCRUD productCrud = new ProductCRUD();
            CustomCRUD customCrud = new CustomCRUD();
            customCrud.Add(new Custom
            {
                Name = txtName.Text,
                Amount = Convert.ToDouble(txtAmount.Text),
                Email = txtEmail.Text,
                HoneyType = drpHoney.SelectedItem.Text,
                Number = Convert.ToInt64(txtNumber.Text),
                PurchaseDate = DateTime.Now

            });
            bool result = productCrud.UpdateByName(new Custom
             {
                 HoneyType = drpHoney.SelectedItem.Text,
                 Amount = Convert.ToDouble(txtAmount.Text)

             });
            if (result == true)
            {
                Response.Redirect("~/Default.aspx?IsSuccess=SuccessPurchase");
            }
            else
            {
                Response.Redirect("~/Default.aspx?IsSuccess=ErrorPurchase");
            }
        }       
    }
}
