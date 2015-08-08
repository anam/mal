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


public partial class AdminDisplayHR_ProvidentFundSetup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HR_ProvidentFundSetupManager.LoadHR_ProvidentFundSetupPage(gvHR_ProvidentFundSetup, rptPager, 1, ddlPageSize);
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        HR_ProvidentFundSetupManager.LoadHR_ProvidentFundSetupPage(gvHR_ProvidentFundSetup, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        HR_ProvidentFundSetupManager.LoadHR_ProvidentFundSetupPage(gvHR_ProvidentFundSetup, rptPager, pageIndex, ddlPageSize);
    }

    protected void gvHR_ProvidentFundSetup_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFundType = (Label)e.Row.FindControl("lblFundTypeID");
            if (lblFundType.Text.Trim() != string.Empty)
            {
                if (lblFundType.Text.Trim().Equals("1"))
                {
                    lblFundType.Text = "EPF";
                }
                else
                {
                    lblFundType.Text = "CPF";
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_ProvidentFundSetup.aspx");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminHR_ProvidentFundSetup.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = HR_ProvidentFundSetupManager.DeleteHR_ProvidentFundSetup(Convert.ToInt32(linkButton.CommandArgument));
        HR_ProvidentFundSetupManager.LoadHR_ProvidentFundSetupPage(gvHR_ProvidentFundSetup, rptPager, 1, ddlPageSize);
    }
}

