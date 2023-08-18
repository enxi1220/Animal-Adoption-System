using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//step 1 : import library

using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnimalAdoptionSystem.View.BackOffice.Euthanasia
{
    public partial class BO_EuthanasiaSummary : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM EUTHANASIA";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
            con.Close();
        }

        //when click the search button 
        protected void searchEv(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM EUTHANASIA WHERE EUTHANASIANO LIKE @euthanasiaNo";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@euthanasiaNo", searchTxt.Text);

            con.Open();
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
            con.Close();
        }
        
        //when press enter in the txtbox
        protected void searchTxt_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM EUTHANASIA WHERE EUTHANASIANO LIKE @euthanasiaNo";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@euthanasiaNo", searchTxt.Text);

            con.Open();
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
            con.Close();
        }
    }
}