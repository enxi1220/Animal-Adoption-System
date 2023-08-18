using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AnimalAdoptionSystem.Helper;

namespace AnimalAdoptionSystem.View.BackOffice.Adoption
{
    public partial class AdoptionReport : System.Web.UI.Page
    {
        string cs = Global.CS;
        public string barData;
        public string pieData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] as string != Constant.getUserRole(Constant.UserRoleEnum.Admin))
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyAdmin(" + "\"" + "/View/BackOffice/Pet/BO_PetSummary.aspx" + "\"" + ");", true);
            }

            //pie chart
            LoadPieChartData("New");
            LoadPieChartData("Approved");
            LoadPieChartData("Rejected");
            LoadPieChartData("Canceled");
            pieData = pieData.Remove(pieData.Length - 1);

            //bar chart
            LoadBarChartData("Underage");
            LoadBarChartData("Too many people / children in a household");
            LoadBarChartData("Long working hours");
            LoadBarChartData("House size too small");
            LoadBarChartData("Application information is not completed");
            LoadBarChartData("Other");
            barData = barData.Remove(barData.Length - 1);
        }

        public void LoadBarChartData(string rejectReason)
        {
            //step 3 
            string sql = "SELECT REASONOFREJECTION, COUNT(REASONOFREJECTION) FROM ADOPTION WHERE REASONOFREJECTION = @REJECTREASON GROUP BY REASONOFREJECTION;";


            //step 4
            SqlConnection con = new SqlConnection(cs);

            //step 5
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1
            cmd.Parameters.AddWithValue("@REJECTREASON", rejectReason);

            //step 6
            con.Open();

            //step 7
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //data: ['467', '576', '572', '79', '92', '574', '573', '576'],
                barData += "'" + dr[1] + "',";
            }
            else
            {
                barData += "'" + 0 + "',";
            }

            //step 9
            con.Close();
            dr.Close();
        }


        public void LoadPieChartData(string approvalStatus)
        {
            //step 3 
            string sql = "SELECT COUNT(STATUS) FROM ADOPTION WHERE STATUS = @STATUS GROUP BY STATUS;";


            //step 4
            SqlConnection con = new SqlConnection(cs);

            //step 5
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1
            cmd.Parameters.AddWithValue("@STATUS", approvalStatus);

            //step 6
            con.Open();

            //step 7
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //data: ['467', '576', '572', '79', '92', '574', '573', '576'],
                pieData += "'" + dr[0] + "',";
            }
            else
            {
                pieData += "'" + 0 + "',";
            }

            //step 9
            con.Close();
            dr.Close();
        }

    }
}