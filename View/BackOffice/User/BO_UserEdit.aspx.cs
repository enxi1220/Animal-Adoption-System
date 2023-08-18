using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Text;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;

namespace AnimalAdoptionSystem.View.BackOffice.User
{
    public partial class BO_UserEdit : System.Web.UI.Page
    {
        string cs = Global.CS;
        string name;
        string phone;
        string mail;
        string position;
        //string username;
        string pw;
        bool found;
        string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //disable position ddl if its staff
            if (!string.IsNullOrEmpty(Session["role"] as string)) //IF SESSION IS NOT NULL
            { 
                if (Session["role"].ToString().Equals(Constant.getUserRole(Constant.UserRoleEnum.Staff)))
                {
                    positionDdl.Enabled = false;
                    positionDdl.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
           
                }
            }

            found = false;
            userId = Request.QueryString["userId"] ?? "";
            if (!Page.IsPostBack)
            {
                found = getUserInfo(userId);
                nameTxt.Text = name;
                //usernameTxt.Text = username;
                mailTxt.Text = mail;
                phoneTxt.Text = phone;

                //remove extra selection
                positionDdl.Items.Remove(positionDdl.Items.FindByValue(position));

                positionDdl.Items.Insert(0, position);

                if (!found)
                {
                    Response.Redirect("BO_UserSummary.aspx");
                }
            }
        }
        private bool getUserInfo(string userId)
        {
            bool found = false;
            string sql = "SELECT NAME, [MAIL], PHONE, USERGROUPNAME, PASSWORD FROM [USER] WHERE USERID = @USERID";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@USERID", userId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                found = true;
                name = dr[0].ToString();
                mail = dr[1].ToString();
                phone = dr[2].ToString();
                position = dr[3].ToString();
                pw = dr[4].ToString();
                //username = dr[5].ToString();
            }
            con.Close();
            dr.Close();
            return found;
        }
        private int checkExistName()
        {
            string sql = "SELECT COUNT(*) FROM [USER] WHERE NAME = @NAME;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@NAME", nameTxt.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        /*
        private int checkCustExistUsername()
        {
            string sql = "SELECT COUNT(*) FROM [CUSTOMER] WHERE USERNAME = @USERNAME;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@USERNAME", usernameTxt.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        private int checkExistUsername()
        {
            string sql = "SELECT COUNT(*) FROM [USER] WHERE USERNAME = @USERNAME;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@USERNAME", usernameTxt.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        */

        private int checkExistPhone()
        {
            string sql = "SELECT COUNT(*) FROM [USER] WHERE PHONE = @PHONE;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PHONE", phoneTxt.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        private int checkExistMail()
        {
            string sql = "SELECT COUNT(*) FROM [USER] WHERE MAIL = @MAIL;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MAIL", mailTxt.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        
        private int checkCustExistMail()
        {
            string sql = "SELECT COUNT(*) FROM [CUSTOMER] WHERE MAIL = @MAIL;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MAIL", mailTxt.Text);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        protected void customValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            found = getUserInfo(userId);
            if (nameTxt.Text != name)
            {
                if (checkExistName() > 0)
                {
                    CustomValidator1.ErrorMessage = "Name entered has already existed in database";
                    args.IsValid = false;
                }
            }
        }
        protected void customValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (phoneTxt.Text != phone)
            {
                if (checkExistPhone() > 0)
                {
                    CustomValidator2.ErrorMessage = "Phone entered has already existed in database";
                    args.IsValid = false;
                }
            }  
        }
        protected void customValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (mailTxt.Text != mail)
            {
                //CUSTOMER mailTaken = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                               //(new CUSTOMER() { MAIL = args.Value }, DAGetCust.GetByEmailExist).FirstOrDefault();


                if (checkExistMail() > 0 || checkCustExistMail() > 0)
                {
                    CustomValidator3.ErrorMessage = "Mail entered has already existed in database";
                    args.IsValid = false;
                }
            }
        }
        /*
        protected void customValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (usernameTxt.Text != username)
            {
                if (checkExistUsername() > 0 || checkCustExistUsername() >0)
                {
                    CustomValidator4.ErrorMessage = "Username entered has already existed in database";
                    args.IsValid = false;
                }
            }
        }*/
        protected void customValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string mailLength = mailTxt.Text;      
            if (mailLength.Length > 60)
            {
                    mailLengthValidator.ErrorMessage = "Mail is too long";
                    args.IsValid = false;
            }
        }
        protected void nameLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string namelLength = nameTxt.Text;      
            if (namelLength.Length > 100)
            {
                nameLengthValidator.ErrorMessage = "Name is too long";
                    args.IsValid = false;
            }
        }
        /*
        protected void usernameLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string usernameLength = usernameTxt.Text;      
            if (usernameLength.Length > 30)
            {
                usernameLengthValidator.ErrorMessage = "Username is too long";
                    args.IsValid = false;
            }
        }
        */

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_UserSummary.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string sql = "UPDATE [USER] SET [NAME] = @NAME, MAIL = @MAIL, PHONE = @PHONE, USERGROUPNAME = @USERGROUPNAME, UPDATEDDATE = @UPDATEDDATE, UPDATEDBY = @UPDATEDBY WHERE USERID = @USERID";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                var culture = new CultureInfo("ms-MY");
                DateTime updatedDate = DateTime.Now;
                cmd.Parameters.AddWithValue("@NAME", nameTxt.Text);
                cmd.Parameters.AddWithValue("@MAIL", mailTxt.Text);
                cmd.Parameters.AddWithValue("@PHONE", phoneTxt.Text);
                cmd.Parameters.AddWithValue("@USERGROUPNAME", Convert.ToString(positionDdl.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@USERID", userId);
                //cmd.Parameters.AddWithValue("@USERNAME", usernameTxt.Text);
                cmd.Parameters.AddWithValue("@UPDATEDDATE", updatedDate);

                if (!string.IsNullOrEmpty(Session["username"] as string)) //IF SESSION IS NOT NULL
                {
                    cmd.Parameters.AddWithValue("@UPDATEDBY", Session["username"].ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UPDATEDBY", "");
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("BO_UserSummary.aspx");
            }
        }
    }
}