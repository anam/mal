using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Accounting_AccountReportView : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BasicAccountIDLoad();
        }

        //if (ddlAccount.SelectedIndex != 0)
        //{
        //    _loadReport();
        //}
      
    }

    private void BasicAccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_BasicAccountManager.GetDropDownListAllACC_BasicAccount();
            ddlBasicAccountID.DataValueField = "BasicAccountID";
            ddlBasicAccountID.DataTextField = "BasicAccountName";
            ddlBasicAccountID.DataSource = ds.Tables[0];
            ddlBasicAccountID.DataBind();
            ddlBasicAccountID.Items.Insert(0, new ListItem("Select BasicAccount >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlBasicAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {

        SubBasicAccountIDLoad();
    }

    protected void ddlSubBasicAccountID_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccountIDLoad();
    }

    private void SubBasicAccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_SubBasicAccountManager.GetACC_SubBasicAccountByBasicAccountIDDataset(int.Parse(ddlBasicAccountID.SelectedValue));
            ddlSubBasicAccountID.DataValueField = "SubBasicAccountID";
            ddlSubBasicAccountID.DataTextField = "SubBasicAccountName";
            ddlSubBasicAccountID.DataSource = ds.Tables[0];
            ddlSubBasicAccountID.DataBind();
            ddlSubBasicAccountID.Items.Insert(0, new ListItem("Select SubBasicAccount >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void AccountIDLoad()
    {
        try
        {
            DataSet ds = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(int.Parse(ddlSubBasicAccountID.SelectedValue), true);
            ddlAccount.DataValueField = "AccountID";
            ddlAccount.DataTextField = "AccountName";
            ddlAccount.DataSource = ds.Tables[0];
            ddlAccount.DataBind();
            ddlAccount.Items.Insert(0, new ListItem("Select Account >>", "0"));

            
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
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

        decimal credit = 0;
        decimal debit = 0;

        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Accounting/Report/AccountView.rpt"));
        List<ACC_Journal> Journals = new List<ACC_Journal>();
        List<ACC_Journal> accountJournals = ACC_JournalManager.ViewAllACC_JournalsByAccountID(Convert.ToInt32(ddlAccount.SelectedValue), startDate, endDate);

        foreach (ACC_Journal accountJournal in accountJournals)
        {
            credit = credit + accountJournal.Credit;
            debit = debit + accountJournal.Debit;
            accountJournal.SumCredit = credit;
            accountJournal.SumDebit = debit;
            accountJournal.StartDate = txtStartDate.Text!=""?"From :"+" "+txtStartDate.Text:"";
            accountJournal.EndDate = txtEndDate.Text!=""?"To :"+" "+txtEndDate.Text:"";
            accountJournal.CreatedDate = accountJournal.AddedDate.ToString("dd MMM, yyyy");
            accountJournal.AccountName = ddlAccount.SelectedItem.Text;
            Journals.Add(accountJournal);
        }

        rptDoc.SetDataSource(Journals);

        //this.crvContact.EnableDatabaseLogonPrompt = false;
        crvAccountView.ReportSource = rptDoc;
        crvAccountView.Zoom(83);
  
    }

    private void load_Account()
    {
        ddlAccount.Items.Clear();
        ddlAccount.Items.Add(new ListItem("Select Account No...", "0"));
        ddlAccount.AppendDataBoundItems = true;

        DataSet ds = ACC_AccountManager.GetAllACC_Accounts();
        ddlAccount.DataValueField = "AccountID";
        ddlAccount.DataTextField = "AccountName";

        ddlAccount.DataSource = ds;
        ddlAccount.DataBind();
    }
    protected void btnAccountJournalView_OnClick(object sender, EventArgs e)
    {
        if (ddlAccount.Items.Count > 0)
        {
            if (ddlAccount.SelectedIndex != 0)
            {
                _loadReport();
            }
        }
    }
}