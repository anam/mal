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


public partial class AdminDisplayHR_OverTimePackage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HR_OverTimePackageManager.LoadHR_OverTimePackagePage(gvHR_OverTimePackage, rptPager, 1, ddlPageSize);
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        HR_OverTimePackageManager.LoadHR_OverTimePackagePage(gvHR_OverTimePackage, rptPager, 1, ddlPageSize);
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        HR_OverTimePackageManager.LoadHR_OverTimePackagePage(gvHR_OverTimePackage, rptPager, pageIndex, ddlPageSize);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_OverTimePackage.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminHR_OverTimePackage.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = HR_OverTimePackageManager.DeleteHR_OverTimePackage(Convert.ToInt32(linkButton.CommandArgument));
        HR_OverTimePackageManager.LoadHR_OverTimePackagePage(gvHR_OverTimePackage, rptPager, 1, ddlPageSize);
    }

    protected void btnAddOverTimePackage_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("AdminHR_OverTimePackage.aspx");
    }
}

