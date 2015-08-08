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
 public partial class AdminHR_LunchRule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_LunchRuleData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_LunchRule hR_LunchRule = new HR_LunchRule ();
//	hR_LunchRule.LunchRuleID=  int.Parse(ddlLunchRuleID.SelectedValue);
    hR_LunchRule.EmployeeID = Profile.card_id;
	hR_LunchRule.LunchOutTimeHours=  int.Parse(txtLunchOutTimeHours.Text);
	hR_LunchRule.LunchOutTimeMins=  int.Parse(txtLunchOutTimeMins.Text);
	hR_LunchRule.LunchFlexibleTimeHours=  int.Parse(txtLunchFlexibleTimeHours.Text);
	hR_LunchRule.LunchFlexibleTimeMins=  int.Parse(txtLunchFlexibleTimeMins.Text);
	hR_LunchRule.LunchTimeAllowed=  int.Parse(txtLunchTimeAllowed.Text);
    hR_LunchRule.LunchFlag = radLunchFlag.SelectedValue == "True" ? true : false; ;
	hR_LunchRule.AddedBy=  Profile.card_id;
	hR_LunchRule.AddedDate=  DateTime.Now;
	hR_LunchRule.ModifiedBy=  Profile.card_id;
	hR_LunchRule.ModifiedDate=  DateTime.Now;
	int resutl =HR_LunchRuleManager.InsertHR_LunchRule(hR_LunchRule);
	Response.Redirect("AdminDisplayHR_LunchRule.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_LunchRule hR_LunchRule = new HR_LunchRule ();
	hR_LunchRule.LunchRuleID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_LunchRule.EmployeeID = Profile.card_id;
	hR_LunchRule.LunchOutTimeHours=  int.Parse(txtLunchOutTimeHours.Text);
	hR_LunchRule.LunchOutTimeMins=  int.Parse(txtLunchOutTimeMins.Text);
	hR_LunchRule.LunchFlexibleTimeHours=  int.Parse(txtLunchFlexibleTimeHours.Text);
	hR_LunchRule.LunchFlexibleTimeMins=  int.Parse(txtLunchFlexibleTimeMins.Text);
	hR_LunchRule.LunchTimeAllowed=  int.Parse(txtLunchTimeAllowed.Text);
    hR_LunchRule.LunchFlag = radLunchFlag.SelectedValue == "True" ? true : false; ;
	hR_LunchRule.AddedBy=  Profile.card_id;
	hR_LunchRule.AddedDate=  DateTime.Now;
	hR_LunchRule.ModifiedBy=  Profile.card_id;
	hR_LunchRule.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_LunchRuleManager.UpdateHR_LunchRule(hR_LunchRule);
	Response.Redirect("AdminDisplayHR_LunchRule.aspx");
	}
	private void showHR_LunchRuleData()
	{
	 	HR_LunchRule hR_LunchRule  = new HR_LunchRule ();
	 	hR_LunchRule = HR_LunchRuleManager.GetHR_LunchRuleByLunchRuleID(Int32.Parse(Request.QueryString["ID"]));
	 	 
	 	txtLunchOutTimeHours.Text =hR_LunchRule.LunchOutTimeHours.ToString();
	 	txtLunchOutTimeMins.Text =hR_LunchRule.LunchOutTimeMins.ToString();
	 	txtLunchFlexibleTimeHours.Text =hR_LunchRule.LunchFlexibleTimeHours.ToString();
	 	txtLunchFlexibleTimeMins.Text =hR_LunchRule.LunchFlexibleTimeMins.ToString();
	 	txtLunchTimeAllowed.Text =hR_LunchRule.LunchTimeAllowed.ToString();
	 	 radLunchFlag.SelectedValue  =hR_LunchRule.LunchFlag.ToString();
	}
	
	 
}

