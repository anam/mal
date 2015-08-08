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
public partial class AdminHR_OverTimePackage : System.Web.UI.Page
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
                showHR_OverTimePackageData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_OverTimePackage hR_OverTimePackage = new HR_OverTimePackage();
        //	hR_OverTimePackage.OverTimePackageID=  int.Parse(ddlOverTimePackageID.SelectedValue);
        hR_OverTimePackage.OverTimePackageName = txtOverTimePackageName.Text;
        hR_OverTimePackage.OverTimeFormula = txtOverTimeFormula.Text;
        string userID = Profile.card_id;
        hR_OverTimePackage.AddedBy = userID;
        hR_OverTimePackage.AddedDate = DateTime.Now;
        hR_OverTimePackage.ModifiedBy = userID;
        hR_OverTimePackage.ModifiedDate = DateTime.Now;
        int resutl = HR_OverTimePackageManager.InsertHR_OverTimePackage(hR_OverTimePackage);
        Response.Redirect("AdminDisplayHR_OverTimePackage.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_OverTimePackage hR_OverTimePackage = new HR_OverTimePackage();
        hR_OverTimePackage.OverTimePackageID = int.Parse(Request.QueryString["ID"].ToString());
        hR_OverTimePackage.OverTimePackageName = txtOverTimePackageName.Text;
        hR_OverTimePackage.OverTimeFormula = txtOverTimeFormula.Text;
        string userID = Profile.card_id;
        hR_OverTimePackage.AddedBy = userID;
        hR_OverTimePackage.AddedDate = DateTime.Now;
        hR_OverTimePackage.ModifiedBy = userID;
        hR_OverTimePackage.ModifiedDate = DateTime.Now;
        bool resutl = HR_OverTimePackageManager.UpdateHR_OverTimePackage(hR_OverTimePackage);
        Response.Redirect("AdminDisplayHR_OverTimePackage.aspx");
    }

    private void showHR_OverTimePackageData()
    {
        HR_OverTimePackage hR_OverTimePackage = new HR_OverTimePackage();
        hR_OverTimePackage = HR_OverTimePackageManager.GetHR_OverTimePackageByOverTimePackageID(Int32.Parse(Request.QueryString["ID"]));
        txtOverTimePackageName.Text = hR_OverTimePackage.OverTimePackageName.ToString();
        txtOverTimeFormula.Text = hR_OverTimePackage.OverTimeFormula.ToString();
    }
}

