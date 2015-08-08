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
public partial class AdminHR_SalaryIncrementPackage : System.Web.UI.Page
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
                showHR_SalaryIncrementPackageData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_SalaryIncrementPackage hR_SalaryIncrementPackage = new HR_SalaryIncrementPackage();
        //	hR_SalaryIncrementPackage.SalaryIncrementPackageID=  int.Parse(ddlSalaryIncrementPackageID.SelectedValue);
        hR_SalaryIncrementPackage.SalaryIncrementPackageName = txtSalaryIncrementPackageName.Text;
        hR_SalaryIncrementPackage.SalaryIncrementFormula = txtSalaryIncrementFormula.Text;
        string userID = Profile.card_id;
        hR_SalaryIncrementPackage.AddedBy = userID;
        hR_SalaryIncrementPackage.AddedDate = DateTime.Now;
        hR_SalaryIncrementPackage.ModifiedBy = userID;
        hR_SalaryIncrementPackage.ModifiedDate = DateTime.Now;
        int resutl = HR_SalaryIncrementPackageManager.InsertHR_SalaryIncrementPackage(hR_SalaryIncrementPackage);
        Response.Redirect("AdminDisplayHR_SalaryIncrementPackage.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_SalaryIncrementPackage hR_SalaryIncrementPackage = new HR_SalaryIncrementPackage();
        hR_SalaryIncrementPackage.SalaryIncrementPackageID = int.Parse(Request.QueryString["ID"].ToString());
        hR_SalaryIncrementPackage.SalaryIncrementPackageName = txtSalaryIncrementPackageName.Text;
        hR_SalaryIncrementPackage.SalaryIncrementFormula = txtSalaryIncrementFormula.Text;
        string userID = Profile.card_id;
        hR_SalaryIncrementPackage.AddedBy = userID;
        hR_SalaryIncrementPackage.AddedDate = DateTime.Now;
        hR_SalaryIncrementPackage.ModifiedBy = userID;
        hR_SalaryIncrementPackage.ModifiedDate = DateTime.Now;
        bool resutl = HR_SalaryIncrementPackageManager.UpdateHR_SalaryIncrementPackage(hR_SalaryIncrementPackage);
        Response.Redirect("AdminDisplayHR_SalaryIncrementPackage.aspx");
    }

    private void showHR_SalaryIncrementPackageData()
    {
        HR_SalaryIncrementPackage hR_SalaryIncrementPackage = new HR_SalaryIncrementPackage();
        hR_SalaryIncrementPackage = HR_SalaryIncrementPackageManager.GetHR_SalaryIncrementPackageBySalaryIncrementPackageID(Int32.Parse(Request.QueryString["ID"]));
        if (hR_SalaryIncrementPackage != null)
        {
            txtSalaryIncrementPackageName.Text = hR_SalaryIncrementPackage.SalaryIncrementPackageName.ToString();
            txtSalaryIncrementFormula.Text = hR_SalaryIncrementPackage.SalaryIncrementFormula.ToString();
        }
    }
}

