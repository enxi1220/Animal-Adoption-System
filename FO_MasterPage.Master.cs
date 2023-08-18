using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.FrontOffice
{
    public partial class FO_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HyperLink loginLink = (HyperLink)FindControl("loginLink");
                HyperLink custProfileLink = (HyperLink)FindControl("custProfileLink");
                HyperLink backOfficeLink = (HyperLink)FindControl("backOfficeLink");
                LinkButton logoutLink = (LinkButton)FindControl("logoutLink");
                Image custProfileImg = (Image)FindControl("custProfileImg");
                Image backOfficeImg = (Image)FindControl("backOfficeImg");

                if (string.IsNullOrEmpty(Session["username"] as string))
                {
                    loginLink.Visible = true;
                    logoutLink.Visible = false;
                    custProfileLink.Visible = false;
                    backOfficeLink.Visible = false;
                }
                else
                {
                    loginLink.Visible = false;
                    logoutLink.Visible = true;

                    if (string.IsNullOrEmpty(Session["role"] as string))
                    {
                        backOfficeImg.Visible = false;
                        custProfileLink.Visible = true;
                        CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                                       (new CUSTOMER() { USERNAME = Session["username"].ToString() }, DAGetCust.GetByUsername).First();
                        custProfileImg.ImageUrl = customer.IMAGE;
                    }
                    else{
                        backOfficeLink.Visible= true;
                    }

                }
            }

        }

        protected void logoutLink_Click(object sender, EventArgs e)
        {

            Session.Remove("username");
            Session.Remove("role");
            Response.Redirect("~/View/FrontOffice/FO_Home.aspx");


        }
    }
}