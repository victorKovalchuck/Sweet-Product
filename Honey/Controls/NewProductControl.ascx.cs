using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;

namespace Honey.Controls
{
    public partial class NewProductControl : System.Web.UI.UserControl
    {
        public int PageID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    return int.Parse(Request.QueryString["ID"]);
                }
                return 0;
            }
        }

        public int DeleteID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["DeleteID"]))
                {
                    return int.Parse(Request.QueryString["DeleteID"]);
                }
                return 0;
            }
        }
        DateTime dataTime = DateTime.Now;


        protected void Page_Load(object sender, EventArgs e)
        {
            ProductCRUD productCrud = new ProductCRUD();         
            if (!IsPostBack && PageID != 0)
            {
                Product product = productCrud.GetList()
                     .Where(x => x.Id == PageID)
                     .FirstOrDefault();
                txtbxName.Text = product.Name;
                txtbxPrice.Text = product.Cost.ToString();
                txtbxRecived.Text = product.Recived.ToString();
                txtDataTime.Text = product.ProductedDate.ToShortDateString();
                txtbxRemains.Text = product.Remains.ToString();
                listDiscount.SelectedValue = product.Discount.ToString();
                chckDefault.Checked = product.IsDefault;
            }
            else if (!IsPostBack && PageID == 0)
            {
                txtDataTime.Text = DateTime.Now.ToShortDateString();
            }
            if (DeleteID != 0)
            {
                productCrud.Delete(DeleteID);
                Response.Redirect("~/Products.aspx");
            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductCRUD productCRUD = new ProductCRUD();
            DateTime.TryParse(txtDataTime.Text, out dataTime);
            if (PageID == 0)
            {
                int result = productCRUD.Add(new Product
                {
                    Cost = Convert.ToInt32(txtbxPrice.Text),
                    Id = new ProductCRUD().GetNextNumber(),
                    Name = txtbxName.Text,
                    ProductedDate=dataTime,
                    Recived = Convert.ToDouble(txtbxRecived.Text),
                    Remains = Convert.ToDouble(txtbxRemains.Text),
                    Discount = Convert.ToInt32(listDiscount.SelectedValue),
                    IsDefault = chckDefault.Checked                  
                    
                });
                Response.Redirect("~/Products.aspx");
            }
            else
            {
                productCRUD.Update(new Product
                {

                    Cost = Convert.ToInt32(txtbxPrice.Text),
                    Id = PageID,
                    Name = txtbxName.Text,
                    Recived = Convert.ToDouble(txtbxRecived.Text),
                    ProductedDate=dataTime,
                    Remains = Convert.ToDouble(txtbxRemains.Text),
                    Discount = Convert.ToInt32(listDiscount.SelectedValue),
                    IsDefault = chckDefault.Checked
                });
                Response.Redirect("~/Products.aspx");
            }
        }
    }
}