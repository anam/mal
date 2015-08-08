using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDisplayHR_ProvidentfundRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HR_ProvidentfundRulesManager.LoadHR_ProvidentfundRulesPage(gvHR_ProvidentfundRules, rptPager, 1, ddlPageSize);
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        HR_ProvidentfundRulesManager.LoadHR_ProvidentfundRulesPage(gvHR_ProvidentfundRules, rptPager, 1, ddlPageSize);
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        HR_ProvidentfundRulesManager.LoadHR_ProvidentfundRulesPage(gvHR_ProvidentfundRules, rptPager, pageIndex, ddlPageSize);
    }

    //gvHR_ProvidentfundRules_OnRowDataBound

    protected void gvHR_ProvidentfundRules_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIsGrossPortion = (Label)e.Row.FindControl("lblIsGrossPortion");
            if (lblIsGrossPortion.Text.Trim() != string.Empty)
            {
                if (lblIsGrossPortion.Text.Trim().Equals("True"))
                {
                    lblIsGrossPortion.Text = "Yes";
                }
                else
                {
                    lblIsGrossPortion.Text = "No";
                }
            }
        }
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminHR_ProvidentfundRules.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = HR_ProvidentfundRulesManager.DeleteHR_ProvidentfundRules(Convert.ToInt32(linkButton.CommandArgument));
        HR_ProvidentfundRulesManager.LoadHR_ProvidentfundRulesPage(gvHR_ProvidentfundRules, rptPager, 1, ddlPageSize);
    }

    protected void btnAddProvidentFundRules_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_ProvidentfundRules.aspx");
    }
}