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

public partial class AdminEmployeeLeaveInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadEmployee();
            loadLeaveType();
            loadRowStatus();
            if (Request.QueryString["employeeLeaveID"] != null)
            {
                int employeeLeaveID = Int32.Parse(Request.QueryString["employeeLeaveID"]);
                if (employeeLeaveID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showEmployeeLeaveData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        EmployeeLeave employeeLeave = new EmployeeLeave();

        employeeLeave.EmployeeID = Int32.Parse(ddlEmployee.SelectedValue);
        employeeLeave.LeaveDate = txtLeaveDate.Text;
        employeeLeave.LeaveTypeID = Int32.Parse(ddlLeaveType.SelectedValue);
        employeeLeave.AddedBy = txtAddedBy.Text;
        employeeLeave.AddedDate = DateTime.Now;
        employeeLeave.UpdatedBy = txtUpdatedBy.Text;
        employeeLeave.UpdateDate = txtUpdateDate.Text;
        employeeLeave.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        int resutl = EmployeeLeaveManager.InsertEmployeeLeave(employeeLeave);
        Response.Redirect("AdminEmployeeLeaveDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        EmployeeLeave employeeLeave = new EmployeeLeave();
        employeeLeave = EmployeeLeaveManager.GetEmployeeLeaveByID(Int32.Parse(Request.QueryString["employeeLeaveID"]));
        EmployeeLeave tempEmployeeLeave = new EmployeeLeave();
        tempEmployeeLeave.EmployeeLeaveID = employeeLeave.EmployeeLeaveID;

        tempEmployeeLeave.EmployeeID = Int32.Parse(ddlEmployee.SelectedValue);
        tempEmployeeLeave.LeaveDate = txtLeaveDate.Text;
        tempEmployeeLeave.LeaveTypeID = Int32.Parse(ddlLeaveType.SelectedValue);
        tempEmployeeLeave.AddedBy = txtAddedBy.Text;
        tempEmployeeLeave.AddedDate = DateTime.Now;
        tempEmployeeLeave.UpdatedBy = txtUpdatedBy.Text;
        tempEmployeeLeave.UpdateDate = txtUpdateDate.Text;
        tempEmployeeLeave.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        bool result = EmployeeLeaveManager.UpdateEmployeeLeave(tempEmployeeLeave);
        Response.Redirect("AdminEmployeeLeaveDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlEmployee.SelectedIndex = 0;
        txtLeaveDate.Text = "";
        ddlLeaveType.SelectedIndex = 0;
        txtAddedBy.Text = "";
        txtUpdatedBy.Text = "";
        txtUpdateDate.Text = "";
        ddlRowStatus.SelectedIndex = 0;
    }
    private void showEmployeeLeaveData()
    {
        EmployeeLeave employeeLeave = new EmployeeLeave();
        employeeLeave = EmployeeLeaveManager.GetEmployeeLeaveByID(Int32.Parse(Request.QueryString["employeeLeaveID"]));

        ddlEmployee.SelectedValue = employeeLeave.EmployeeID.ToString();
        txtLeaveDate.Text = employeeLeave.LeaveDate;
        ddlLeaveType.SelectedValue = employeeLeave.LeaveTypeID.ToString();
        txtAddedBy.Text = employeeLeave.AddedBy;
        txtUpdatedBy.Text = employeeLeave.UpdatedBy;
        txtUpdateDate.Text = employeeLeave.UpdateDate;
        ddlRowStatus.SelectedValue = employeeLeave.RowStatusID.ToString();
    }
    private void loadEmployee()
    {
        ListItem li = new ListItem("Select Employee...", "0");
        ddlEmployee.Items.Add(li);

        List<Employee> employees = new List<Employee>();
        employees = EmployeeManager.GetAllEmployees();
        foreach (Employee employee in employees)
        {
            ListItem item = new ListItem(employee.EmployeeName.ToString(), employee.EmployeeID.ToString());
            ddlEmployee.Items.Add(item);
        }
    }
    private void loadLeaveType()
    {
        ListItem li = new ListItem("Select LeaveType...", "0");
        ddlLeaveType.Items.Add(li);

        List<LeaveType> leaveTypes = new List<LeaveType>();
        leaveTypes = LeaveTypeManager.GetAllLeaveTypes();
        foreach (LeaveType leaveType in leaveTypes)
        {
            ListItem item = new ListItem(leaveType.LeaveTypeName.ToString(), leaveType.LeaveTypeID.ToString());
            ddlLeaveType.Items.Add(item);
        }
    }
    private void loadRowStatus()
    {
        ListItem li = new ListItem("Select RowStatus...", "0");
        ddlRowStatus.Items.Add(li);

        List<RowStatus> rowStatuss = new List<RowStatus>();
        rowStatuss = RowStatusManager.GetAllRowStatuss();
        foreach (RowStatus rowStatus in rowStatuss)
        {
            ListItem item = new ListItem(rowStatus.RowStatusName.ToString(), rowStatus.RowStatusID.ToString());
            ddlRowStatus.Items.Add(item);
        }
    }
}
