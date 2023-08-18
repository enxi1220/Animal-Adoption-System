using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
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
    public partial class FO_AdoptionView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("~/View/FrontOffice/Customer/FO_CustSignIn.aspx?url=" + Request.RawUrl);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["adoptionId"]))
                {
                    int adoptionId = int.Parse(Request.QueryString["adoptionId"]);
                    ADOPTION adoption = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(new ADOPTION() { ADOPTIONID = adoptionId }).FirstOrDefault();

                    //bind data
                    lblAdoptionNo.Text = adoption.ADOPTIONNO;
                    lblBreed.Text = adoption.BREED;
                    imgPet.ImageUrl = adoption.IMAGE;
                    lblName.Text = adoption.NAME;
                    lblAge.Text = adoption.AGE;
                    lblGender.Text = adoption.GENDER;
                    lblSize.Text = adoption.SIZE;
                    lblDesc.Text = adoption.DESC;
                    lblType.Text = adoption.TYPE;
                    lblRejctReason.Text = adoption.REASONOFREJECTION;
                    lblStatus.Text = adoption.STATUS;

                    if (string.IsNullOrEmpty(lblRejctReason.Text))
                    {
                        labelRejctReason.Visible = false;
                    }


                    btnCancel.Visible = false;

                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int adoptionId = int.Parse(Request.QueryString["adoptionId"]);
            BusinessLogicExecutor.Execute<BLCancelAdoption, ADOPTION>(new ADOPTION()
            {
                ADOPTIONID = adoptionId,
                UPDATEDBY = Session["username"].ToString()
            });
            Response.Redirect("FO_AdoptionSummary.aspx");
        }
    }
}