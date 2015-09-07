using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Web.Security;
using Honey.MetaTagsBase;
namespace Honey
{
    public partial class Postings : MetaTagsBase.MetaTagsBase
    {
        private int _totalRows;      

        public int RowsPerPage
        {
            get
            {
                return Common.Constants.ROWSPERPAGE;
            }          
        }

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
     
        public int TotalRows
        {
            get
            {
                return _totalRows;
            }
            set
            {
                _totalRows = value;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                PostingCRUD postingCrud = new PostingCRUD();
                List<Posting> postings = postingCrud.GetList()
                    .Where(x => x.Show == true)
                    .OrderByDescending(x => x.PostedDate)
                    .Skip((PageNumber - 1) * RowsPerPage)
                    .Take(RowsPerPage)
                    .ToList();
                rptData.DataSource = postings;
                rptData.DataBind();
            }
            else
            {
                cntrlPostings.Visible = false;
                PostingCRUD postingCrud = new PostingCRUD();
                List<Posting> postings = postingCrud.GetList()
                    .OrderByDescending(x => x.PostedDate)
                    .Skip((PageNumber - 1) * RowsPerPage)
                    .Take(RowsPerPage)
                    .ToList();
                rptData.DataSource = postings;
                rptData.DataBind();
            }
        }

        protected void ShowCommentInput(object sender, EventArgs e)
        {
            cntrlPostings.Visible = true;
        }        
    }
}

