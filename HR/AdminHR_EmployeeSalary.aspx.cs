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
public partial class AdminHR_EmployeeSalary : System.Web.UI.Page
{
    private static List<HR_PackageRules> ListPackageRules = new List<HR_PackageRules>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            LoadPackage();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_EmployeeSalaryData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        hR_EmployeeSalary.EmployeeSalaryID = int.Parse(Request.QueryString["ID"].ToString());
        hR_EmployeeSalary.EmployeeID = Profile.card_id;
        hR_EmployeeSalary.IsGross = radIsGross.SelectedValue == "True" ? true : false;
        hR_EmployeeSalary.BasicAmount = decimal.Parse(txtAmount.Text);
        hR_EmployeeSalary.IsActive = true;// bool.Parse(radIsActive.SelectedValue);
        hR_EmployeeSalary.AddedBy = Profile.card_id;
        hR_EmployeeSalary.AddedDate = DateTime.Now;
        hR_EmployeeSalary.ModifiedBy = Profile.card_id;
        hR_EmployeeSalary.ModifiedDate = DateTime.Now;
        bool resutl = HR_EmployeeSalaryManager.UpdateHR_EmployeeSalary(hR_EmployeeSalary);
        Response.Redirect("AdminDisplayHR_EmployeeSalary.aspx");
    }

    public void LoadPackage()
    {
        try
        {
            DataSet ds = HR_PackageManager.GetDropDownListAllHR_Package();
            ddlPackage.DataValueField = "PackageID";
            ddlPackage.DataTextField = "PackageName";
            ddlPackage.DataSource = ds.Tables[0];
            ddlPackage.DataBind();
            ddlPackage.Items.Insert(0, new ListItem("Select Package >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    public void LoadPackageRules(int PackageID)
    {
        try
        {
            DataSet ds = HR_PackageRulesManager.GetAllHR_PackageRulessByPackageID(PackageID);
            ddlPackageRules.DataValueField = "PackageRulesID";
            ddlPackageRules.DataTextField = "PackageRulesName";
            ddlPackageRules.DataSource = ds.Tables[0];
            ddlPackageRules.DataBind();
            ddlPackageRules.Items.Insert(0, new ListItem("Select Package  Rules>>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    //ddlPackage
    private void showHR_EmployeeSalaryData()
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        hR_EmployeeSalary = HR_EmployeeSalaryManager.GetHR_EmployeeSalaryByEmployeeSalaryID(Int32.Parse(Request.QueryString["ID"]));
        radIsGross.SelectedValue = hR_EmployeeSalary.IsGross.ToString();
        txtAmount.Text = hR_EmployeeSalary.BasicAmount.ToString();
        // radIsActive.SelectedValue  =hR_EmployeeSalary.IsActive.ToString();
    }


    protected void radSalaryRules_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radSalaryRules.SelectedValue == "False")
        {
            ddlPackage.Visible = true;
            gridViewPackageAndPackageRules.Visible = false;
        }
        else
        {
            ddlPackage.Visible = false;
            gridViewPackageAndPackageRules.Visible = true;
            DataSet dataSet = HR_PackageRulesManager.GetAllHR_PackageAndPackageRuless();

            gridViewPackageAndPackageRules.DataSource = dataSet.Tables[0];
            gridViewPackageAndPackageRules.DataBind();

            gvHR_PackageRules.DataSource = null;
            gvHR_PackageRules.DataBind();
        }
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int index = Convert.ToInt32(linkButton.CommandArgument);
        ListPackageRules.RemoveAt(index);
        gvHR_PackageRules.DataSource = ListPackageRules;
        gvHR_PackageRules.DataBind();
    }


    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        HR_PackageRules packageRule = new HR_PackageRules();
        packageRule = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(int.Parse(ddlPackageRules.SelectedValue));
        packageRule.PackageRulesID = packageRule.PackageRulesID;
        packageRule.PackageRulesName = packageRule.PackageRulesName;
        packageRule.RulesValue = packageRule.RulesValue;
        packageRule.RulesOperator = packageRule.RulesOperator;
        ListPackageRules.Add(packageRule);
        gvHR_PackageRules.DataSource = ListPackageRules;
        gvHR_PackageRules.DataBind();

    }
    protected void ddlPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvHR_PackageRules.DataSource = HR_PackageRulesManager.GetAllHR_PackageRulessByPackageID(Convert.ToInt32(ddlPackage.SelectedValue));
        gvHR_PackageRules.DataBind();
    }

    private void RefreshPackageRelues()
    {
        ListPackageRules = new List<HR_PackageRules>();
        if (radSalaryRules.SelectedValue == "True")
        {
            for (int rowCounter = 0; rowCounter < gridViewPackageAndPackageRules.Rows.Count; rowCounter++)
            {
                CheckBox checkBox = (CheckBox)gridViewPackageAndPackageRules.Rows[rowCounter].FindControl("chkPackageRulesID");
                if (checkBox.Checked)
                {
                    HR_PackageRules packageRule = new HR_PackageRules();

                    packageRule = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(int.Parse(((Label)gridViewPackageAndPackageRules.Rows[rowCounter].FindControl("lblPackageRulesID")).Text));
                    packageRule.PackageRulesID = packageRule.PackageRulesID;
                    packageRule.PackageRulesName = packageRule.PackageRulesName;
                    packageRule.RulesValue = packageRule.RulesValue;
                    packageRule.RulesOperator = packageRule.RulesOperator;

                    ListPackageRules.Add(packageRule);
                }
            }
        }
        else
        {
            for (int rowCounter = 0; rowCounter < gvHR_PackageRules.Rows.Count; rowCounter++)
            {
                HR_PackageRules packageRule = new HR_PackageRules();
                packageRule = HR_PackageRulesManager.GetHR_PackageRulesByPackageRulesID(int.Parse(((Label)gvHR_PackageRules.Rows[rowCounter].FindControl("lblPackageRulesID")).Text));
                packageRule.PackageRulesID = packageRule.PackageRulesID;
                packageRule.PackageRulesName = packageRule.PackageRulesName;
                packageRule.RulesValue = packageRule.RulesValue;
                packageRule.RulesOperator = packageRule.RulesOperator;

                ListPackageRules.Add(packageRule);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        HR_EmployeeSalary hR_EmployeeSalary = new HR_EmployeeSalary();
        //	hR_EmployeeSalary.EmployeeSalaryID=  int.Parse(ddlEmployeeSalaryID.SelectedValue);
        hR_EmployeeSalary.EmployeeID = Profile.card_id;
        hR_EmployeeSalary.IsGross = radIsGross.SelectedValue == "True" ? true : false;
        hR_EmployeeSalary.BasicAmount = decimal.Parse(txtAmount.Text);
        hR_EmployeeSalary.IsActive = true;// bool.Parse(radIsActive.SelectedValue);
        hR_EmployeeSalary.AddedBy = Profile.card_id;
        hR_EmployeeSalary.AddedDate = DateTime.Now;
        hR_EmployeeSalary.ModifiedBy = Profile.card_id;
        hR_EmployeeSalary.ModifiedDate = DateTime.Now;
        int resutl = HR_EmployeeSalaryManager.InsertHR_EmployeeSalary(hR_EmployeeSalary);

        RefreshPackageRelues();

        foreach (HR_PackageRules packageRules in ListPackageRules)
        {
            HR_EmployeeSalaryRules hR_EmployeeSalaryRules = new HR_EmployeeSalaryRules();

            hR_EmployeeSalaryRules.EmployeeID = Profile.card_id;
            hR_EmployeeSalaryRules.PackageRulesID = packageRules.PackageRulesID;
            hR_EmployeeSalaryRules.AddedBy = Profile.card_id;
            hR_EmployeeSalaryRules.AddedDate = DateTime.Now;
            hR_EmployeeSalaryRules.UpdatedBy = Profile.card_id;
            hR_EmployeeSalaryRules.UpdatedDate = DateTime.Now;
            int resID = HR_EmployeeSalaryRulesManager.InsertHR_EmployeeSalaryRules(hR_EmployeeSalaryRules);
        }
        Response.Redirect("AdminDisplayHR_EmployeeSalary.aspx");
    }
}

