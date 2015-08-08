using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Accounting_ViewTeacherMoneyReceit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["Amount"] != "") 
        _LoadViewReport();
    }

    public void _LoadViewReport()
    {
        

        
        List<HR_Employee> employeeReceit = new List<HR_Employee>();

        HR_Employee employee = HR_EmployeeManager.ViewTeacherMoneyReceipt(Request.QueryString["EmployeeID"]);

        employee.Amount = Request.QueryString["Amount"]; ;
        employee.AddedDate = DateTime.Now;
        employeeReceit.Add(employee);
       
        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/TeacherMoneyReceipt.rpt"));
        rptDoc.SetDataSource(employeeReceit);

        //this.crvContact.EnableDatabaseLogonPrompt = false;
        crvTeacherMoneyReceit.ReportSource = rptDoc;
        crvTeacherMoneyReceit.Zoom(83);
    }
}