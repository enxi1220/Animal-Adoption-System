using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace AnimalAdoptionSystem.View.BackOffice.Euthanasia
{
    public partial class BO_EuthanasiaView1 : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            string petId = "";
            bool found = false;
            if (!Page.IsPostBack)
            {
                string euthanasiaId = Request.QueryString["euthanasiaId"] ?? "";
                string sql = "SELECT EUTHANASIANO, [DESC], MEDICINE, DOSE, UOM, STATUS, EXECUTIONDATE, PETID FROM EUTHANASIA WHERE EUTHANASIAID = @EUTHANASIAID";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EUTHANASIAID", euthanasiaId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    found = true;
                    euthNoTxt.Text = dr[0].ToString();
                    descTxt.Text = dr[1].ToString();
                    medTxt.Text = dr[2].ToString();
                    uomTxt.Text = dr[4].ToString();
                    statusTxt.Text = dr[5].ToString();
                    doseTxt.Text = dr[3].ToString();
                    exeDateTxt.Text = (Convert.ToDateTime(dr[6]).ToString("yyyy-MM-dd"));
                    petId = dr[7].ToString();       
                }

                con.Close();
                dr.Close();

                if (!found)
                {
                    Response.Redirect("BO_EuthanasiaSummary.aspx");
                }
                PetInfo(petId);
            }

        }

        protected void PetInfo(String petId)
        {
            string sql = "SELECT P.IMAGE, P.PETNO, P.NAME, P.AGE, P.SIZE, P.GENDER, P.BREED, P.TYPE, P.[DESC] FROM EUTHANASIA E, PET P WHERE E.PETID = P.PETID AND E.PETID = @PETID";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PETID", petId);

            con.Open();
            PetDetailsView.DataSource = cmd.ExecuteReader();
            PetDetailsView.DataBind();
            con.Close();
        }
    }
}