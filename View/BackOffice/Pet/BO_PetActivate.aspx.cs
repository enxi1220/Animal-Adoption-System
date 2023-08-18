using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
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
    public partial class BO_PetActivate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] as string != Constant.getUserRole(Constant.UserRoleEnum.Admin))
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyAdmin(" + "\"" + "/View/BackOffice/Pet/BO_PetSummary.aspx" + "\"" + ");", true);
            }

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
                    petAgeTxt.Text = pet.AGE;
                    petSizeTxt.Text = pet.SIZE;
                    petBreedTxt.Text = pet.BREED;
                    petTypeTxt.Text = pet.TYPE;
                    petImg.ImageUrl = pet.IMAGE;
                    auditPeriodTxt.Text = pet.AUDITPERIOD.ToString();
                    ownerTxt.Text = pet.OWNER;
                    adoptionTimeTxt.Text = pet.ADOPTIONTIME.ToString();
                    statusTxt.Text = pet.STATUS;
                    petGender.Text = pet.GENDER;
                    petSizeTxt.Text = pet.SIZE;
                }
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            BusinessLogicExecutor.Execute<BLActivatePet, PET>(new PET()
            {
                PETID = int.Parse(Request.QueryString["petId"]),
                UPDATEDBY = Session["username"].ToString()
            });

            Response.Redirect("BO_PetSummary.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("BO_PetSummary.aspx");
        }
    }
}