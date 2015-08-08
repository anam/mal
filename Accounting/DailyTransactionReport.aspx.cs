using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Accounting_DailyTransactionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Text = String.Format("{0:dd MMM yyyy}", DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())));
            txtEndDate.Text = String.Format("{0:dd MMM yyyy}", DateTime.Now.AddHours(double.Parse(ConfigurationManager.AppSettings["ServerTimeDiff"].ToString())));

            //txtStartDate.Enabled = false;
            //txtEndDate.Enabled = false;
        }
    }
    protected void btnDailyReport_OnClick(object sender, EventArgs e)
    {
        txtStartDate.Text += " 12:00:00 AM";
        txtEndDate.Text += " 11:59:59 PM";

        DateTime startDate = txtStartDate.Text != "" ? Convert.ToDateTime(txtStartDate.Text) : Convert.ToDateTime("1/1/1753");
        DateTime endDate = txtEndDate.Text != "" ? Convert.ToDateTime(txtEndDate.Text).AddDays(0) : DateTime.Now.AddDays(0);
        Response.Redirect("DailyTransactionReportView.aspx?startDate=" + startDate.ToString() + "&endDate=" + endDate.ToString());
    }
}