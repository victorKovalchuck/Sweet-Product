using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey;

namespace Honey.Controls
{
    public partial class PagerControl : System.Web.UI.UserControl
    {
        public int PageNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Page"]))
                {
                    return int.Parse(Request.QueryString["Page"]);
                }
                return 1;
            }
        }
        Postings postings = new Postings();

        protected void Page_Load(object sender, EventArgs e)
        {                   
            PostingCRUD postingCrud = new PostingCRUD();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                postings.TotalRows = postingCrud.GetList().Count;
            }
            else
            {
                postings.TotalRows = postingCrud.GetList().Where(x=>x.Show==true).Count();
            }
            int pagesCount = (int)Math.Ceiling((double)postings.TotalRows / postings.RowsPerPage);            
            List<string> pages = new List<string>();
            if (PageNumber > 4)
            {
                pages.Add("1");
                pages.Add("..");
            }
            else
            {
                pages.Add("1");
            }
            for (int i = 2; i < pagesCount; i++)
            {
                if (i <= (PageNumber + 2) && i >= (PageNumber - 2))
                {
                    pages.Add(i.ToString());
                }               
            }
            if (PageNumber < pagesCount - 3)
            {
                pages.Add("..");
                pages.Add(pagesCount.ToString());
            }
            else
            {
                pages.Add(pagesCount.ToString());
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();

            if (PageNumber > 1)
            {
                lnkPrev.NavigateUrl = string.Format("../Postings.aspx?Page={0}",PageNumber - 1);
                lnkPrev.Visible = true;
            }
            if (PageNumber < pagesCount)
            {
                lnkNext.NavigateUrl = string.Format("~/Postings.aspx?Page={0}", PageNumber + 1);
                lnkNext.Visible = true;
            }

        }

        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink hyperLink = (HyperLink)e.Item.FindControl("links");
            if (hyperLink.Text == PageNumber.ToString() || hyperLink.Text == "..")
            {
                hyperLink.NavigateUrl = null;
                hyperLink.Style.Add("color", "Blue");
            }
        }
    }
}