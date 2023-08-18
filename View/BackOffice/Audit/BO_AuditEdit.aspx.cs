using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAudit;
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
    public partial class BO_AuditEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["auditId"]))
                {
                    int auditId = int.Parse(Request.QueryString["auditId"]);
                    AUDIT audit = BusinessLogicExecutor.Execute<BLGetAudit, AUDIT, IEnumerable<AUDIT>>(new AUDIT() { AUDITID = auditId })
                                                       .First();
                    //bind data
                    txtAuditNo.Text = audit.AUDITNO;
                    txtPetNo.Text = audit.PETNO;
                    txtDescription.Text = audit.DESC;
                    ddlCondition.SelectedValue = audit.CONDITION;
                    txtStatus.Text = audit.STATUS;
                    var conditionList = Enum.GetValues(typeof(Constant.AuditConditionEnum));
                    ddlCondition.DataSource = conditionList;
                    ddlCondition.DataBind();
                    DateTime bookingTime = new DateTime();
                    DateTime startTime = new DateTime();
                    DateTime completionTime = new DateTime();
                    if (audit.BOOKINGTIME.HasValue)
                    {
                        bookingTime = (DateTime)audit.BOOKINGTIME;
                        dtBookingTime.Text = bookingTime.ToString("mm/dd/yyyy hh:mm tt");
                    }
                    if (audit.STARTTIME.HasValue)
                    {
                        startTime = (DateTime)audit.STARTTIME;
                        dtStartingTime.Text = startTime.ToString("mm/dd/yyyy hh:mm tt");
                    }
                    if (audit.COMPLETIONTIME.HasValue)
                    {
                        completionTime = (DateTime)audit.COMPLETIONTIME;
                        dtCompletionTime.Text = completionTime.ToString("mm/dd/yyyy hh:mm tt");
                    }
                    

                    if(audit.STATUS == Constant.getAuditStatus(Constant.AuditStatusEnum.Completed))
                    {
                        btnSave.Enabled = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AUDIT audit = new AUDIT();
                audit.AUDITID = int.Parse(Request.QueryString["auditId"]);
                audit.BOOKINGTIME = string.IsNullOrEmpty(dtBookingTime.Text) ? audit.BOOKINGTIME : Converter.DateTimeConverter(dtBookingTime.Text);
                audit.STARTTIME = string.IsNullOrEmpty(dtStartingTime.Text) ? audit.STARTTIME : Converter.DateTimeConverter(dtStartingTime.Text);
                audit.COMPLETIONTIME = string.IsNullOrEmpty(dtCompletionTime.Text) ? audit.COMPLETIONTIME : Converter.DateTimeConverter(dtCompletionTime.Text);
                audit.DESC = string.IsNullOrEmpty(txtDescription.Text) ? default(string) : txtDescription.Text;
                audit.CONDITION = string.IsNullOrEmpty(ddlCondition.SelectedValue) ? default(string) : ddlCondition.SelectedValue;
                audit.UPDATEDBY = Session["username"].ToString();
                BusinessLogicExecutor.Execute<BLEditAudit, AUDIT>(audit);

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
            }
        }

        protected void dtStartingTime_TextChanged(object sender, EventArgs e)
        {
            bookingTimeRequiredFieldValidator.Enabled = string.IsNullOrEmpty(dtStartingTime.Text) ? false : true;
        }

        protected void dtBookingTime_TextChanged(object sender, EventArgs e)
        {
            bookingTimeRequiredFieldValidator.Enabled = string.IsNullOrEmpty(dtStartingTime.Text)? false: true;
        }
    }
}