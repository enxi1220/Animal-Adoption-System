using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.BackOffice
{
    public partial class BO_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["username"] == null)
                {
                    Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx?url=" + Request.RawUrl);
                }
                if (Session["role"] == null)
                {
                    Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx?url=" + Request.RawUrl);
                }
                else
                {
                    lblUsername.Text = Session["username"].ToString();
                }
            }

        }


    }
}