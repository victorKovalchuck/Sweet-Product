using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;

namespace Honey.BE
{
    public partial class Customers : System.Web.UI.Page
    {

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
            CustomCRUD customCrud = new CustomCRUD();
            if (DeleteID != 0)
            {
                customCrud.Delete(DeleteID);
            
            }
           
            List<Custom> customers = customCrud.GetList();
            rptClients.DataSource = customers;
            rptClients.DataBind();
        }
    }
}