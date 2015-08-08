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


public partial class AdminDisplayHR_EmployerType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showLeaveTypeGrid();
        }
    }
    
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminHR_LeaveType.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = LeaveTypeManager.DeleteLeaveType(Convert.ToInt32(linkButton.CommandArgument));
        showLeaveTypeGrid();
    }

    private void showLeaveTypeGrid()
    {
        gvLeaveType.DataSource = LeaveTypeManager.GetAllLeaveTypes();
        gvLeaveType.DataBind();
    }

    protected void btnAddEmployeeType_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_LeaveType.aspx");
    }
}

