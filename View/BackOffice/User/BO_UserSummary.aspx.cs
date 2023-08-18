using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using AnimalAdoptionSystem.Helper;

namespace AnimalAdoptionSystem.View.BackOffice.User
{
    public partial class BO_UserSummary : System.Web.UI.Page
    {
        string cs = Global.CS;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT [USERID], [NAME], [USERNAME], [PHONE], [STATUS], [USERGROUPNAME], [MAIL], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY] FROM [USER]";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            BO_gvUser.DataSource = cmd.ExecuteReader();
            BO_gvUser.DataBind();
            con.Close();
        }

        //to make activate & deactivate btn invisible if it is staff
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["role"] as string)) //IF SESSION IS NOT NULL
            {//if is staff
                if (Session["role"].ToString().Equals(Constant.getUserRole(Constant.UserRoleEnum.Staff)))
                {
                    HyperLink activateHyperLink;
                    HyperLink deactivateHyperLink;

                    System.Data.Common.DbDataRecord objData = (System.Data.Common.DbDataRecord)e.Row.DataItem;

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        activateHyperLink = (HyperLink)e.Row.FindControl("activateHyperLink");  //Gets the HyperLink
                        deactivateHyperLink = (HyperLink)e.Row.FindControl("deactivateHyperLink");  //Gets the HyperLink
                        
                        //if is staff, make the btn invisible
                        activateHyperLink.Visible = false;
                        deactivateHyperLink.Visible = false;
                        myHyperLink.Visible = false;  
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:unauthorized(" + "View/FrontOffice/Customer/FO_CustSignIn.aspx" + ");", true);
            }
        }

        protected void searchEv(object sender, EventArgs e)
        {

            string sql = "SELECT [USERID], [NAME], [USERNAME], [PHONE], [STATUS], [USERGROUPNAME], [MAIL], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY] FROM [USER] WHERE NAME LIKE @keyword OR USERNAME LIKE @keyword OR PHONE LIKE @keyword OR STATUS LIKE @keyword OR USERGROUPNAME LIKE @keyword OR MAIL LIKE @keyword ";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@keyword", searchTxt.Text);

            con.Open();
            BO_gvUser.DataSource = cmd.ExecuteReader();
            BO_gvUser.DataBind();
            con.Close();
        }

        protected void searchTxt_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT [USERID], [NAME], [USERNAME], [PHONE], [STATUS], [USERGROUPNAME], [MAIL], [CREATEDDATE], [CREATEDBY], [UPDATEDDATE], [UPDATEDBY] FROM [USER] WHERE NAME LIKE @keyword OR USERNAME LIKE @keyword OR PHONE LIKE @keyword OR STATUS LIKE @keyword OR USERGROUPNAME LIKE @keyword OR MAIL LIKE @keyword ";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@keyword", searchTxt.Text);

            con.Open();
            BO_gvUser.DataSource = cmd.ExecuteReader();
            BO_gvUser.DataBind();
            con.Close();
        }
    }
}