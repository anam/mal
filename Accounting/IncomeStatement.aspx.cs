using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;

public partial class Accounting_IncomeStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _loadMonths();
            _loadYears();
        }
    }

    private void _loadYears()
    {
        try
        {
            int firstYear = DateTime.Now.Year - 5;
            for (int i = 0; i < 20; i++)
            {
                ddlYearsFrom.Items.Add(new ListItem((firstYear + i).ToString()));
                ddlYearsTo.Items.Add(new ListItem((firstYear + i).ToString()));
            }

            ddlYearsFrom.Items.Insert(0, new ListItem("...Select Year...", "0"));
            ddlYearsFrom.SelectedValue = firstYear + 5 + "";

            ddlYearsTo.Items.Insert(0, new ListItem("...Select Year...", "0"));
            ddlYearsTo.SelectedValue = firstYear + 5 + "";
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
                ddlMonthsFrom.Items.Add(new ListItem(month.MonthName, month.Month.ToString()));
                ddlMonthsTo.Items.Add(new ListItem(month.MonthName, month.Month.ToString()));
            }

            ddlMonthsFrom.Items.Insert(0, new ListItem("...Select Month...", "0"));
            ddlMonthsFrom.SelectedValue = DateTime.Now.Month.ToString();

            ddlMonthsTo.Items.Insert(0, new ListItem("...Select Month...", "0"));
            ddlMonthsTo.SelectedValue = DateTime.Now.Month.ToString();

        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblPrint.Text = "<a target='_blank' href='IncomeStatementPrint.aspx?WithDevelopmentFund="+(chkShowCompanyDevelopmentFund.Checked?"1":"0")+"&FromMonth=" + ddlMonthsFrom.SelectedValue + "&ToMonth=" + ddlMonthsTo.SelectedValue + "&FromYear=" + ddlYearsFrom.SelectedValue + "&ToYear=" + ddlYearsTo.SelectedValue+"'>Click here to See the Statement</a>";
        
    }
//    protected void btnSearch_Click(object sender, EventArgs e)
//    {
//        string SQL_Final = "";
//        string fromDate = ddlYearsFrom.SelectedValue + "-" + ddlMonthsFrom.SelectedValue + "-01 00:00:00";
//        string toDate = DateTime.Parse(ddlYearsTo.SelectedValue + "-" + ddlMonthsTo.SelectedValue + "-01 00:00:00").AddMonths(1).ToString("yyyy-MM-dd") + " 00:00:00";

//        string SQL_Top = @" Select SUM(Credit - Debit) Balance, 
//	                            ACC_Account.AccountName,
//	                            ACC_SubBasicAccount.SubBasicAccountName,
//	                            ACC_BasicAccount.BasicAccountName,
//	                            ACC_Account.AccountID,
//	                            ACC_SubBasicAccount.SubBasicAccountID,
//	                            ACC_BasicAccount.BasicAccountID
//                            from ACC_Journal 
//                            inner join ACC_Head on ACC_Head.HeadID = ACC_Journal.HeadID
//                            inner join ACC_Account on ACC_Account.AccountID = ACC_Head.AccountID
//                            inner join ACC_SubBasicAccount on ACC_SubBasicAccount.SubBasicAccountID = ACC_Account.SubBasicAccountID 
//                            inner join ACC_BasicAccount on ACC_BasicAccount.BasicAccountID = ACC_SubBasicAccount.BasicAccountID";


//        string SQL_Bottom = @" group by ACC_Account.AccountName,ACC_Account.AccountID,ACC_Account.SubBasicAccountID,ACC_BasicAccount.BasicAccountName,
//                    ACC_SubBasicAccount.SubBasicAccountName,ACC_SubBasicAccount.SubBasicAccountID,ACC_BasicAccount.BasicAccountID
//                    order by ACC_BasicAccount.BasicAccountID desc, ACC_Account.SubBasicAccountID, ACC_Account.AccountID;";

//        bool isSingle = false;

//        SQL_Final += SQL_Top + " where ACC_BasicAccount.BasicAccountID in (2,3) and ACC_Journal.UpdateDate >= '" + fromDate + "' and ACC_Journal.UpdateDate < '" + toDate + "'" + SQL_Bottom;

