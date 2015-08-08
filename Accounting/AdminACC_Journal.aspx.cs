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
 public partial class AdminACC_Journal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_JournalData();
         		HeadIDLoad();
		VoucherIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_JournalData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_Journal aCC_Journal = new ACC_Journal ();
//	aCC_Journal.JournalID=  int.Parse(ddlJournalID.SelectedValue);
	aCC_Journal.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_Journal.Debit=  decimal.Parse(txtDebit.Text);
	aCC_Journal.Credit=  decimal.Parse(txtCredit.Text);
	//aCC_Journal.VoucherID=  int.Parse(ddlVoucherID.SelectedValue);
	aCC_Journal.JournalVoucherNo=  txtJournalVoucherNo.Text;
	aCC_Journal.AddedBy=  Profile.card_id;
	aCC_Journal.AddedDate=  DateTime.Now;
	aCC_Journal.UpdatedBy=  Profile.card_id;
	aCC_Journal.UpdateDate=  DateTime.Now;
	aCC_Journal.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_JournalManager.InsertACC_Journal(aCC_Journal);
	Response.Redirect("AdminDisplayACC_Journal.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_Journal aCC_Journal = new ACC_Journal ();
	aCC_Journal.JournalID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_Journal.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_Journal.Debit=  decimal.Parse(txtDebit.Text);
	aCC_Journal.Credit=  decimal.Parse(txtCredit.Text);
	//aCC_Journal.VoucherID=  int.Parse(ddlVoucherID.SelectedValue);
	aCC_Journal.JournalVoucherNo=  txtJournalVoucherNo.Text;
	aCC_Journal.AddedBy=  Profile.card_id;
	aCC_Journal.AddedDate=  DateTime.Now;
	aCC_Journal.UpdatedBy=  Profile.card_id;
	aCC_Journal.UpdateDate=  DateTime.Now;
	aCC_Journal.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_JournalManager.UpdateACC_Journal(aCC_Journal);
	Response.Redirect("AdminDisplayACC_Journal.aspx");
	}
	private void showACC_JournalData()
	{
	 	ACC_Journal aCC_Journal  = new ACC_Journal ();
	 	aCC_Journal = ACC_JournalManager.GetACC_JournalByJournalID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlHeadID.SelectedValue  =aCC_Journal.HeadID.ToString();
	 	txtDebit.Text =aCC_Journal.Debit.ToString();
	 	txtCredit.Text =aCC_Journal.Credit.ToString();
	 	ddlVoucherID.SelectedValue  =aCC_Journal.JournalMasterID.ToString();
	 	txtJournalVoucherNo.Text =aCC_Journal.JournalVoucherNo.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_Journal.RowStatusID.ToString();
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
	private void VoucherIDLoad()
	{
		try {
		DataSet ds = ACC_VoucherManager.GetDropDownListAllACC_Voucher();
		ddlVoucherID.DataValueField = "VoucherID";
		ddlVoucherID.DataTextField = "VoucherName";
		ddlVoucherID.DataSource = ds.Tables[0];
		ddlVoucherID.DataBind();
		ddlVoucherID.Items.Insert(0, new ListItem("Select Voucher >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
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

