using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.FrontOffice.Customer
{
    public partial class FO_PwdRecovery : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Session.Clear();
                validateOtpDiv.Visible = false;
                resetPwdDiv.Visible = false;

                emailSentMsgLbl.Visible = false;
                emailSentErrMsgLbl.Visible = false;
                enterOTPBtn.Visible = false;

                validateOTPBtn.Visible = false;
                verifiedOTPBtn.Visible = false;
                validateOTPMsgLbl.Visible = false;
                validateOTPErrMsgLbl.Visible = false;
                resetPwdBtn.Visible = false;

                resetPwdMsgLbl.Visible = false;
                resetPwdErrMsgLbl.Visible = false;
                loginWithNewPwdBtn.Visible = false;

            }

        }

        protected void getOTPMailCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CUSTOMER mailExist = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                               (new CUSTOMER() { MAIL = args.Value }, DAGetCust.GetByEmailExist).FirstOrDefault();
            if (mailExist == null)
            {
                args.IsValid = false;
            }

        }

        protected void getOTP_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrEmpty(Session["email"] as string))
                {
                    try
                    {
                        string otp = MailSender.sendMail(getOTPMail.Text);
                        if (!string.IsNullOrEmpty(otp))
                        {

                            Session["email"] = getOTPMail.Text;

                            editOTP(otp);

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

                    emailSentMsgLbl.Visible = true;
                }
                else
                {
                    emailSentErrMsgLbl.Visible = true;
                }
                getOtpBtn.Visible = false;
                enterOTPBtn.Visible = true;
                getOTPMail.Enabled = false;
                pwdResetCancelBtn.Visible = false;
            }
        }

        protected void enterOTPBtn_Click(object sender, EventArgs e)
        {
            enterOTPBtn.Visible = false;
            getOtpDiv.Visible = false;
            validateOtpDiv.Visible = true;
            validateOTPBtn.Visible = true;
        }

        protected void verifyOTPCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrEmpty(Session["email"] as string))
                {

                    string tempOTP = getCustomerByEmail().OTP.ToString();
                    string otpEntered = args.Value;

                    if (!otpEntered.Equals(tempOTP))
                    {
                        args.IsValid = false;

                    }

                }

            }


        }

        protected void validateOTPBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (!string.IsNullOrEmpty(Session["email"] as string))
                {
                    Session["otpEntered"] = "yes";
                    validateOTPMsgLbl.Visible = true;

                }
                else
                {

                    validateOTPErrMsgLbl.Visible = true;
                }

                otpReceived.Enabled = false;
                verifiedOTPBtn.Visible = true;
            }
        }

        protected void verifiedOTPBtn_Click(object sender, EventArgs e)
        {
            verifiedOTPBtn.Visible = false;
            validateOtpDiv.Visible = false;
            validateOTPBtn.Visible = false;
            resetPwdDiv.Visible = true;
            resetPwdBtn.Visible = true;
        }

        protected void resetPwdBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrEmpty(Session["otpEntered"] as string))
                {
                    try
                    {
                        string username = getCustomerByEmail().USERNAME.ToString();

                        CUSTOMER customer = new CUSTOMER();
                        customer.USERNAME = username;
                        customer.PASSWORD = PwEncryptionDecryption.EncodePasswordToBase64(resetPwd.Text);
                        customer.UPDATEDDATE = DateTime.Now;
                        customer.UPDATEDBY = username;
                        BusinessLogicExecutor.Execute<BLEditCust, CUSTOMER>(customer, DAEditCust.EditPwd);
                        editOTP(null);

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
                    resetPwdMsgLbl.Visible = true;

                    Session.Remove("email");
                    Session.Remove("otpEntered");

                }
                else
                {

                    resetPwdErrMsgLbl.Visible = true;

                }
                resetPwdBtn.Visible = false;
                resetPwd.Enabled = false;
                loginWithNewPwdBtn.Visible = true;
            }
        }

        protected CUSTOMER getCustomerByEmail()
        {
            CUSTOMER customer = new CUSTOMER();
            if (!string.IsNullOrEmpty(Session["email"] as string))
            {

                customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                                      (new CUSTOMER() { MAIL = Session["email"].ToString() }, DAGetCust.GetByEmailExist).First();
            }

            return customer;
        }

        protected void editOTP(string otp)
        {

            if (!string.IsNullOrEmpty(Session["email"] as string))
            {
                CUSTOMER customer = new CUSTOMER();
                customer.MAIL = Session["email"].ToString();
                customer.OTP = otp;
                BusinessLogicExecutor.Execute<BLEditCust, CUSTOMER>(customer, DAEditCust.EditOTP);
            }
        }

        protected void loginWithNewPwdBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx");
        }



    }
}