using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;

namespace AnimalAdoptionSystem.View.BackOffice.Customer
{
    public partial class BO_CustomerSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BO_gvCust.DataSource = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>(
                new CUSTOMER(), DAGetCust.GetAllCustomer);
            BO_gvCust.DataBind();
        }

        protected void searchEv(object sender, EventArgs e)
        {
            BO_gvCust.DataSource = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>(new CUSTOMER() { USERNAME = searchTxt.Text });
            BO_gvCust.DataBind();
        }

        protected void searchTxt_TextChanged(object sender, EventArgs e)
        {
            BO_gvCust.DataSource = BusinessLogicExecutor.Execute<BLGetCust, CUSTOMER, IEnumerable<CUSTOMER>>(new CUSTOMER() { USERNAME = searchTxt.Text });
            BO_gvCust.DataBind();
        }
    }
}