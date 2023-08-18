using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.BackOffice.Pet
{
    public partial class BO_PetEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["petId"]))
                {
                    int petId = int.Parse(Request.QueryString["petId"]);
                    PET pet = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET() { PETID = petId })
                                                       .First();
                    //bind data
                    petNoTxt.Text = pet.PETNO;
                    petNameTxt.Text = pet.NAME;
                    descriptionTxt.Text = pet.DESC;
                    ddlAge.SelectedValue = pet.AGE;
                    ddlSize.SelectedValue = pet.SIZE;
                    var sizeList = Enum.GetValues(typeof(Constant.PetSizeEnum));
                    ddlSize.DataSource = sizeList;
                    ddlSize.DataBind();

                    var ageList = Enum.GetValues(typeof(Constant.PetAgeEnum));
                    ddlAge.DataSource = ageList;
                    ddlAge.DataBind();
                    petBreedTxt.Text = pet.BREED;
                    petTypeTxt.Text = pet.TYPE;
                    auditPeriodTxt.Text = pet.AUDITPERIOD.ToString();
                    ownerTxt.Text = pet.OWNER;
                    adoptionTimeTxt.Text = pet.ADOPTIONTIME.ToString();
                    petGender.SelectedValue = pet.GENDER;
                    statusTxt.Text = pet.STATUS;
                    petImgEdit.ImageUrl = pet.IMAGE;
                }
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int petId = int.Parse(Request.QueryString["petId"]);
            //save img with new name
            string image = "";
            if (!string.IsNullOrEmpty(petImageFile.FileName))
            {
                string imgName = UniqueNoGenerator.imgUniqueName(petImageFile.FileName);
                image = "~/Images/Uploads/" + imgName;
                petImageFile.SaveAs(Server.MapPath("~/Images/Uploads/" + imgName));
            }
            else
            {
                image = petImgEdit.ImageUrl;
            }
            try
            {
                BusinessLogicExecutor.Execute<BLEditPet, PET>(new PET()
                {
                    PETID = int.Parse(Request.QueryString["petId"]),
                    NAME = petNameTxt.Text,
                    DESC = descriptionTxt.Text,
                    AGE = string.IsNullOrEmpty(ddlAge.SelectedValue) ? default(string) : ddlAge.SelectedValue,
                    SIZE = string.IsNullOrEmpty(ddlSize.SelectedValue) ? default(string) : ddlSize.SelectedValue,
                    BREED = petBreedTxt.Text,
                    TYPE = petTypeTxt.Text,
                    GENDER = string.IsNullOrEmpty(petGender.SelectedValue) ? default(string) : petGender.SelectedValue,
                    STATUS = statusTxt.Text,
                    IMAGE = image,
                    UPDATEDBY = Session["username"].ToString()

                }, DAGetPet.GetMaxId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "fail('" + ex.Message + "');", true);
            }
            Response.Redirect("BO_PetSummary.aspx");


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_PetSummary.aspx");
        }
    }
}