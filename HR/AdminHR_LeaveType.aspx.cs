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
public partial class AdminHR_EmployerType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadHR_EmployerTypeData();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_EmployerTypeData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LeaveType leaveType = new LeaveType();

        leaveType.LeaveName = txtEmployerTypeName.Text;
        int resutl = LeaveTypeManager.InsertLeaveType(leaveType);
        Response.Redirect("AdminDisplayHR_LeaveType.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        LeaveType leaveType = new LeaveType();
        leaveType = LeaveTypeManager.GetLeaveTypeByID(int.Parse(Request.QueryString["ID"].ToString()));
        LeaveType tempLeaveType = new LeaveType();
        tempLeaveType.LeaveTypeID = leaveType.LeaveTypeID;

        tempLeaveType.LeaveName = txtEmployerTypeName.Text;
        bool result = LeaveTypeManager.UpdateLeaveType(tempLeaveType);


        Response.Redirect("AdminDisplayHR_LeaveType.aspx");
    }

    private void showHR_EmployerTypeData()
    {
        LeaveType leaveType = new LeaveType();
        leaveType = LeaveTypeManager.GetLeaveTypeByID(Int32.Parse(Request.QueryString["ID"]));

        txtEmployerTypeName.Text = leaveType.LeaveName;
    }
}

