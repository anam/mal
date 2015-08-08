using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class AdminDisplayUSER_Module : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            USER_ModuleManager.LoadUSER_ModulePage(gvUSER_Module, rptPager, 1, ddlPageSize);
        }
    }

    protected void gvUSER_Module_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblRowStatusID = (Label)e.Row.FindControl("lblRowStatusID");
                if (Convert.ToInt32(lblRowStatusID.Text) == 1)
                    lblRowStatusID.Text = "Active";
                else
                    lblRowStatusID.Text = "Deleted";
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        USER_ModuleManager.LoadUSER_ModulePage(gvUSER_Module, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        USER_ModuleManager.LoadUSER_ModulePage(gvUSER_Module, rptPager, pageIndex, ddlPageSize);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminUSER_Module.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminUSER_Module.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = USER_ModuleManager.DeleteUSER_Module(Convert.ToInt32(linkButton.CommandArgument));
        USER_ModuleManager.LoadUSER_ModulePage(gvUSER_Module, rptPager, 1, ddlPageSize);
    }
}

