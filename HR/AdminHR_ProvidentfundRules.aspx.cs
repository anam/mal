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


public partial class AdminHR_ProvidentfundRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            if (Request.QueryString["ID"] != null)
            {
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                ShowData();
            }
        }
    }

    private void ShowData()
    {
        int providentFundID = Convert.ToInt32(Request.QueryString["ID"].ToString());
        HR_ProvidentfundRules ProvidentfundRules = HR_ProvidentfundRulesManager.GetHR_ProvidentfundRulesByProvidentfundRulesID(providentFundID);
        if (ProvidentfundRules != null)
        {
            hdnProvidentFundID.Value = ProvidentfundRules.ProvidentfundRulesID.ToString();
            txtValue.Text = ProvidentfundRules.Value.ToString("n2");
            radIsGrossPortion.Checked = ProvidentfundRules.IsGrossPortion;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtValue.Text.Trim() != string.Empty)
        {
            HR_ProvidentfundRules providentfundRules = new HR_ProvidentfundRules(0, Convert.ToDecimal(txtValue.Text.Trim()), radIsGrossPortion.Checked, Profile.card_id, DateTime.Now, Profile.card_id, DateTime.Now);
            HR_ProvidentfundRulesManager.InsertHR_ProvidentfundRules(providentfundRules);
        }
        Response.Redirect("AdminDisplayHR_ProvidentfundRules.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (hdnProvidentFundID.Value != string.Empty)
        {
            if (txtValue.Text.Trim() != string.Empty)
            {
                HR_ProvidentfundRules providentfundRules = new HR_ProvidentfundRules(Convert.ToInt32(hdnProvidentFundID.Value), Convert.ToDecimal(txtValue.Text.Trim()), radIsGrossPortion.Checked, Profile.card_id, DateTime.Now, Profile.card_id, DateTime.Now);
                HR_ProvidentfundRulesManager.UpdateHR_ProvidentfundRules(providentfundRules);
                Response.Redirect("AdminDisplayHR_ProvidentfundRules.aspx");
            }
        }
    }
}

