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
public partial class AdminHR_SalaryTaxPackageRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadHR_SalaryTaxPackageRulesData();
            EmployeeIDLoad();
            SalaryTaxPackageIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_SalaryTaxPackageRulesData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        //	hR_SalaryTaxPackageRules.SalaryTaxPackageRulesID=  int.Parse(ddlSalaryTaxPackageRulesID.SelectedValue);
        hR_SalaryTaxPackageRules.EmployeeID = ddlEmployeeID.SelectedValue;
        hR_SalaryTaxPackageRules.SalaryTaxPackageID = int.Parse(ddlSalaryTaxPackageID.SelectedValue);
        hR_SalaryTaxPackageRules.AddedBy = Profile.card_id;
        hR_SalaryTaxPackageRules.AddedDate = DateTime.Now;
        hR_SalaryTaxPackageRules.ModifiedBy = Profile.card_id;
        hR_SalaryTaxPackageRules.ModifiedDate = DateTime.Now;
        int resutl = HR_SalaryTaxPackageRulesManager.InsertHR_SalaryTaxPackageRules(hR_SalaryTaxPackageRules);
        Response.Redirect("AdminDisplayHR_SalaryTaxPackageRules.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        hR_SalaryTaxPackageRules.SalaryTaxPackageRulesID = int.Parse(Request.QueryString["ID"].ToString());
        hR_SalaryTaxPackageRules.EmployeeID = ddlEmployeeID.SelectedValue;
        hR_SalaryTaxPackageRules.SalaryTaxPackageID = int.Parse(ddlSalaryTaxPackageID.SelectedValue);
        hR_SalaryTaxPackageRules.AddedBy = Profile.card_id;
        hR_SalaryTaxPackageRules.AddedDate = DateTime.Now;
        hR_SalaryTaxPackageRules.ModifiedBy = Profile.card_id;
        hR_SalaryTaxPackageRules.ModifiedDate = DateTime.Now;
        bool resutl = HR_SalaryTaxPackageRulesManager.UpdateHR_SalaryTaxPackageRules(hR_SalaryTaxPackageRules);
        Response.Redirect("AdminDisplayHR_SalaryTaxPackageRules.aspx");
    }
    private void showHR_SalaryTaxPackageRulesData()
    {
        HR_SalaryTaxPackageRules hR_SalaryTaxPackageRules = new HR_SalaryTaxPackageRules();
        hR_SalaryTaxPackageRules = HR_SalaryTaxPackageRulesManager.GetHR_SalaryTaxPackageRulesBySalaryTaxPackageRulesID(Int32.Parse(Request.QueryString["ID"]));
        ddlEmployeeID.SelectedValue = hR_SalaryTaxPackageRules.EmployeeID.ToString();
        ddlSalaryTaxPackageID.SelectedValue = hR_SalaryTaxPackageRules.SalaryTaxPackageID.ToString();
    }

    private void EmployeeIDLoad()
    {
        try
        {
            DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
            ddlEmployeeID.DataValueField = "EmployeeID";
            ddlEmployeeID.DataTextField = "EmployeeNameNo";
            ddlEmployeeID.DataSource = ds.Tables[0];
            ddlEmployeeID.DataBind();
            ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void SalaryTaxPackageIDLoad()
    {
        try
        {
            DataSet ds = HR_SalaryTaxPackageManager.GetDropDownListAllHR_SalaryTaxPackage();
            ddlSalaryTaxPackageID.DataValueField = "SalaryTaxPackageID";
            ddlSalaryTaxPackageID.DataTextField = "SalaryTaxPackageName";
            ddlSalaryTaxPackageID.DataSource = ds.Tables[0];
            ddlSalaryTaxPackageID.DataBind();
            ddlSalaryTaxPackageID.Items.Insert(0, new ListItem("Select SalaryTaxPackage >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

