using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class Accounting_AccountJournalReportView : System.Web.UI.Page
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


        decimal sumCredit = 0, sumdebit = 0;

        List<ACC_Account> acc_credit = new List<ACC_Account>();
        List<ACC_Account> acc_debit = new List<ACC_Account>();
        List<ACC_Account> accounts = ACC_AccountManager.ViewAllACC_JournalsByAccountID(startDate, endDate);

        foreach (ACC_Account account in accounts)
        {
            decimal credit = 0, debit = 0;

            List<ACC_Journal> accountJournals = ACC_JournalManager.ViewAllACC_JournalsByAccountID(account.AccountID, startDate, endDate);

            
            account.StartDate = txtStartDate.Text;
            account.EndDate = txtEndDate.Text;
            foreach (ACC_Journal accountJournal in accountJournals)
            {
                credit = credit + accountJournal.Credit;
                debit = debit + accountJournal.Debit;
            }

           
           
            if (credit > debit)
            {
                account.CreditAccountName = ACC_AccountManager.GetACC_AccountByAccountID(account.AccountID).AccountName;
                account.DebitAccountName = "";
                account.Credit = credit - debit;
                account.Debit = 0;
                sumCredit = sumCredit + account.Credit;
                account.SumCredit = sumCredit;

                acc_credit.Add(account);
            }
            else if (debit > credit)
            {
                account.DebitAccountName = ACC_AccountManager.GetACC_AccountByAccountID(account.AccountID).AccountName;
                account.CreditAccountName = "";
                account.Debit = debit - credit;
                account.Credit = 0;
                sumdebit = sumdebit + account.Debit;
                account.SumDebit = sumdebit;
                acc_debit.Add(account);
            }
            else
            {
                account.CreditAccountName = "";
                account.DebitAccountName = "";
                account.Credit = 0;
                account.Debit = 0;
            }          
        }


        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/TrialBalanceView.rpt"));

        rptDoc.OpenSubreport("TrialBalanceDebitReport.rpt").SetDataSource(acc_debit);

        rptDoc.OpenSubreport("TrialBalanceCreditReportView.rpt").SetDataSource(acc_credit);


        rptDoc.SetDataSource(acc_credit);

        this.crvTrialBalance.EnableDatabaseLogonPrompt = false;
        crvTrialBalance.ReportSource = rptDoc;

        crvTrialBalance.Zoom(83);

    }
    protected void btnAccountJournalView_OnClick(object sender, EventArgs e)
    {
        _loadReport();
       
    }
}