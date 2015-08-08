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
public partial class AdminHR_SalaryIncrementPackageRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeIDLoad();
            SalaryIncrementPackageIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_SalaryIncrementPackageRulesData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
        //	hR_SalaryIncrementPackageRules.SalaryIncrementPackageRulesID=  int.Parse(ddlSalaryIncrementPackageRulesID.SelectedValue);
        hR_SalaryIncrementPackageRules.EmployeeID = ddlEmployeeID.SelectedValue;
        hR_SalaryIncrementPackageRules.SalaryIncrementPackageID = int.Parse(ddlSalaryIncrementPackageID.SelectedValue);
        hR_SalaryIncrementPackageRules.Year = int.Parse(txtYear.Text);
        hR_SalaryIncrementPackageRules.Month = int.Parse(txtMonth.Text);
        string userID = Profile.card_id;
        hR_SalaryIncrementPackageRules.AddedBy = userID;
        hR_SalaryIncrementPackageRules.AddedDate = DateTime.Now;
        hR_SalaryIncrementPackageRules.ModifiedBy = userID;
        hR_SalaryIncrementPackageRules.ModifiedDate = DateTime.Now;
        int resutl = HR_SalaryIncrementPackageRulesManager.InsertHR_SalaryIncrementPackageRules(hR_SalaryIncrementPackageRules);
        Response.Redirect("AdminDisplayHR_SalaryIncrementPackageRules.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
        hR_SalaryIncrementPackageRules.SalaryIncrementPackageRulesID = int.Parse(Request.QueryString["ID"].ToString());
        hR_SalaryIncrementPackageRules.EmployeeID = ddlEmployeeID.SelectedValue;
        hR_SalaryIncrementPackageRules.SalaryIncrementPackageID = int.Parse(ddlSalaryIncrementPackageID.SelectedValue);
        hR_SalaryIncrementPackageRules.Year = int.Parse(txtYear.Text);
        hR_SalaryIncrementPackageRules.Month = int.Parse(txtMonth.Text);
        string userID = Profile.card_id;
        hR_SalaryIncrementPackageRules.AddedBy = userID;
        hR_SalaryIncrementPackageRules.AddedDate = DateTime.Now;
        hR_SalaryIncrementPackageRules.ModifiedBy = userID;
        hR_SalaryIncrementPackageRules.ModifiedDate = DateTime.Now;
        bool resutl = HR_SalaryIncrementPackageRulesManager.UpdateHR_SalaryIncrementPackageRules(hR_SalaryIncrementPackageRules);
        Response.Redirect("AdminDisplayHR_SalaryIncrementPackageRules.aspx");
    }

    private void showHR_SalaryIncrementPackageRulesData()
    {
        HR_SalaryIncrementPackageRules hR_SalaryIncrementPackageRules = new HR_SalaryIncrementPackageRules();
        hR_SalaryIncrementPackageRules = HR_SalaryIncrementPackageRulesManager.GetHR_SalaryIncrementPackageRulesBySalaryIncrementPackageRulesID(Int32.Parse(Request.QueryString["ID"]));
        ddlEmployeeID.SelectedValue = hR_SalaryIncrementPackageRules.EmployeeID.ToString();
        ddlSalaryIncrementPackageID.SelectedValue = hR_SalaryIncrementPackageRules.SalaryIncrementPackageID.ToString();
        txtYear.Text = hR_SalaryIncrementPackageRules.Year.ToString();
        txtMonth.Text = hR_SalaryIncrementPackageRules.Month.ToString();
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

    private void SalaryIncrementPackageIDLoad()
    {
        try
        {
            DataSet ds = HR_SalaryIncrementPackageManager.GetDropDownListAllHR_SalaryIncrementPackage();
            ddlSalaryIncrementPackageID.DataValueField = "SalaryIncrementPackageID";
            ddlSalaryIncrementPackageID.DataTextField = "SalaryIncrementPackageName";
            ddlSalaryIncrementPackageID.DataSource = ds.Tables[0];
            ddlSalaryIncrementPackageID.DataBind();
            ddlSalaryIncrementPackageID.Items.Insert(0, new ListItem("Select SalaryIncrementPackage >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}

