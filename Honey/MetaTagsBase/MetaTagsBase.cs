using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace Honey.MetaTagsBase
{
    public partial class MetaTagsBase : System.Web.UI.Page
    {

        private string _keywords;
        private string _description;

        public MetaTagsBase()
        {
            Init += new EventHandler(MetaTagsBase_Init);
        }


        void MetaTagsBase_Init(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(Meta_Keywords))
            {
                HtmlMeta tag = new HtmlMeta();
                tag.Name = "keywords";
                tag.Content = Meta_Keywords;
                Header.Controls.Add(tag);
            }

            if (!String.IsNullOrEmpty(Meta_Description))
            {
                HtmlMeta tag = new HtmlMeta();
                tag.Name = "description";
                tag.Content = Meta_Description;
                Header.Controls.Add(tag);
            }
        }


        public string Meta_Keywords
        {
            get
            {
                return _keywords;
            }
            set
            {
                // strip out any excessive white-space, newlines and linefeeds
                _keywords = Regex.Replace(value, "\\s+", " ");
            }
        }


        public string Meta_Description
        {
            get
            {
                return _description;
            }
            set
            {
                // strip out any excessive white-space, newlines and linefeeds
                _description = Regex.Replace(value, "\\s+", " ");
            }
        }
    }
}