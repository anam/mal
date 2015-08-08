using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDisplay1HR_ProvidentfundRules : System.Web.UI.Page
{
    //AdminDisplay1HR_ProvidentfundRules.aspx
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
}