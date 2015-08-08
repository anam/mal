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
 

public partial class AdminDisplayACC_Account : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnPaging.Visible = true;
            _loadBasicAccount(ddlBasicAccount);
            ACC_AccountManager.LoadACC_AccountPage(gvACC_Account, rptPager, 1, ddlPageSize);
        }
    }

    private void _loadBasicAccount(DropDownList ddlBasicAccount)
    {
        DataSet basicAccounts = ACC_BasicAccountManager.GetAllACC_BasicAccounts();
        ddlBasicAccount.DataTextField = "BasicAccountName";
        ddlBasicAccount.DataValueField = "BasicAccountID";
        ddlBasicAccount.DataSource = basicAccounts;
        ddlBasicAccount.DataBind();

        ddlBasicAccount.Items.Insert(0, new ListItem("Select Basic Account>>", "0"));
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        ACC_AccountManager.LoadACC_AccountPage(gvACC_Account, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ACC_AccountManager.LoadACC_AccountPage(gvACC_Account, rptPager, pageIndex, ddlPageSize);
    }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminACC_Account.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminACC_Account.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
        ACC_Account account = ACC_AccountManager.GetACC_AccountByAccountID(Convert.ToInt32(linkButton.CommandArgument));
        account.RowStatusID = 3;
        ACC_AccountManager.UpdateACC_Account(account);
        //bool result = ACC_AccountManager.DeleteACC_Account(Convert.ToInt32(linkButton.CommandArgument));
        if (ddlSubBasicAccount.SelectedIndex != 0)
        {
            pnPaging.Visible = false;
            DataSet accounts = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(Convert.ToInt32(ddlSubBasicAccount.SelectedValue), true);
            if (accounts != null)
            {
                gvACC_Account.DataSource = accounts;
                gvACC_Account.DataBind();
            }
        }
        else
        {
            pnPaging.Visible = true;
            ACC_AccountManager.LoadACC_AccountPage(gvACC_Account, rptPager, 1, ddlPageSize);
        }
  	}

    protected void ddlBasicAccount_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBasicAccount.SelectedIndex != 0)
        {
            DataSet subBasicAccounts = ACC_SubBasicAccountManager.GetACC_SubBasicAccountByBasicAccountIDDataset(Convert.ToInt32(ddlBasicAccount.SelectedValue));

            if (subBasicAccounts != null)
            {
                ddlSubBasicAccount.Items.Clear();

                ddlSubBasicAccount.DataTextField = "SubBasicAccountName";
                ddlSubBasicAccount.DataValueField = "SubBasicAccountID";

                ddlSubBasicAccount.DataSource = subBasicAccounts;
                ddlSubBasicAccount.DataBind();

                ddlSubBasicAccount.Items.Insert(0, new ListItem("Select SubBasicAccount>>", "0"));
            }
        }
        else
        {
            ddlSubBasicAccount.Items.Clear();
        }
    }
    protected void ddlSubBasicAccount_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        

        if (ddlSubBasicAccount.SelectedIndex != 0)
        {
            pnPaging.Visible = false;
            DataSet accounts = ACC_AccountManager.GetACC_AccountBySubBasicAccountID(Convert.ToInt32(ddlSubBasicAccount.SelectedValue), true);
            if (accounts != null)
            {
                gvACC_Account.DataSource = accounts;
                gvACC_Account.DataBind();
            }
        }
        else
        {
            pnPaging.Visible = true;
            ACC_AccountManager.LoadACC_AccountPage(gvACC_Account, rptPager, 1, ddlPageSize);
        }
    }
}

