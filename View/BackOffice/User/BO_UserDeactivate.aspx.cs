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
    public partial class BO_UserDeactivate : System.Web.UI.Page
    {
        //step 2
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool found = false;
            if (!Page.IsPostBack)
            {
                string userId = Request.QueryString["userId"] ?? "";
                hiddendUserId.Value = userId;
                string sql = "SELECT NAME, USERNAME, MAIL, PHONE, USERGROUPNAME, STATUS FROM [USER] WHERE USERID = @USERID";
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
                }
                con.Close();
                dr.Close();

                if (!found)
                {
                    Response.Redirect("BO_UserSummary.aspx");
                }
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

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string sql = "UPDATE [USER] SET STATUS = @STATUS, UPDATEDDATE = @UPDATEDDATE, UPDATEDBY = @UPDATEDBY WHERE USERID = @USERID";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@STATUS", "Deactivate");
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

                //send email to notify acc has been deactivated
                string subject = "Your account has been deactivated!";
                string mailbody = "Hello " + nameTxt.Text + ", We regret to inform you that your Adopt Me account has been deactivated. If you require assistance, please contact us at adoptme.ewyv.noreply@gmail.com";
                sendEmail(mailTxt.Text, mailbody, subject);
                Response.Redirect("BO_UserSummary.aspx");
            }

        }
    }
}