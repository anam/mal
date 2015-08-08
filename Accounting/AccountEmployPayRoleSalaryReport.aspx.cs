using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Accounting_AccountEmployPayRoleSalaryReport : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
           int id = Convert.ToInt32(Request.QueryString["id"]);
            _LoadViewReport(id);
        }
    }

    public void _LoadViewReport(int id)
    {
        List<ACC_EmployPayRoleSalary> payRoles = ACC_EmployPayRoleSalaryManager.GetAllEmployPayRoleSalariesByID(id);

        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/EmployPayRoleReport.rpt"));
        rptDoc.SetDataSource(payRoles);

        //this.crvContact.EnableDatabaseLogonPrompt = false;
        crvSalaryStatement.ReportSource = rptDoc;
        crvSalaryStatement.Zoom(83);
    }
}