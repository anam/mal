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
 public partial class AdminACC_Voucher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_VoucherData();
         		HeadIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_VoucherData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_Voucher aCC_Voucher = new ACC_Voucher ();
//	aCC_Voucher.VoucherID=  int.Parse(ddlVoucherID.SelectedValue);
	aCC_Voucher.VoucherNo=  txtVoucherNo.Text;
	aCC_Voucher.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_Voucher.DebitOrCredit=  txtDebitOrCredit.Text;
	aCC_Voucher.FromTo=  txtFromTo.Text;
	aCC_Voucher.OnAccountOf=  txtOnAccountOf.Text;
	aCC_Voucher.InWord=  txtInWord.Text;
	aCC_Voucher.IsApproved=  bool.Parse( radIsApproved.SelectedValue);
	aCC_Voucher.ApprovalDate=   DateTime.Parse(txtApprovalDate.Text);
	aCC_Voucher.VoucherDate=   DateTime.Parse(txtVoucherDate.Text);
	aCC_Voucher.AddedBy=  Profile.card_id;
	aCC_Voucher.AddedDate=  DateTime.Now;
	aCC_Voucher.UpdatedBy=  Profile.card_id;
	aCC_Voucher.UpdateDate=  DateTime.Now;
	aCC_Voucher.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	aCC_Voucher.Remarks=  txtRemarks.Text;
	int resutl =ACC_VoucherManager.InsertACC_Voucher(aCC_Voucher);
	Response.Redirect("AdminDisplayACC_Voucher.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_Voucher aCC_Voucher = new ACC_Voucher ();
	aCC_Voucher.VoucherID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_Voucher.VoucherNo=  txtVoucherNo.Text;
	aCC_Voucher.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_Voucher.DebitOrCredit=  txtDebitOrCredit.Text;
	aCC_Voucher.FromTo=  txtFromTo.Text;
	aCC_Voucher.OnAccountOf=  txtOnAccountOf.Text;
	aCC_Voucher.InWord=  txtInWord.Text;
	aCC_Voucher.IsApproved=  bool.Parse( radIsApproved.SelectedValue);
	aCC_Voucher.ApprovalDate=   DateTime.Parse(txtApprovalDate.Text);
	aCC_Voucher.VoucherDate=   DateTime.Parse(txtVoucherDate.Text);
	aCC_Voucher.AddedBy=  Profile.card_id;
	aCC_Voucher.AddedDate=  DateTime.Now;
	aCC_Voucher.UpdatedBy=  Profile.card_id;
	aCC_Voucher.UpdateDate=  DateTime.Now;
	aCC_Voucher.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	aCC_Voucher.Remarks=  txtRemarks.Text;
	bool  resutl =ACC_VoucherManager.UpdateACC_Voucher(aCC_Voucher);
	Response.Redirect("AdminDisplayACC_Voucher.aspx");
	}
	private void showACC_VoucherData()
	{
	 	ACC_Voucher aCC_Voucher  = new ACC_Voucher ();
	 	aCC_Voucher = ACC_VoucherManager.GetACC_VoucherByVoucherID(Int32.Parse(Request.QueryString["ID"]));
	 	txtVoucherNo.Text =aCC_Voucher.VoucherNo.ToString();
	 	ddlHeadID.SelectedValue  =aCC_Voucher.HeadID.ToString();
	 	txtDebitOrCredit.Text =aCC_Voucher.DebitOrCredit.ToString();
	 	txtFromTo.Text =aCC_Voucher.FromTo.ToString();
	 	txtOnAccountOf.Text =aCC_Voucher.OnAccountOf.ToString();
	 	txtInWord.Text =aCC_Voucher.InWord.ToString();
	 	 radIsApproved.SelectedValue  =aCC_Voucher.IsApproved.ToString();
	 	txtApprovalDate.Text =aCC_Voucher.ApprovalDate.ToString();
	 	txtVoucherDate.Text =aCC_Voucher.VoucherDate.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_Voucher.RowStatusID.ToString();
	 	txtRemarks.Text =aCC_Voucher.Remarks.ToString();
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

