using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.FrontOffice.Adoption
{
    public partial class FO_AdoptionNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx?url=" + Request.RawUrl);
            }
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["petId"]))
                {
                    int petId = int.Parse(Request.QueryString["petId"]);
                    PET pet = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET() { PETID = petId }).First();

                    //bind data
                    lblBreed.Text = pet.BREED;
                    imgPet.ImageUrl = pet.IMAGE;
                    lblName.Text = pet.NAME;
                    lblAge.Text = pet.AGE;
                    if (pet.GENDER == "F")
                    {
                        lblGender.Text = "Female";
                    }
                    else
                    {
                        lblGender.Text = "Male";
                    }

                    lblSize.Text = pet.SIZE;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                int petId = int.Parse(Request.QueryString["petId"]);
                //save img with new name
                string imgName = UniqueNoGenerator.imgUniqueName(imgIC.FileName);
                imgIC.SaveAs(Server.MapPath("~/Images/Uploads/" + imgName));
                try
                {
                    BusinessLogicExecutor.Execute<BLAddAdoption, ADOPTION>(new ADOPTION()
                    {
                        CUSTOMERNAME = txtCustomerName.Text,
                        PHONE = txtCustomerPhone.Text,
                        ICIMAGE = "~/Images/Uploads/" + imgName,
                        PETID = petId,
                        USERNAME = Session["username"].ToString(),
                        CREATEDBY = Session["username"].ToString()
                    }, DAGetAdoption.GetMaxId);
                    Response.Redirect("~/View/FrontOffice/Pet/FO_PetSummary.aspx");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "fail(" + "\"" + ex.Message + "\"" + "," + "\"" + "/View/BackOffice/Adoption/BO_AdoptionSummary.aspx" + "\"" + ");", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/FrontOffice/Pet/FO_PetSummary.aspx");
        }
    }
}