using System;
using System.IO;
using System.Web;

namespace Honey.Common
{
    public class ExceptionHandler
    {
        private string FILE_NAME = String.Format("{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));

        public void Handle(string message)
        {
            String path = String.Format("{0}logs\\", HttpContext.Current.ApplicationInstance.Server.MapPath("~/"));
            try
            {
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                path += String.Format("{0}", FILE_NAME);

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
            }
            catch(Exception)
            {
                // Fatal fail
            }
        }

        public void Handle(Exception ex)
        {
            string userAgent = HttpContext.Current.Request.UserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                userAgent = string.Format("\n\rUser Agent: {0}", userAgent);
            }

            string url = string.Empty;
            if (HttpContext.Current.Request.Url != null)
            {
                url = string.Format("\nUrl: {0}", HttpContext.Current.Request.Url);
            }

            string referrer = string.Empty;
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                referrer = string.Format("\nReferrer: {0}", HttpContext.Current.Request.UrlReferrer);
            }

            Handle("Exception of type " + ex.GetType().ToString() + " occured " + DateTime.Now.ToString("(MM-dd-yyyy HH:mm:ss)") + ": " + ex.Message + "\n\r" + ex.StackTrace + userAgent + url + referrer + "\n\r");
        }
    }
}
