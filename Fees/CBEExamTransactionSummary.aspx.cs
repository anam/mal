using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Fees_CBEExamTransactionSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }

    private void loadData()
    {

        string fromDate = DateTime.Today.ToString("yyyy-MM-dd");
        if (Request.QueryString["fromDate"] != null)
        {
            fromDate = Request.QueryString["fromDate"];
        }

        string toDate = DateTime.Today.ToString("yyyy-MM-dd");
        if (Request.QueryString["toDate"] != null)
        {
            toDate = Request.QueryString["toDate"];
        }

        if (fromDate == toDate)
        {
            lblDate.Text = fromDate;
        }
        else
        {
            lblDate.Text =  fromDate +" to "+ toDate;
        }

        string sql = @"
--opinining cash in hand
SELECT SUM([Amount])
FROM [STD_CBEExamAcc]
where [AddedDate] <=  '" + DateTime.Parse(fromDate).AddDays(-1).ToString("yyyy-MM-dd") + @" 11:59:59 PM'


--opining bank
SELECT SUM([Amount]) as Amount,AccountFor
FROM [STD_CBEExamAcc]
where [AddedDate] <=  '" + DateTime.Parse(fromDate).AddDays(-1).ToString("yyyy-MM-dd") + @" 11:59:59 PM'
and Head like 'Bank%'
group by AccountFor


--Closing cash in hand
SELECT SUM([Amount])
FROM [STD_CBEExamAcc]
where [AddedDate] <=  '" + DateTime.Parse(toDate).ToString("yyyy-MM-dd") + @" 11:59:59 PM'

--Closing Bank
SELECT SUM([Amount]) as Amount,AccountFor
FROM [STD_CBEExamAcc]
where [AddedDate] <=  '" + DateTime.Parse(toDate).ToString("yyyy-MM-dd") + @" 11:59:59 PM'
and Head like 'Bank%'
group by AccountFor


--Income
SELECT [Head]
      ,[AccountFor]
      ,[Amount]
      ,[AddedDate]
  FROM [STD_CBEExamAcc]
where [AddedDate] between  '" + DateTime.Parse(fromDate).AddDays(-1).ToString("yyyy-MM-dd") + @" 11:59:59 PM' and '" + DateTime.Parse(toDate).ToString("yyyy-MM-dd") + @" 11:59:59 PM'
and Amount>0

--expence
SELECT [Head]
      ,[AccountFor]
      ,[Amount]
      ,[AddedDate]
  FROM [STD_CBEExamAcc]
where [AddedDate] between  '" + DateTime.Parse(fromDate).AddDays(-1).ToString("yyyy-MM-dd") + @"  11:59:59 PM' and '" + DateTime.Parse(toDate).ToString("yyyy-MM-dd") + @" 11:59:59 PM'
and Amount<0
";

        DataSet ds = CommonManager.SQLExec(sql);

        string opining = "<table><tr><td colspan='2' class='header'>Opening</td></tr><tr><td class='head'>Head</td><td class='amount'>Amount</td></tr>";
        string closinging = "<table><tr><td colspan='2' class='header'>Closing</td></tr>";
        string expence = "<table><tr><td colspan='3' class='header'>Expense</td></tr><tr><td class='date'>Date</td><td class='head'>Head</td><td class='amount'>Amount</td></tr>"; ;
        string income = "<table><tr><td colspan='3' class='header'>Income</td></tr><tr><td class='date'>Date</td><td class='head'>Head</td><td class='amount'>Amount</td></tr>";

        decimal opiningTotal = 0;
        try{
            
            if (decimal.Parse(ds.Tables[0].Rows[0][0].ToString()) != 0)
            {
                opining += "<tr><td class='head'>Cash</td><td class='amount'>" + decimal.Parse(ds.Tables[0].Rows[0][0].ToString()).ToString("0,0") + @"</td></tr>";
                opiningTotal += decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
        }
        catch(Exception ex)
        {}

        foreach(DataRow dr in ds.Tables[1].Rows)
        {
            dr["Amount"] = (-1) * decimal.Parse(dr["Amount"].ToString());
            opining += "<tr><td class='head'>" + dr["AccountFor"].ToString() + @"</td><td class='amount'>" + decimal.Parse(dr["Amount"].ToString()).ToString("0,0") + @"</td></tr>";
            opiningTotal += decimal.Parse(dr["Amount"].ToString());
        }
        opining += "<tr><td class='head'>Total Opining</td><td class='amount'>" + opiningTotal.ToString("0,0") + @"</td></tr>";
        opining += "</table>";

        decimal closingTotal = 0;
        try
        {

            if (decimal.Parse(ds.Tables[2].Rows[0][0].ToString()) != 0)
            {
                closinging += "<tr><td class='head'>Cash</td><td class='amount'>" + decimal.Parse(ds.Tables[2].Rows[0][0].ToString()).ToString("0,0") + @"</td></tr>";
                closingTotal += decimal.Parse(ds.Tables[2].Rows[0][0].ToString());
            }
        }
        catch (Exception ex)
        { 
        
        }

        foreach (DataRow dr in ds.Tables[3].Rows)
        {
            dr["Amount"] = (-1) * decimal.Parse(dr["Amount"].ToString());
            closinging += "<tr><td class='head'>" + dr["AccountFor"].ToString() + @"</td><td class='amount'>" + decimal.Parse(dr["Amount"].ToString()).ToString("0,0") + @"</td></tr>";
            closingTotal += decimal.Parse(dr["Amount"].ToString());
        }
        closinging += "<tr><td class='head'>Total Closing</td><td class='amount'>" + closingTotal.ToString("0,0") + @"</td></tr>";
        closinging += "</table>";

        decimal totalincome = 0;
        foreach (DataRow dr in ds.Tables[4].Rows)
        {
            totalincome += decimal.Parse(dr["Amount"].ToString());
            income += "<tr><td class='date'>" + DateTime.Parse(dr["AddedDate"].ToString()).ToString("dd MMM yyyy") + @"</td><td class='head'>" + dr["Head"].ToString() + " - " + dr["AccountFor"].ToString() + @"</td><td class='amount'>" + decimal.Parse(dr["Amount"].ToString()).ToString("0,0") + @"</td></tr>";
        }
        string incometotal = "<table><tr><td class='date' ></td><td class='head'>Total Income</td><td class='amount'>" + totalincome.ToString("0,0") + @"</td></tr></table>";
        income += "</table>";

        decimal totalexpnese = 0;

        foreach (DataRow dr in ds.Tables[5].Rows)
        {
            dr["Amount"] = (-1) * decimal.Parse(dr["Amount"].ToString());
            totalexpnese += decimal.Parse(dr["Amount"].ToString());
            expence += "<tr><td class='date'>" + DateTime.Parse(dr["AddedDate"].ToString()).ToString("dd MMM yyyy") + @"</td><td class='head'>" + dr["Head"].ToString() + " - " + dr["AccountFor"].ToString() + @"</td><td class='amount'>" + decimal.Parse(dr["Amount"].ToString()).ToString("0,0") + @"</td></tr>";
        }
        string expenceTotal = "<table><tr><td class='date' ></td><td class='head' >Total Expense</td><td class='amount'>" + totalexpnese.ToString("0,0") + @"</td></tr></table>";
        expence += "</table>";

        lblHtml.Text = "<table><tr><td colspan='2' align='center'>"+opining+"</td></tr>";
        lblHtml.Text += "<tr><td valign='top'>" + income + "</td><td valign='top'>" + expence + "</td></tr>";
        lblHtml.Text += "<tr><td valign='top'>" + incometotal + "</td><td valign='top'>" + expenceTotal + "</td></tr>";
        lblHtml.Text += "<tr><td colspan='2' align='center'>" + closinging + "</td></tr>";
    }


}