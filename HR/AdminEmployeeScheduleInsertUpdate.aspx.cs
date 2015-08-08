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

public partial class AdminEmployeeScheduleInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadEmployee();
            loadClassDay();
            loadRowStatus();
            if (Request.QueryString["employeeScheduleID"] != null)
            {
                int employeeScheduleID = Int32.Parse(Request.QueryString["employeeScheduleID"]);
                if (employeeScheduleID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showEmployeeScheduleData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        EmployeeSchedule employeeSchedule = new EmployeeSchedule();

        employeeSchedule.EmployeeID = Int32.Parse(ddlEmployee.SelectedValue);
        employeeSchedule.ClassDayID = Int32.Parse(ddlClassDay.SelectedValue);
        employeeSchedule.StartTime = txtStartTime.Text;
        employeeSchedule.EndTime = txtEndTime.Text;
        employeeSchedule.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        employeeSchedule.AddedBy = txtAddedBy.Text;
        employeeSchedule.AddedDate = DateTime.Now;
        employeeSchedule.UpdatedBy = txtUpdatedBy.Text;
        employeeSchedule.UpdateDate = txtUpdateDate.Text;
        int resutl = EmployeeScheduleManager.InsertEmployeeSchedule(employeeSchedule);
        Response.Redirect("AdminEmployeeScheduleDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        EmployeeSchedule employeeSchedule = new EmployeeSchedule();
        employeeSchedule = EmployeeScheduleManager.GetEmployeeScheduleByID(Int32.Parse(Request.QueryString["employeeScheduleID"]));
        EmployeeSchedule tempEmployeeSchedule = new EmployeeSchedule();
        tempEmployeeSchedule.EmployeeScheduleID = employeeSchedule.EmployeeScheduleID;

        tempEmployeeSchedule.EmployeeID = Int32.Parse(ddlEmployee.SelectedValue);
        tempEmployeeSchedule.ClassDayID = Int32.Parse(ddlClassDay.SelectedValue);
        tempEmployeeSchedule.StartTime = txtStartTime.Text;
        tempEmployeeSchedule.EndTime = txtEndTime.Text;
        tempEmployeeSchedule.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        tempEmployeeSchedule.AddedBy = txtAddedBy.Text;
        tempEmployeeSchedule.AddedDate = DateTime.Now;
        tempEmployeeSchedule.UpdatedBy = txtUpdatedBy.Text;
        tempEmployeeSchedule.UpdateDate = txtUpdateDate.Text;
        bool result = EmployeeScheduleManager.UpdateEmployeeSchedule(tempEmployeeSchedule);
        Response.Redirect("AdminEmployeeScheduleDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlEmployee.SelectedIndex = 0;
        ddlClassDay.SelectedIndex = 0;
        txtStartTime.Text = "";
        txtEndTime.Text = "";
        ddlRowStatus.SelectedIndex = 0;
        txtAddedBy.Text = "";
        txtUpdatedBy.Text = "";
        txtUpdateDate.Text = "";
    }
    private void showEmployeeScheduleData()
    {
        EmployeeSchedule employeeSchedule = new EmployeeSchedule();
        employeeSchedule = EmployeeScheduleManager.GetEmployeeScheduleByID(Int32.Parse(Request.QueryString["employeeScheduleID"]));

        ddlEmployee.SelectedValue = employeeSchedule.EmployeeID.ToString();
        ddlClassDay.SelectedValue = employeeSchedule.ClassDayID.ToString();
        txtStartTime.Text = employeeSchedule.StartTime;
        txtEndTime.Text = employeeSchedule.EndTime;
        ddlRowStatus.SelectedValue = employeeSchedule.RowStatusID.ToString();
        txtAddedBy.Text = employeeSchedule.AddedBy;
        txtUpdatedBy.Text = employeeSchedule.UpdatedBy;
        txtUpdateDate.Text = employeeSchedule.UpdateDate;
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
    private void loadClassDay()
    {
        ListItem li = new ListItem("Select ClassDay...", "0");
        ddlClassDay.Items.Add(li);

        List<ClassDay> classDaies = new List<ClassDay>();
        classDaies = ClassDayManager.GetAllClassDaies();
        foreach (ClassDay classDay in classDaies)
        {
            ListItem item = new ListItem(classDay.ClassDayName.ToString(), classDay.ClassDayID.ToString());
            ddlClassDay.Items.Add(item);
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
