using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Executors;
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

    public partial class BO_PetNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sizeList = Enum.GetValues(typeof(Helper.Constant.PetSizeEnum));
            ddlSize.DataSource = sizeList;
            ddlSize.DataBind();

            var ageList = Enum.GetValues(typeof(Helper.Constant.PetAgeEnum));
            ddlAge.DataSource = ageList;
            ddlAge.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //save img with new name
            string imgName = UniqueNoGenerator.imgUniqueName(petImageFile.FileName);
            petImageFile.SaveAs(Server.MapPath("~/Images/Uploads/" + imgName));

            BusinessLogicExecutor.Execute<BLAddPet, PET>(new PET()
            {
                NAME = petNameTxt.Text,
                DESC = descriptionTxt.Text,
                AGE = string.IsNullOrEmpty(ddlAge.SelectedValue) ? default(string) : ddlAge.SelectedValue,
                SIZE = string.IsNullOrEmpty(ddlSize.SelectedValue) ? default(string) : ddlSize.SelectedValue,
                BREED = petBreedTxt.Text,
                TYPE = petTypeTxt.Text,
                GENDER = string.IsNullOrEmpty(petGender.SelectedValue) ? default(string) : petGender.SelectedValue,
                AUDITPERIOD = int.Parse(auditPeriodTxt.Text),
                IMAGE = "~/Images/Uploads/" + imgName,
                CREATEDBY = Session["username"].ToString()

            }, DAGetPet.GetMaxId); ;

            Response.Redirect("BO_PetSummary.aspx");


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_PetSummary.aspx");
        }
    }
}