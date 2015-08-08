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


public partial class AdminDisplayLIB_BookIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BookIDLoad();
            LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, 1, ddlPageSize);
        }
    }

    private void BookIDLoad()
    {

        try
        {
            DataSet ds = LIB_BookManager.GetDropDownListAllLIB_Book();
            ddlBookID.DataValueField = "BookID";
            ddlBookID.DataTextField = "BookName";
            ddlBookID.DataSource = ds.Tables[0];
            ddlBookID.DataBind();
            ddlBookID.Items.Insert(0, new ListItem("Select Book >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, 1, ddlPageSize);
    }

    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, pageIndex, ddlPageSize);
    }

    protected void btnIssueSearch_Click(object sender, EventArgs e)
    {
        showPageDiv.Visible = true;
        string searchSQLString = "Where";
        if (ddlBookID.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " LIB_BookIssue.BookID = " + ddlBookID.SelectedValue;
        }

        if (txtIssueTo.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " LIB_BookIssue.IssedToID = '" + txtIssueTo.Text.Trim() + "'";
        }

        if (txtIssueToDate.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " LIB_BookIssue.IssueDate >= '" + txtIssueToDate.Text.Trim() + "'";
        }

        if (txtIssueFromDate.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND " + " LIB_BookIssue.IssueDate <= '" + txtIssueFromDate.Text.Trim() + "'";
        }

        if (searchSQLString.StartsWith("Where AND", System.StringComparison.OrdinalIgnoreCase))
        {
            searchSQLString= searchSQLString.Replace("Where AND", "Where ");
        }

        if (searchSQLString.Equals("Where") != true)
        {
            gvLIB_BookIssue.DataSource = LIB_BookIssueManager.GetLIB_IssueBooksBySearchString(searchSQLString);
            gvLIB_BookIssue.DataBind();
            showPageDiv.Visible = false;
        }
        else
        {
            LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, 1, ddlPageSize);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDisplayLIB_BookIssue.aspx?ID=0");
    }

    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminLIB_BookIssue.aspx?ID=" + id);
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = LIB_BookIssueManager.DeleteLIB_BookIssue(Convert.ToInt32(linkButton.CommandArgument));
        if (!result)
        {
            txtMassage.Text = "      Received Successfully!";
        }
        LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, 1, ddlPageSize);
    }
}

