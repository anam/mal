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


public partial class AdminDisplayINV_Issue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StoreIDLoad();
            INV_IssueManager.LoadINV_IssuePage(gvINV_Issue, rptPager, 1, ddlPageSize);
            string totalItem = gvINV_Issue.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
        }
    }


    private void StoreIDLoad()
    {
        try
        {
            DataSet ds = INV_StoreManager.GetDropDownListAllINV_Store();
            ddlStoreName.DataValueField = "StoreID";
            ddlStoreName.DataTextField = "StoreName";
            ddlStoreName.DataSource = ds.Tables[0];
            ddlStoreName.DataBind();
            ddlStoreName.Items.Insert(0, new ListItem("Select Store >>", "0"));
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
        if (txtItemName.Text.Trim() != string.Empty)
        {
            searchSQLString += " INV_Iteam.Description = '" + txtItemName.Text.Trim() + "'";
        }

        if (txtIssueName.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND INV_IssueMaster.IssueMasterName = '" + txtIssueName.Text.Trim()+"'";
        }

        if (ddlStoreName.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND INV_Issue.StoreID = " + ddlStoreName.SelectedValue.ToString();
        }

        if (txtIssueToDate.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " INV_Issue.IssueDate >= '" + txtIssueToDate.Text.Trim() + "'";
        }

        if (txtIssueFromDate.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " INV_Issue.IssueDate <= '" + txtIssueFromDate.Text.Trim() + "'";
        }

        if (searchSQLString.StartsWith("Where AND"))
        {
            searchSQLString = searchSQLString.Replace("Where AND", "Where ");
        }

        if (searchSQLString.Equals("Where") != true)
        {
            gvINV_Issue.DataSource = INV_IssueManager.GetINV_IssueBySerachString(searchSQLString);
            gvINV_Issue.DataBind();

            string totalItem = gvINV_Issue.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
            showPageDiv.Visible = false;
        }
        else
        {
            INV_IssueManager.LoadINV_IssuePage(gvINV_Issue, rptPager, 1, ddlPageSize);
            string totalItem = gvINV_Issue.Rows.Count.ToString("N");
            string[] totalItems = totalItem.Split('.');
            lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        INV_IssueManager.LoadINV_IssuePage(gvINV_Issue, rptPager, 1, ddlPageSize);
        string totalItem = gvINV_Issue.Rows.Count.ToString("N");
        string[] totalItems = totalItem.Split('.');
        lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        INV_IssueManager.LoadINV_IssuePage(gvINV_Issue, rptPager, pageIndex, ddlPageSize);
        string totalItem = gvINV_Issue.Rows.Count.ToString("N");
        string[] totalItems = totalItem.Split('.');
        lblTotalItem.Text = "Total Item Issue : " + totalItems[0];
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminINV_Issue.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminINV_ItemIssueEntryScreen.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = INV_IssueManager.DeleteINV_Issue(Convert.ToInt32(linkButton.CommandArgument));
        INV_IssueManager.LoadINV_IssuePage(gvINV_Issue, rptPager, 1, ddlPageSize);
    }
}

