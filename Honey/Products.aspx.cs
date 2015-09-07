using System;
using System.Collections.Generic;
using System.Web.UI;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Web.UI.WebControls;
using System.Linq;
using Honey.Controls;
using System.IO;
using System.Web.UI.HtmlControls;
using Honey.MetaTagsBase;
namespace Honey
{
    public partial class Products : MetaTagsBase.MetaTagsBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {           
                ProductCRUD priceCrud = new ProductCRUD();
                List<Product> prices = priceCrud.GetList()
                    .Where(x => x.IsDefault == false)
                    .ToList();               
            
                Product IsDefault = priceCrud.GetList()
                        .Where(x => x.IsDefault == true)
                        .FirstOrDefault();

                if (IsDefault != null)
                {
                    prices.Add(IsDefault);
                    prices.Reverse();
                }

                rptPrices.DataSource = prices;
                rptPrices.DataBind();
                         
        }   
         
        protected void rptPrices_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Product product = (Product)e.Item.DataItem;
            System.Web.UI.WebControls.Image imageDiscount = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDiscount");
            System.Web.UI.WebControls.Image imageBarrel = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgBarrel");
            JqueryLightBoxControl lightBoxControl = (JqueryLightBoxControl)e.Item.FindControl("cntrlJqueryLightBox");
            if (product.Discount != 0)
            {                
                SetNewPrice(product, e);                
            }
            SetDiscountImage(product, imageDiscount);

            if (imageBarrel == null) { return; }         
            double content = product.Remains * 100 / product.Recived;
            if (content <= 25 & content > 0)
            {
                imageBarrel.ImageUrl = @"~/App_Themes/Honey/img/Мед25.PNG";
            }
            else if (content > 25 & content <= 75)
            {
                imageBarrel.ImageUrl = @"~/App_Themes/Honey/img/Мед50.PNG";
            }
            else if (content == 0)
            {
                imageBarrel.ImageUrl = @"~/App_Themes/Honey/img/Мед0.PNG";
                System.Web.UI.HtmlControls.HtmlGenericControl spanEmptyBottle = (HtmlGenericControl)e.Item.FindControl("spnEmptyBottle");
                System.Web.UI.HtmlControls.HtmlGenericControl outlineDiv = (HtmlGenericControl)e.Item.FindControl("outlineDiv");
                System.Web.UI.HtmlControls.HtmlGenericControl animate = (HtmlGenericControl)e.Item.FindControl("divAnimate");
                if (spanEmptyBottle == null || outlineDiv == null)
                {
                    return;
                }              
                spanEmptyBottle.InnerText="Немає у наявності";
                outlineDiv.Attributes["style"] = "outline:none;width:100%;box-shadow:none;";
                outlineDiv.Attributes["data"] = "none";

                animate.Attributes["style"] = "width:0%; visibility: collapse;";
              
            }
            else if (content > 75 & content < 100)
            {
                imageBarrel.ImageUrl = @"~/App_Themes/Honey/img/Мед75.PNG";
            }
            else
            {
                imageBarrel.ImageUrl = @"~/App_Themes/Honey/img/Мед100.PNG";
            }

            SetLightBox(product, lightBoxControl);
        }

        void SetLightBox(Product product, JqueryLightBoxControl lightBoxControl)
        {           
            if (lightBoxControl == null)
            {
                return;
            }
            List<string> names = Directory.GetFiles(Server.MapPath("~/Pictures"), "*.jpg")
               .Select(x => Path.GetFileNameWithoutExtension(x))
               .OrderBy(x => x.Length)
               .ToList();
            for (int i = 0; i < names.Count; i++)
            {
                if (product.Name == names[i])
                {
                    lightBoxControl.Title = names[i];
                    return;
                }
            }
            lightBoxControl.SetUrl = "~/Pictures/NoImage.png";
            lightBoxControl.Title = "none";
        }

        void SetDiscountImage(Product product, Image image)
        {
            int discount = product.Discount;
            if (image == null || discount == 0)
            {
                image.Attributes["style"] = "visibility: collapse;";
                return;
            }
            try
            {
                image.ImageUrl = string.Format("~/Pictures/{0}.jpg",discount.ToString());
            }
            catch
            {
                return;
            }
        }

        void SetNewPrice(Product product, RepeaterItemEventArgs e)
        {
            Label oldPrice = (Label)e.Item.FindControl("oldPrice");
            Label newPrice = (Label)e.Item.FindControl("newPrice");
            int discountPrice = product.Cost - (product.Cost * product.Discount / 100);
            oldPrice.CssClass = "ProductOldPrice";
            newPrice.Text = string.Format("Нова Ціна: {0}грн.л", discountPrice.ToString());
        }
    }
}
