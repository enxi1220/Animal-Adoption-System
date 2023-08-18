using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnimalAdoptionSystem.View.BackOffice.Pet
{
    public partial class BO_PetSummary : System.Web.UI.Page
    {
        //Step 2 : get connection string from Global.asax
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    GridView1.DataSource = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET());
            //    GridView1.DataBind();
            //}
            //step 3 : sql statement
            //@ = activate the parameter
            string sql = "SELECT * FROM PET";

            //step 4 : establish connection 
            SqlConnection con = new SqlConnection(cs);

            //step 5 : pass in sql stat to sqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            //(parameterName, obj / str)
            //cmd.Parameters.AddWithValue("@euthanasiaNo", searchTxt.Text);

            //step 6 : open connection 
            con.Open();

            //step 7 : run sql cmd
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();

            //step 8 : close connection 
            con.Close();

        }

        protected void searchPet(object sender, EventArgs e)
        {
            //step 3 : sql statement
            //@ = activate the parameter
            string sql = "SELECT * FROM PET WHERE PETNO LIKE @petNo";

            //step 4 : establish connection 
            SqlConnection con = new SqlConnection(cs);

            //step 5 : pass in sql stat to sqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            //(parameterName, obj / str)
            cmd.Parameters.AddWithValue("@petNo", search.Text);

            //step 6 : open connection 
            con.Open();

            //step 7 : run sql cmd
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();

            //step 8 : close connection 
            con.Close();
        }

        //when press enter in the txtbox
        protected void searchPet_TextChanged(object sender, EventArgs e)
        {
            //step 3 : sql statement
            //@ = activate the parameter
            string sql = "SELECT * FROM PET WHERE PETNO LIKE @petNo";

            //step 4 : establish connection 
            SqlConnection con = new SqlConnection(cs);

            //step 5 : pass in sql stat to sqlCommand
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            //(parameterName, obj / str)
            cmd.Parameters.AddWithValue("@petNo", search.Text);

            //step 6 : open connection 
            con.Open();

            //step 7 : run sql cmd
            //GridView1.DataSource = cmd.ExecuteReader();
            //GridView1.DataBind();

            //step 8 : close connection 
            con.Close();
        }
    }
}