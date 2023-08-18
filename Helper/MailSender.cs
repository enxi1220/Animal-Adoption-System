using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AnimalAdoptionSystem.Helper
{
    public class MailSender
    {
        public static string sendMail(string customerMail) {
            string from = "adoptme.ewyv.noreply@gmail.com";
            string pwd = "czzlcsrigfwyieug";
            string randomOTP = getRandomOTP();
            MailMessage message = new MailMessage(from, customerMail);

            
            message.Subject = "Reset Password OTP";
            message.Body = "Use this OTP to reset your password ^-^ :\n\n" + randomOTP;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(from, pwd);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return randomOTP;
        }
        public static string getRandomOTP()
        {
            // Generate random number
            Random rnd = new Random();
            int number = rnd.Next(999999);

            // Convert any number sequence into 6 digits as OTP
            return number.ToString("D6").Trim();
        }
    }
}