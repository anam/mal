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


public partial class Admin1HR_ProvidentfundRules : System.Web.UI.Page
{
    //Admin1HR_ProvidentfundRules.aspx
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtValue.Text.Trim() != string.Empty)
        {
            HR_ProvidentfundRules providentfundRules = new HR_ProvidentfundRules(0, Convert.ToDecimal(txtValue.Text.Trim()), radIsGrossPortion.Checked, Profile.card_id, DateTime.Now, Profile.card_id, DateTime.Now);
            HR_ProvidentfundRulesManager.InsertHR_ProvidentfundRules(providentfundRules);
            //HR_ProvidentfundRulesManager.LoadHR_ProvidentfundRulesPage(gvHR_ProvidentfundRules, rptPager, 1, ddlPageSize);
        }
        Response.Redirect("AdminHR_ProvidentfundRules.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AdminHR_ProvidentfundRules.aspx?ID=0");
    }
}

