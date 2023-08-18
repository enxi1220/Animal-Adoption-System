using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;
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
    public partial class FO_CustEditPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {

                Response.Redirect("FO_CustSignIn.aspx?url=" + Request.RawUrl);
            }
            else if (!string.IsNullOrEmpty(Session["role"] as string))
            {
                custEditPwdContainer.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyCustomer(" + "\"" + "/View/BackOffice/Pet/BO_PetSummary.aspx" + "\"" + ");", true);
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                            (new CUSTOMER() { USERNAME = Session["username"].ToString() }, DAGetCust.GetByUsername).FirstOrDefault();
                    
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
                    editPwdDiv.Visible = false;



                }
            }
        }

        protected void chkOldPwdbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                chkOldPwdDiv.Visible = false;
                editPwdDiv.Visible = true;
            }
        }

        protected void editOldPwdbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CUSTOMER customer = new CUSTOMER();
                customer.USERNAME = Session["username"].ToString();
                customer.PASSWORD = PwEncryptionDecryption.EncodePasswordToBase64(custEditPass.Text);
                customer.UPDATEDDATE = DateTime.Now;
                customer.UPDATEDBY = Session["username"].ToString();

                try
                {
                    BusinessLogicExecutor.Execute<BLEditCust, CUSTOMER>(customer, DAEditCust.EditPwd);

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

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:editPwdsuccessful();", true);
                chkOldPwdDiv.Visible = true;
                editPwdDiv.Visible = false;


            }

        }

        protected void editOldPwdCancelbtn_Click(object sender, EventArgs e)
        {
            chkOldPwdDiv.Visible = true;
            editPwdDiv.Visible = false;
        }

        protected void chkOldPwd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                (new CUSTOMER() { USERNAME = Session["username"].ToString() }).First();


                if (customer != null) //if pw is found in db -> perform decoding
                {
                    if (!args.Value.Equals(PwEncryptionDecryption.DecodeFrom64(customer.PASSWORD)))
                    {
                        args.IsValid = false;
                    }
                }
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
        }
    }
}