//        if (ddlMonthsFrom.SelectedValue == ddlMonthsTo.SelectedValue && ddlYearsFrom.SelectedValue == ddlYearsTo.SelectedValue)
//        {
//            isSingle = true;
//        }
//        else
//        {
//            for (int i = 0; DateTime.Parse(toDate) > DateTime.Parse(fromDate).AddMonths(i); i++)
//            {
//                string from_date = DateTime.Parse(fromDate).AddMonths(i).ToString("yyyy-MM-dd") + " 00:00:00";
//                string to_date = DateTime.Parse(fromDate).AddMonths(i + 1).ToString("yyyy-MM-dd") + " 00:00:00";
//                SQL_Final += SQL_Top + " where  ACC_BasicAccount.BasicAccountID in (2,3) and ACC_Journal.UpdateDate >= '" + from_date + "' and ACC_Journal.UpdateDate < '" + to_date + "'" + SQL_Bottom;
//            }
//        }

//        DataSet ds = ACC_AccountingCommonManager.ExecSQL(SQL_Final);

//        List<ACC_JournalStatement> incomeStatement = new List<ACC_JournalStatement>();
//        List<List<ACC_JournalStatement>> incomeStatements = new List<List<ACC_JournalStatement>>();

//        decimal sumBasicAccount = 0;
//        decimal sumSubBasicAccount = 0;
//        string htmlString = @"<table border='2'><tr><td class='Account_Head'></td><td></td><td></td><td></td></tr>";

//        foreach (DataRow dr in ds.Tables[0].Rows)
//        {
//            ACC_JournalStatement JournalStatement = new ACC_JournalStatement();
//            JournalStatement.AccountID = int.Parse(dr["AccountID"].ToString());
//            JournalStatement.Balance = decimal.Parse(dr["Balance"].ToString());
//            JournalStatement.AccountName = dr["AccountName"].ToString();
//            JournalStatement.SubBasicAccountName = dr["SubBasicAccountName"].ToString();
//            JournalStatement.BasicAccountName = dr["BasicAccountName"].ToString();
//            JournalStatement.SubBasicAccountID = int.Parse(dr["SubBasicAccountID"].ToString());
//            JournalStatement.BasicAccountID = int.Parse(dr["BasicAccountID"].ToString());
//            if (incomeStatement.Count != 0)
//            {
//                if (incomeStatement[incomeStatement.Count - 1].BasicAccountID == JournalStatement.BasicAccountID)
//                {
//                    sumBasicAccount += JournalStatement.Balance;
//                    if (incomeStatement[incomeStatement.Count - 1].SubBasicAccountID == JournalStatement.SubBasicAccountID)
//                    {
//                        sumSubBasicAccount += JournalStatement.Balance;
//                    }
//                    else
//                    {
//                        //ACC_JournalStatement JournalStatement1 = new ACC_JournalStatement();
//                        incomeStatement.Add(new ACC_JournalStatement());
//                        incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
//                        incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                        incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
//                        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>--------Sub Total:</td><td></td><td>" + sumSubBasicAccount.ToString("0") + "</td><td></td>";
//                        htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode + "</tr>";
//                        sumSubBasicAccount = JournalStatement.Balance;


//                        incomeStatement.Add(new ACC_JournalStatement());
//                        incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
//                        incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>----" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td>";
//                        htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode + "</tr>";                        
//                    }
//                }
//                else
//                {

//                    //ACC_JournalStatement JournalStatement1 = new ACC_JournalStatement();
//                    incomeStatement.Add(new ACC_JournalStatement());
//                    incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
//                    incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
//                    incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                    incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>--------Sub Total:</td><td></td><td>" + sumSubBasicAccount.ToString("0") + "</td><td></td>";
//                    htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode+"</tr>";
//                    sumSubBasicAccount = JournalStatement.Balance;


//                    incomeStatement.Add(new ACC_JournalStatement());
//                    incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount = sumBasicAccount;
//                    incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                    incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>----Total Income:</td><td></td><td></td><td>" + sumBasicAccount.ToString("0") + "</td>";
//                    htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode+"</tr>";
//                    sumBasicAccount = JournalStatement.Balance;

//                    incomeStatement.Add(new ACC_JournalStatement());
//                    incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                    incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>Expence:</td><td></td><td></td><td></td>";
//                    htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode + "</tr>";                        
//                }
//            }
//            else
//            {
//                incomeStatement.Add(new ACC_JournalStatement());
//                incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>Income:</td><td></td><td></td><td></td>";
//                htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode + "</tr>";

//                incomeStatement.Add(new ACC_JournalStatement());
//                incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
//                incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
//                incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>----" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td>";
//                htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode + "</tr>"; 

//                sumBasicAccount += JournalStatement.Balance;
//                sumSubBasicAccount += JournalStatement.Balance;
//            }

