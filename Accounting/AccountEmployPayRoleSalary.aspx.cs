using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using CrystalDecisions.CrystalReports.Engine;
using System.Data;

public partial class Accounting_AccountEmployPayRoleSalary : System.Web.UI.Page
{
    static decimal unPaidSalary = 0, paidSalaryAmount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["EmployeeID"] != null)
            {
                showACC_EmployPayRoleSalaryGridByEmployeeID();
            }
            else
            {
                showACC_EmployPayRoleSalaryGrid();
            }
        }

    }


    

    protected void lnkViewReport_OnClick(object sender, EventArgs e)
    {
        Button lnkViewReport = new Button();
        lnkViewReport = (Button)sender;
        int id;
        id = Convert.ToInt32(lnkViewReport.CommandArgument);

        Response.Redirect("~/Accounting/AccountEmployPayRoleSalaryReport.aspx?id=" + id);

    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = ACC_EmployPayRoleSalaryManager.DeleteEmployPayRoleSalary(Convert.ToInt32(linkButton.CommandArgument));
        showACC_EmployPayRoleSalaryGrid();
        
    }

    private void showACC_EmployPayRoleSalaryGrid()
    {
        gvACC_EmployPayRoleSalary.DataSource = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalaries();
        gvACC_EmployPayRoleSalary.DataBind();

        gvSalaryHistory.DataSource = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalariesHistory();
        gvSalaryHistory.DataBind();
    }

   

    private void showACC_EmployPayRoleSalaryGridByEmployeeID()
    {
        gvACC_EmployPayRoleSalary.DataSource = ACC_EmployPayRoleSalaryManager.GetAllEmployeeByID(Request.QueryString["EmployeeID"]);
        gvACC_EmployPayRoleSalary.DataBind();
    }


    protected void lnkPaid_Click(object sender, EventArgs e)
    {
        Button lnkPaid = new Button();
        lnkPaid = (Button)sender;

        foreach (GridViewRow row in gvACC_EmployPayRoleSalary.Rows)
        {
            TextBox txtSalaryAmount = (TextBox)row.FindControl("txtSalaryAmount");
            Label lblID = (Label)row.FindControl("lblID");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            Label lblSalaryOfDate = (Label)row.FindControl("lblSalaryOfDate");
            if (Convert.ToInt32(lnkPaid.CommandArgument) == Convert.ToInt32(lblID.Text))
            {
                ACC_EmployPayRoleSalary employPayRoleSalary = ACC_EmployPayRoleSalaryManager.GetEmployPayRoleSalaryByID(Convert.ToInt32(lblID.Text));

                if (txtSalaryAmount.Text != "" && employPayRoleSalary.UnpaidSalaryAmount == 0 && employPayRoleSalary.PaidSalaryAmount == 0)
                {
                    decimal payMent = decimal.Parse(txtSalaryAmount.Text);
                    decimal salaryAmount = employPayRoleSalary.SalaryAmount;


                    if (payMent < salaryAmount)
                    {
                        unPaidSalary = salaryAmount - payMent;
                        paidSalaryAmount = employPayRoleSalary.PaidSalaryAmount + payMent;


                        employPayRoleSalary.PaidSalaryAmount = paidSalaryAmount;
                        employPayRoleSalary.UnpaidSalaryAmount = unPaidSalary;
                        employPayRoleSalary.Status = (int)Enums.SalaryStatus.PartiallyPaid;
                        lblStatus.Text = "PartiallyPaid";
                        employPayRoleSalary.UpdatedDate = DateTime.Now;
                        //bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayRoleSalary);
                        Session["employPayRoleSalary"] = employPayRoleSalary;
                        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Salary of " + lblSalaryOfDate.Text + "&EmployPayRoleSalaryID=" + employPayRoleSalary.EmployPayRoleSalaryID.ToString() + "&PaidSalaryAmount=" + employPayRoleSalary.PaidSalaryAmount + "&UnpaidSalaryAmount=" + employPayRoleSalary.UnpaidSalaryAmount + "&Status=" + employPayRoleSalary.Status + "&DrOrCr=Dr&SubBasicAccountID=11&AccountID=17&UserTypeID=2&EmployeeID=" + employPayRoleSalary.EmployeeID + "&Amount=" + txtSalaryAmount.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");

                        //showACC_EmployPayRoleSalaryGrid();
                    }

                    else if (payMent > salaryAmount)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('PayMent Salary is greater than Salary Amount')", true);
                    }
                    else
                    {
                        employPayRoleSalary.Status = (int)Enums.SalaryStatus.Paid;
                        txtSalaryAmount.Enabled = false;
                        employPayRoleSalary.PaidSalaryAmount = payMent;
                        employPayRoleSalary.UnpaidSalaryAmount = 0;
                        lblStatus.Text = "Paid";
                        employPayRoleSalary.UpdatedDate = DateTime.Now;
                        //bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayRoleSalary);
                        Session["employPayRoleSalary"] = employPayRoleSalary;
                        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Salary of " + lblSalaryOfDate.Text + "&EmployPayRoleSalaryID=" + employPayRoleSalary.EmployPayRoleSalaryID.ToString() + "&PaidSalaryAmount=" + employPayRoleSalary.PaidSalaryAmount + "&UnpaidSalaryAmount=" + employPayRoleSalary.UnpaidSalaryAmount + "&Status=" + employPayRoleSalary.Status + "&DrOrCr=Dr&SubBasicAccountID=11&AccountID=17&UserTypeID=2&EmployeeID=" + employPayRoleSalary.EmployeeID + "&Amount=" + txtSalaryAmount.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");

                        //showACC_EmployPayRoleSalaryGrid();
                    }

                }
                else if (txtSalaryAmount.Text != "" && employPayRoleSalary.UnpaidSalaryAmount != 0 && employPayRoleSalary.PaidSalaryAmount == 0)
                {
                    decimal payMent = decimal.Parse(txtSalaryAmount.Text);
                    decimal salaryAmount = employPayRoleSalary.SalaryAmount;


                    if (payMent < salaryAmount)
                    {
                        unPaidSalary = salaryAmount - payMent;
                        paidSalaryAmount = employPayRoleSalary.PaidSalaryAmount + payMent;


                        employPayRoleSalary.PaidSalaryAmount = paidSalaryAmount;
                        employPayRoleSalary.UnpaidSalaryAmount = unPaidSalary;
                        employPayRoleSalary.Status = (int)Enums.SalaryStatus.PartiallyPaid;
                        lblStatus.Text = "PartiallyPaid";
                        employPayRoleSalary.UpdatedDate = DateTime.Now;
                        //bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayRoleSalary);
                        Session["employPayRoleSalary"] = employPayRoleSalary;
                        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Salary of " + lblSalaryOfDate.Text + "&EmployPayRoleSalaryID=" + employPayRoleSalary.EmployPayRoleSalaryID.ToString() + "&PaidSalaryAmount=" + employPayRoleSalary.PaidSalaryAmount + "&UnpaidSalaryAmount=" + employPayRoleSalary.UnpaidSalaryAmount + "&Status=" + employPayRoleSalary.Status + "&DrOrCr=Dr&SubBasicAccountID=11&AccountID=17&UserTypeID=2&EmployeeID=" + employPayRoleSalary.EmployeeID + "&Amount=" + txtSalaryAmount.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");

                        showACC_EmployPayRoleSalaryGrid();
                    }

                    else if (payMent > salaryAmount)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('PayMent Salary is greater than Salary Amount')", true);
                    }
                    else
                    {
                        employPayRoleSalary.Status = (int)Enums.SalaryStatus.Paid;
                        txtSalaryAmount.Enabled = false;
                        employPayRoleSalary.PaidSalaryAmount = payMent;
                        employPayRoleSalary.UnpaidSalaryAmount = 0;
                        lblStatus.Text = "Paid";
                        employPayRoleSalary.UpdatedDate = DateTime.Now;
                        //bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayRoleSalary);
                        Session["employPayRoleSalary"] = employPayRoleSalary;
                        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Salary of " + lblSalaryOfDate.Text + "&EmployPayRoleSalaryID=" + employPayRoleSalary.EmployPayRoleSalaryID.ToString() + "&PaidSalaryAmount=" + employPayRoleSalary.PaidSalaryAmount + "&UnpaidSalaryAmount=" + employPayRoleSalary.UnpaidSalaryAmount + "&Status=" + employPayRoleSalary.Status + "&DrOrCr=Dr&SubBasicAccountID=11&AccountID=17&UserTypeID=2&EmployeeID=" + employPayRoleSalary.EmployeeID + "&Amount=" + txtSalaryAmount.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");

                        showACC_EmployPayRoleSalaryGrid();
                    }

                }
                else if (txtSalaryAmount.Text != "" && employPayRoleSalary.UnpaidSalaryAmount != 0 && employPayRoleSalary.PaidSalaryAmount != 0)
                {
                    unPaidSalary = employPayRoleSalary.UnpaidSalaryAmount;
                    decimal paymentAmount = decimal.Parse(txtSalaryAmount.Text);

                    if (paymentAmount < unPaidSalary)
                    {
                        unPaidSalary = unPaidSalary - paymentAmount;
                        paidSalaryAmount = employPayRoleSalary.PaidSalaryAmount + paymentAmount;


                        employPayRoleSalary.UnpaidSalaryAmount = unPaidSalary;
                        employPayRoleSalary.PaidSalaryAmount = paidSalaryAmount;
                        employPayRoleSalary.UpdatedDate = DateTime.Now;
                        employPayRoleSalary.Status = (int)Enums.SalaryStatus.PartiallyPaid;
                        lblStatus.Text = "Partially Paid";
                        //bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayRoleSalary);
                        Session["employPayRoleSalary"] = employPayRoleSalary;
                        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Salary of " + lblSalaryOfDate.Text + "&EmployPayRoleSalaryID=" + employPayRoleSalary.EmployPayRoleSalaryID.ToString() + "&PaidSalaryAmount=" + employPayRoleSalary.PaidSalaryAmount + "&UnpaidSalaryAmount=" + employPayRoleSalary.UnpaidSalaryAmount + "&Status=" + employPayRoleSalary.Status + "&DrOrCr=Dr&SubBasicAccountID=11&AccountID=17&UserTypeID=2&EmployeeID=" + employPayRoleSalary.EmployeeID + "&Amount=" + txtSalaryAmount.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");

                        showACC_EmployPayRoleSalaryGrid();

                    }

                    else if (paymentAmount > unPaidSalary)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Message", "alert('PayMent Salary is greater than Unpaid Amount')", true);
                    }

                    else
                    {
                        employPayRoleSalary.Status = (int)Enums.SalaryStatus.Paid;
                        txtSalaryAmount.Enabled = false;
                        employPayRoleSalary.PaidSalaryAmount = employPayRoleSalary.PaidSalaryAmount + paymentAmount;
                        employPayRoleSalary.UnpaidSalaryAmount = 0;
                        employPayRoleSalary.UpdatedDate = DateTime.Now;
                        lblStatus.Text = "Paid";
                        //bool result = ACC_EmployPayRoleSalaryManager.UpdateEmployPayRoleSalary(employPayRoleSalary);
                        Session["employPayRoleSalary"] = employPayRoleSalary;
                        Response.Redirect("~/Accounting/JournalDoubleEntryCommon.aspx?Purpose=Salary of " + lblSalaryOfDate.Text + "&EmployPayRoleSalaryID=" + employPayRoleSalary.EmployPayRoleSalaryID.ToString() + "&PaidSalaryAmount=" + employPayRoleSalary.PaidSalaryAmount + "&UnpaidSalaryAmount=" + employPayRoleSalary.UnpaidSalaryAmount + "&Status=" + employPayRoleSalary.Status + "&DrOrCr=Dr&SubBasicAccountID=11&AccountID=17&UserTypeID=2&EmployeeID=" + employPayRoleSalary.EmployeeID + "&Amount=" + txtSalaryAmount.Text + "&UserTypeIDMoney=2&AccountIDMoney=1");

                        showACC_EmployPayRoleSalaryGrid();

                    }

                }

                break;
            }
        }

    }

    protected void gvACC_EmployPayRoleSalary_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Label lblID = (Label)e.Row.FindControl("lblID");
            TextBox txtSalaryAmount = (TextBox)e.Row.FindControl("txtSalaryAmount");

            ACC_EmployPayRoleSalary employPayRoleSalary = ACC_EmployPayRoleSalaryManager.GetEmployPayRoleSalaryByID(Convert.ToInt32(lblID.Text));

            if (employPayRoleSalary.Status == (int)Enums.SalaryStatus.Paid)
            {
                lblStatus.Text = "Paid";
                txtSalaryAmount.Enabled = false;
            }
            else if (employPayRoleSalary.Status == (int)Enums.SalaryStatus.PartiallyPaid)
            {
                lblStatus.Text = "Partially Paid";
            }
            else
            {
                lblStatus.Text = "UnPaid";
            }
        }
    }
    protected void btnViewReport_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Accounting/AccountEmployPayRoleSalaryReport.aspx");
    }


    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (txtSearch.Text == "Paid" || txtSearch.Text == "paid")
            {
                List<ACC_EmployPayRoleSalary> employeeSalaries = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalariesByNameAndStatus("", (int)Enums.SalaryStatus.Paid);

                gvACC_EmployPayRoleSalary.DataSource = employeeSalaries;
                gvACC_EmployPayRoleSalary.DataBind();
            }

            else if (txtSearch.Text == "PartiallyPaid" || txtSearch.Text == "partiallyPaid" || txtSearch.Text == "partiallypaid")
            {
                List<ACC_EmployPayRoleSalary> employeeSalaries = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalariesByNameAndStatus("", (int)Enums.SalaryStatus.PartiallyPaid);

                gvACC_EmployPayRoleSalary.DataSource = employeeSalaries;
                gvACC_EmployPayRoleSalary.DataBind();
            }
            else if (txtSearch.Text == "Unpaid" || txtSearch.Text == "UnPaid" || txtSearch.Text == "unPaid")
            {
                List<ACC_EmployPayRoleSalary> employeeSalaries = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalariesByNameAndStatus("", (int)Enums.SalaryStatus.Unpaid);

                gvACC_EmployPayRoleSalary.DataSource = employeeSalaries;
                gvACC_EmployPayRoleSalary.DataBind();
            }

            else
            {
                List<ACC_EmployPayRoleSalary> employeeSalaries = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalariesByNameAndStatus(txtSearch.Text, 0);

                gvACC_EmployPayRoleSalary.DataSource = employeeSalaries;
                gvACC_EmployPayRoleSalary.DataBind();
            }
        }
        catch (Exception ex)
        {
            //
        }
    }
}