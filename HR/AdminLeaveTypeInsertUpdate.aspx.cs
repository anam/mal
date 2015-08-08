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

public partial class AdminLeaveTypeInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["leaveTypeID"] != null)
            {
                int leaveTypeID = Int32.Parse(Request.QueryString["leaveTypeID"]);
                if (leaveTypeID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLeaveTypeData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LeaveType leaveType = new LeaveType();

        leaveType.LeaveName = txtLeaveName.Text;
        int resutl = LeaveTypeManager.InsertLeaveType(leaveType);
        Response.Redirect("AdminLeaveTypeDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        LeaveType leaveType = new LeaveType();
        leaveType = LeaveTypeManager.GetLeaveTypeByID(Int32.Parse(Request.QueryString["leaveTypeID"]));
        LeaveType tempLeaveType = new LeaveType();
        tempLeaveType.LeaveTypeID = leaveType.LeaveTypeID;

        tempLeaveType.LeaveName = txtLeaveName.Text;
        bool result = LeaveTypeManager.UpdateLeaveType(tempLeaveType);
        Response.Redirect("AdminLeaveTypeDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtLeaveName.Text = "";
    }
    private void showLeaveTypeData()
    {
        LeaveType leaveType = new LeaveType();
        leaveType = LeaveTypeManager.GetLeaveTypeByID(Int32.Parse(Request.QueryString["leaveTypeID"]));

        txtLeaveName.Text = leaveType.LeaveName;
    }
}
