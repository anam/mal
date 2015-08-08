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
 public partial class AdminHR_EmployeeSalaryRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadHR_EmployeeSalaryRulesData();
         		EmployeeIDLoad();
		PackageRulesIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_EmployeeSalaryRulesData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules ();
//	hR_EmployeeSalaryRules.EmployeeSalaryPackageRulesID=  int.Parse(ddlEmployeeSalaryPackageRulesID.SelectedValue);
	hR_EmployeeSalaryRules.EmployeeID=  ddlEmployeeID.SelectedValue;
	hR_EmployeeSalaryRules.PackageRulesID=  int.Parse(ddlPackageRulesID.SelectedValue);
	hR_EmployeeSalaryRules.AddedBy=  Profile.card_id;
	hR_EmployeeSalaryRules.AddedDate=  DateTime.Now;
	hR_EmployeeSalaryRules.UpdatedBy=  Profile.card_id;
	hR_EmployeeSalaryRules.UpdatedDate=  DateTime.Now;
	int resutl =HR_EmployeeSalaryRulesManager.InsertHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
	Response.Redirect("AdminDisplayHR_EmployeeSalaryRules.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules ();
	hR_EmployeeSalaryRules.EmployeeSalaryPackageRulesID=  int.Parse(Request.QueryString["ID"].ToString());
	hR_EmployeeSalaryRules.EmployeeID=  ddlEmployeeID.SelectedValue;
	hR_EmployeeSalaryRules.PackageRulesID=  int.Parse(ddlPackageRulesID.SelectedValue);
	hR_EmployeeSalaryRules.AddedBy=  Profile.card_id;
	hR_EmployeeSalaryRules.AddedDate=  DateTime.Now;
	hR_EmployeeSalaryRules.UpdatedBy=  Profile.card_id;
	hR_EmployeeSalaryRules.UpdatedDate=  DateTime.Now;
	bool  resutl =HR_EmployeeSalaryRulesManager.UpdateHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
	Response.Redirect("AdminDisplayHR_EmployeeSalaryRules.aspx");
	}
	private void showHR_EmployeeSalaryRulesData()
	{
	 	HR_EmployeeSalaryRules hR_EmployeeSalaryRules  = new HR_EmployeeSalaryRules ();
	 	hR_EmployeeSalaryRules = HR_EmployeeSalaryRulesManager.GetHR_EmployeeSalaryRulesByEmployeeSalaryPackageRulesID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlEmployeeID.SelectedValue  =hR_EmployeeSalaryRules.EmployeeID.ToString();
	 	ddlPackageRulesID.SelectedValue  =hR_EmployeeSalaryRules.PackageRulesID.ToString();
	}
	
	private void EmployeeIDLoad()
	{
		try {
		DataSet ds = HR_EmployeeManager.GetDropDownListAllHR_Employee();
		ddlEmployeeID.DataValueField = "EmployeeID";
		ddlEmployeeID.DataTextField = "EmployeeNameNo";
		ddlEmployeeID.DataSource = ds.Tables[0];
		ddlEmployeeID.DataBind();
		ddlEmployeeID.Items.Insert(0, new ListItem("Select Employee >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void PackageRulesIDLoad()
	{
		try {
		DataSet ds = HR_PackageRulesManager.GetDropDownListAllHR_PackageRules();
		ddlPackageRulesID.DataValueField = "PackageRulesID";
		ddlPackageRulesID.DataTextField = "PackageRulesName";
		ddlPackageRulesID.DataSource = ds.Tables[0];
		ddlPackageRulesID.DataBind();
		ddlPackageRulesID.Items.Insert(0, new ListItem("Select PackageRules >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

