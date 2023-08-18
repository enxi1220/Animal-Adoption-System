using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.BackOffice.User
{
    public partial class BO_UserView : System.Web.UI.Page
    {
        //step 2
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool found = false;
            if (!Page.IsPostBack)
            {
                string userId = Request.QueryString["userId"] ?? "";

                //step 3 
                string sql = "SELECT NAME, USERNAME, MAIL, PHONE, USERGROUPNAME, STATUS FROM [USER] WHERE USERID = @USERID";

                //step 4
                SqlConnection con = new SqlConnection(cs);

                //step 5
                SqlCommand cmd = new SqlCommand(sql, con);
                //step 5.1
                cmd.Parameters.AddWithValue("@USERID", userId);

                //step 6
                con.Open();

                //step 7
                SqlDataReader dr = cmd.ExecuteReader();

                //step 8 :handle return record
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

                //step 9
                con.Close();
                dr.Close();

                if (!found)
                {
                    Response.Redirect("BO_UserSummary.aspx");
                }

            }
        }
    }
}