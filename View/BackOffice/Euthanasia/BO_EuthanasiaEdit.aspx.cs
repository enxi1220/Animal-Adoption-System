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
    public partial class BO_EuthanasiaEdit1 : System.Web.UI.Page
    { 
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            //to disable previous dates
            txt_ExeDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

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
                    petNoTxt.Text = dr[0].ToString();
                    string desc = dr[1].ToString(); 
                    string med = dr[2].ToString();
                    txt_Dose.Text = dr[3].ToString();
                    string uom = dr[4].ToString(); 
                    string status = dr[5].ToString();
                    string petId = dr[7].ToString();

                    //remove extra / duplicate selection
                    ddl_Status.Items.Remove(ddl_Status.Items.FindByValue(status));
                    ddl_Desc.Items.Remove(ddl_Desc.Items.FindByValue(desc));
                    ddl_med.Items.Remove(ddl_med.Items.FindByValue(med));
                    ddl_Uom.Items.Remove(ddl_Uom.Items.FindByValue(uom));

                    txt_ExeDate.Text = (Convert.ToDateTime(dr[6]).ToString("yyyy-MM-dd"));
                    hiddendPetId.Value = Convert.ToString(petId);

                    //insert the previously selected ans as 1st selection
                    ddl_Desc.Items.Insert(0, desc);
                    ddl_med.Items.Insert(0, med);
                    ddl_Uom.Items.Insert(0, uom);
                    ddl_Status.Items.Insert(0, status);
                }

                con.Close();
                dr.Close();

                if (!found)
                {
                    Response.Redirect("BO_EuthanasiaSummary.aspx");
                }
            }            
        }


        private void updatePetStatus(int petId, string petStatus)
        {
            string sql = "UPDATE PET SET [STATUS] = @STATUS WHERE PETID = @PETID";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@STATUS", petStatus);
            cmd.Parameters.AddWithValue("@PETID", petId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
                if (Page.IsValid)
                {
                    string sql = "UPDATE EUTHANASIA SET [DESC] = @DESC, MEDICINE = @MEDICINE, DOSE = @DOSE, UOM = @UOM, STATUS = @STATUS, EXECUTIONDATE = @EXECUTIONDATE, UPDATEDDATE = @UPDATEDDATE, UPDATEDBY = @UPDATEDBY WHERE EUTHANASIANO = @EUTHANASIANO";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    var culture = new CultureInfo("ms-MY");
                    string description = Convert.ToString(ddl_Desc.SelectedItem.Value);
                    string medicine = Convert.ToString(ddl_med.SelectedItem.Value);
                    decimal dose;
                    decimal.TryParse(txt_Dose.Text, out dose);
                    string uom = Convert.ToString(ddl_Uom.SelectedItem.Value);
                    string status = Convert.ToString(ddl_Status.SelectedItem.Value);
                    DateTime executionDate = Convert.ToDateTime(txt_ExeDate.Text, culture);
                    DateTime updatedDate = DateTime.Now;

                    cmd.Parameters.AddWithValue("@DESC", description);
                    cmd.Parameters.AddWithValue("@MEDICINE", medicine);
                    cmd.Parameters.AddWithValue("@DOSE", dose);
                    cmd.Parameters.AddWithValue("@UOM", uom);
                    cmd.Parameters.AddWithValue("@STATUS", status);
                    cmd.Parameters.AddWithValue("@EXECUTIONDATE", executionDate);
                    cmd.Parameters.AddWithValue("@EUTHANASIANO", petNoTxt.Text);
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

                    //update pet status if euth status changes
                    if (status == "Cancelled")
                    {
                        updatePetStatus(Convert.ToInt32(hiddendPetId.Value), "New");

                    }
                    if (status == "Completed")
                    {
                        updatePetStatus(Convert.ToInt32(hiddendPetId.Value), "Euthanasia");

                    }

                Response.Redirect("BO_EuthanasiaSummary.aspx");
                
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_EuthanasiaSummary.aspx");
        }
    }
}