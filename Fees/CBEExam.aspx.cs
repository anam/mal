using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Fees_CBEExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadBank();
            txtFromDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            txtToDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            txtDate.Text = DateTime.Today.ToString("dd MMM yyyy");
            txtExpenceDate.Text = DateTime.Today.ToString("dd MMM yyyy");
        }
    }

    private void loadBank()
    {
        string sql = @"Select distinct AccountFor from STD_CBEExamAcc where Head like 'Bank%' order by AccountFor
            Select distinct AccountFor from STD_CBEExamAcc where Head not like 'Bank%' and Head <> 'Exam Fees' order by AccountFor";

        DataSet ds = CommonManager.SQLExec(sql);
        ddlBank.Items.Clear();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ddlBank.Items.Add(new ListItem(dr["AccountFor"].ToString(), dr["AccountFor"].ToString()));
        }

        ddlHead.Items.Clear();
        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            ddlHead.Items.Add(new ListItem(dr["AccountFor"].ToString(), dr["AccountFor"].ToString()));
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string sql = @"
INSERT INTO [STD_CBEExamAcc]
           ([Head]
           ,[AccountFor]
           ,[Amount]
           ,[AddedDate]
           ,[AddedBy]
           ,[IsOpiningOrClosingAcc])
     VALUES
           ('Bank " + (chkisDeposit.Checked ? "Deposit" : "Withdraw") + "','" + (txtBankName.Text.Trim() == "" ? ddlBank.SelectedValue :  txtBankName.Text ) + @"'
," + (chkisDeposit.Checked ? "-" : "") + txtAmount.Text + ",'" + DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd") + @"','" + Profile.FirstName + @"',0);
";
        CommonManager.SQLExec(sql);
        txtAmount.Text = "";

        loadBank();
    }
    protected void btnOtherAccounts_Click(object sender, EventArgs e)
    {
        string sql = @"
INSERT INTO [STD_CBEExamAcc]
           ([Head]
           ,[AccountFor]
           ,[Amount]
           ,[AddedDate]
           ,[AddedBy]
           ,[IsOpiningOrClosingAcc])
     VALUES
           ('Other " + (chkExpence.Checked ? "Expence" : "Income") + "','" + (txtNewHead.Text.Trim() == "" ? ddlHead.SelectedValue : txtNewHead.Text) + @"'
," + (chkExpence.Checked ? "-" : "") + txtExpenceAmount.Text + ",'" + DateTime.Parse(txtExpenceDate.Text).ToString("yyyy-MM-dd") + @"','" + Profile.FirstName + @"',0);
";
        CommonManager.SQLExec(sql);
        txtExpenceAmount.Text = "";
        loadBank();
    }
    protected void btnReprt_Click(object sender, EventArgs e)
    {
        lblLink.Text = "<a target='_blank' href='CBEExamTransactionSummary.aspx?fromdate=" + DateTime.Parse(txtFromDate.Text).ToString("yyyy-MM-dd") + @"&todate=" + DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd") + @"'>Print Transation Summary</a>";
    }
}