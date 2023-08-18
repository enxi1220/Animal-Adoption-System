using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
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

namespace AnimalAdoptionSystem.View.FrontOffice
{
    public partial class FO_CustSignUp : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                regImgPre.ImageUrl = "~/Images/Uploads/defaultProfileImg.jpg";
            }
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                try
                {
                    CUSTOMER customer = new CUSTOMER();

                    customer.NAME = custRegName.Text;
                    customer.USERNAME = custRegUsername.Text;
                    customer.MAIL = custRegMail.Text;
                    customer.PHONE = custRegPhone.Text;
                    customer.PASSWORD = PwEncryptionDecryption.EncodePasswordToBase64(custRegConfirmPass.Text);

                    string imgName = string.IsNullOrEmpty(custRegImg.FileName) ? "defaultProfileImg.jpg" : UniqueNoGenerator.imgUniqueName(custRegImg.FileName);
                    customer.IMAGE = "~/Images/Uploads/" + imgName;

                    if (!string.IsNullOrEmpty(custRegImg.FileName))
                        custRegImg.SaveAs(Server.MapPath("~/Images/Uploads/" + imgName));

                    BusinessLogicExecutor.Execute<BLAddCust, CUSTOMER>(customer);
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

                //redirect user to sign in after sign up
                Response.Redirect("FO_CustSignIn.aspx");

            }



        }

        protected void ChkUsernameTakenCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                CUSTOMER usernameTakan = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                                   (new CUSTOMER() { USERNAME = args.Value }, DAGetCust.GetByUsername).FirstOrDefault();

                if (usernameTakan != null)
                {
                    args.IsValid = false;
                }
                else
                {
                    string sql = "SELECT COUNT(*) FROM [USER] WHERE USERNAME = @USERNAME;";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@USERNAME", args.Value);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (count > 0)
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

        protected void ChkMailTakenCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                CUSTOMER mailTaken = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                                   (new CUSTOMER() { MAIL = args.Value }, DAGetCust.GetByEmailExist).FirstOrDefault();
                if (mailTaken != null)
                {
                    args.IsValid = false;
                }
                else
                {
                    string sql = "SELECT COUNT(*) FROM [USER] WHERE MAIL = @MAIL;";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MAIL", args.Value);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (count > 0)
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