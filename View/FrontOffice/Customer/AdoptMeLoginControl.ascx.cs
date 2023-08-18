using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnimalAdoptionSystem.Helper;

namespace AnimalAdoptionSystem.View.FrontOffice.Customer
{
    public partial class AdoptMeLoginControl : System.Web.UI.UserControl
    {
        string CS = Global.CS;
        SqlConnection con;
        SqlCommand cmd;
        string sql = "";
        bool notCustomer = false;
        int customerCount = 0;
        int userCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string urlGiven = Request.QueryString["url"] ?? "";

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(urlGiven))
                    Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:checkLogin();", true);

                if (Request.Cookies["user"] != null)
                    loginUsername.Text = Request.Cookies["user"].Value;
                if (Request.Cookies["pass"] != null)
                    loginPass.Attributes.Add("value", Request.Cookies["pass"].Value);
                if (Request.Cookies["user"] != null && Request.Cookies["pass"] != null)
                    rmbMeChkBox.Checked = true;

            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            bool activeOrNot = false;
            if (Page.IsValid)
            {
                string url;
                string urlGiven = Request.QueryString["url"] ?? "";

                if (notCustomer)
                {
                    sql = "Select UserGroupName, Status FROM [User] WHERE Username = @Username AND Password = @Password";
                    con = new SqlConnection(CS);
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Username", loginUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", PwEncryptionDecryption.EncodePasswordToBase64(loginPass.Text));
                    con.Open();

                    string role = string.Empty;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["status"].ToString().Equals(Constant.getStatus(Constant.StatusEnum.Activate)))
                        {
                            activeOrNot = true;
                            role = reader["usergroupname"].ToString();
                        }
                    }

                    reader.Close();
                    con.Close();

                    Session["role"] = role;
                }
                else
                {
                    sql = "Select Status FROM Customer WHERE Username = @Username AND Password = @Password";
                    con = new SqlConnection(CS);
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Username", loginUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", PwEncryptionDecryption.EncodePasswordToBase64(loginPass.Text));
                    con.Open();

                    string accStatus = (string)cmd.ExecuteScalar();
                    con.Close();

                    if (accStatus.Equals(Constant.getStatus(Constant.StatusEnum.Activate)))
                        activeOrNot = true;
                }

                if (activeOrNot)
                {
                    //redirect from the page that need login to access
                    if (!string.IsNullOrEmpty(urlGiven))
                    {
                        url = urlGiven;
                    }
                    else //normal login
                    {
                        if (notCustomer)
                        {
                            url = "/View/BackOffice/Pet/BO_PetSummary.aspx";
                        }
                        else
                        {
                            url = "/View/FrontOffice/Pet/FO_PetSummary.aspx";
                        }
                    }

                    Session["username"] = loginUsername.Text;
                    //rmb me
                    if (rmbMeChkBox.Checked)
                    {
                        Response.Cookies["user"].Value = loginUsername.Text.Trim();
                        Response.Cookies["pass"].Value = loginPass.Text.Trim();
                        Response.Cookies["user"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:loginSuccess(" + "\"" + Session["username"].ToString() + "\"" + "," + "\"" + url + "\"" + ");", true);

                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:accDeactivated();", true);
                }

            }


        }

        protected void LoginUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value;

            sql = "Select COUNT(*) FROM Customer WHERE Username = @Username";
            con = new SqlConnection(CS);
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Username", username);
            con.Open();
            customerCount = (int)cmd.ExecuteScalar();
            con.Close();

            if (customerCount < 1)
            {
                sql = "Select COUNT(*) FROM [User] WHERE Username = @Username";
                con = new SqlConnection(CS);
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username", username);
                con.Open();
                userCount = (int)cmd.ExecuteScalar();
                con.Close();

                notCustomer = true;
            }

            if (customerCount < 1 && userCount < 1)
                args.IsValid = false;



        }

        protected void PasswordCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                string username = loginUsername.Text;
                string password = args.Value;
                string userPwdInDb = string.Empty;

                sql = "Select Password FROM Customer WHERE Username = @Username";
                con = new SqlConnection(CS);
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username", username);
                con.Open();
                string custPwdInDb = (string)cmd.ExecuteScalar();
                con.Close();

                if (custPwdInDb != null)
                {
                    try { 
                    if (!password.Equals(PwEncryptionDecryption.DecodeFrom64(custPwdInDb)))
                    {
                        sql = "Select Password FROM [User] WHERE Username = @Username";
                        con = new SqlConnection(CS);
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@Username", username);
                        con.Open();
                        userPwdInDb = (string)cmd.ExecuteScalar();
                        con.Close();
                    }
                    }
                    catch (SqlException sqlEx)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:exceptionFound(" + "\"" + sqlEx.Message + "\"" + ");", true);
                    }
                    catch (NullReferenceException nullEx)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:exceptionFound(" + "\"" + nullEx.Message + "\"" + ");", true);
                    }
                    catch (Exception ex)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:exceptionFound(" + "\"" + ex.Message + "\"" + ");", true);
                    }

                }

                if (notCustomer == true)
                {
                    sql = "Select Password FROM [User] WHERE Username = @Username";
                    con = new SqlConnection(CS);
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    con.Open();
                    userPwdInDb = (string)cmd.ExecuteScalar();
                    con.Close();
                }

                if (custPwdInDb != null) //if pw is found in db -> perform decoding
                {
                    if (!password.Equals(PwEncryptionDecryption.DecodeFrom64(custPwdInDb)))
                    {
                        args.IsValid = false;
                    }
                }
                else if (userPwdInDb != null)
                {
                    if (!password.Equals(PwEncryptionDecryption.DecodeFrom64(userPwdInDb)))
                    {
                        args.IsValid = false;
                    }
                }
                else //if null is valid = false
                {
                    args.IsValid = false;
                }

                if (userPwdInDb != null)
                {
                    if (password.Equals(PwEncryptionDecryption.DecodeFrom64(userPwdInDb)))
                    {
                        notCustomer = true;
                    }
                }

            }

        }

    }
}