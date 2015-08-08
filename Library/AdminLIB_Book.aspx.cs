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
 public partial class AdminLIB_Book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadLIB_BookData();
         		SubjectIDLoad();
		        PublisherIDLoad();
		        AuthorIDLoad();
                Category();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showLIB_BookData();
                    //Category();

             }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	LIB_Book lIB_Book = new LIB_Book ();
//	lIB_Book.BookID=  int.Parse(ddlBookID.SelectedValue);
	lIB_Book.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	lIB_Book.PublisherID=  int.Parse(ddlPublisherID.SelectedValue);
	lIB_Book.AuthorID=  int.Parse(ddlAuthorID.SelectedValue);//ddlSubCategory
    lIB_Book.SubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
	lIB_Book.BookName=  txtBookName.Text;
	lIB_Book.BookISBN=  txtBookISBN.Text;
    lIB_Book.PublishedYear = int.Parse(txtPublishedYear.Text);
    lIB_Book.BookNo = int.Parse(txtBookNo.Text);
	lIB_Book.AddedBy=  Profile.card_id;
	lIB_Book.AddedDate=  DateTime.Now;
	lIB_Book.ModifiedBy=  Profile.card_id;
	lIB_Book.ModifiedDate=  DateTime.Now;
	int resutl =LIB_BookManager.InsertLIB_Book(lIB_Book);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_Book.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){
        try
		{
	LIB_Book lIB_Book = new LIB_Book ();
	lIB_Book.BookID=  int.Parse(Request.QueryString["ID"].ToString());
	lIB_Book.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	lIB_Book.PublisherID=  int.Parse(ddlPublisherID.SelectedValue);
	lIB_Book.AuthorID=  int.Parse(ddlAuthorID.SelectedValue);
    lIB_Book.SubCategoryID = int.Parse(ddlSubCategory.SelectedValue);
	lIB_Book.BookName=  txtBookName.Text;
	lIB_Book.BookISBN=  txtBookISBN.Text;
    lIB_Book.PublishedYear= int.Parse(txtPublishedYear.Text);
    lIB_Book.BookNo = int.Parse(txtBookNo.Text);
	lIB_Book.AddedBy=  Profile.card_id;
	lIB_Book.AddedDate=  DateTime.Now;
	lIB_Book.ModifiedBy=  Profile.card_id;
	lIB_Book.ModifiedDate=  DateTime.Now;
	bool  resutl =LIB_BookManager.UpdateLIB_Book(lIB_Book);
	}catch(Exception ex){}Response.Redirect("AdminDisplayLIB_Book.aspx");
	}
	private void showLIB_BookData()
	{
	 	LIB_Book lIB_Book  = new LIB_Book ();
	 	lIB_Book = LIB_BookManager.GetLIB_BookByBookID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlSubjectID.SelectedValue  =lIB_Book.SubjectID.ToString();
	 	ddlPublisherID.SelectedValue  =lIB_Book.PublisherID.ToString();
        ddlAuthorID.SelectedValue = lIB_Book.AuthorID.ToString();
        ddlCategory.SelectedValue = lIB_Book.CategoryID.ToString();
        ddlCategory_SelectedIndexChanged(this, new EventArgs());
        ddlSubCategory.SelectedValue = lIB_Book.SubCategoryID.ToString();
	 	txtBookName.Text =lIB_Book.BookName.ToString();
	 	txtBookISBN.Text =lIB_Book.BookISBN.ToString();
        txtPublishedYear.Text = lIB_Book.PublishedYear.ToString();
        txtBookNo.Text = lIB_Book.BookNo.ToString();
	}
	
	private void SubjectIDLoad()
	{
		try {
		DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_Subject();
		ddlSubjectID.DataValueField = "SubjectID";
		ddlSubjectID.DataTextField = "SubjectName";
		ddlSubjectID.DataSource = ds.Tables[0];
		ddlSubjectID.DataBind();
		ddlSubjectID.Items.Insert(0, new ListItem("Select Subject >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void PublisherIDLoad()
	{
		try {
		DataSet ds = LIB_PublisherManager.GetDropDownListAllLIB_Publisher();
		ddlPublisherID.DataValueField = "PublisherID";
		ddlPublisherID.DataTextField = "PublisherName";
		ddlPublisherID.DataSource = ds.Tables[0];
		ddlPublisherID.DataBind();
		ddlPublisherID.Items.Insert(0, new ListItem("Select Publisher >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void AuthorIDLoad()
	{
		try {
		DataSet ds = LIB_AuthorManager.GetDropDownListAllLIB_Author();
		ddlAuthorID.DataValueField = "AuthorID";
		ddlAuthorID.DataTextField = "AuthorName";
		ddlAuthorID.DataSource = ds.Tables[0];
		ddlAuthorID.DataBind();
		ddlAuthorID.Items.Insert(0, new ListItem("Select Author >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
    private void SubCategory(int CategoryID)
    {
        try
        {
            DataSet ds = LIB_SubCategoryManager.GetDropDownListAllLIB_SubCategory(CategoryID);
            ddlSubCategory.DataValueField = "SubCategoryID";
            ddlSubCategory.DataTextField = "SubCategoryName";
            ddlSubCategory.DataSource = ds.Tables[0];
            ddlSubCategory.DataBind();
            ddlSubCategory.Items.Insert(0, new ListItem("Select SubCategory >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
     private void Category()
    {

        try
        {
            DataSet ds = LIB_CategoryManager.GetDropDownListAllLIB_Category();
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
     
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CategoryID =Convert.ToInt32(this.ddlCategory.SelectedValue.ToString());
        SubCategory(CategoryID);
    }
}

