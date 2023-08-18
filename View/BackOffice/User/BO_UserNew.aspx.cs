using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;

namespace AnimalAdoptionSystem.View.BackOffice.User
{
    public partial class BO_UserNew : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {/*
                var statusList = Enum.GetValues(typeof(Helper.Constant.StatusEnum));
                statusDdl.DataSource = statusList;
                statusDdl.DataBind();*/
                
                var positionList = Enum.GetValues(typeof(Helper.Constant.UserRoleEnum));
                positionDdl.DataSource = positionList;
                positionDdl.DataBind();
            }
                
        }


        // Generate a random password
        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

            // Generate a random number between two numbers    
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
        

            // Generate a random string with a given size and case.   
            // If second parameter is true, the return string is lowercase  
            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }
        
        
        protected void btnSave3_Click(object sender, EventArgs e)
        {
            string password = RandomPassword(); //create random pw

            //generate unique username
            Random rnd = new Random();
            var randomNo = rnd.Next(1, 10000); //4-digits random no in username
            string pattern = @"^\w+"; //to get first word in name
            string name = nameTxt.Text;
            var username = Regex.Match(name, pattern); //extract 1st word from name 
            string uname = username.Value  + randomNo.ToString().PadLeft(4, '0'); //username = 1st word in name + 4-digit random no

            if (Page.IsValid)
            {
                DateTime today = DateTime.Now;
                var culture = new CultureInfo("ms-MY");
                //string status = Convert.ToString(statusDdl.SelectedItem.Value);
                string userGroupName = Convert.ToString(positionDdl.SelectedItem.Value);
                string phone = phoneTxt.Text;
                string mail = mailTxt.Text;
                DateTime createdDate = DateTime.Now;

                string sql = @"INSERT INTO [USER] (USERNAME, STATUS, USERGROUPNAME, NAME, PASSWORD, PHONE, MAIL, CREATEDDATE, CREATEDBY) VALUES (@USERNAME, @STATUS, @USERGROUPNAME, @NAME, @PASSWORD, @PHONE, @MAIL, @CREATEDDATE, @CREATEDBY)";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@USERNAME", uname);
                cmd.Parameters.AddWithValue("@STATUS", Constant.getStatus(Constant.StatusEnum.Activate));
                cmd.Parameters.AddWithValue("@USERGROUPNAME", userGroupName);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@PASSWORD", EncodePasswordToBase64(password));
                cmd.Parameters.AddWithValue("@PHONE", phone);
                cmd.Parameters.AddWithValue("@MAIL", mail);
                cmd.Parameters.AddWithValue("@CREATEDDATE", createdDate);

                if (!string.IsNullOrEmpty(Session["username"] as string)) //if session is not null
                {
                    cmd.Parameters.AddWithValue("@CREATEDBY", Session["username"].ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CREATEDBY", "");
                }
                

                con.Open();
                cmd.ExecuteNonQuery(); 
                con.Close();
                //if(status.Equals(Constant.getStatus(Constant.StatusEnum.Activate))) //if status = active, send email to notify them
                //{
                    sendEmail(name, mail, uname, password);
                //}
                Response.Redirect("BO_UserSummary.aspx");
            }
        }
        
        /*
        protected void btnSave3_Click(object sender, CommandEventArgs e)
        {
            string password = RandomPassword(); //create random pw

            //generate unique username
            Random rnd = new Random();
            var randomNo = rnd.Next(1, 10000); //4-digits random no in username
            string pattern = @"^\w+"; //to get first word in name
            string name = nameTxt.Text;
            var username = Regex.Match(name, pattern); //extract 1st word from name 
            string uname = username.Value  + randomNo.ToString().PadLeft(4, '0'); //username = 1st word in name + 4-digit random no

            if (Page.IsValid)
            {
                DateTime today = DateTime.Now;
                var culture = new CultureInfo("ms-MY");
                //string status = Convert.ToString(statusDdl.SelectedItem.Value);
                string userGroupName = Convert.ToString(positionDdl.SelectedItem.Value);
                string phone = phoneTxt.Text;
                string mail = mailTxt.Text;
                DateTime createdDate = DateTime.Now;

                string sql = @"INSERT INTO [USER] (USERNAME, STATUS, USERGROUPNAME, NAME, PASSWORD, PHONE, MAIL, CREATEDDATE, CREATEDBY) VALUES (@USERNAME, @STATUS, @USERGROUPNAME, @NAME, @PASSWORD, @PHONE, @MAIL, @CREATEDDATE, @CREATEDBY)";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@USERNAME", uname);
                cmd.Parameters.AddWithValue("@STATUS", Constant.getStatus(Constant.StatusEnum.Activate));
                cmd.Parameters.AddWithValue("@USERGROUPNAME", userGroupName);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@PASSWORD", EncodePasswordToBase64(password));
                cmd.Parameters.AddWithValue("@PHONE", phone);
                cmd.Parameters.AddWithValue("@MAIL", mail);
                cmd.Parameters.AddWithValue("@CREATEDDATE", createdDate);

                if (!string.IsNullOrEmpty(Session["username"] as string)) //if session is not null
                {
                    cmd.Parameters.AddWithValue("@CREATEDBY", Session["username"].ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CREATEDBY", "");
                }
                

                con.Open();
                cmd.ExecuteNonQuery(); 
                con.Close();
                //if(status.Equals(Constant.getStatus(Constant.StatusEnum.Activate))) //if status = active, send email to notify them
                //{
                    sendEmail(name, mail, uname, password);
                //}
                Response.Redirect("BO_UserSummary.aspx");
            }
        }
        */
        private void sendEmail(string name, string to, string uname, string pw)
        {
            string from = "adoptme.ewyv.noreply@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Hello "+ name + ", we are excited to welcome you as a new member of Adopt Me.\n\n You may log in to your account by using the following details : \nUsername:\n" + uname + "\nPassword:\n"+ pw;
            message.Subject = "Activate your email address now!";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("adoptme.ewyv.noreply@gmail.com", "czzlcsrigfwyieug");
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.EnableSsl = true;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int checkExistName()
        {
            //step 3 : sql statement
            string sql = "SELECT COUNT(*) FROM [USER] WHERE NAME = @NAME;";

            //step 4 : establish connection 
            SqlConnection con = new SqlConnection(cs);

            //step 5 : pass in sql stat to sqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            cmd.Parameters.AddWithValue("@NAME", nameTxt.Text);

            //step 6 : open connection 
            con.Open();

            //step 7 : run sql cmd
            int count = (int)cmd.ExecuteScalar();

            //step 8 : close connection 
            con.Close();

            return count;
        }
        
        private int checkExistPhone()
        {
            //step 3 : sql statement
            string sql = "SELECT COUNT(*) FROM [USER] WHERE PHONE = @PHONE;";

            //step 4 : establish connection 
            SqlConnection con = new SqlConnection(cs);

            //step 5 : pass in sql stat to sqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            cmd.Parameters.AddWithValue("@PHONE", phoneTxt.Text);

            //step 6 : open connection 
            con.Open();

            //step 7 : run sql cmd
            int count = (int)cmd.ExecuteScalar();

            //step 8 : close connection 
            con.Close();

            return count;
        }
        
        private int checkExistMail()
        {
            //step 3 : sql statement
            string sql = "SELECT COUNT(*) FROM [USER] WHERE MAIL = @MAIL;";

            //step 4 : establish connection 
            SqlConnection con = new SqlConnection(cs);

            //step 5 : pass in sql stat to sqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            cmd.Parameters.AddWithValue("@MAIL", mailTxt.Text);

            //step 6 : open connection 
            con.Open();

            //step 7 : run sql cmd
            int count = (int)cmd.ExecuteScalar();

            //step 8 : close connection 
            con.Close();

            return count;
        }

        protected void customValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (checkExistName() > 0)
            {
                CustomValidator1.ErrorMessage = "Name entered has already existed in database";
                args.IsValid = false;
            }
            
        }
         protected void customValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (checkExistPhone()>0)
            {
                CustomValidator2.ErrorMessage = "Phone entered has already existed in database";
                args.IsValid = false;
            }
            
        }
        protected void customValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
           /* CUSTOMER mailTaken = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>
                                               (new CUSTOMER() { MAIL = args.Value }, DAGetCust.GetByEmailExist).FirstOrDefault();
           */
            if (checkExistMail()>0 || checkCustExistMail() > 0)
            {
                CustomValidator3.ErrorMessage = "Mail entered has already existed in database";
                args.IsValid = false;
            }
           
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
        protected void customValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string mailLength = mailTxt.Text;
            if (mailLength.Length > 60)
            {
                CustomValidator5.ErrorMessage = "Mail is too long";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_UserSummary.aspx");
        }

        //Encrypt pw
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}