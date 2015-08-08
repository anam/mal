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
public partial class AdminHR_OverTimePackageRule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            OverTimePackageIDLoad();
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_OverTimePackageRuleData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_OverTimePackageRule hR_OverTimePackageRule = new HR_OverTimePackageRule();
        //	hR_OverTimePackageRule.OverTimeRuleID=  int.Parse(ddlOverTimeRuleID.SelectedValue);
        hR_OverTimePackageRule.OverTimePackageID = int.Parse(ddlOverTimePackageID.SelectedValue);
        hR_OverTimePackageRule.OverTimeRuleName = txtOverTimeRuleName.Text;
        hR_OverTimePackageRule.OverTimeRuleValue = int.Parse(txtOverTimeRuleValue.Text);
        hR_OverTimePackageRule.OverTimeRuleOperator = txtOverTimeRuleOperator.Text;
        int resutl = HR_OverTimePackageRuleManager.InsertHR_OverTimePackageRule(hR_OverTimePackageRule);
        Response.Redirect("AdminDisplayHR_OverTimePackageRule.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_OverTimePackageRule hR_OverTimePackageRule = new HR_OverTimePackageRule();
        hR_OverTimePackageRule.OverTimeRuleID = int.Parse(Request.QueryString["ID"].ToString());
        hR_OverTimePackageRule.OverTimePackageID = int.Parse(ddlOverTimePackageID.SelectedValue);
        hR_OverTimePackageRule.OverTimeRuleName = txtOverTimeRuleName.Text;
        hR_OverTimePackageRule.OverTimeRuleValue = int.Parse(txtOverTimeRuleValue.Text);
        hR_OverTimePackageRule.OverTimeRuleOperator = txtOverTimeRuleOperator.Text;
        bool resutl = HR_OverTimePackageRuleManager.UpdateHR_OverTimePackageRule(hR_OverTimePackageRule);
        Response.Redirect("AdminDisplayHR_OverTimePackageRule.aspx");
    }

    private void showHR_OverTimePackageRuleData()
    {
        HR_OverTimePackageRule hR_OverTimePackageRule = new HR_OverTimePackageRule();
        hR_OverTimePackageRule = HR_OverTimePackageRuleManager.GetHR_OverTimePackageRuleByOverTimeRuleID(Int32.Parse(Request.QueryString["ID"]));
        ddlOverTimePackageID.SelectedValue = hR_OverTimePackageRule.OverTimePackageID.ToString();
        txtOverTimeRuleName.Text = hR_OverTimePackageRule.OverTimeRuleName.ToString();
        txtOverTimeRuleValue.Text = hR_OverTimePackageRule.OverTimeRuleValue.ToString();
        txtOverTimeRuleOperator.Text = hR_OverTimePackageRule.OverTimeRuleOperator.ToString();
    }

    private void OverTimePackageIDLoad()
    {
        try
        {
            DataSet ds = HR_OverTimePackageManager.GetDropDownListAllHR_OverTimePackage();
            ddlOverTimePackageID.DataValueField = "OverTimePackageID";
            ddlOverTimePackageID.DataTextField = "OverTimePackageName";
            ddlOverTimePackageID.DataSource = ds.Tables[0];
            ddlOverTimePackageID.DataBind();
            ddlOverTimePackageID.Items.Insert(0, new ListItem("Select OverTimePackage >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

