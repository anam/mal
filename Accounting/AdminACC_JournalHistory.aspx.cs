using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
 public partial class AdminACC_JournalHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_JournalHistoryData();
         		HeadIDLoad();
		JournalMasterIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_JournalHistoryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory ();
//	aCC_JournalHistory.JournalID=  int.Parse(ddlJournalID.SelectedValue);
	aCC_JournalHistory.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_JournalHistory.Debit=  decimal.Parse(txtDebit.Text);
	aCC_JournalHistory.Credit=  decimal.Parse(txtCredit.Text);
	aCC_JournalHistory.JournalMasterID=  int.Parse(ddlJournalMasterID.SelectedValue);
	aCC_JournalHistory.JournalVoucherNo=  txtJournalVoucherNo.Text;
	aCC_JournalHistory.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	aCC_JournalHistory.AddedDate=  DateTime.Now;
	aCC_JournalHistory.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	aCC_JournalHistory.UpdateDate=  DateTime.Now;
	aCC_JournalHistory.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	aCC_JournalHistory.HistoryDate=   DateTime.Parse(txtHistoryDate.Text);
	aCC_JournalHistory.HistoryBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	int resutl =ACC_JournalHistoryManager.InsertACC_JournalHistory(aCC_JournalHistory);
	Response.Redirect("AdminDisplayACC_JournalHistory.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_JournalHistory aCC_JournalHistory = new ACC_JournalHistory ();
	aCC_JournalHistory.JournalID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_JournalHistory.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_JournalHistory.Debit=  decimal.Parse(txtDebit.Text);
	aCC_JournalHistory.Credit=  decimal.Parse(txtCredit.Text);
	aCC_JournalHistory.JournalMasterID=  int.Parse(ddlJournalMasterID.SelectedValue);
	aCC_JournalHistory.JournalVoucherNo=  txtJournalVoucherNo.Text;
	aCC_JournalHistory.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	aCC_JournalHistory.AddedDate=  DateTime.Now;
	aCC_JournalHistory.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	aCC_JournalHistory.UpdateDate=  DateTime.Now;
	aCC_JournalHistory.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	aCC_JournalHistory.HistoryDate=   DateTime.Parse(txtHistoryDate.Text);
	aCC_JournalHistory.HistoryBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	bool  resutl =ACC_JournalHistoryManager.UpdateACC_JournalHistory(aCC_JournalHistory);
	Response.Redirect("AdminDisplayACC_JournalHistory.aspx");
	}
	private void showACC_JournalHistoryData()
	{
	 	ACC_JournalHistory aCC_JournalHistory  = new ACC_JournalHistory ();
	 	aCC_JournalHistory = ACC_JournalHistoryManager.GetACC_JournalHistoryByJournalID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlHeadID.SelectedValue  =aCC_JournalHistory.HeadID.ToString();
	 	txtDebit.Text =aCC_JournalHistory.Debit.ToString();
	 	txtCredit.Text =aCC_JournalHistory.Credit.ToString();
	 	ddlJournalMasterID.SelectedValue  =aCC_JournalHistory.JournalMasterID.ToString();
	 	txtJournalVoucherNo.Text =aCC_JournalHistory.JournalVoucherNo.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_JournalHistory.RowStatusID.ToString();
	 	txtHistoryDate.Text =aCC_JournalHistory.HistoryDate.ToString();
	 	txtHistoryBy.Text =aCC_JournalHistory.HistoryBy.ToString();
	}
	
	private void HeadIDLoad()
	{
		try {
		DataSet ds = ACC_HeadManager.GetDropDownListAllACC_Head();
		ddlHeadID.DataValueField = "HeadID";
		ddlHeadID.DataTextField = "HeadName";
		ddlHeadID.DataSource = ds.Tables[0];
		ddlHeadID.DataBind();
		ddlHeadID.Items.Insert(0, new ListItem("Select Head >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void JournalMasterIDLoad()
	{
		try {
		DataSet ds = ACC_JournalMasterManager.GetDropDownListAllACC_JournalMaster();
		ddlJournalMasterID.DataValueField = "JournalMasterID";
		ddlJournalMasterID.DataTextField = "JournalMasterName";
		ddlJournalMasterID.DataSource = ds.Tables[0];
		ddlJournalMasterID.DataBind();
		ddlJournalMasterID.Items.Insert(0, new ListItem("Select JournalMaster >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = ACC_RowStatusManager.GetDropDownListAllACC_RowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

