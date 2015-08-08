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
public partial class AdminHR_BenifitPackage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //           loadHR_BenifitPackageData();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                showHR_BenifitPackageData();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_BenifitPackage hR_BenifitPackage = new HR_BenifitPackage();
        //	hR_BenifitPackage.BenifitPackageID=  int.Parse(ddlBenifitPackageID.SelectedValue);
        hR_BenifitPackage.BenifitPackageName = txtBenifitPackageName.Text;
        hR_BenifitPackage.BenifitTimesYear = int.Parse(txtBenifitTimesYear.Text);
        hR_BenifitPackage.BebifitFormula = txtBebifitFormula.Text.Trim();
        hR_BenifitPackage.IsGrossBenifit = chkIsRespectGross.Checked;

        string userID = Profile.card_id;

        hR_BenifitPackage.AddedBy = userID;
        hR_BenifitPackage.AddedDate = DateTime.Now;
        int resutl = HR_BenifitPackageManager.InsertHR_BenifitPackage(hR_BenifitPackage);
        Response.Redirect("AdminDisplayHR_BenifitPackage.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_BenifitPackage hR_BenifitPackage = new HR_BenifitPackage();
        hR_BenifitPackage.BenifitPackageID = int.Parse(Request.QueryString["ID"].ToString());
        hR_BenifitPackage.BenifitPackageName = txtBenifitPackageName.Text;
        hR_BenifitPackage.BenifitTimesYear = int.Parse(txtBenifitTimesYear.Text);
        hR_BenifitPackage.BebifitFormula = txtBebifitFormula.Text;
        hR_BenifitPackage.IsGrossBenifit = chkIsRespectGross.Checked;
        
        string userID = Profile.card_id;

        hR_BenifitPackage.ModifiedBy = userID;
        hR_BenifitPackage.ModifiedDate = DateTime.Now;
        bool resutl = HR_BenifitPackageManager.UpdateHR_BenifitPackage(hR_BenifitPackage);
        Response.Redirect("AdminDisplayHR_BenifitPackage.aspx");
    }
    private void showHR_BenifitPackageData()
    {
        HR_BenifitPackage hR_BenifitPackage = new HR_BenifitPackage();
        hR_BenifitPackage = HR_BenifitPackageManager.GetHR_BenifitPackageByBenifitPackageID(Int32.Parse(Request.QueryString["ID"]));
        txtBenifitPackageName.Text = hR_BenifitPackage.BenifitPackageName.ToString();
        txtBenifitTimesYear.Text = hR_BenifitPackage.BenifitTimesYear.ToString();
        txtBebifitFormula.Text = hR_BenifitPackage.BebifitFormula.ToString();
        chkIsRespectGross.Checked = hR_BenifitPackage.IsGrossBenifit;
    }
}

