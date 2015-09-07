using System;
using Honey.Common;

namespace Honey
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                try
                {
                    ExceptionHandler handler = new ExceptionHandler();
                    if (exception.InnerException != null)
                    {
                        handler.Handle(exception.InnerException);
                    }
                    else
                        handler.Handle(exception);
                }
                catch
                {
                    // TODO: Empty catch
                }
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}