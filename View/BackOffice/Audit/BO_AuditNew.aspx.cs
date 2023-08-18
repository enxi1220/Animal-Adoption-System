using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAudit;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet;
using AnimalAdoptionSystem.DataAccess.DataAccessAudit;
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

namespace AnimalAdoptionSystem.View.BackOffice.Audit
{
    public partial class BO_AuditNew : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<PET> pets = BusinessLogicExecutor.Execute<BLGetPet, PET, IEnumerable<PET>>(new PET(), DAGetPet.GetPetWithOwner);
                var petList = new ListItemCollection();
                petList.AddRange(pets.Select(x => new ListItem(x.PETNO + "  " + x.NAME,
                                                               x.PETID.ToString()))
                                                                .ToArray());
                ddlPetNo.DataSource = petList;
                ddlPetNo.DataValueField = "Value";
                ddlPetNo.DataTextField = "Text";
                ddlPetNo.DataBind();

                var conditionList = Enum.GetValues(typeof(Helper.Constant.AuditConditionEnum));
                ddlCondition.DataSource = conditionList;
                ddlCondition.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AUDIT audit = new AUDIT();
                audit.PETID = int.Parse(ddlPetNo.SelectedItem.Value);
                audit.BOOKINGTIME = string.IsNullOrEmpty(dtBookingTime.Text) ? audit.BOOKINGTIME : Converter.DateTimeConverter(dtBookingTime.Text);
                audit.STARTTIME = string.IsNullOrEmpty(dtStartingTime.Text) ? audit.STARTTIME : Converter.DateTimeConverter(dtStartingTime.Text);
                audit.COMPLETIONTIME = string.IsNullOrEmpty(dtCompletionTime.Text) ? audit.COMPLETIONTIME : Converter.DateTimeConverter(dtCompletionTime.Text);
                audit.DESC = string.IsNullOrEmpty(txtDescription.Text) ? default(string) : txtDescription.Text;
                audit.CONDITION = string.IsNullOrEmpty(ddlCondition.SelectedValue) ? default(string) : ddlCondition.SelectedValue;
                audit.CREATEDBY = Session["username"].ToString();
                BusinessLogicExecutor.Execute<BLAddAudit, AUDIT>(audit, DAGetAudit.GetMaxId);

                Response.Redirect("BO_AuditSummary.aspx");
            }
        }

        protected void dtCompletionTime_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dtCompletionTime.Text))
            {
                bookingTimeRequiredFieldValidator.Enabled = 
                startingTimeRequiredFieldValidator.Enabled = 
                conditionRequiredFieldValidator.Enabled = true;
            }else
            {
                bookingTimeRequiredFieldValidator.Enabled =
                startingTimeRequiredFieldValidator.Enabled =
                conditionRequiredFieldValidator.Enabled = false;
            }

        }

        protected void dtStartingTime_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dtStartingTime.Text))
            {
                bookingTimeRequiredFieldValidator.Enabled = true;
            }
            else
            {
                bookingTimeRequiredFieldValidator.Enabled = false;
            }
        }
    }
}