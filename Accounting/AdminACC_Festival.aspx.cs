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
            //_loadMonths();
            //_loadYears();
            loadEmployee();
            loadBonousType();
            loadHtmlOfBonusList();
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

    private void loadHtmlOfBonusList()
    {
        a_BounusList.HRef = "ListOfAllEmployeeBonusPrint.aspx?Percentage=" + txtNoOfDays.Text;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Bonus of " + ddlBonous.SelectedItem.Text + "&DrOrCr=Dr&SubBasicAccountID=12&AccountID="+ddlBonous.SelectedValue+"&UserTypeID=2&EmployeeID=" + ddlEmployee.SelectedValue + "&Amount=" + txtSalaryDeduction.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
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

    private void loadBonousType()
    {
        DataSet ds = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(12,true);//Bonous //HR_EmployeeManager.GetDropDownListAllHR_Employee();

        //ListItem li = new ListItem("Select Employee...", "0");
        //ddlEmployee.Items.Add(li);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ListItem item = new ListItem(dr["AccountName"].ToString(), dr["AccountID"].ToString());
            ddlBonous.Items.Add(item);            
        }
    }

    //private void _loadYears()
    //{
    //    try
    //    {
    //        int firstYear = DateTime.Now.Year - 5;
    //        for (int i = 0; i < 20; i++)
    //        {
    //            ddlYears.Items.Add(new ListItem((firstYear + i).ToString()));
    //        }
    //        ddlYears.Items.Insert(0, new ListItem("...Select Year...", "0"));
    //        ddlYears.SelectedValue = firstYear + 5 + "";
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //private void _loadMonths()
    //{
    //    try
    //    {
    //        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.TakeWhile(m => m != String.Empty).Select((m, i) => new { Month = i + 1, MonthName = m }).ToList();
    //        foreach (var month in months)
    //        {
    //            ddlMonths.Items.Add(new ListItem(month.MonthName, month.MonthName));
    //        }

    //        ddlMonths.Items.Insert(0, new ListItem("...Select Month...", "0"));
    //        ddlMonths.SelectedValue = DateTime.Now.Month.ToString();

    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

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

        loadHtmlOfBonusList();
        txtSalaryDeduction.Text = (decimal.Parse(txtTotalSalary.Text) * decimal.Parse(txtNoOfDays.Text) /100).ToString("0");

    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployee.SelectedValue != "0")
        {
            txtNoOfDays_TextChanged(this, new EventArgs());
        }
    }
}

