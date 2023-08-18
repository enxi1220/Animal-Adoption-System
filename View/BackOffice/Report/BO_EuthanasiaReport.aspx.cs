using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AnimalAdoptionSystem.Helper;

namespace AnimalAdoptionSystem.View.BackOffice.Euthanasia
{
    public partial class BO_EuthanasiaReport : System.Web.UI.Page
    {
        string cs = Global.CS;
        public string barData;
        public string doughnutData;
        public string pieData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] as string != Constant.getUserRole(Constant.UserRoleEnum.Admin))
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyAdmin(" + "\"" + "/View/BackOffice/Pet/BO_PetSummary.aspx" + "\"" + ");", true);
            }

            //pieData = "[";
            LoadBarChartData("READY");
            LoadBarChartData("PENDING");
            LoadBarChartData("COMPLETED");
            LoadBarChartData("CANCELLED");
            //pieData = pieData.Remove(pieData.Length - 1) + ']';
            barData = barData.Remove(barData.Length - 1);

            //doughnut chart
            LoadDoughnutChartData("Terminal illness, e.g. cancer or rabies");
            LoadDoughnutChartData("Behavioral problems e.g. aggression");
            LoadDoughnutChartData("Old age and deterioration");
            LoadDoughnutChartData("Lack of home or caretaker or resources for feeding");
            LoadDoughnutChartData("Research and testing purpose");
            LoadDoughnutChartData("Other");
            doughnutData = doughnutData.Remove(doughnutData.Length - 1);

            //pie chart
            LoadPieChartData("Pentobarbital Sodium");
            LoadPieChartData("Phenytoin Sodium");
            LoadPieChartData("Rhodamine B");
            LoadPieChartData("Bluish-red fluorescent dye");
            LoadPieChartData("Benzyl Alcohol");
            LoadPieChartData("IV Injection");
            LoadPieChartData("Seizure Medication");
            LoadPieChartData("Sedative");
            LoadPieChartData("Other");
            pieData = pieData.Remove(pieData.Length - 1);
        }

        public void LoadBarChartData(string status)
        {
            //step 3 
            string sql = "SELECT STATUS, COUNT(STATUS) FROM EUTHANASIA WHERE STATUS = @STATUS GROUP BY STATUS;";


            //step 4
            SqlConnection con = new SqlConnection(cs);

            //step 5
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1
            cmd.Parameters.AddWithValue("@STATUS", status);

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
        public void LoadDoughnutChartData(string desc)
        {
            //step 3 
            string sql = "SELECT COUNT([DESC]) FROM EUTHANASIA WHERE [DESC] = @DESC GROUP BY [DESC];";


            //step 4
            SqlConnection con = new SqlConnection(cs);

            //step 5
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1
            cmd.Parameters.AddWithValue("@DESC", desc);

            //step 6
            con.Open();

            //step 7
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //data: ['467', '576', '572', '79', '92', '574', '573', '576'],
                doughnutData += "'" + dr[0] + "',";
            }
            else
            {
                doughnutData += "'" + 0 + "',";
            }

            //step 9
            con.Close();
            dr.Close();
        }

        public void LoadPieChartData(string med)
        {
            //step 3 
            string sql = "SELECT COUNT(MEDICINE) FROM EUTHANASIA WHERE MEDICINE = @MEDICINE GROUP BY MEDICINE;";


            //step 4
            SqlConnection con = new SqlConnection(cs);

            //step 5
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1
            cmd.Parameters.AddWithValue("@MEDICINE", med);

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