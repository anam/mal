using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_ListOfAllEmployeePrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = HR_EmployeeSalaryManager.GetHR_EmployeeBounusAll(int.Parse(Request.QueryString["Percentage"] == null ? "60" : Request.QueryString["Percentage"]));

        decimal totalBounusAmount = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
           totalBounusAmount+=decimal.Parse(dr["Bonus Amount"].ToString());
        }

        lblTotal.Text = totalBounusAmount.ToString("0,0.00");

        gvListOfAllEmployee.DataSource = ds.Tables[0];
        gvListOfAllEmployee.DataBind();
    }
}