//            JournalStatement.htmlCode = "<tr><td class='Account_Head'>--------" + JournalStatement.AccountName + ":</td><td>" + JournalStatement.Balance.ToString("0") + "</td><td></td><td></td>";
//            htmlString += JournalStatement.htmlCode + "</tr>";
//            incomeStatement.Add(JournalStatement);
//        }

//        incomeStatement.Add(new ACC_JournalStatement());
//        incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
//        incomeStatement[incomeStatement.Count - 1].BasicAccountID = incomeStatement[incomeStatement.Count - 2].BasicAccountID;
//        incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = incomeStatement[incomeStatement.Count - 2].SubBasicAccountID;
//        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>--------Sub Total:</td><td></td><td>" + sumSubBasicAccount.ToString("0") + "</td><td></td>";
//        htmlString += incomeStatement[incomeStatement.Count - 1].htmlCode + "</tr>";


//        incomeStatement.Add(new ACC_JournalStatement());
//        incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount = sumBasicAccount;
//        incomeStatement[incomeStatement.Count - 1].BasicAccountID = incomeStatement[incomeStatement.Count - 2].BasicAccountID;
//        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr><td class='Account_Head'>----Total Expence:</td><td></td><td></td><td>" + sumBasicAccount.ToString("0") + "</td>";
//        htmlString +=incomeStatement[incomeStatement.Count - 1].htmlCode+ "</tr>";

//        incomeStatements.Add(incomeStatement);

//        //For other Month
//        #region For other Month
//        if (!isSingle)
//        {
//            for (int tbl = 1; tbl < ds.Tables.Count; tbl++)
//            {
//                //making a duplicate of The 1st list
//                decimal sumBasicAccountPerMonth = 0;
//                decimal sumSubBasicAccountPerMonth = 0;
//                for (int i = 0; i < incomeStatement.Count; i++)
//                {
//                    if (i <= 1)
//                    {
//                        incomeStatement[i].htmlCode += "<td style='width:5px'></td><td></td><td></td><td></td>";
//                        continue;
//                    }

//                    if (incomeStatement[i].AccountID != 0)
//                    {
//                        string htmlTmp = "<td style='width:5px'></td><td>0</td><td></td><td></td>";
//                        foreach (DataRow dr in ds.Tables[tbl].Rows)
//                        {
//                            if (dr["AccountID"].ToString() == incomeStatement[i].AccountID.ToString())
//                            {
//                                sumBasicAccountPerMonth += decimal.Parse(dr["Balance"].ToString());
//                                sumSubBasicAccountPerMonth += decimal.Parse(dr["Balance"].ToString());

//                                htmlTmp = "<td style='width:5px'></td><td>" + decimal.Parse(dr["Balance"].ToString()).ToString("0") + "</td><td></td><td></td>";
//                                //incomeStatement[i].htmlCode += "<td style='width:5px'></td><td>" + decimal.Parse(dr["Balance"].ToString()).ToString("0") + "</td><td></td><td></td>";
//                                break;
//                            }
//                        }

//                        incomeStatement[i].htmlCode += htmlTmp;

//                    }
//                    else if (incomeStatement[i].SubBasicAccountID != 0 && incomeStatement[i].BalanceSubBasicAccount == 0) //only Text
//                    {
//                        incomeStatement[i].htmlCode += "<td style='width:5px'></td><td></td><td></td><td></td>";
//                        continue;
//                    }
//                    else if (incomeStatement[i].SubBasicAccountID != 0 && incomeStatement[i].BalanceSubBasicAccount != 0)
//                    {
//                        incomeStatement[i].htmlCode += "<td style='width:5px'></td><td>0</td><td>" + sumSubBasicAccountPerMonth.ToString("0") + "</td><td></td>";
//                        sumSubBasicAccountPerMonth = 0 ;
//                    }
//                    else if (incomeStatement[i].BasicAccountID != 0 && incomeStatement[i].BalanceBasicAccount == 0) //only Text
//                    {
//                        incomeStatement[i].htmlCode += "<td style='width:5px'></td><td></td><td></td><td></td>";
//                        continue;
//                    }
//                    else if (incomeStatement[i].BasicAccountID != 0 && incomeStatement[i].BalanceBasicAccount != 0)
//                    {
//                        incomeStatement[i].htmlCode += "<td style='width:5px'></td><td>0</td><td></td><td>" + sumBasicAccountPerMonth.ToString("0") + "</td>";
//                        sumBasicAccountPerMonth = 0;
//                    }
//                }               
//            }
//        }
//        #endregion
//        lblIncomeStatement.Text = "<table border='2'><tr><td class='Account_Head'></td><td></td><td></td><td></td>";
//        for (int i = 0; DateTime.Parse(toDate) > DateTime.Parse(fromDate).AddMonths(i); i++)
//        {
//            lblIncomeStatement.Text += "<td>&nbsp;</td><td colspan='3' style='text-align:center;'>" + DateTime.Parse(fromDate).AddMonths(i).ToString("MMMM, yyyy-dd").Split('-')[0] + "</td>";

