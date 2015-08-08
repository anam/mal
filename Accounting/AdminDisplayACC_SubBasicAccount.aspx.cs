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
 

public partial class AdminDisplayACC_SubBasicAccount : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnPaging.Visible = true;
            _loadBasicAccount(ddlBasicAccount);
            ACC_SubBasicAccountManager.LoadACC_SubBasicAccountPage(gvACC_SubBasicAccount, rptPager, 1, ddlPageSize);
        }
    }

    private void _loadBasicAccount(DropDownList ddlBasicAccount)
    {
        DataSet basicAccounts = ACC_BasicAccountManager.GetAllACC_BasicAccounts();
        ddlBasicAccount.DataTextField = "BasicAccountName";
        ddlBasicAccount.DataValueField = "BasicAccountID";
        ddlBasicAccount.DataSource = basicAccounts;
        ddlBasicAccount.DataBind();

        ddlBasicAccount.Items.Insert( 0, new ListItem("Select Basic Account>>","0"));
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        ACC_SubBasicAccountManager.LoadACC_SubBasicAccountPage(gvACC_SubBasicAccount, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ACC_SubBasicAccountManager.LoadACC_SubBasicAccountPage(gvACC_SubBasicAccount, rptPager, pageIndex, ddlPageSize);
    }
	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Response.Redirect("AdminACC_SubBasicAccount.aspx?ID=0");
	}
	protected void lbSelect_Click(object sender, EventArgs e)
	{
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		int id;
		id = Convert.ToInt32(linkButton.CommandArgument);
		Response.Redirect("AdminACC_SubBasicAccount.aspx?ID=" + id);
	}
	protected void lbDelete_Click(object sender, EventArgs e)
	{ 
		ImageButton linkButton = new ImageButton();
		linkButton = (ImageButton)sender;
		bool result = ACC_SubBasicAccountManager.DeleteACC_SubBasicAccount(Convert.ToInt32(linkButton.CommandArgument));
       ACC_SubBasicAccountManager.LoadACC_SubBasicAccountPage(gvACC_SubBasicAccount, rptPager, 1, ddlPageSize);
  	}
    protected void ddlBasicAccount_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBasicAccount.SelectedIndex != 0)
        {
            pnPaging.Visible = false;
            gvACC_SubBasicAccount.DataSource = ACC_SubBasicAccountManager.GetACC_SubBasicAccountByBasicAccountIDDataset(Convert.ToInt32(ddlBasicAccount.SelectedValue));
            gvACC_SubBasicAccount.DataBind();
        }
        else
        {
            pnPaging.Visible = true;
            ACC_SubBasicAccountManager.LoadACC_SubBasicAccountPage(gvACC_SubBasicAccount, rptPager, 1, ddlPageSize);
        }
    }
}

