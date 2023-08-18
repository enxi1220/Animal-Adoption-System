using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//step 1 : import library

using System.Data.SqlClient;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption;

namespace AnimalAdoptionSystem.View.BackOffice.Adoption
{
    public partial class BO_AdoptionSummary1 : System.Web.UI.Page
    {
        //Step 2 : get connection string from Global.asax
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            adoptionGV.DataSource = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(new ADOPTION());
            adoptionGV.DataBind();
        }

        protected void searchEv(object sender, EventArgs e)
        {
            adoptionGV.DataSource = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(new ADOPTION() { ADOPTIONNO = searchTxt.Text });
            adoptionGV.DataBind();
        }

        protected void searchTxt_TextChanged(object sender, EventArgs e)
        {
            adoptionGV.DataSource = BusinessLogicExecutor.Execute<BLGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(new ADOPTION() { ADOPTIONNO = searchTxt.Text });
            adoptionGV.DataBind();
        }
    }
}