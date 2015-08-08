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


public partial class AdminDisplayINV_MRRInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CampusIDLoad();
            INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, 1, ddlPageSize);
            string totalItem = gvINV_MRRInfo.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
        }
    }

    private void CampusIDLoad()
    {
        try
        {
            DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
            ddlCampusName.DataValueField = "CampusID";
            ddlCampusName.DataTextField = "CampusName";
            ddlCampusName.DataSource = ds.Tables[0];
            ddlCampusName.DataBind();
            ddlCampusName.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void btnIssueSearch_Click(object sender, EventArgs e)
    {
        showPageDiv.Visible = true;
        string searchSQLString = "Where";

        if (ddlCampusName.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " INV_MRRInfo.CampusID = " + ddlCampusName.SelectedValue.ToString();
        }

        if (txtMRRCode.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND INV_MRRInfo.MRRCode = '" + txtMRRCode.Text.Trim() + "'";
        }  

        if (txtItemCode.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND INV_Iteam.IteamCode = '" + txtItemCode.Text.Trim() + "'";
        }           

        if (txtMRRToDate.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " INV_MRRInfo.MRRDate >= '" + txtMRRToDate.Text.Trim() + "'";
        }

        if (txtMRRFromDate.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " INV_MRRInfo.MRRDate <= '" + txtMRRFromDate.Text.Trim() + "'";
        }

        if (searchSQLString.StartsWith("Where AND"))
        {
            searchSQLString = searchSQLString.Replace("Where AND", "Where ");
        }

        if (searchSQLString.Equals("Where") != true)
        {
            gvINV_MRRInfo.DataSource = INV_MRRInfoManager.GetINV_MRRInfoBySearchString(searchSQLString);
            gvINV_MRRInfo.DataBind();

            string totalItem = gvINV_MRRInfo.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
            showPageDiv.Visible = false;
        }
        else
        {
            INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, 1, ddlPageSize);
            string totalItem = gvINV_MRRInfo.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, 1, ddlPageSize);
        string totalItem = gvINV_MRRInfo.Rows.Count.ToString("N");
        string[] totalItems = totalItem.Split('.');
        lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, pageIndex, ddlPageSize);
        string totalItem = gvINV_MRRInfo.Rows.Count.ToString("N");
        string[] totalItems = totalItem.Split('.');
        lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminINV_MRRInfo.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminINV_MRRInfo.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = INV_MRRInfoManager.DeleteINV_MRRInfo(Convert.ToInt32(linkButton.CommandArgument));
        INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, 1, ddlPageSize);
    }
}

