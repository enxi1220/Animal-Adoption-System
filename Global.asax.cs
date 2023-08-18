using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Windows.Forms;

namespace AnimalAdoptionSystem
{
    public class Global : System.Web.HttpApplication
    {
        public const string CS = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    AttachDbFilename=|DataDirectory|\PETADOPTION.mdf;
                                    Integrated Security=True";
        protected void Application_Start(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (false)
                {
                    MessageBox.Show(DateTime.Now.ToString());
                    Thread.Sleep(5000);
                }
            });
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

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}