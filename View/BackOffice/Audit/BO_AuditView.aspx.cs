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
    public partial class BO_AuditView : System.Web.UI.Page
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
                    txtCondition.Text = audit.CONDITION;
                    txtStatus.Text = audit.STATUS;
                    DateTime bookingTime = new DateTime();
                    DateTime startTime = new DateTime();
                    DateTime completionTime = new DateTime();
                    if (audit.BOOKINGTIME.HasValue)
                    {
                        bookingTime = (DateTime)audit.BOOKINGTIME;
                        txtBookingTime.Text = bookingTime.ToString("mm/dd/yyyy hh:mm tt");
                    }
                    if (audit.STARTTIME.HasValue)
                    {
                        startTime = (DateTime)audit.STARTTIME;
                        txtStartingTime.Text = startTime.ToString("mm/dd/yyyy hh:mm tt");
                    }
                    if (audit.COMPLETIONTIME.HasValue)
                    {
                        completionTime = (DateTime)audit.COMPLETIONTIME;
                        txtCompletionTime.Text = completionTime.ToString("mm/dd/yyyy hh:mm tt");
                    }
                }

            }
        }
    }
}