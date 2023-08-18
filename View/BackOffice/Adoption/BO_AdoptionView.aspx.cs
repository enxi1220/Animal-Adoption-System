using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.BackOffice.Adoption
{
    public partial class BO_AdoptionView2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["adoptionId"]))
                {
                    int adoptionId = int.Parse(Request.QueryString["adoptionId"]);
                    ADOPTION adoption = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(new ADOPTION() { ADOPTIONID = adoptionId }).FirstOrDefault();

                    //bind data
                    txtAdoptionNo.Text = adoption.ADOPTIONNO;
                    txtUsername.Text = adoption.USERNAME;
                    txtStatus.Text = adoption.STATUS;
                    txtRejectReason.Text = adoption.REASONOFREJECTION;
                    txtCustomerName.Text = adoption.CUSTOMERNAME;
                    txtCustomerPhone.Text = adoption.PHONE;
                    imgIC.ImageUrl = adoption.ICIMAGE;
                    lblBreed.Text = adoption.BREED;
                    lblPetNo.Text = adoption.PETNO;
                    lblPetName.Text = adoption.NAME;
                    lblAge.Text = adoption.AGE;
                    lblGender.Text = adoption.GENDER;
                    lblSize.Text = adoption.SIZE;
                    lblDesc.Text = adoption.DESC;
                    lblType.Text = adoption.TYPE;
                }
            }
        }
    }
}