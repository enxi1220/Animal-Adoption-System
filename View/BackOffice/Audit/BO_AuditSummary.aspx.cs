using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAudit;
using AnimalAdoptionSystem.DataAccess.DataAccessAudit;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalAdoptionSystem.View.BackOffice.Audit
{
    public partial class BO_AuditSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = BusinessLogicExecutor.Execute<BLGetAudit, AUDIT, IEnumerable<AUDIT>>(new AUDIT());
                GridView1.DataBind();
            }
        }

        protected void searchEv(object sender, EventArgs e)
        {
            GridView1.DataSource = BusinessLogicExecutor.Execute<BLGetAudit, AUDIT, IEnumerable<AUDIT>>(new AUDIT() { AUDITNO = searchTxt.Text });
            GridView1.DataBind();
        }

        protected void searchTxt_TextChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = BusinessLogicExecutor.Execute<BLGetAudit, AUDIT, IEnumerable<AUDIT>>(new AUDIT() { AUDITNO = searchTxt.Text });
            GridView1.DataBind();
        }
    }
}