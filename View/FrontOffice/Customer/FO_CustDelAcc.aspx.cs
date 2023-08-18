using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.FrontOffice.Customer
{
    public partial class FO_CustDelAcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("FO_CustSignIn.aspx?url=" + Request.RawUrl);
            }
            else if (!string.IsNullOrEmpty(Session["role"] as string))
            {
                custDelAccContainer.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyCustomer(" + "\"" + "/View/BackOffice/Pet/BO_PetSummary.aspx" + "\"" + ");", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                              (new CUSTOMER() { USERNAME = Session["username"].ToString() }).First();
                    IEnumerable<ADOPTION> adoption = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>
                                               (new ADOPTION() { CUSTOMERID = customer.CUSTOMERID, STATUS = Constant.getAdoptStatus(Constant.AdoptStatusEnum.Approved) }, DAGetAdoption.GetCustomerId);
                    int adoptionCount = adoption.Count();

                    custProImg.ImageUrl = customer.IMAGE;
                    custUsername.Text = customer.USERNAME;
                    adoptedPetCount.Text = adoptionCount.ToString();

                    DateTime joinedDate = new DateTime();
                    if (customer.CREATEDDATE.HasValue)
                    {
                        joinedDate = (DateTime)customer.CREATEDDATE;
                    }

                    custJoinedDate.Text = joinedDate.ToString("dddd, dd MMMM yyyy");
                    confirmDelAccDiv.Visible = false;
                }
            }
        }

       

        protected void delAccBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                delAccDiv.Visible = false;
                confirmDelAccDiv.Visible = true;
            }
        }

        protected void delAccChkPwd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                            (new CUSTOMER() { USERNAME = Session["username"].ToString() }).First();

            if (!args.Value.Equals(PwEncryptionDecryption.DecodeFrom64(customer.PASSWORD)))
            {
                args.IsValid = false;

            }

        }

        protected void confirmDelAccBtn_Click(object sender, EventArgs e)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.USERNAME = Session["username"].ToString();
            customer.UPDATEDDATE = DateTime.Now;
            customer.UPDATEDBY = Session["username"].ToString();

            try
            {
                BusinessLogicExecutor.Execute<BLDelCust, CUSTOMER>(customer);

            }
            catch (SqlException sqlEx)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:exceptionFound(" + "\"" + sqlEx.Message + "\"" + ");", true);
            }
            catch (NullReferenceException nullEx)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:exceptionFound(" + "\"" + nullEx.Message + "\"" + ");", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:exceptionFound(" + "\"" + ex.Message + "\"" + ");", true);
            }

            Session.Remove("username");
            Session.Remove("role");
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:delAccSuccessful(" +"\"/View/FrontOffice/FO_Home.aspx\"" + ");", true);

        }

        protected void cancelDelAccBtn_Click(object sender, EventArgs e)
        {
            delAccDiv.Visible = true;
            confirmDelAccDiv.Visible = false;
        }
    }
}