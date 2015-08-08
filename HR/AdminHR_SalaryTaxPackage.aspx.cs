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
public partial class AdminHR_SalaryTaxPackage : System.Web.UI.Page
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
                showHR_SalaryTaxPackageData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_SalaryTaxPackage hR_SalaryTaxPackage = new HR_SalaryTaxPackage();
        //	hR_SalaryTaxPackage.SalaryTaxPackagePackageID=  int.Parse(ddlSalaryTaxPackagePackageID.SelectedValue);
        hR_SalaryTaxPackage.SalaryTaxPackagePackageName = txtSalaryTaxPackageName.Text;
        hR_SalaryTaxPackage.SalaryTaxPackageFormula = txtSalaryTaxPackageFormula.Text;
        string userID = Profile.card_id;
        hR_SalaryTaxPackage.AddedBy = userID;
        hR_SalaryTaxPackage.AddedDate = DateTime.Now;
        hR_SalaryTaxPackage.ModifiedBy = userID;
        hR_SalaryTaxPackage.ModifiedDate = DateTime.Now;
        int resutl = HR_SalaryTaxPackageManager.InsertHR_SalaryTaxPackage(hR_SalaryTaxPackage);
        Response.Redirect("AdminDisplayHR_SalaryTaxPackage.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_SalaryTaxPackage hR_SalaryTaxPackage = new HR_SalaryTaxPackage();
        hR_SalaryTaxPackage.SalaryTaxPackagePackageID = int.Parse(Request.QueryString["ID"].ToString());
        hR_SalaryTaxPackage.SalaryTaxPackagePackageName = txtSalaryTaxPackageName.Text;
        hR_SalaryTaxPackage.SalaryTaxPackageFormula = txtSalaryTaxPackageFormula.Text;
        string userID = Profile.card_id;
        hR_SalaryTaxPackage.AddedBy = userID;
        hR_SalaryTaxPackage.AddedDate = DateTime.Now;
        hR_SalaryTaxPackage.ModifiedBy = userID;
        hR_SalaryTaxPackage.ModifiedDate = DateTime.Now;
        bool resutl = HR_SalaryTaxPackageManager.UpdateHR_SalaryTaxPackage(hR_SalaryTaxPackage);
        Response.Redirect("AdminDisplayHR_SalaryTaxPackage.aspx");
    }

    private void showHR_SalaryTaxPackageData()
    {
        HR_SalaryTaxPackage hR_SalaryTaxPackage = new HR_SalaryTaxPackage();
        hR_SalaryTaxPackage = HR_SalaryTaxPackageManager.GetHR_SalaryTaxPackageBySalaryTaxPackagePackageID(Int32.Parse(Request.QueryString["ID"]));
        txtSalaryTaxPackageName.Text = hR_SalaryTaxPackage.SalaryTaxPackagePackageName.ToString();
        txtSalaryTaxPackageFormula.Text = hR_SalaryTaxPackage.SalaryTaxPackageFormula.ToString();
    }
}

