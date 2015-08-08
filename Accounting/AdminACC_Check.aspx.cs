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
 public partial class AdminACC_Check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_CheckData();
         		BankIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_CheckData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_Check aCC_Check = new ACC_Check ();
//	aCC_Check.CheckID=  int.Parse(ddlCheckID.SelectedValue);
	aCC_Check.CheckNo=  txtCheckNo.Text;
	aCC_Check.BankAccountNo=  txtBankAccountNo.Text;
	aCC_Check.BankID=  int.Parse(ddlBankID.SelectedValue);
	aCC_Check.BranchNOtherDetails=  txtBranchNOtherDetails.Text;
	aCC_Check.Remarks=  txtRemarks.Text;
	aCC_Check.IsCashCheck=  bool.Parse( radIsCashCheck.SelectedValue);
	aCC_Check.ExtraField1=  txtExtraField1.Text;
	aCC_Check.ExtraField2=  txtExtraField2.Text;
	aCC_Check.ExtraField3=  txtExtraField3.Text;
	aCC_Check.ExtraField4=  txtExtraField4.Text;
	aCC_Check.ExtraField5=  txtExtraField5.Text;
	aCC_Check.AddedBy=  Profile.card_id;
	aCC_Check.AddedDate=  DateTime.Now;
	aCC_Check.UpdatedBy=  Profile.card_id;
	aCC_Check.UpdateDate=  DateTime.Now;
	aCC_Check.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_CheckManager.InsertACC_Check(aCC_Check);
	Response.Redirect("AdminDisplayACC_Check.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_Check aCC_Check = new ACC_Check ();
	aCC_Check.CheckID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_Check.CheckNo=  txtCheckNo.Text;
	aCC_Check.BankAccountNo=  txtBankAccountNo.Text;
	aCC_Check.BankID=  int.Parse(ddlBankID.SelectedValue);
	aCC_Check.BranchNOtherDetails=  txtBranchNOtherDetails.Text;
	aCC_Check.Remarks=  txtRemarks.Text;
	aCC_Check.IsCashCheck=  bool.Parse( radIsCashCheck.SelectedValue);
	aCC_Check.ExtraField1=  txtExtraField1.Text;
	aCC_Check.ExtraField2=  txtExtraField2.Text;
	aCC_Check.ExtraField3=  txtExtraField3.Text;
	aCC_Check.ExtraField4=  txtExtraField4.Text;
	aCC_Check.ExtraField5=  txtExtraField5.Text;
	aCC_Check.AddedBy=  Profile.card_id;
	aCC_Check.AddedDate=  DateTime.Now;
	aCC_Check.UpdatedBy=  Profile.card_id;
	aCC_Check.UpdateDate=  DateTime.Now;
	aCC_Check.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_CheckManager.UpdateACC_Check(aCC_Check);
	Response.Redirect("AdminDisplayACC_Check.aspx");
	}
	private void showACC_CheckData()
	{
	 	ACC_Check aCC_Check  = new ACC_Check ();
	 	aCC_Check = ACC_CheckManager.GetACC_CheckByCheckID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCheckNo.Text =aCC_Check.CheckNo.ToString();
	 	txtBankAccountNo.Text =aCC_Check.BankAccountNo.ToString();
	 	ddlBankID.SelectedValue  =aCC_Check.BankID.ToString();
	 	txtBranchNOtherDetails.Text =aCC_Check.BranchNOtherDetails.ToString();
	 	txtRemarks.Text =aCC_Check.Remarks.ToString();
	 	 radIsCashCheck.SelectedValue  =aCC_Check.IsCashCheck.ToString();
	 	txtExtraField1.Text =aCC_Check.ExtraField1.ToString();
	 	txtExtraField2.Text =aCC_Check.ExtraField2.ToString();
	 	txtExtraField3.Text =aCC_Check.ExtraField3.ToString();
	 	txtExtraField4.Text =aCC_Check.ExtraField4.ToString();
	 	txtExtraField5.Text =aCC_Check.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_Check.RowStatusID.ToString();
	}


    private void BankIDLoad()
    {
        try
        {

            DataSet ds = ACC_AccountingUserManager.GetACC_UserTypeByUserTypeID(3, true); //3 for user type Bank
            ddlBankID.DataValueField = "AccountingUserID";
            ddlBankID.DataTextField = "AccountingUserName";
            ddlBankID.DataSource = ds.Tables[0];
            ddlBankID.DataBind();
            ddlBankID.Items.Insert(0, new ListItem("Select Bank >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void RowStatusIDLoad()
    {
        try
        {
            DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
            ddlRowStatusID.DataValueField = "RowStatusID";
            ddlRowStatusID.DataTextField = "RowStatusName";
            ddlRowStatusID.DataSource = ds.Tables[0];
            ddlRowStatusID.DataBind();
            ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

