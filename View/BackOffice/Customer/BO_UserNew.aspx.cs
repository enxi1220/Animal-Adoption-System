using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AnimalAdoptionSystem.View.BackOffice.Customer
{

    public partial class BO_UserNew : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
{


            }
        }

        protected void addNewStaff_Click(object sender, EventArgs e)
        {

            //if (Page.IsValid)
            //{
                //get input form txtbox & radiobtnlist
                string staffName = name.Text;
                string staffEmail = email.Text;
                string staffPassword = password.Text;
                string staffPhone = phone.Text;
                int staffId = 0;
                string userGroupName = RadioButtonList1.Text;

            //step 3 : sql stat
            //string sql = @"INSERT INTO [USER] (USERID, NAME, PASSWORD, MAIL, PHONE, USERGROUPNAME) VALUES (@USERID, @NAME, @PASSWORD, @MAIL, @PHONE, @USERGROUPNAME)";
            string sql = @"INSERT INTO [USER] (USERNAME, STATUS, NAME, PASSWORD, MAIL, PHONE, USERGROUPNAME) VALUES (@USERNAME, @STATUS, @NAME, @PASSWORD, @MAIL, @PHONE, @USERGROUPNAME)";


                //step 4 : establish connection 
                SqlConnection con = new SqlConnection(cs);

                //step 5 : sql cmd to process sql 
                SqlCommand cmd = new SqlCommand(sql, con);

                //step 5.1 : pass in parameter to the sql 

                Random rnd = new Random();

                for (int j = 0; j < 4; j++)
                {
                    staffId = rnd.Next();
                }
                //cmd.Parameters.AddWithValue("@USERID", staffId);
                cmd.Parameters.AddWithValue("@USERNAME", staffName);
                cmd.Parameters.AddWithValue("@STATUS", "Active");
                cmd.Parameters.AddWithValue("@NAME", staffName);
                cmd.Parameters.AddWithValue("@PASSWORD", staffPassword);
                cmd.Parameters.AddWithValue("@MAIL", staffEmail);
                cmd.Parameters.AddWithValue("@PHONE", staffPhone);
                cmd.Parameters.AddWithValue("@USERGROUPNAME", userGroupName);

                //step 6 : open connection 
                con.Open();

                //step 7 : run cmd
                cmd.ExecuteNonQuery(); 

                //stp 8 : close con
                con.Close();

                //redirect usr back to select2.aspx
                Response.Redirect("BO_UserEdit.aspx");

            //}


        }
    }
}