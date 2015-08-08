using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string fromMonth = "";
            string toMonth = "";
            string fromYear = "";
            string toYear= "";

            if (Request.QueryString["FromMonth"] != null)
            {
                fromMonth = Request.QueryString["FromMonth"];
            }
            if (Request.QueryString["ToMonth"] != null)
            {
                toMonth = Request.QueryString["ToMonth"];
            }
            if (Request.QueryString["FromYear"] != null)
            {
                fromYear = Request.QueryString["FromYear"];
            }
            if (Request.QueryString["ToYear"] != null)
            {
                toYear = Request.QueryString["ToYear"];
            }

            loadHtmlText(fromMonth, fromYear, toMonth, toYear);
        }
    }

    private void loadHtmlText(string fromMonth, string fromYear, string toMonth, string toYear)
    {
    
        string SQL_Final = "";
        string fromDate = fromYear + "-" + fromMonth + "-01 00:00:00";
        string toDate = DateTime.Parse(toYear + "-" + toMonth + "-01 00:00:00").AddMonths(1).ToString("yyyy-MM-dd") + " 00:00:00";


        string SQL_Top = @" Select SUM(Credit - Debit) Balance, 
	                            ACC_Account.AccountName,
	                            ACC_SubBasicAccount.SubBasicAccountName,
	                            ACC_BasicAccount.BasicAccountName,
	                            ACC_Account.AccountID,
	                            ACC_SubBasicAccount.SubBasicAccountID,
	                            ACC_BasicAccount.BasicAccountID
                            from ACC_Journal 
                            inner join ACC_Head on ACC_Head.HeadID = ACC_Journal.HeadID
                            inner join ACC_Account on ACC_Account.AccountID = ACC_Head.AccountID
                            inner join ACC_SubBasicAccount on ACC_SubBasicAccount.SubBasicAccountID = ACC_Account.SubBasicAccountID 
                            inner join ACC_BasicAccount on ACC_BasicAccount.BasicAccountID = ACC_SubBasicAccount.BasicAccountID";


        string SQL_Bottom = @" group by ACC_Account.AccountName,ACC_Account.AccountID,ACC_Account.SubBasicAccountID,ACC_BasicAccount.BasicAccountName,
                    ACC_SubBasicAccount.SubBasicAccountName,ACC_SubBasicAccount.SubBasicAccountID,ACC_BasicAccount.BasicAccountID
                    order by ACC_BasicAccount.BasicAccountID desc, ACC_Account.SubBasicAccountID, ACC_Account.AccountID;";

        bool isSingle = false;

        SQL_Final += SQL_Top + " where " + (Request.QueryString["WithDevelopmentFund"] == "0,0" ? "ACC_SubBasicAccount.SubBasicAccountID <> 36 and" : "") + "  (ACC_BasicAccount.BasicAccountID in (2,3) or ACC_Account.AccountID in (46,47,49,50,88,89)) and ACC_Journal.UpdateDate >= '" + fromDate + "' and ACC_Journal.UpdateDate < '" + toDate + "'" + SQL_Bottom;

        if (fromMonth == toMonth && fromYear == toYear)
        {
            isSingle = true;
        }
        else
        {
            for (int i = 0; DateTime.Parse(toDate) > DateTime.Parse(fromDate).AddMonths(i); i++)
            {
                string from_date = DateTime.Parse(fromDate).AddMonths(i).ToString("yyyy-MM-dd") + " 00:00:00";
                string to_date = DateTime.Parse(fromDate).AddMonths(i + 1).ToString("yyyy-MM-dd") + " 00:00:00";
                SQL_Final += SQL_Top + " where " + (Request.QueryString["WithDevelopmentFund"] == "0,0" ? "ACC_SubBasicAccount.SubBasicAccountID <> 36 and" : "") + " (ACC_BasicAccount.BasicAccountID in (2,3) or ACC_Account.AccountID in (46,47,49,50,88,89))  and ACC_Journal.UpdateDate >= '" + from_date + "' and ACC_Journal.UpdateDate < '" + to_date + "'" + SQL_Bottom;
            }
        }

        DataSet ds = ACC_AccountingCommonManager.ExecSQL(SQL_Final);


        #region Employee Provident Fund
        /*
        2	49	Allowance (Provident Fund)
        4	47	Company Provident Fund
        2	50	Salary (Provident Fund)
        4	46	Employee Provident Fund
        2	88	Salary(Security Money)
        4	89	Security Money
         */

        for (int tbl = 0; tbl < ds.Tables.Count; tbl++)
        { 
            decimal	_2_49_Allowance_Provident_Fund =0;
            decimal _4_47_Company_Provident_Fund=0;
            decimal _2_50_Salary_Provident_Fund = 0;
            decimal _4_46_Employee_Provident_Fund = 0;
            decimal _2_88_Salary_Security_Money = 0;
            decimal _4_89_Security_Money = 0;

            foreach (DataRow dr in ds.Tables[tbl].Rows)
	        {
                if (dr["AccountID"].ToString() == "49")
                {
                    _2_49_Allowance_Provident_Fund =  decimal.Parse(dr["Balance"].ToString());
                    if (_2_49_Allowance_Provident_Fund < 0) _2_49_Allowance_Provident_Fund *= -1;
                }
                else
                    if (dr["AccountID"].ToString() == "47")
                    {
                        _4_47_Company_Provident_Fund = decimal.Parse(dr["Balance"].ToString());
                        if (_4_47_Company_Provident_Fund < 0) _4_47_Company_Provident_Fund *= -1;
                        dr.Delete();
                    }
                    else
                        if (dr["AccountID"].ToString() == "50")
                        {
                            _2_50_Salary_Provident_Fund = decimal.Parse(dr["Balance"].ToString());
                            if (_2_50_Salary_Provident_Fund < 0) _2_50_Salary_Provident_Fund *= -1;
                        }
                        else
                            if (dr["AccountID"].ToString() == "46")
                            {
                                _4_46_Employee_Provident_Fund = decimal.Parse(dr["Balance"].ToString());
                                if (_4_46_Employee_Provident_Fund < 0) _4_46_Employee_Provident_Fund *= -1;
                                dr.Delete();
                            }
                            else
                                if (dr["AccountID"].ToString() == "88")
                                {
                                    _2_88_Salary_Security_Money = decimal.Parse(dr["Balance"].ToString());
                                    if (_2_88_Salary_Security_Money < 0) _2_88_Salary_Security_Money *= -1;
                                }
                                else
                                    if (dr["AccountID"].ToString() == "89")
                                    {
                                        _4_89_Security_Money = decimal.Parse(dr["Balance"].ToString());
                                        if (_4_89_Security_Money < 0) _4_89_Security_Money *= -1;
                                        dr.Delete();
                                    }
	        }


            foreach (DataRow dr in ds.Tables[tbl].Rows)
            {
                try
                {
                    if (dr["AccountID"].ToString() == "49")
                    {
                        dr["Balance"] = _2_49_Allowance_Provident_Fund - _4_47_Company_Provident_Fund;
                    }
                    else
                        if (dr["AccountID"].ToString() == "50")
                        {
                            dr["Balance"] = _2_50_Salary_Provident_Fund - _4_46_Employee_Provident_Fund;

                        }
                        else
                            if (dr["AccountID"].ToString() == "88")
                            {
                                dr["Balance"] = _2_88_Salary_Security_Money - _4_89_Security_Money;
                            }
                }
                catch (Exception ex)
                { }
            }
        }
        #endregion


        List<ACC_JournalStatement> incomeStatement = new List<ACC_JournalStatement>();
        List<List<ACC_JournalStatement>> incomeStatements = new List<List<ACC_JournalStatement>>();

        decimal sumBasicAccount = 0;
        decimal sumSubBasicAccount = 0;
        
        decimal income = 0;
        decimal expence = 0;

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ACC_JournalStatement JournalStatement = new ACC_JournalStatement();
            
            try
            {
                JournalStatement.AccountID = int.Parse(dr["AccountID"].ToString());
                JournalStatement.Balance = decimal.Parse(dr["Balance"].ToString());
                if (JournalStatement.Balance < 0)
                {
                    JournalStatement.Balance *= -1;
                }
                else if (JournalStatement.Balance == 0)
                {
                    continue;
                }
                JournalStatement.AccountName = dr["AccountName"].ToString();
                JournalStatement.SubBasicAccountName = dr["SubBasicAccountName"].ToString();
                JournalStatement.BasicAccountName = dr["BasicAccountName"].ToString();
                JournalStatement.SubBasicAccountID = int.Parse(dr["SubBasicAccountID"].ToString());
                JournalStatement.BasicAccountID = int.Parse(dr["BasicAccountID"].ToString());
                if (incomeStatement.Count != 0)
                {
                    if (incomeStatement[incomeStatement.Count - 1].BasicAccountID == JournalStatement.BasicAccountID)
                    {
                        sumBasicAccount += JournalStatement.Balance;
                        if (incomeStatement[incomeStatement.Count - 1].SubBasicAccountID == JournalStatement.SubBasicAccountID)
                        {
                            sumSubBasicAccount += JournalStatement.Balance;
                        }
                        else
                        {
                            //ACC_JournalStatement JournalStatement1 = new ACC_JournalStatement();
                            incomeStatement.Add(new ACC_JournalStatement());
                            incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
                            incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                            incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
                            incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr class='SubTotal'><td class='Account_Head'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub Total:</td><td></td><td>" + sumSubBasicAccount.ToString("0,0") + "</td><td></td>";
                            sumSubBasicAccount = JournalStatement.Balance;


                            incomeStatement.Add(new ACC_JournalStatement());
                            incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
                            incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                            incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr class='SubBasicAccount'><td class='Account_Head'>" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td>";
                        }
                    }
                    else
                    {

                        //ACC_JournalStatement JournalStatement1 = new ACC_JournalStatement();
                        incomeStatement.Add(new ACC_JournalStatement());
                        incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
                        incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
                        incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr class='SubTotal'><td class='Account_Head'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub Total:</td><td></td><td>" + sumSubBasicAccount.ToString("0,0") + "</td><td></td>";
                        sumSubBasicAccount = JournalStatement.Balance;


                        incomeStatement.Add(new ACC_JournalStatement());
                        incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount = sumBasicAccount;
                        incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr style='background-color:Green;font-size:25px;'><td class='Account_Head'>Total Income:</td><td></td><td></td><td>" + sumBasicAccount.ToString("0,0") + "</td>";
                        income = sumBasicAccount;
                        sumBasicAccount = JournalStatement.Balance;

                        incomeStatement.Add(new ACC_JournalStatement());
                        incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr style='color:Red;font-size:35px;'><td class='Account_Head'>Expence:</td><td></td><td></td><td></td>";

                        incomeStatement.Add(new ACC_JournalStatement());
                        incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
                        incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr class='SubBasicAccount'><td class='Account_Head'>" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td>";

                    }
                }
                else
                {
                    incomeStatement.Add(new ACC_JournalStatement());
                    incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                    incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr  style='color:Green;font-size:35px;'><td class='Account_Head'>Income:</td><td></td><td></td><td></td>";

                    incomeStatement.Add(new ACC_JournalStatement());
                    incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = JournalStatement.SubBasicAccountID;
                    incomeStatement[incomeStatement.Count - 1].BasicAccountID = JournalStatement.BasicAccountID;
                    incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr class='SubBasicAccount'><td class='Account_Head'>" + JournalStatement.SubBasicAccountName + ":</td><td></td><td></td><td></td>";

                    sumBasicAccount += JournalStatement.Balance;
                    sumSubBasicAccount += JournalStatement.Balance;
                }
            }
            catch (Exception ex)
            { continue; }

            JournalStatement.htmlCode = "<tr><td class='Account_Head'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + JournalStatement.AccountName + ":</td><td>" + JournalStatement.Balance.ToString("0,0") + "</td><td></td><td></td>";
            incomeStatement.Add(JournalStatement);
        }

        incomeStatement.Add(new ACC_JournalStatement());
        incomeStatement[incomeStatement.Count - 1].BalanceSubBasicAccount = sumSubBasicAccount;
        incomeStatement[incomeStatement.Count - 1].BasicAccountID = incomeStatement[incomeStatement.Count - 2].BasicAccountID;
        incomeStatement[incomeStatement.Count - 1].SubBasicAccountID = incomeStatement[incomeStatement.Count - 2].SubBasicAccountID;
        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr class='SubTotal'><td class='Account_Head'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sub Total:</td><td></td><td>" + sumSubBasicAccount.ToString("0,0") + "</td><td></td>";


        incomeStatement.Add(new ACC_JournalStatement());
        incomeStatement[incomeStatement.Count - 1].BalanceBasicAccount = sumBasicAccount;
        incomeStatement[incomeStatement.Count - 1].BasicAccountID = incomeStatement[incomeStatement.Count - 2].BasicAccountID;
        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr  style='background-color:Red;font-size:25px;'><td class='Account_Head'>Total Expence:</td><td></td><td></td><td>" + sumBasicAccount.ToString("0,0") + "</td>";
        expence = sumBasicAccount;

        incomeStatement.Add(new ACC_JournalStatement());
        incomeStatement[incomeStatement.Count - 1].htmlCode = "<tr  style='font-size:25px;'><td class='Account_Head'>Net Income:</td><td colspan='3' style='background-color:" + ((income - expence) > 0 ? "Green":"Red" )+ "'>" + (income - expence).ToString("0,0") + "</td>";
        

        incomeStatements.Add(incomeStatement);

        //For other Month
        #region For other Month
        if (!isSingle)
        {
            for (int tbl = 1; tbl < ds.Tables.Count; tbl++)
            {
               
                //making a duplicate of The 1st list
                income = 0;
                expence = 0;
                decimal sumBasicAccountPerMonth = 0;
                decimal sumSubBasicAccountPerMonth = 0;
                for (int i = 0; i < incomeStatement.Count; i++)
			    {
                    if (i <= 1)
                    {
                        incomeStatement[i].htmlCode += "<td class='breakBorder'></td><td></td><td></td><td></td>";
                        continue;
                    }
                    
                    if (incomeStatement[i].AccountID != 0)
                    {
                        string htmlTmp = "<td class='breakBorder'>&nbsp;</td><td>0</td><td></td><td></td>";
                        foreach (DataRow dr in ds.Tables[tbl].Rows)
                        {
                            try
                            {
                                if (decimal.Parse(dr["Balance"].ToString()) < 0)
                                {
                                    dr["Balance"] = decimal.Parse(dr["Balance"].ToString()) * (-1);
                                }

                                if (dr["AccountID"].ToString() == incomeStatement[i].AccountID.ToString())
                                {
                                    sumBasicAccountPerMonth += decimal.Parse(dr["Balance"].ToString());
                                    sumSubBasicAccountPerMonth += decimal.Parse(dr["Balance"].ToString());

                                    htmlTmp = "<td  class='breakBorder'>&nbsp;</td><td>" + decimal.Parse(dr["Balance"].ToString()).ToString("0,0") + "</td><td></td><td></td>";
                                    //incomeStatement[i].htmlCode += "<td style='width:5px'></td><td>" + decimal.Parse(dr["Balance"].ToString()).ToString("0,0") + "</td><td></td><td></td>";
                                    break;
                                }
                            }
                            catch (Exception ex)
                            { }
                        }

                        incomeStatement[i].htmlCode += htmlTmp;

                    }
                    else if (incomeStatement[i].SubBasicAccountID != 0 && incomeStatement[i].BalanceSubBasicAccount == 0) //only Text
                    {
                        incomeStatement[i].htmlCode += "<td  class='breakBorder'>&nbsp;</td><td></td><td></td><td></td>";
                        continue;
                    }
                    else if (incomeStatement[i].SubBasicAccountID != 0 && incomeStatement[i].BalanceSubBasicAccount != 0)
                    {
                        incomeStatement[i].htmlCode += "<td  class='breakBorder'>&nbsp;</td><td></td><td>" + sumSubBasicAccountPerMonth.ToString("0,0") + "</td><td></td>";
                        sumSubBasicAccountPerMonth = 0 ;
                    }
                    else if (incomeStatement[i].BasicAccountID != 0 && incomeStatement[i].BalanceBasicAccount == 0) //only Text
                    {
                        incomeStatement[i].htmlCode += "<td  class='breakBorder'>&nbsp;</td><td></td><td></td><td></td>";
                        continue;
                    }
                    else if (incomeStatement[i].BasicAccountID != 0 && incomeStatement[i].BalanceBasicAccount != 0)
                    {
                        incomeStatement[i].htmlCode += "<td  class='breakBorder'>&nbsp;</td><td></td><td></td><td>" + sumBasicAccountPerMonth.ToString("0,0") + "</td>";
                        if (income == 0)
                        {
                            income = sumBasicAccountPerMonth;
                        }
                        else
                        {
                            expence = sumBasicAccountPerMonth;
                        }
                        sumBasicAccountPerMonth = 0;
                    }
                    else if (incomeStatement[i].BasicAccountID == 0 && incomeStatement[i].BalanceBasicAccount == 0)
                    { 
                        //last balance
                        incomeStatement[i].htmlCode += "<td  class='breakBorder'>&nbsp;</td><td colspan='3' style='background-color:" + ((income - expence) > 0 ? "Green" : "Red") + "'>" + (income - expence).ToString("0,0") + "</td>";
                    }
			    }               
            }
        }
        #endregion
        lblIncomeStatement.Text = "<table align='Center' cellspacing='0' cellpadding='0' border='2'>";
        string  bottomLine="<tr style='font-size:20px;'><td class='Account_Head' >----------------------------------</td><td colspan='3' style='text-align:center;'>" + DateTime.Parse(fromDate).ToString("MMMM, yyyy-dd").Split('-')[0] + " - " + DateTime.Parse(toDate).AddMonths(-1).ToString("MMMM, yyyy-dd").Split('-')[0] + "</td>";
        if (!isSingle)
        {
            for (int i = 0; DateTime.Parse(toDate) > DateTime.Parse(fromDate).AddMonths(i); i++)
            {
                 bottomLine += "<td  class='breakBorder'>&nbsp;</td><td colspan='3' style='text-align:center;'>" + DateTime.Parse(fromDate).AddMonths(i).ToString("MMMM, yyyy-dd").Split('-')[0] + "</td>";
            }
        }


        bottomLine +="</tr>";
        lblIncomeStatement.Text += bottomLine;

        for (int i = 0; i < incomeStatement.Count; i++)
        {
            if (i % 2 == 0)
            {
                lblIncomeStatement.Text += incomeStatement[i].htmlCode + "</tr>";
            }
            else
            {
                lblIncomeStatement.Text += incomeStatement[i].htmlCode.Replace("<tr>", "<tr style='background-color:#E8ECF4'>") + "</tr>";
            }
        }

        lblIncomeStatement.Text += bottomLine;

        lblIncomeStatement.Text += "</table>";

        lblIncomeStatement.Text = "<div align='Center'><h2>Income Statement</h2><h4>" + DateTime.Parse(fromDate).ToString("MMMM, yyyy-dd").Split('-')[0] + " - " + DateTime.Parse(toDate).AddMonths(-1).ToString("MMMM, yyyy-dd").Split('-')[0] + "</h4></div>" + lblIncomeStatement.Text;
    }
}