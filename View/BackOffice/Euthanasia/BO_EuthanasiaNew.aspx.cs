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
    public partial class BO_EuthanasiaNew2__01 : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            //to disable previous dates
            txt_ExeDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Page.IsPostBack)
            {
                //if no pets are available 
                if (checkAvaPet() == 0)
                {
                    ddl_PetNo.Items.Insert(0, "No Pets Available");
                    ddl_PetNo.Items[0].Selected = true;
                    ddl_PetNo.Items[0].Attributes["Disabled"] = "Disabled";

                    //disable save btn
                    btnSave9.Enabled = false;
                    ddl_PetNo.Enabled = false;
                    ddl_Desc.Enabled = false;
                    ddl_med.Enabled = false;
                    txt_Dose.Enabled = false;
                    ddl_Uom.Enabled = false;
                    ddl_Status.Enabled = false;
                    txt_ExeDate.Enabled = false;

                    //set css to input field to indicate the input fields are disabled
                    btnSave9.Attributes.Remove("href");
                    btnSave9.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "white";
                    btnSave9.Attributes.CssStyle[HtmlTextWriterStyle.BackgroundColor] = "gray";
                    btnSave9.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";

                    ddl_PetNo.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block;  font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f; font-weight:bold; appearance: none;    border-radius: 0.25rem;");
                    ddl_Desc.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
                    ddl_med.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block;  font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
                    txt_Dose.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
                    ddl_Uom.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block;  font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
                    ddl_Status.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
                    txt_ExeDate.Attributes.Add("style", "background-color: #e9ecef; min-height: auto; padding: 0.33em 0.75em; transition: all .2s linear; opacity: 1; border: 1px solid #e0e0e0 !important; display: block; font-size: 1rem;    font-weight: 400;    line-height: 1.6;    color: #4f4f4f;    appearance: none;    border-radius: 0.25rem;");
                }
                //if pets are available
                else
                {
                    //set the available pets no to ddl
                    setDdlDefaultValue();
                }

            }
        }

        //to check if there are available pets (pet status = new & pets havent been euthanized)
        private int checkAvaPet()
        {
            string sql = "SELECT COUNT(PET.PETID) FROM PET LEFT JOIN EUTHANASIA ON EUTHANASIA.PETID= PET.PETID WHERE EUTHANASIA.PETID IS NULL AND PET.STATUS = @PETSTATUS;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PETSTATUS", "New");
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        
        //set available pet no to drop down list
        private void setDdlDefaultValue()
        {
            string sql = "SELECT PET.PETNO, PET.PETID FROM PET LEFT JOIN EUTHANASIA ON EUTHANASIA.PETID= PET.PETID WHERE EUTHANASIA.PETID IS NULL AND PET.STATUS = @PETSTATUS;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PETSTATUS", "New");
            con.Open();
            ddl_PetNo.DataSource = cmd.ExecuteReader();
            ddl_PetNo.DataTextField = "PETNO";
            ddl_PetNo.DataValueField = "PETID";
            ddl_PetNo.DataBind();
            con.Close();
            ddl_PetNo.Items.Insert(0, "");
            ddl_PetNo.Items[0].Selected = true;
            ddl_PetNo.Items[0].Attributes["Disabled"] = "Disabled";
        }

        private void updatePetStatus(int petId)
        {
            string sql = "UPDATE PET SET [STATUS] = @STATUS WHERE PETID = @PETID";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@STATUS", "Euthanasia");
            cmd.Parameters.AddWithValue("@PETID", petId);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //to generate euth no
                DateTime date = DateTime.Now;
                string year = date.ToString("yy"); //year
                string month = DateTime.Now.ToString("MM"); //month
                Random rnd = new Random();
                int no = rnd.Next(1, 1000000); //no
                string euthNo = "EUTH/" + year + month + "/" + no;

                //get input
                var culture = new CultureInfo("ms-MY");
                int petId = Convert.ToInt32(ddl_PetNo.SelectedItem.Value);
                string description = Convert.ToString(ddl_Desc.SelectedItem.Value);
                string medicine = Convert.ToString(ddl_med.SelectedItem.Value);
                decimal dose;
                decimal.TryParse(txt_Dose.Text, out dose);
                string uom = Convert.ToString(ddl_Uom.SelectedItem.Value);
                string status = Convert.ToString(ddl_Status.SelectedItem.Value);
                DateTime executionDate = Convert.ToDateTime(txt_ExeDate.Text, culture);
                DateTime createdDate = DateTime.Now;

                //step 3 : sql stat
                string sql = @"INSERT INTO EUTHANASIA (PETID, EUTHANASIANO, [DESC], MEDICINE, DOSE, UOM, STATUS, EXECUTIONDATE, CREATEDDATE, CREATEDBY) VALUES (@PETID, @EUTHANASIANO, @DESC, @MEDICINE, @DOSE, @UOM, @STATUS, @EXECUTIONDATE, @CREATEDDATE, @CREATEDBY)";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                //step 5.1 : pass in parameter to the sql 
                cmd.Parameters.AddWithValue("@PETID", petId);
                cmd.Parameters.AddWithValue("@EUTHANASIANO", euthNo);
                cmd.Parameters.AddWithValue("@DESC", description);
                cmd.Parameters.AddWithValue("@MEDICINE", medicine);
                cmd.Parameters.AddWithValue("@DOSE", dose);
                cmd.Parameters.AddWithValue("@UOM", uom);
                cmd.Parameters.AddWithValue("@STATUS", status);
                cmd.Parameters.AddWithValue("@EXECUTIONDATE", executionDate);
                cmd.Parameters.AddWithValue("@CREATEDDATE", createdDate);
                if (!string.IsNullOrEmpty(Session["username"] as string)) //if session is not null
                {
                    cmd.Parameters.AddWithValue("@CREATEDBY", Session["username"].ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CREATEDBY", "");
                }


                //if euth status = "Completed", pet status is updated to "Euthanasia"
                if (status == "Completed")
                {
                    updatePetStatus(petId);
                }

                con.Open();
                cmd.ExecuteNonQuery(); 
                con.Close();
                Response.Redirect("BO_EuthanasiaSummary.aspx");

            }
        }

        protected void ddl_PetNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [PETNO], [NAME], [AGE], [SIZE], [GENDER], [BREED], [TYPE], [IMAGE], [DESC] FROM [PET] WHERE ([PETID] = @PETNO)";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            //step 5.1 : pass in the parameter (@Id in sql) to the sql cmd
            cmd.Parameters.AddWithValue("@PETNO", ddl_PetNo.SelectedItem.Value);

            con.Open();

            //step 7 : run sql cmd
            PetDetailsView.DataSource = cmd.ExecuteReader();
            PetDetailsView.DataBind();

            //step 8 : close connection 
            con.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_EuthanasiaSummary.aspx");
        }
    }
}