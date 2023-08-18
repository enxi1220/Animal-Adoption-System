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
    public partial class FO_CustomerView : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Redirect("FO_CustSignIn.aspx?url=" + Request.RawUrl);

            }
            else if (!string.IsNullOrEmpty(Session["role"] as string))
            {
                custViewAccContainer.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyCustomer(" + "\"" + "/View/BackOffice/Pet/BO_PetSummary.aspx" + "\"" + ");", true);
            }
            else
            {

                if (!Page.IsPostBack)
                {
                    try
                    {
                        CUSTOMER customer = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                                (new CUSTOMER() { USERNAME = Session["username"].ToString() }, DAGetCust.GetByUsername).FirstOrDefault();

                        IEnumerable<ADOPTION> adoption = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>
                                                (new ADOPTION() { CUSTOMERID = customer.CUSTOMERID, STATUS = Constant.getAdoptStatus(Constant.AdoptStatusEnum.Approved) }, DAGetAdoption.GetCustomerId);
                        int adoptionCount = adoption.Count();


                        DateTime joinedDate = new DateTime();
                        if (customer.CREATEDDATE.HasValue)
                        {
                            joinedDate = (DateTime)customer.CREATEDDATE;
                        }


                        custProImg.ImageUrl = customer.IMAGE;
                        custUsername.Text = customer.USERNAME;
                        custJoinedDate.Text = joinedDate.ToString("dddd, dd MMMM yyyy");
                        adoptedPetCount.Text = adoptionCount.ToString();
                        custName.Text = customer.NAME;
                        custMail.Text = customer.MAIL;
                        custPhone.Text = customer.PHONE;
                        editAccDiv.Visible = false;

                        custEditName.Text = customer.NAME;
                        custEditMail.Text = customer.MAIL;
                        custEditPhone.Text = customer.PHONE;
                        custEditImgPre.ImageUrl = customer.IMAGE;
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
        protected void editAccBtn_Click(object sender, EventArgs e)
        {
            viewAccDiv.Visible = false;
            editAccDiv.Visible = true;
        }

        protected void editAccCancelBtn_Click(object sender, EventArgs e)
        {
            editAccDiv.Visible = false;
            viewAccDiv.Visible = true;
            custEditName.Text = custName.Text;
            custEditPhone.Text = custPhone.Text;
            custEditMail.Text = custMail.Text;
            custEditImgPre.ImageUrl = custProImg.ImageUrl;

        }

        protected void editAccSaveBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                CUSTOMER customer = new CUSTOMER();
                customer.USERNAME = Session["username"].ToString();
                customer.NAME = custEditName.Text;
                customer.PHONE = custEditPhone.Text;
                customer.MAIL = custEditMail.Text;

                if (!string.IsNullOrEmpty(custEditImg.FileName))
                {
                    string imgName = UniqueNoGenerator.imgUniqueName(custEditImg.FileName);
                    customer.IMAGE = "~/Images/Uploads/" + imgName;
                    custEditImg.SaveAs(Server.MapPath("~/Images/Uploads/" + imgName));
                }
                else
                {
                    customer.IMAGE = custEditImgPre.ImageUrl;
                }

                try
                {
                    BusinessLogicExecutor.Execute<BLEditCust, CUSTOMER>(customer, DAEditCust.EditAcc);
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

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:editAccsuccessful(" + "\"" + Request.RawUrl + "\"" + ");", true);

                editAccDiv.Visible = false;
                viewAccDiv.Visible = true;
            }

        }

        protected void ChkRegisteredMail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!args.Value.Equals(custMail.Text))
            {
                try
                {
                    CUSTOMER registeredMail = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                                   (new CUSTOMER() { USERNAME = Session["username"].ToString(), MAIL = args.Value }, DAGetCust.GetByEmail).FirstOrDefault();

                    if (registeredMail != null)
                    {
                        args.IsValid = false;
                        custEditMail.Text = custMail.Text;

                    }
                    else if (registeredMail == null)
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

}