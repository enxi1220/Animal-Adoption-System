using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.FrontOffice.Adoption
{
    public partial class FO_AdoptionSummary : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx?url=" + Request.RawUrl);
            }
            if (Session["role"] != null)
            {
                Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx?url=" + Request.RawUrl);
            }
            if (!IsPostBack)
            {
                btnPending_Click(sender, e);
            }

        }

        protected void btnPending_Click(object sender, EventArgs e)
        {
            getData(Constant.getAdoptStatus(Constant.AdoptStatusEnum.New));
            btnPending.CssClass = "nav-link active text-capitalize";
            btnApproved.CssClass = "nav-link text-capitalize";
            btnRejected.CssClass = "nav-link text-capitalize";
            btnCanceled.CssClass = "nav-link text-capitalize";
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {
            getData(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Approved));
            btnPending.CssClass = "nav-link text-capitalize";
            btnApproved.CssClass = "nav-link active text-capitalize";
            btnRejected.CssClass = "nav-link text-capitalize";
            btnCanceled.CssClass = "nav-link text-capitalize";
        }

        protected void btnRejected_Click(object sender, EventArgs e)
        {
            getData(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Rejected));
            btnPending.CssClass = "nav-link text-capitalize";
            btnApproved.CssClass = "nav-link text-capitalize";
            btnRejected.CssClass = "nav-link active text-capitalize";
            btnCanceled.CssClass = "nav-link text-capitalize";
        }

        protected void btnCanceled_Click(object sender, EventArgs e)
        {
            getData(Constant.getAdoptStatus(Constant.AdoptStatusEnum.Canceled));
            btnPending.CssClass = "nav-link text-capitalize";
            btnApproved.CssClass = "nav-link text-capitalize";
            btnRejected.CssClass = "nav-link text-capitalize";
            btnCanceled.CssClass = "nav-link active text-capitalize";
        }
        protected void getData(string status)
        {
            CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>(
                new CUSTOMER()
                {
                    USERNAME = Session["username"].ToString()
                }).FirstOrDefault();

            IEnumerable<ADOPTION> adoptions = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(
                                new ADOPTION()
                                {
                                    STATUS = status,
                                    CUSTOMERID = customer.CUSTOMERID
                                }, DAGetAdoption.GetInStatus);
            if (adoptions != null)
            {
                DataList1.DataSource = adoptions;
                DataList1.DataBind();
            }

        }
    }
}