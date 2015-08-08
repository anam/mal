using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoleManagement_AdminRoleWiseModuleDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showRoleWiseModuleGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminRoleWiseModuleInsertUpdate.aspx?roleWiseModuleID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminRoleWiseModuleInsertUpdate.aspx?roleWiseModuleID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = RoleWiseModuleManager.DeleteRoleWiseModule(Convert.ToInt32(linkButton.CommandArgument));
        showRoleWiseModuleGrid();
    }

    private void showRoleWiseModuleGrid()
    {
        gvRoleWiseModule.DataSource = RoleWiseModuleManager.GetAllRoleWiseModules();
        gvRoleWiseModule.DataBind();
    }
}