//            //string from_date = DateTime.Parse(fromDate).AddMonths(i).ToString("yyyy-MM-dd") + " 00:00:00";
//            //string to_date = DateTime.Parse(fromDate).AddMonths(i + 1).ToString("yyyy-MM-dd") + " 00:00:00";
//            //SQL_Final += SQL_Top + " where  ACC_BasicAccount.BasicAccountID in (2,3) and ACC_Journal.UpdateDate >= '" + from_date + "' and ACC_Journal.UpdateDate < '" + to_date + "'" + SQL_Bottom;
//        }
        
//        for (int tbl = 1; tbl < ds.Tables.Count; tbl++)
//        {
//            lblIncomeStatement.Text += "<td>&nbsp;</td><td></td><td></td><td></td>";
//        }
//        lblIncomeStatement.Text +="</tr>";

//        for (int i = 0; i < incomeStatement.Count; i++)
//        {
//            lblIncomeStatement.Text += incomeStatement[i].htmlCode + "</tr>";
//        }

//        lblIncomeStatement.Text += "</table>";
//    }

//    protected void btnSearch_Click(object sender, EventArgs e)
//    {
//        string SQL_Final = "";
//        string fromDate = ddlYearsFrom.SelectedValue + "-" + ddlMonthsFrom.SelectedValue + "-01 00:00:00";
//        string toDate = DateTime.Parse(ddlYearsTo.SelectedValue + "-" + ddlMonthsTo.SelectedValue + "-01 00:00:00").AddMonths(1).ToString("yyyy-MM-dd") + " 00:00:00";

//        string SQL_Top = @" Select SUM(Credit - Debit) Balance, 
//	                            ACC_Account.AccountName,
//	                            ACC_SubBasicAccount.SubBasicAccountName,
//	                            ACC_BasicAccount.BasicAccountName,
//	                            ACC_Account.AccountID,
//	                            ACC_SubBasicAccount.SubBasicAccountID,
//	                            ACC_BasicAccount.BasicAccountID
//                            from ACC_Journal 
//                            inner join ACC_Head on ACC_Head.HeadID = ACC_Journal.HeadID
//                            inner join ACC_Account on ACC_Account.AccountID = ACC_Head.AccountID
//                            inner join ACC_SubBasicAccount on ACC_SubBasicAccount.SubBasicAccountID = ACC_Account.SubBasicAccountID 
//                            inner join ACC_BasicAccount on ACC_BasicAccount.BasicAccountID = ACC_SubBasicAccount.BasicAccountID";


//        string SQL_Bottom = @" group by ACC_Account.AccountName,ACC_Account.AccountID,ACC_Account.SubBasicAccountID,ACC_BasicAccount.BasicAccountName,
//                    ACC_SubBasicAccount.SubBasicAccountName,ACC_SubBasicAccount.SubBasicAccountID,ACC_BasicAccount.BasicAccountID
//                    order by ACC_BasicAccount.BasicAccountID desc, ACC_Account.SubBasicAccountID, ACC_Account.AccountID;";

//        bool isSingle = false;

//        SQL_Final += SQL_Top + " where ACC_BasicAccount.BasicAccountID in (2,3) and ACC_Journal.UpdateDate >= '" + fromDate + "' and ACC_Journal.UpdateDate < '" + toDate + "'" + SQL_Bottom;

//        if (ddlMonthsFrom.SelectedValue == ddlMonthsTo.SelectedValue && ddlYearsFrom.SelectedValue == ddlYearsTo.SelectedValue)
//        {
//            isSingle = true;
//        }
//        else
//        {
//            for (int i = 0; DateTime.Parse(toDate) > DateTime.Parse(fromDate).AddMonths(i); i++)
//            {
//                string from_date = DateTime.Parse(fromDate).AddMonths(i).ToString("yyyy-MM-dd") + " 00:00:00";
//                string to_date = DateTime.Parse(fromDate).AddMonths(i + 1).ToString("yyyy-MM-dd") + " 00:00:00";
//                SQL_Final += SQL_Top + " where ACC_Journal.UpdateDate >= '" + from_date + "' and ACC_Journal.UpdateDate < '" + to_date + "'" + SQL_Bottom;
//            }
//        }

