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
using System.Globalization;
 

public partial class AdminDisplayHR_Bank : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadMonths();
            _loadYears();
            loadEmployee();
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
            else
            {
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();

        absendSalaryDiduction.EmployeeID = ddlEmployee.SelectedValue;
        absendSalaryDiduction.SalaryOfMonth = ddlMonths.SelectedValue + ", " + ddlYears.SelectedValue;
        absendSalaryDiduction.NoOfDays = Int32.Parse(txtNoOfDays.Text);
        absendSalaryDiduction.TotalSalary = Decimal.Parse(txtTotalSalary.Text);
        absendSalaryDiduction.SalaryDeduction = Decimal.Parse(txtSalaryDeduction.Text);
        absendSalaryDiduction.AddedBy = Profile.card_id;
        absendSalaryDiduction.AddedDate = DateTime.Now;
        absendSalaryDiduction.UpdatedBy = Profile.card_id;
        absendSalaryDiduction.UpdateDate = DateTime.Now;
        absendSalaryDiduction.RowStatusID = 1;
        int resutl = AbsendSalaryDiductionManager.InsertAbsendSalaryDiduction(absendSalaryDiduction);
        Response.Redirect("AdminDisplayHR_AbsentSalaryDiduction.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();
        absendSalaryDiduction = AbsendSalaryDiductionManager.GetAbsendSalaryDiductionByID(Int32.Parse(Request.QueryString["absendSalaryDiductionID"]));
        AbsendSalaryDiduction tempAbsendSalaryDiduction = new AbsendSalaryDiduction();
        tempAbsendSalaryDiduction.AbsendSalaryDiductionID = absendSalaryDiduction.AbsendSalaryDiductionID;

        tempAbsendSalaryDiduction.EmployeeID =ddlEmployee.SelectedValue;
        tempAbsendSalaryDiduction.SalaryOfMonth = ddlMonths.SelectedValue+", "+ddlYears.SelectedValue;
        tempAbsendSalaryDiduction.NoOfDays = Int32.Parse(txtNoOfDays.Text);
        tempAbsendSalaryDiduction.TotalSalary = Decimal.Parse(txtTotalSalary.Text);
        tempAbsendSalaryDiduction.SalaryDeduction = Decimal.Parse(txtSalaryDeduction.Text);
        tempAbsendSalaryDiduction.AddedBy = Profile.card_id;
        tempAbsendSalaryDiduction.AddedDate = DateTime.Now;
        tempAbsendSalaryDiduction.UpdatedBy = Profile.card_id;
        tempAbsendSalaryDiduction.UpdateDate = DateTime.Now;
        tempAbsendSalaryDiduction.RowStatusID = 1;
        bool result = AbsendSalaryDiductionManager.UpdateAbsendSalaryDiduction(tempAbsendSalaryDiduction);
        Response.Redirect("AdminDisplayHR_AbsentSalaryDiduction.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlEmployee.SelectedIndex = 0;
        
        txtNoOfDays.Text = "";
        txtTotalSalary.Text = "";
        txtSalaryDeduction.Text = "";
    }
    private void showAbsendSalaryDiductionData()
    {
        AbsendSalaryDiduction absendSalaryDiduction = new AbsendSalaryDiduction();
        absendSalaryDiduction = AbsendSalaryDiductionManager.GetAbsendSalaryDiductionByID(Int32.Parse(Request.QueryString["absendSalaryDiductionID"]));

        ddlEmployee.SelectedValue = absendSalaryDiduction.EmployeeID.ToString();
        ddlMonths.SelectedValue = absendSalaryDiduction.SalaryOfMonth.Split(',')[0];
        ddlYears.SelectedValue = absendSalaryDiduction.SalaryOfMonth.Split(',')[1].Trim();
        txtNoOfDays.Text = absendSalaryDiduction.NoOfDays.ToString();
        txtTotalSalary.Text = absendSalaryDiduction.TotalSalary.ToString();
        txtSalaryDeduction.Text = absendSalaryDiduction.SalaryDeduction.ToString();
       
    }
    private void loadEmployee()
    {
        DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();

        ListItem li = new ListItem("Select Employee...", "0");
        ddlEmployee.Items.Add(li);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (bool.Parse(dr["Flag"].ToString()) == true)
            {
                ListItem item = new ListItem(dr["EmployeeNameNo"].ToString(), dr["EmployeeID"].ToString());
                ddlEmployee.Items.Add(item);
            }
        }
    }

    private void _loadYears()
    {
        try
        {
            int firstYear = DateTime.Now.Year - 5;
            for (int i = 0; i < 20; i++)
            {
                ddlYears.Items.Add(new ListItem((firstYear + i).ToString()));
            }
            ddlYears.Items.Insert(0, new ListItem("...Select Year...", "0"));
            ddlYears.SelectedValue = firstYear + 5 + "";
        }
        catch (Exception ex)
        {
        }
    }

    private void _loadMonths()
    {
        try
        {
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.TakeWhile(m => m != String.Empty).Select((m, i) => new { Month = i + 1, MonthName = m }).ToList();
            foreach (var month in months)
            {
                ddlMonths.Items.Add(new ListItem(month.MonthName, month.MonthName));
            }

            ddlMonths.Items.Insert(0, new ListItem("...Select Month...", "0"));
            ddlMonths.SelectedValue = DateTime.Now.Month.ToString();

        }
        catch (Exception ex)
        {
        }
    }

    protected void txtNoOfDays_TextChanged(object sender, EventArgs e)
    {
        HR_EmployeeSalary employeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeID(ddlEmployee.SelectedValue);

        if (employeeSalary != null)
        {
            if (employeeSalary.IsGross)
            {
                txtTotalSalary.Text = employeeSalary.GrossAmount.ToString("0");
            }
            else
            {
                txtTotalSalary.Text = employeeSalary.BasicAmount.ToString("0");
            }
        }

        txtSalaryDeduction.Text = (decimal.Parse(txtTotalSalary.Text) * decimal.Parse(txtNoOfDays.Text) /30).ToString("0");

    }
}

