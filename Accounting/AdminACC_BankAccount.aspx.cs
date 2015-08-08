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
 public partial class AdminACC_BankAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_BankAccountData();
         		BankIDLoad();
		RowStatusIDLoad();
        ddlRowStatusID.SelectedIndex = 1;
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_BankAccountData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	        ACC_BankAccount aCC_BankAccount = new ACC_BankAccount ();
        //	aCC_BankAccount.BankAcountID=  int.Parse(ddlBankAcountID.SelectedValue);
	        aCC_BankAccount.BankAccountName=  txtBankAccountName.Text;
	        aCC_BankAccount.AccountNo=  txtAccountNo.Text;
	        aCC_BankAccount.BankID=  int.Parse(ddlBankID.SelectedValue);
	        aCC_BankAccount.BranchNOtherDetails=  txtBranchNOtherDetails.Text;
	        aCC_BankAccount.ExtraField1=  txtExtraField1.Text;
	        aCC_BankAccount.ExtraField2=  txtExtraField2.Text;
	        aCC_BankAccount.ExtraField3=  txtExtraField3.Text;
	        aCC_BankAccount.ExtraField4=  txtExtraField4.Text;
	        aCC_BankAccount.ExtraField5=  txtExtraField5.Text;
	        aCC_BankAccount.AddedBy=  Profile.card_id;
	        aCC_BankAccount.AddedDate=  DateTime.Now;
	        aCC_BankAccount.UpdatedBy=  Profile.card_id;
	        aCC_BankAccount.UpdateDate=  DateTime.Now;
	        aCC_BankAccount.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	        int resutl =ACC_BankAccountManager.InsertACC_BankAccount(aCC_BankAccount);
	        Response.Redirect("AdminDisplayACC_BankAccount.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_BankAccount aCC_BankAccount = new ACC_BankAccount ();
	aCC_BankAccount.BankAcountID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_BankAccount.BankAccountName=  txtBankAccountName.Text;
	aCC_BankAccount.AccountNo=  txtAccountNo.Text;
	aCC_BankAccount.BankID=  int.Parse(ddlBankID.SelectedValue);
	aCC_BankAccount.BranchNOtherDetails=  txtBranchNOtherDetails.Text;
	aCC_BankAccount.ExtraField1=  txtExtraField1.Text;
	aCC_BankAccount.ExtraField2=  txtExtraField2.Text;
	aCC_BankAccount.ExtraField3=  txtExtraField3.Text;
	aCC_BankAccount.ExtraField4=  txtExtraField4.Text;
	aCC_BankAccount.ExtraField5=  txtExtraField5.Text;
	aCC_BankAccount.AddedBy=  Profile.card_id;
	aCC_BankAccount.AddedDate=  DateTime.Now;
	aCC_BankAccount.UpdatedBy=  Profile.card_id;
	aCC_BankAccount.UpdateDate=  DateTime.Now;
	aCC_BankAccount.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_BankAccountManager.UpdateACC_BankAccount(aCC_BankAccount);
	Response.Redirect("AdminDisplayACC_BankAccount.aspx");
	}
	private void showACC_BankAccountData()
	{
	 	ACC_BankAccount aCC_BankAccount  = new ACC_BankAccount ();
	 	aCC_BankAccount = ACC_BankAccountManager.GetACC_BankAccountByBankAcountID(Int32.Parse(Request.QueryString["ID"]));
	 	txtBankAccountName.Text =aCC_BankAccount.BankAccountName.ToString();
	 	txtAccountNo.Text =aCC_BankAccount.AccountNo.ToString();
	 	ddlBankID.SelectedValue  =aCC_BankAccount.BankID.ToString();
	 	txtBranchNOtherDetails.Text =aCC_BankAccount.BranchNOtherDetails.ToString();
	 	txtExtraField1.Text =aCC_BankAccount.ExtraField1.ToString();
	 	txtExtraField2.Text =aCC_BankAccount.ExtraField2.ToString();
	 	txtExtraField3.Text =aCC_BankAccount.ExtraField3.ToString();
	 	txtExtraField4.Text =aCC_BankAccount.ExtraField4.ToString();
	 	txtExtraField5.Text =aCC_BankAccount.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_BankAccount.RowStatusID.ToString();
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

