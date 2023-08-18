using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.DataAccess.DataAccessPet;

namespace AnimalAdoptionSystem.View.FrontOffice.Pet
{
    public partial class FO_PetSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                allPetBtn_Click(sender, e);
            }
        }

        protected void allPetBtn_Click(object sender, EventArgs e)
        {
            getPetByStatus(Constant.getPetStatus(Constant.PetStatusEnum.New));

            allPetBtn.CssClass = "nav-link active mt-3 mb-0";
            kidPetBtn.CssClass = "nav-link mt-3 mb-0";
            adultPetBtn.CssClass = "nav-link mt-3 mb-0";
            smallPetBtn.CssClass = "nav-link mt-3 mb-0";
            bigPetBtn.CssClass = "nav-link mt-3 mb-0";
        }

        protected void getPetByStatus(string status)
        {
            DataList1.DataSource = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET()
            {
                STATUS = status
            }, DAGetPet.GetStatuses);
            DataList1.DataBind();
        }
        
        protected void getPetByAge(string age)
        {
            DataList1.DataSource = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET()
            {
                AGE = age,
                STATUS = Constant.getPetStatus(Constant.PetStatusEnum.New)
            }, DAGetPet.GetByAge);
            DataList1.DataBind();
        }
        
        protected void getPetBySize(string size)
        {
            DataList1.DataSource = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET()
            {
                SIZE = size,
                STATUS = Constant.getPetStatus(Constant.PetStatusEnum.New)
            }, DAGetPet.GetBySize);
            DataList1.DataBind();
        }

        

        protected void kidPetBtn_Click(object sender, EventArgs e)
        {
            getPetByAge(Constant.getPetAge(Constant.PetAgeEnum.Kid));

            allPetBtn.CssClass = "nav-link mt-3 mb-0";
            kidPetBtn.CssClass = "nav-link active mt-3 mb-0";
            adultPetBtn.CssClass = "nav-link mt-3 mb-0";
            smallPetBtn.CssClass = "nav-link mt-3 mb-0";
            bigPetBtn.CssClass = "nav-link mt-3 mb-0";
        }

        protected void adultPetBtn_Click(object sender, EventArgs e)
        {

            getPetByAge(Constant.getPetAge(Constant.PetAgeEnum.Adult));

            allPetBtn.CssClass = "nav-link mt-3 mb-0";
            kidPetBtn.CssClass = "nav-link mt-3 mb-0";
            adultPetBtn.CssClass = "nav-link active mt-3 mb-0";
            smallPetBtn.CssClass = "nav-link mt-3 mb-0";
            bigPetBtn.CssClass = "nav-link mt-3 mb-0";
        }

        protected void smallPetBtn_Click(object sender, EventArgs e)
        {
            getPetBySize(Constant.getPetSize(Constant.PetSizeEnum.Small));
            allPetBtn.CssClass = "nav-link mt-3 mb-0";
            kidPetBtn.CssClass = "nav-link mt-3 mb-0";
            adultPetBtn.CssClass = "nav-link mt-3 mb-0";
            smallPetBtn.CssClass = "nav-link active mt-3 mb-0";
            bigPetBtn.CssClass = "nav-link mt-3 mb-0";
        }

        protected void bigPetBtn_Click(object sender, EventArgs e)
        {
            getPetBySize(Constant.getPetSize(Constant.PetSizeEnum.Big));
            allPetBtn.CssClass = "nav-link mt-3 mb-0";
            kidPetBtn.CssClass = "nav-link mt-3 mb-0";
            adultPetBtn.CssClass = "nav-link mt-3 mb-0";
            smallPetBtn.CssClass = "nav-link mt-3 mb-0";
            bigPetBtn.CssClass = "nav-link active mt-3 mb-0";
        }
    }
}