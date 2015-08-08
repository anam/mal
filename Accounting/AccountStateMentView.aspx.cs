using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Accounting_AccountStateMentView : System.Web.UI.Page
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
            endDate = txtEndDate.Text != "" ? Convert.ToDateTime(txtEndDate.Text) : DateTime.Now;
        }
        catch (Exception ex)
        {
            endDate = DateTime.Now;
        }



        List<ACC_SubBasicAccount> suBasicAcc = new List<ACC_SubBasicAccount>();
        List<ACC_SubBasicAccount> subBasicAccounts = ACC_SubBasicAccountManager.ViewACC_BasicAccountStatementsByDateRange(startDate, endDate);

        foreach (ACC_SubBasicAccount subBasicAccount in subBasicAccounts)
        {
            decimal credit = 0, debit = 0;
            string headName = "";
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
            subBasicAccount.StartDate = txtStartDate.Text;
            subBasicAccount.EndDate = txtEndDate.Text;

            if (credit > debit)
            {
                subBasicAccount.Credit = credit - debit;
                subBasicAccount.Debit = 0;
            }
            else if (debit > credit)
            {
                subBasicAccount.Debit = debit - credit;
                subBasicAccount.Credit = 0;
            }
            else
            {
                subBasicAccount.Credit = 0;
                subBasicAccount.Debit = 0;
            }
            suBasicAcc.Add(subBasicAccount);

            
        }

        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/AccountStatement.rpt"));
        rptDoc.SetDataSource(suBasicAcc);

        //this.crvContact.EnableDatabaseLogonPrompt = false;
        crvAccountStatus.ReportSource = rptDoc;
        crvAccountStatus.Zoom(83);
    }
    protected void btnAccountStatementView_OnClick(object sender, EventArgs e)
    {
        _loadReport();
    }
}