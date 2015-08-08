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


public partial class AdminDisplayLIB_Book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SubjectIDLoad();
            AuthorIDLoad();
            PublisherIDLoad();
            
            LIB_BookManager.LoadLIB_BookPage(gvLIB_Book, rptPager, 1, ddlPageSize);
            string totalBook = gvLIB_Book.Rows.Count.ToString("N");
            string[] totalBooks = totalBook.Split('.');
            lblTotalBook.Text = "Total Book : " + totalBooks[0];
        }
    }


    private void SubjectIDLoad()
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds.Tables[0];
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void PublisherIDLoad()
    {
        try
        {
            DataSet ds = LIB_PublisherManager.GetDropDownListAllLIB_Publisher();
            ddlPublisherID.DataValueField = "PublisherID";
            ddlPublisherID.DataTextField = "PublisherName";
            ddlPublisherID.DataSource = ds.Tables[0];
            ddlPublisherID.DataBind();
            ddlPublisherID.Items.Insert(0, new ListItem("Select Publisher >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void AuthorIDLoad()
    {
        try
        {
            DataSet ds = LIB_AuthorManager.GetDropDownListAllLIB_Author();
            ddlAuthorID.DataValueField = "AuthorID";
            ddlAuthorID.DataTextField = "AuthorName";
            ddlAuthorID.DataSource = ds.Tables[0];
            ddlAuthorID.DataBind();
            ddlAuthorID.Items.Insert(0, new ListItem("Select Author >>", "0"));
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
        if (txtBook.Text.Trim() != string.Empty)
        {
            searchSQLString += " LIB_Book.BookName = '" + txtBook.Text.Trim() + "'";
        }

        if (ddlSubjectID.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND LIB_Book.SubjectID = " + ddlSubjectID.SelectedValue.ToString();
        }

        if (ddlAuthorID.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND LIB_Book.AuthorID = " + ddlAuthorID.SelectedValue.ToString();
        }

        if (ddlPublisherID.SelectedValue.Equals("0") != true)
        {
            searchSQLString += " AND LIB_Book.PublisherID = " + ddlPublisherID.SelectedValue.ToString();
        }

        if (txtBookISBN.Text.Trim() != string.Empty)
        {
            searchSQLString += " AND LIB_Book.BookISBN = '" + txtBookISBN.Text.Trim() + "'";
        }

        if (searchSQLString.StartsWith("Where AND"))
        {
            searchSQLString= searchSQLString.Replace("Where AND", "Where ");
        }

        if (searchSQLString.Equals("Where") != true)
        {
            gvLIB_Book.DataSource = LIB_BookManager.GetLIB_BookBySearchString(searchSQLString);
            gvLIB_Book.DataBind();
            string totalBook = gvLIB_Book.Rows.Count.ToString("N");
            string[] totalBooks = totalBook.Split('.');
            lblTotalBook.Text = "Total Book : " + totalBooks[0];
            showPageDiv.Visible = false;
        }
        else
        {
            LIB_BookManager.LoadLIB_BookPage(gvLIB_Book, rptPager, 1, ddlPageSize);
            string totalBook = gvLIB_Book.Rows.Count.ToString("N");
            string[] totalBooks = totalBook.Split('.');
            lblTotalBook.Text = "Total Book : " + totalBooks[0];
        }
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        LIB_BookManager.LoadLIB_BookPage(gvLIB_Book, rptPager, 1, ddlPageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        LIB_BookManager.LoadLIB_BookPage(gvLIB_Book, rptPager, pageIndex, ddlPageSize);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLIB_Book.aspx?ID=0");
    }
    protected void lbSelect_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        int id;
        id = Convert.ToInt32(linkButton.CommandArgument);
        Response.Redirect("AdminLIB_Book.aspx?ID=" + id);
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = LIB_BookManager.DeleteLIB_Book(Convert.ToInt32(linkButton.CommandArgument));
        LIB_BookManager.LoadLIB_BookPage(gvLIB_Book, rptPager, 1, ddlPageSize);
    }
}

