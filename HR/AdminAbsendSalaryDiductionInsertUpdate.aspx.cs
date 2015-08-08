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

public partial class AdminAbsendSalaryDiductionInsertUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadEmployee();
            loadRowStatus();
            if (Request.QueryString["absendSalaryDiductionID"] != null)
            {
                int absendSalaryDiductionID = Int32.Parse(Request.QueryString["absendSalaryDiductionID"]);
                if (absendSalaryDiductionID == 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }
                else
                {
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showAbsendSalaryDiductionData();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();

        absendSalaryDiduction.EmployeeID = Int32.Parse(ddlEmployee.SelectedValue);
        absendSalaryDiduction.SalaryOfMonth = txtSalaryOfMonth.Text;
        absendSalaryDiduction.NoOfDays = Int32.Parse(txtNoOfDays.Text);
        absendSalaryDiduction.TotalSalary = Decimal.Parse(txtTotalSalary.Text);
        absendSalaryDiduction.SalaryDeduction = Decimal.Parse(txtSalaryDeduction.Text);
        absendSalaryDiduction.AddedBy = txtAddedBy.Text;
        absendSalaryDiduction.AddedDate = DateTime.Now;
        absendSalaryDiduction.UpdatedBy = txtUpdatedBy.Text;
        absendSalaryDiduction.UpdateDate = txtUpdateDate.Text;
        absendSalaryDiduction.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        int resutl = AbsendSalaryDiductionManager.InsertAbsendSalaryDiduction(absendSalaryDiduction);
        Response.Redirect("AdminAbsendSalaryDiductionDisplay.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();
        absendSalaryDiduction = AbsendSalaryDiductionManager.GetAbsendSalaryDiductionByID(Int32.Parse(Request.QueryString["absendSalaryDiductionID"]));
        AbsendSalaryDiduction tempAbsendSalaryDiduction = new AbsendSalaryDiduction();
        tempAbsendSalaryDiduction.AbsendSalaryDiductionID = absendSalaryDiduction.AbsendSalaryDiductionID;

        tempAbsendSalaryDiduction.EmployeeID = Int32.Parse(ddlEmployee.SelectedValue);
        tempAbsendSalaryDiduction.SalaryOfMonth = txtSalaryOfMonth.Text;
        tempAbsendSalaryDiduction.NoOfDays = Int32.Parse(txtNoOfDays.Text);
        tempAbsendSalaryDiduction.TotalSalary = Decimal.Parse(txtTotalSalary.Text);
        tempAbsendSalaryDiduction.SalaryDeduction = Decimal.Parse(txtSalaryDeduction.Text);
        tempAbsendSalaryDiduction.AddedBy = txtAddedBy.Text;
        tempAbsendSalaryDiduction.AddedDate = DateTime.Now;
        tempAbsendSalaryDiduction.UpdatedBy = txtUpdatedBy.Text;
        tempAbsendSalaryDiduction.UpdateDate = txtUpdateDate.Text;
        tempAbsendSalaryDiduction.RowStatusID = Int32.Parse(ddlRowStatus.SelectedValue);
        bool result = AbsendSalaryDiductionManager.UpdateAbsendSalaryDiduction(tempAbsendSalaryDiduction);
        Response.Redirect("AdminAbsendSalaryDiductionDisplay.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlEmployee.SelectedIndex = 0;
        txtSalaryOfMonth.Text = "";
        txtNoOfDays.Text = "";
        txtTotalSalary.Text = "";
        txtSalaryDeduction.Text = "";
        txtAddedBy.Text = "";
        txtUpdatedBy.Text = "";
        txtUpdateDate.Text = "";
        ddlRowStatus.SelectedIndex = 0;
    }
    private void showAbsendSalaryDiductionData()
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();
        absendSalaryDiduction = AbsendSalaryDiductionManager.GetAbsendSalaryDiductionByID(Int32.Parse(Request.QueryString["absendSalaryDiductionID"]));

        ddlEmployee.SelectedValue = absendSalaryDiduction.EmployeeID.ToString();
        txtSalaryOfMonth.Text = absendSalaryDiduction.SalaryOfMonth;
        txtNoOfDays.Text = absendSalaryDiduction.NoOfDays.ToString();
        txtTotalSalary.Text = absendSalaryDiduction.TotalSalary.ToString();
        txtSalaryDeduction.Text = absendSalaryDiduction.SalaryDeduction.ToString();
        txtAddedBy.Text = absendSalaryDiduction.AddedBy;
        txtUpdatedBy.Text = absendSalaryDiduction.UpdatedBy;
        txtUpdateDate.Text = absendSalaryDiduction.UpdateDate;
        ddlRowStatus.SelectedValue = absendSalaryDiduction.RowStatusID.ToString();
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
