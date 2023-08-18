using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.BackOffice.User
{
    public partial class BO_UserActivate : System.Web.UI.Page
    {
        string userId;
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool found = false;
            
            if (!Page.IsPostBack)
            {
                userId = Request.QueryString["userId"] ?? "";
                hiddendUserId.Value = userId;
                string sql = "SELECT NAME, USERNAME, MAIL, PHONE, USERGROUPNAME, STATUS, PASSWORD FROM [USER] WHERE USERID = @USERID";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@USERID", userId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    found = true;
                    nameTxt.Text = dr[0].ToString();
                    usernameTxt.Text = dr[1].ToString();
                    mailTxt.Text = dr[2].ToString();
                    phoneTxt.Text = dr[3].ToString();
                    positionTxt.Text = dr[4].ToString();
                    statusTxt.Text = dr[5].ToString();
                    hiddenPw.Value = dr[6].ToString();
                }
                con.Close();
                dr.Close();
                if (!found)
                {
                    Response.Redirect("BO_UserSummary.aspx");
                }
            }
        }
        protected void btnActivate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string sql = "UPDATE [USER] SET STATUS = @STATUS, UPDATEDDATE = @UPDATEDDATE, UPDATEDBY = @UPDATEDBY WHERE USERID = @USERID";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@STATUS", "Activate");
                cmd.Parameters.AddWithValue("@USERID", Convert.ToInt32(hiddendUserId.Value));
                DateTime updatedDate = DateTime.Now;
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


                //send email notify user
                string subject = "Activate your email address now!";
                string mailbody = "Hello " + nameTxt.Text + ", we are excited to welcome you as a new member of Adopt Me.\n\n You may log in to your account by using the following details : Username:" + usernameTxt.Text + "\nPassword:\n" + DecodeFrom64(hiddenPw.Value);
                sendEmail(mailTxt.Text, mailbody, subject);
                Response.Redirect("BO_UserSummary.aspx");
            }
        }
        private void sendEmail(string to, string mailbody, string subject)
        {
            string from = "adoptme.ewyv.noreply@gmail.com"; //From address
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
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

        //Decrypt pw
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

    }
}