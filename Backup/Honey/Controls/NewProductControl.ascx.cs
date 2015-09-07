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
                txtbxRemains.Text = product.Remains.ToString();
                chckDefault.Checked = product.IsDefault;
            }
            if (DeleteID != 0)
            {
                productCrud.Delete(DeleteID);
                Response.Redirect("~/Postings.aspx");
            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductCRUD productCRUD = new ProductCRUD();
            if (PageID == 0)
            {                
                int result = productCRUD.Add(new Product
                {
                    Cost = Convert.ToInt32(txtbxPrice.Text),
                    Id = new ProductCRUD().GetNextNumber(),
                    Name = txtbxName.Text,
                    ProductedDate = DateTime.Now,
                    Recived=Convert.ToInt32(txtbxRecived.Text),
                    Remains = Convert.ToInt32(txtbxRemains.Text),
                    IsDefault=chckDefault.Checked
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
                    Recived = Convert.ToInt32(txtbxRecived.Text),
                    Remains = Convert.ToInt32(txtbxRemains.Text)
                });
                Response.Redirect("~/Products.aspx");
            }
        }
    }
}