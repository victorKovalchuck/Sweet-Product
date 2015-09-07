using System;
using System.Web.UI;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using System.Text;
using Honey.MetaTagsBase;
using Honey.Crypt;
using System.Web.Services;
using System.Web.Script.Serialization;
namespace Honey
{
    public partial class _Default : MetaTagsBase.MetaTagsBase
    {       
        List<Posting> postings = new List<Posting>();
        int i = 1;     
        protected void Page_Load(object sender, EventArgs e)
        {
            PostingCRUD postingCrud = new PostingCRUD();
                postings = postingCrud.GetList()
                .Where(x => x.Show == true)
                .OrderByDescending(x => x.PostedDate)                
                .ToList();
                postings = GetEveryThirdPosting(postings);            
                rptData.DataSource = postings;
            rptData.DataBind();
  
            FillScrollingString();
        }

        public List<Posting> GetEveryThirdPosting(List<Posting> postings)
        {
            List<Posting> selectedList = new List<Posting>();
            for (int i = 0; i < postings.Count; i += 3)
            {
                selectedList.Add(postings[i]);
            }
            return selectedList
                .Take(3)
                .ToList();
        
        }
        public void FillScrollingString()
        {          
            //lblScroll.Text = "Режим Роботи: Прийом замовлень інтернетом: Доставка по Львову безкоштовна, ";                               
        }

 

        protected string SetShortComment(object Description)
        {
            string SubstringOfDescription = "";
            if (Description.ToString().Length > 20)
            {
                SubstringOfDescription = Description.ToString().Substring(0, 20) + "...";
            }
            else
            {
                SubstringOfDescription = Description.ToString();
            }
            return SubstringOfDescription;
        }

        protected string NavigateToPostings()
        {
            string path = "~/Postings.aspx?Page="+i.ToString();
            i += 1;
            return path;
        }

        protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {      
            if (e.Item.ItemType!=ListItemType.Footer && e.Item.ItemType!=ListItemType.Header)
            {
                System.Web.UI.WebControls.Literal literal = (System.Web.UI.WebControls.Literal)e.Item.FindControl("litHr");
                if (literal != null && postings.Count - 1 != e.Item.ItemIndex)
                {
                    literal.Text = "<hr />";
                }
            }
        }
        #region JqueryUIDialog
        [WebMethod]
        public static string PriceOfSelectedHoney(string selectedHoney)
        {
            if (selectedHoney != "--Вибрати мед--")
            {
                ProductCRUD productCrud = new ProductCRUD();
                Product product = productCrud.GetList()
                    .Where(x => x.Name == selectedHoney)
                    .FirstOrDefault();
                if (product.Discount != 0)
                {
                    product.Cost = product.Cost - (product.Cost * product.Discount / 100);
                }
                //if (product.Remains < 0.5)
                //{
                //    product.Remains = 0;
                //}
                string jsonProduct = new JavaScriptSerializer().Serialize(product);
                return jsonProduct;
            }
            else
            {
                Product defaultProduct = new Product();
                defaultProduct.Name = "--Вибрати мед--";
                string jsonDefaultProduct = new JavaScriptSerializer().Serialize(defaultProduct);
                return jsonDefaultProduct;
            }
        }
        #endregion
    }
}
