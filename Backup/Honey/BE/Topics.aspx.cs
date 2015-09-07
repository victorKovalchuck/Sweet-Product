using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.Entity;
using Honey.DAL.CRUD;
using System.Text;

namespace Honey.BE
{
    public partial class Topics : Page
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

        TopicCRUD topicCrud = new TopicCRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageID != 0)
            {
                cntrlNewTopic.Visible = true;
                lnkAdd.Visible = false;
            }
            else
            {
                List<Topic> topics = topicCrud.GetList();
                topics.ForEach(x => x.Content = Encoding.UTF8.GetString(Convert.FromBase64String(x.Content)));
                rptr.DataSource = topics;
                rptr.DataBind();
            }          
        }
    }
}
