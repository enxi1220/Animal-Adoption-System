using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;
using AnimalAdoptionSystem.Helper;

namespace AnimalAdoptionSystem.View.BackOffice.Adoption
{
    public partial class BO_AdoptionApproval1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] as string != Constant.getUserRole(Constant.UserRoleEnum.Admin))
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:onlyAdmin(" + "\"" + "/View/BackOffice/Adoption/BO_AdoptionSummary.aspx" + "\"" + ");", true);
            }

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

                    if (adoption.STATUS == Constant.getAdoptStatus(Constant.AdoptStatusEnum.New))
                    {
                        btnApprove.Enabled = true;
                        btnReject.Enabled = true;
                    }
                    else if (adoption.STATUS == Constant.getAdoptStatus(Constant.AdoptStatusEnum.Rejected))
                    {
                        btnApprove.Enabled = true;
                    }
                }

            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ddl_RejectReason.Visible = true;
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLogicExecutor.Execute<BLApproveAdoption, ADOPTION>(new ADOPTION()
                {
                    ADOPTIONID = int.Parse(Request.QueryString["adoptionId"]),
                    UPDATEDBY = Session["username"].ToString()
                });
                Response.Redirect("BO_AdoptionSummary.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "fail(" + "\"" + ex.Message + "\"" + "," + "\"" + "/View/BackOffice/Adoption/BO_AdoptionSummary.aspx" + "\"" + ");", true);
            }
        }

        protected void ddl_RejectReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BusinessLogicExecutor.Execute<BLRejectAdoption, ADOPTION>(new ADOPTION()
                {
                    ADOPTIONID = int.Parse(Request.QueryString["adoptionId"]),
                    REASONOFREJECTION = ddl_RejectReason.SelectedValue,
                    UPDATEDBY = Session["username"].ToString()
                });
                Response.Redirect("BO_AdoptionSummary.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "fail(" + "\"" + ex.Message + "\"" + "," + "\"" + "/View/BackOffice/Adoption/BO_AdoptionSummary.aspx" + "\"" + ");", true);
            }
        }
    }
}