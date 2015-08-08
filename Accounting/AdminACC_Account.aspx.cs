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
 public partial class AdminACC_Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadACC_AccountData();
            BasicAccountIDLoad();
            SubBasicAccountIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showACC_AccountData();
            }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
            try
            {
                ACC_Account aCC_Account = new ACC_Account();
                //	aCC_Account.AccountID=  int.Parse(ddlAccountID.SelectedValue);
                aCC_Account.AccountName = txtAccountName.Text;
                aCC_Account.Description = txtDescription.Text;
                aCC_Account.SubBasicAccountID = int.Parse(ddlSubBasicAccountID.SelectedValue);
                aCC_Account.AccountCode ="";
                aCC_Account.AddedBy = Profile.card_id;
                aCC_Account.AddedDate = DateTime.Now;
                aCC_Account.UpdatedBy = Profile.card_id;
                aCC_Account.UpdateDate = DateTime.Now;
                aCC_Account.RowStatusID = 1;
                int resutl = ACC_AccountManager.InsertACC_Account(aCC_Account);
                Response.Redirect("AdminDisplayACC_Account.aspx");
            }
            catch (Exception ex)
            {
            }
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
            try
            {
                ACC_Account aCC_Account = new ACC_Account();
                aCC_Account.AccountID = int.Parse(Request.QueryString["ID"].ToString());
                aCC_Account.AccountName = txtAccountName.Text;
                aCC_Account.Description = txtDescription.Text;
                aCC_Account.SubBasicAccountID = int.Parse(ddlSubBasicAccountID.SelectedValue);
                aCC_Account.AccountCode = "";
                aCC_Account.AddedBy = Profile.card_id;
                aCC_Account.AddedDate = DateTime.Now;
                aCC_Account.UpdatedBy = Profile.card_id;
                aCC_Account.UpdateDate = DateTime.Now;
                aCC_Account.RowStatusID = 1;
                bool resutl = ACC_AccountManager.UpdateACC_Account(aCC_Account);
                Response.Redirect("AdminDisplayACC_Account.aspx");
            }
            catch (Exception ex)
            {
            }
	}
	private void showACC_AccountData()
	{
	 	ACC_Account aCC_Account  = new ACC_Account ();
	 	aCC_Account = ACC_AccountManager.GetACC_AccountByAccountID(Int32.Parse(Request.QueryString["ID"]));
	 	txtAccountName.Text =aCC_Account.AccountName.ToString();
	 	txtDescription.Text =aCC_Account.Description.ToString();
	 	ddlSubBasicAccountID.SelectedValue  =aCC_Account.SubBasicAccountID.ToString();
        ddlBasicAccountID.SelectedValue = aCC_Account.BasicAccountID.ToString();
	 	
	}
	
	private void SubBasicAccountIDLoad()
	{
		try {
		DataSet ds = ACC_SubBasicAccountManager.GetDropDownListAllACC_SubBasicAccount();
		ddlSubBasicAccountID.DataValueField = "SubBasicAccountID";
		ddlSubBasicAccountID.DataTextField = "SubBasicAccountName";
		ddlSubBasicAccountID.DataSource = ds.Tables[0];
		ddlSubBasicAccountID.DataBind();
		ddlSubBasicAccountID.Items.Insert(0, new ListItem("Select SubBasicAccount >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
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
    protected void ddlBasicAccountID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubBasicAccountID.Items.Clear();

        DataSet ds = ACC_SubBasicAccountManager.GetACC_SubBasicAccountByBasicAccountIDDataset(int.Parse(ddlBasicAccountID.SelectedValue));

        ddlSubBasicAccountID.DataValueField = "SubBasicAccountID";
        ddlSubBasicAccountID.DataTextField = "SubBasicAccountName";
        ddlSubBasicAccountID.DataSource = ds.Tables[0];
        ddlSubBasicAccountID.DataBind();
        ddlSubBasicAccountID.Items.Insert(0, new ListItem("Select SubBasicAccount >>", "0"));
    }
}

