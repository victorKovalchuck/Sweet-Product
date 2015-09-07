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
    public partial class NewPosting : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            PostingCRUD postingsCrud = new PostingCRUD();
            List<Posting> postings = postingsCrud.GetList();
            rptPostings.DataSource = postings;
            rptPostings.DataBind();
        }
    }
}
