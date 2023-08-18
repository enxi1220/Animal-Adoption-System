using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AnimalAdoptionSystem.View.FrontOffice.Pet
{
    public partial class FO_PetView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = Global.CS;

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["petId"]))
                {
                    Response.Redirect("FO_PetSummary.aspx");
                }

                //retrieve PK from URL
                string petId = Request.QueryString["petId"] ?? "";

                string sql = "SELECT * FROM PET WHERE PetId = @PetId";

      
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@PetId", petId);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    pViewImg.ImageUrl = (string)dr["Image"];
                    pViewDesc.Text = (string)dr["Desc"];
                    pViewName.Text = (string)dr["Name"];
                }


                //9. close con and dr
                dr.Close();
                con.Close();

                adoptbtn.NavigateUrl = "~/View/FrontOffice/Adoption/FO_AdoptionNew.aspx?petId=" + Request.QueryString["petId"];
           
                
            }
        }

       
    }
}