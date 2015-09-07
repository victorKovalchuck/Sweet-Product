using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Honey
{
    public partial class Products : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {           
                ProductCRUD priceCrud = new ProductCRUD();
                List<Product> prices = priceCrud.GetList()
                    .Where(x => x.IsDefault == false)
                    .ToList();
                rptPrices.DataSource = prices;
                rptPrices.DataBind();

                List<Product> IsDefault = priceCrud.GetList()
                        .Where(x => x.IsDefault == true)
                        .ToList();
                rptIsDefault.DataSource = IsDefault;
                rptIsDefault.DataBind();  
            ((UserMaster)this.Page.Master).Load()
                         
        }   
         
        protected void rptPrices_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Product price = (Product)e.Item.DataItem;
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgBarrel");
            if (image == null) { return; }
            int content = price.Remains * 100 / price.Recived;
            if (content <= 25)
            {
                image.ImageUrl = @"~/App_Themes/Honey/img/Мед25.PNG";
            }
            else if (content > 25 & content <= 75)
            {
                image.ImageUrl = @"~/App_Themes/Honey/img/Мед50.PNG";
            }
            else if (content == 0)
            {
                image.ImageUrl = @"~/App_Themes/Honey/img/Мед0.PNG";
            }
            else if (content > 75 & content < 100)
            {
                image.ImageUrl = @"~/App_Themes/Honey/img/Мед75.PNG";
            }
            else
            {
                image.ImageUrl = @"~/App_Themes/Honey/img/Мед100.PNG";
            }      
        }
    }
}