//        DataSet ds = ACC_AccountingCommonManager.ExecSQL(SQL_Final);

//        List<ACC_JournalStatement> incomeStatement = new List<ACC_JournalStatement>();

//        decimal sumBasicAccount = 0;
//        decimal sumSubBasicAccount = 0;
//        string htmlString = @"<table><tr><td><table border='2'><tr><td class='Account_Head'></td><td></td><td></td><td></td></tr>";

//        foreach (DataRow dr in ds.Tables[0].Rows)
//        {


//            ACC_JournalStatement JournalStatement = new ACC_JournalStatement();
//            JournalStatement.AccountID = int.Parse(dr["AccountID"].ToString());
//            JournalStatement.Balance = decimal.Parse(dr["Balance"].ToString());
//            JournalStatement.AccountName = dr["AccountName"].ToString();
//            JournalStatement.SubBasicAccountName = dr["SubBasicAccountName"].ToString();
//            JournalStatement.BasicAccountName = dr["BasicAccountName"].ToString();
//            JournalStatement.SubBasicAccountID = int.Parse(dr["SubBasicAccountID"].ToString());
//            JournalStatement.BasicAccountID = int.Parse(dr["BasicAccountID"].ToString());
//            if (incomeStatement.Count != 0)
//            {
//                if (incomeStatement[incomeStatement.Count - 1].BasicAccountID == JournalStatement.BasicAccountID)
//                {
//                    sumBasicAccount += JournalStatement.Balance;
//                    if (incomeStatement[incomeStatement.Count - 1].SubBasicAccountID == JournalStatement.SubBasicAccountID)
//                    {
//                        sumSubBasicAccount += JournalStatement.Balance;
//                    }
//                    else
//                    {
//                        //ACC_JournalStatement JournalStatement1 = new ACC_JournalStatement();
//                        incomeStatement.Add(new ACC_JournalStatement());
//                        incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
//                        sumSubBasicAccount = JournalStatement.Balance;
//                        htmlString += "<tr><td class='Account_Head'>--------Sub Total:</td><td></td><td>" + incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount.ToString("0") + "</td><td></td></tr>";

//                        htmlString += "<tr><td class='Account_Head'>----" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td></tr>";
//                    }
//                }
//                else
//                {

//                    //ACC_JournalStatement JournalStatement1 = new ACC_JournalStatement();
//                    incomeStatement.Add(new ACC_JournalStatement());
//                    incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
//                    sumSubBasicAccount = JournalStatement.Balance;
//                    htmlString += "<tr><td class='Account_Head'>--------Sub Total:</td><td></td><td>" + incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount.ToString("0") + "</td><td></td></tr>";


//                    incomeStatement.Add(new ACC_JournalStatement());
//                    incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount = sumBasicAccount;
//                    sumBasicAccount = JournalStatement.Balance;
//                    htmlString += "<tr><td class='Account_Head'>----Total Income:</td><td></td><td></td><td>" + incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount.ToString("0") + "</td></tr>";

//                    htmlString += "</table></td><td><table><tr><td class='Account_Head'>Expence:</td><td></td><td></td><td></td></tr>";
//                }
//            }
//            else
//            {
//                htmlString += "<tr><td class='Account_Head'>Income:</td><td></td><td></td><td></td></tr>";
//                htmlString += "<tr><td class='Account_Head'>----" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td></tr>";

//                sumBasicAccount += JournalStatement.Balance;
//                sumSubBasicAccount += JournalStatement.Balance;
//            }

//            htmlString += "<tr><td class='Account_Head'>--------" + JournalStatement.AccountName + ":</td><td>" + JournalStatement.Balance.ToString("0") + "</td><td></td><td></td></tr>";
//            incomeStatement.Add(JournalStatement);
//        }

//        //last
//        incomeStatement.Add(new ACC_JournalStatement());
//        incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
//        htmlString += "<tr><td class='Account_Head'>--------Sub Total:</td><td></td><td>" + incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount.ToString("0") + "</td><td></td></tr>";


//        incomeStatement.Add(new ACC_JournalStatement());
//        incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount = sumBasicAccount;
//        htmlString += "<tr><td class='Account_Head'>----Total Expence:</td><td></td><td></td><td>" + incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount.ToString("0") + "</td></tr>";

//        //GridView1.DataSource = incomeStatement;

//        //GridView1.DataBind();

//        lblIncomeStatement.Text = htmlString + "</table></td><tr></table>";

//    }
}