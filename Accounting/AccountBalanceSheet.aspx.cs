using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Accounting_AccountBalanceSheet : System.Web.UI.Page
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


        decimal sumAssets = 0, sumCapital = 0, sumLiability=0;

        List<ACC_SubBasicAccount> assets = new List<ACC_SubBasicAccount>();
        List<ACC_SubBasicAccount> capital = new List<ACC_SubBasicAccount>();
        List<ACC_SubBasicAccount> liability = new List<ACC_SubBasicAccount>();

        List<ACC_SubBasicAccount> balanseSheet = new List<ACC_SubBasicAccount>();

        List<ACC_SubBasicAccount> subBasicAccounts = ACC_SubBasicAccountManager.ViewACC_BalanceSheetByDateRange(startDate, endDate);

        foreach (ACC_SubBasicAccount subBasicAccount in subBasicAccounts)
        {
            decimal credit = 0, debit = 0;
            string headName = "";
            if (subBasicAccount.BasicAccountID == 1)
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


                subBasicAccount.Asset = debit - credit;
                sumAssets = sumAssets + subBasicAccount.Asset;
                subBasicAccount.SumAsset = sumAssets;
                subBasicAccount.AssetAccountName = subBasicAccount.SubBasicAccountName;
                assets.Add(subBasicAccount);

            }

            else if (subBasicAccount.BasicAccountID == 4)
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


                subBasicAccount.Liability = credit - debit;
                sumLiability = sumLiability + subBasicAccount.Liability;
                subBasicAccount.SumLiability = sumLiability;
                subBasicAccount.LiabilityAccountName = subBasicAccount.SubBasicAccountName;
                liability.Add(subBasicAccount);
            }

            else if (subBasicAccount.BasicAccountID == 5)
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


                subBasicAccount.Capital = credit - debit;
                sumCapital = sumCapital + subBasicAccount.Capital;
                subBasicAccount.SumCapital = sumCapital;
                subBasicAccount.CapitalAccountName = subBasicAccount.SubBasicAccountName;
                capital.Add(subBasicAccount);
            }


        }


        ACC_SubBasicAccount subBasic = new ACC_SubBasicAccount();
        subBasic.StartDate = txtStartDate.Text;
        subBasic.EndDate = txtEndDate.Text;

        //if (sumExpense > 0 && sumIncome > sumExpense)
        //{
        //    subBasic.NetIncome = sumIncome - sumExpense;
        //}

        //else
        //{
        //    subBasic.NetIncome = 0;
        //}
        balanseSheet.Add(subBasic);

        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/BalanceSheetView.rpt"));

        rptDoc.OpenSubreport("AssetBalanceSheet.rpt").SetDataSource(assets);

        rptDoc.OpenSubreport("CapitalBalanceSheet.rpt").SetDataSource(capital);
        rptDoc.OpenSubreport("LiabilityBalanceSheet.rpt").SetDataSource(liability);

        rptDoc.SetDataSource(balanseSheet);

        this.crvBalanceSheet.EnableDatabaseLogonPrompt = false;
        crvBalanceSheet.ReportSource = rptDoc;
        crvBalanceSheet.Zoom(83);
    }
    protected void btnBalanceSheet_OnClick(object sender, EventArgs e)
    {
        _loadReport();
    }
}