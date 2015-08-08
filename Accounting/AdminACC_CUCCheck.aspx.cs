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
 public partial class AdminACC_CUCCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_CUCCheckData();
         		BankAccountIDLoad();
		PaytoHeadIDLoad();
		JournalIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_CUCCheckData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck ();
//	aCC_CUCCheck.CUCCheckID=  int.Parse(ddlCUCCheckID.SelectedValue);
	aCC_CUCCheck.CUCCheckName=  txtCUCCheckName.Text;
	aCC_CUCCheck.CUCCheckNo=  txtCUCCheckNo.Text;
	aCC_CUCCheck.BankAccountID=  int.Parse(ddlBankAccountID.SelectedValue);
	aCC_CUCCheck.CheckDate=   DateTime.Parse(txtCheckDate.Text);
	aCC_CUCCheck.PaytoHeadID=  int.Parse(ddlPaytoHeadID.SelectedValue);
	aCC_CUCCheck.JournalID=  int.Parse(ddlJournalID.SelectedValue);
	aCC_CUCCheck.Amount=  decimal.Parse(txtAmount.Text);
	aCC_CUCCheck.ExtraField1=  txtExtraField1.Text;
	aCC_CUCCheck.ExtraField2=  txtExtraField2.Text;
	aCC_CUCCheck.ExtraField3=  txtExtraField3.Text;
	aCC_CUCCheck.ExtraField4=  txtExtraField4.Text;
	aCC_CUCCheck.ExtraField5=  txtExtraField5.Text;
	aCC_CUCCheck.AddedBy=  Profile.card_id;
	aCC_CUCCheck.AddedDate=  DateTime.Now;
	aCC_CUCCheck.UpdatedBy=  Profile.card_id;
	aCC_CUCCheck.UpdatedDate=  DateTime.Now;
	aCC_CUCCheck.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_CUCCheckManager.InsertACC_CUCCheck(aCC_CUCCheck);
	Response.Redirect("AdminDisplayACC_CUCCheck.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_CUCCheck aCC_CUCCheck = new ACC_CUCCheck ();
	aCC_CUCCheck.CUCCheckID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_CUCCheck.CUCCheckName=  txtCUCCheckName.Text;
	aCC_CUCCheck.CUCCheckNo=  txtCUCCheckNo.Text;
	aCC_CUCCheck.BankAccountID=  int.Parse(ddlBankAccountID.SelectedValue);
	aCC_CUCCheck.CheckDate=   DateTime.Parse(txtCheckDate.Text);
	aCC_CUCCheck.PaytoHeadID=  int.Parse(ddlPaytoHeadID.SelectedValue);
	aCC_CUCCheck.JournalID=  int.Parse(ddlJournalID.SelectedValue);
	aCC_CUCCheck.Amount=  decimal.Parse(txtAmount.Text);
	aCC_CUCCheck.ExtraField1=  txtExtraField1.Text;
	aCC_CUCCheck.ExtraField2=  txtExtraField2.Text;
	aCC_CUCCheck.ExtraField3=  txtExtraField3.Text;
	aCC_CUCCheck.ExtraField4=  txtExtraField4.Text;
	aCC_CUCCheck.ExtraField5=  txtExtraField5.Text;
	aCC_CUCCheck.AddedBy=  Profile.card_id;
	aCC_CUCCheck.AddedDate=  DateTime.Now;
	aCC_CUCCheck.UpdatedBy=  Profile.card_id;
	aCC_CUCCheck.UpdatedDate=  DateTime.Now;
	aCC_CUCCheck.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_CUCCheckManager.UpdateACC_CUCCheck(aCC_CUCCheck);
	Response.Redirect("AdminDisplayACC_CUCCheck.aspx");
	}
	private void showACC_CUCCheckData()
	{
	 	ACC_CUCCheck aCC_CUCCheck  = new ACC_CUCCheck ();
	 	aCC_CUCCheck = ACC_CUCCheckManager.GetACC_CUCCheckByCUCCheckID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCUCCheckName.Text =aCC_CUCCheck.CUCCheckName.ToString();
	 	txtCUCCheckNo.Text =aCC_CUCCheck.CUCCheckNo.ToString();
	 	ddlBankAccountID.SelectedValue  =aCC_CUCCheck.BankAccountID.ToString();
	 	txtCheckDate.Text =aCC_CUCCheck.CheckDate.ToString();
	 	ddlPaytoHeadID.SelectedValue  =aCC_CUCCheck.PaytoHeadID.ToString();
	 	ddlJournalID.SelectedValue  =aCC_CUCCheck.JournalID.ToString();
	 	txtAmount.Text =aCC_CUCCheck.Amount.ToString();
	 	txtExtraField1.Text =aCC_CUCCheck.ExtraField1.ToString();
	 	txtExtraField2.Text =aCC_CUCCheck.ExtraField2.ToString();
	 	txtExtraField3.Text =aCC_CUCCheck.ExtraField3.ToString();
	 	txtExtraField4.Text =aCC_CUCCheck.ExtraField4.ToString();
	 	txtExtraField5.Text =aCC_CUCCheck.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_CUCCheck.RowStatusID.ToString();
	}
	
	private void BankAccountIDLoad()
	{
		try {
		DataSet ds = ACC_BankAccountManager.GetDropDownListAllACC_BankAccount();
		ddlBankAccountID.DataValueField = "BankAccountID";
		ddlBankAccountID.DataTextField = "BankAccountName";
		ddlBankAccountID.DataSource = ds.Tables[0];
		ddlBankAccountID.DataBind();
		ddlBankAccountID.Items.Insert(0, new ListItem("Select BankAccount >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void PaytoHeadIDLoad()
	{
		try {
		DataSet ds = ACC_PaytoHeadManager.GetDropDownListAllACC_PaytoHead();
		ddlPaytoHeadID.DataValueField = "PaytoHeadID";
		ddlPaytoHeadID.DataTextField = "PaytoHeadName";
		ddlPaytoHeadID.DataSource = ds.Tables[0];
		ddlPaytoHeadID.DataBind();
		ddlPaytoHeadID.Items.Insert(0, new ListItem("Select PaytoHead >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void JournalIDLoad()
	{
		try {
		DataSet ds = ACC_JournalManager.GetDropDownListAllACC_Journal();
		ddlJournalID.DataValueField = "JournalID";
		ddlJournalID.DataTextField = "JournalName";
		ddlJournalID.DataSource = ds.Tables[0];
		ddlJournalID.DataBind();
		ddlJournalID.Items.Insert(0, new ListItem("Select Journal >>", "0"));
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

