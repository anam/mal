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
public partial class AdminHR_PackageRules : System.Web.UI.Page
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
                showHR_PackageRulesData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_PackageRules hR_PackageRules = new HR_PackageRules();
        //	hR_PackageRules.PackageRulesID=  int.Parse(ddlPackageRulesID.SelectedValue);
        hR_PackageRules.PackageRulesName = txtPackageRulesName.Text;
        //hR_PackageRules.PackageID=  int.Parse(ddlPackageID.SelectedValue);
        hR_PackageRules.RulesValue = int.Parse(txtRulesValue.Text);
        hR_PackageRules.RulesOperator = txtRulesOperator.Text;
        string userID = Profile.card_id;
        hR_PackageRules.AddedBy = userID;
        hR_PackageRules.AddedDate = DateTime.Now;
        hR_PackageRules.UpdatedBy = userID;
        hR_PackageRules.UpdatedDate = DateTime.Now;
        int resutl = HR_PackageRulesManager.InsertHR_PackageRules(hR_PackageRules);
        Response.Redirect("AdminDisplayHR_PackageRules.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_PackageRules hR_PackageRules = new HR_PackageRules();
        hR_PackageRules.PackageRulesID = int.Parse(Request.QueryString["ID"].ToString());
        hR_PackageRules.PackageRulesName = txtPackageRulesName.Text;
        //hR_PackageRules.PackageID=  int.Parse(ddlPackageID.SelectedValue);
        hR_PackageRules.RulesValue = int.Parse(txtRulesValue.Text);
        hR_PackageRules.RulesOperator = txtRulesOperator.Text;
        string userID = Profile.card_id;
        hR_PackageRules.AddedBy = userID;
        hR_PackageRules.AddedDate = DateTime.Now;
        hR_PackageRules.UpdatedBy = userID;
        hR_PackageRules.UpdatedDate = DateTime.Now;
        bool resutl = HR_PackageRulesManager.UpdateHR_PackageRules(hR_PackageRules);
        Response.Redirect("AdminDisplayHR_PackageRules.aspx");
    }

    private void showHR_PackageRulesData()
    {
        HR_PackageRules hR_PackageRules = new HR_PackageRules();
        hR_PackageRules = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(Int32.Parse(Request.QueryString["ID"]));
        txtPackageRulesName.Text = hR_PackageRules.PackageRulesName.ToString();
        //	ddlPackageID.SelectedValue  =hR_PackageRules.PackageID.ToString();
        txtRulesValue.Text = hR_PackageRules.RulesValue.ToString();
        txtRulesOperator.Text = hR_PackageRules.RulesOperator.ToString();
    }
}

