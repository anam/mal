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
 public partial class AdminHR_Bank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadHR_BankData();
         		EmployeeIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_BankData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
    HR_BankAccount hR_Bank = new HR_BankAccount();
    //hR_Bank.BankAccountNoID = int.Parse(ddlBankAccountNoID.SelectedValue);
	hR_Bank.EmployeeID=  ddlEmployeeID.SelectedValue;
	hR_Bank.AccountName=  txtBankAccountName.Text;
	hR_Bank.BankName=  txtBankName.Text;
	hR_Bank.BankAddress=  txtBankAddress.Text;
    hR_Bank.ContactPerson = txtBankTelephone.Text;
	hR_Bank.AddedBy=  Profile.card_id;
	hR_Bank.AddedDate=  DateTime.Now;
	hR_Bank.ModifiedBy=  Profile.card_id;
	hR_Bank.ModifiedDate=  DateTime.Now;
	int resutl =HR_BankAccountManager.InsertHR_BankAccount(hR_Bank);
	Response.Redirect("AdminDisplayHR_Bank.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_BankAccount hR_Bank = new HR_BankAccount ();
    hR_Bank.BankAccountNoID = int.Parse(Request.QueryString["ID"].ToString());
	hR_Bank.EmployeeID=  ddlEmployeeID.SelectedValue;
	hR_Bank.AccountName=  txtBankAccountName.Text;
	hR_Bank.BankName=  txtBankName.Text;
	hR_Bank.BankAddress=  txtBankAddress.Text;
    hR_Bank.ContactPerson = txtBankTelephone.Text;
	hR_Bank.AddedBy=  Profile.card_id;
	hR_Bank.AddedDate=  DateTime.Now;
	hR_Bank.ModifiedBy=  Profile.card_id;
	hR_Bank.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_BankAccountManager.UpdateHR_BankAccount(hR_Bank);
	Response.Redirect("AdminDisplayHR_Bank.aspx");
	}
	private void showHR_BankData()
	{
        HR_BankAccount hR_Bank = new HR_BankAccount();
        hR_Bank = HR_BankAccountManager.GetHR_BankAccountByBankAccountNoID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlEmployeeID.SelectedValue  =hR_Bank.EmployeeID.ToString();
	 	txtBankAccountName.Text =hR_Bank.AccountName.ToString();
	 	txtBankName.Text =hR_Bank.BankName.ToString();
	 	txtBankAddress.Text =hR_Bank.BankAddress.ToString();
        txtBankTelephone.Text = hR_Bank.ContactPerson.ToString();
	}
	
	private void EmployeeIDLoad()
	{
		try {
		DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
		ddlEmployeeID.DataValueField = "EmployeeID";
		ddlEmployeeID.DataTextField = "EmployeeNameNo";
		ddlEmployeeID.DataSource = ds.Tables[0];
		ddlEmployeeID.DataBind();
		ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

