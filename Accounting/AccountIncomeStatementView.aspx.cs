using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Accounting_AccountIncomeStatementView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtStartDate.Text != "" && txtEndDate.Text != "")
        {
            _loadReport();
        }
    }

    public void _loadReport()
    {
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();
        try
        {
            startDate = txtStartDate.Text != "" ? Convert.ToDateTime(txtStartDate.Text) : DateTime.Parse("1 / 1 / 1753");
            startDate = startDate.AddDays(1);
        }
        catch (Exception ex)
        {
            startDate = DateTime.MinValue;
        }
        try
        {
            DateTime date = new DateTime();
            date = txtEndDate.Text != "" ? Convert.ToDateTime(txtEndDate.Text) : DateTime.Now.AddDays(1);
           endDate = date.AddDays(1);
        }
        catch (Exception ex)
        {
            endDate = DateTime.Now;
        }


        decimal sumIncome = 0, sumExpense = 0;

        List<ACC_SubBasicAccount> incomes = new List<ACC_SubBasicAccount>();
        List<ACC_SubBasicAccount> incomestatement = new List<ACC_SubBasicAccount>();
        List<ACC_SubBasicAccount> expenses = new List<ACC_SubBasicAccount>();
        List<ACC_SubBasicAccount> subBasicAccounts = ACC_SubBasicAccountManager.ViewACC_IncomeStatementsByDateRange(startDate, endDate);

        foreach (ACC_SubBasicAccount subBasicAccount in subBasicAccounts)
        {
            decimal credit = 0, debit = 0;
            string headName = "";
            if (subBasicAccount.BasicAccountID == 3)
            {
                List<ACC_Account> accounts = ACC_AccountManager.GetAllAccountBySubBasicAccountID(subBasicAccount.SubBasicAccountID);

                foreach (ACC_Account account in accounts)
                {


                    List<ACC_Journal> accountJournals = ACC_JournalManager.ViewAllACC_JournalsByAccountID(account.AccountID, startDate, endDate);


                    foreach (ACC_Journal accountJournal in accountJournals)
                    {
                        credit = credit + accountJournal.Credit;
                        debit = debit + accountJournal.Debit;
                        headName = accountJournal.HeadName;
                    }
                }
                subBasicAccount.HeadName = headName;


                subBasicAccount.SubBasicAccountName = ACC_SubBasicAccountManager.GetACC_SubBasicAccountBySubBasicAccountID(subBasicAccount.SubBasicAccountID).SubBasicAccountName;
               

                subBasicAccount.Income = credit - debit;
                sumIncome = sumIncome + subBasicAccount.Income;
               
                subBasicAccount.IncomeAccountName = subBasicAccount.SubBasicAccountName;
                incomes.Add(subBasicAccount);
               
            }

            else if (subBasicAccount.BasicAccountID == 2)
            {
                List<ACC_Account> accounts = ACC_AccountManager.GetAllAccountBySubBasicAccountID(subBasicAccount.SubBasicAccountID);

                foreach (ACC_Account account in accounts)
                {


                    List<ACC_Journal> accountJournals = ACC_JournalManager.ViewAllACC_JournalsByAccountID(account.AccountID, startDate, endDate);


                    foreach (ACC_Journal accountJournal in accountJournals)
                    {
                        credit = credit + accountJournal.Credit;
                        debit = debit + accountJournal.Debit;
                        headName = accountJournal.HeadName;
                    }
                }
                subBasicAccount.HeadName = headName;


                subBasicAccount.SubBasicAccountName = ACC_SubBasicAccountManager.GetACC_SubBasicAccountBySubBasicAccountID(subBasicAccount.SubBasicAccountID).SubBasicAccountName;


                subBasicAccount.Expense = credit - debit;
                sumExpense = (sumExpense + subBasicAccount.Expense);
                //subBasicAccount.SumExpense = sumExpense; 
                subBasicAccount.ExpenseAccountName = subBasicAccount.SubBasicAccountName;
                expenses.Add(subBasicAccount);
            }

        }

        ACC_SubBasicAccount subBasic = new ACC_SubBasicAccount();
        subBasic.StartDate = txtStartDate.Text;
        subBasic.EndDate = txtEndDate.Text;

        subBasic.SumIncome = sumIncome;

        subBasic.SumExpense = sumExpense * (-1);

        subBasic.NetIncome = sumIncome - subBasic.SumExpense;
        
        incomestatement.Add(subBasic);

        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/IncomeStatementView.rpt"));

        rptDoc.OpenSubreport("IncomeStateMentDebit.rpt").SetDataSource(expenses);

        rptDoc.OpenSubreport("IncomeStateMentCredit.rpt").SetDataSource(incomes);


        rptDoc.SetDataSource(incomestatement);

        this.crvIncomeStatement.EnableDatabaseLogonPrompt = false;
        crvIncomeStatement.ReportSource = rptDoc;
        crvIncomeStatement.Zoom(83);
    }
    protected void btnIncomeStatement_OnClick(object sender, EventArgs e)
    {
        _loadReport();
    }
}