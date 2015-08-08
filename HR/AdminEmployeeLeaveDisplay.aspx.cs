using System;
using System.Collections;
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

public partial class AdminEmployeeLeaveDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showEmployeeLeaveGrid();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminEmployeeLeaveInsertUpdate.aspx?employeeLeaveID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminEmployeeLeaveInsertUpdate.aspx?employeeLeaveID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = EmployeeLeaveManager.DeleteEmployeeLeave(Convert.ToInt32(linkButton.CommandArgument));
        showEmployeeLeaveGrid();
    }

    private void showEmployeeLeaveGrid()
    {
        gvEmployeeLeave.DataSource = EmployeeLeaveManager.GetAllEmployeeLeaves();
        gvEmployeeLeave.DataBind();
    }
}
