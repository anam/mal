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
public partial class AdminHR_ProvidentFundSetup : System.Web.UI.Page
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
                showHR_ProvidentFundSetupData();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_ProvidentFundSetup hR_ProvidentFundSetup = new HR_ProvidentFundSetup();
        hR_ProvidentFundSetup.ServiceLenStartYear = int.Parse(txtServiceLenStartYear.Text);
        hR_ProvidentFundSetup.ServiceLenEndYear = int.Parse(txtServiceLenEndYear.Text);
        hR_ProvidentFundSetup.FundTypeID = int.Parse(ddlFundTypeID.SelectedValue);
        hR_ProvidentFundSetup.FundPercentForEmp = double.Parse(txtFundPercentForEmp.Text);

        hR_ProvidentFundSetup.AddedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
        hR_ProvidentFundSetup.AddedDate = DateTime.Now;

        int resutl = HR_ProvidentFundSetupManager.InsertHR_ProvidentFundSetup(hR_ProvidentFundSetup);
        Response.Redirect("AdminDisplayHR_ProvidentFundSetup.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        HR_ProvidentFundSetup hR_ProvidentFundSetup = new HR_ProvidentFundSetup();
        hR_ProvidentFundSetup.ProvidentFundSetupID = int.Parse(Request.QueryString["ID"].ToString());
        hR_ProvidentFundSetup.ServiceLenStartYear = int.Parse(txtServiceLenStartYear.Text);
        hR_ProvidentFundSetup.ServiceLenEndYear = int.Parse(txtServiceLenEndYear.Text);
        hR_ProvidentFundSetup.FundTypeID = int.Parse(ddlFundTypeID.SelectedValue);
        hR_ProvidentFundSetup.FundPercentForEmp = double.Parse(txtFundPercentForEmp.Text);
               
        hR_ProvidentFundSetup.ModifiedBy = "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
        hR_ProvidentFundSetup.ModifiedDate = DateTime.Now;
        bool resutl = HR_ProvidentFundSetupManager.UpdateHR_ProvidentFundSetup(hR_ProvidentFundSetup);
        Response.Redirect("AdminDisplayHR_ProvidentFundSetup.aspx");
    }

    private void showHR_ProvidentFundSetupData()
    {
        HR_ProvidentFundSetup hR_ProvidentFundSetup = new HR_ProvidentFundSetup();
        hR_ProvidentFundSetup = HR_ProvidentFundSetupManager.GetHR_ProvidentFundSetupByProvidentFundSetupID(Int32.Parse(Request.QueryString["ID"]));
        txtServiceLenStartYear.Text = hR_ProvidentFundSetup.ServiceLenStartYear.ToString();
        txtServiceLenEndYear.Text = hR_ProvidentFundSetup.ServiceLenEndYear.ToString();
        ddlFundTypeID.SelectedValue = hR_ProvidentFundSetup.FundTypeID.ToString();
        txtFundPercentForEmp.Text = hR_ProvidentFundSetup.FundPercentForEmp.ToString();        
    }    
}

