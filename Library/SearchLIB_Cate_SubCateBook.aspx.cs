using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using RPT_LIB;


public partial class SearchLIB_Cate_SubCateBook: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AuthorIDLoad();
            Category();
            SubCategory(0);
        }
    }
    //private void AuthorIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = LIB_AuthorManager.GetDropDownListAllLIB_Author();
    //        ddlAuthorID.DataValueField = "AuthorID";
    //        ddlAuthorID.DataTextField = "AuthorName";
    //        ddlAuthorID.DataSource = ds.Tables[0];
    //        ddlAuthorID.DataBind();
    //        ddlAuthorID.Items.Insert(0, new ListItem("Select Author >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}
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
        int CategoryID = Convert.ToInt32(this.ddlCategory.SelectedValue.ToString());
        SubCategory(CategoryID);
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
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        DataTable bookListDT = (DataTable)Session["tblCategorySubCategory"];
        ReportDocument rptAuthorWiseBook = new RPT_LIB.LIB_RPT.rptCate_SubCategoryWise();//rptCateSubCategoryWise();//rptAuthorWiseBook();
        TextObject rptCname = rptAuthorWiseBook.ReportDefinition.ReportObjects["txtComName"] as TextObject;
        rptCname.Text = "CUC";
        TextObject txtTitle = rptAuthorWiseBook.ReportDefinition.ReportObjects["txtTitle"] as TextObject;
        txtTitle.Text = "Category Sub Category Wise Report";

        //txtTitle
        rptAuthorWiseBook.SetDataSource(bookListDT);
        Session["Report1"] = rptAuthorWiseBook;
        lbljavascript.Text = @"<script>window.open('../RptViewer.aspx?PrintOpt=" +
                            this.DDPrintOpt.SelectedValue.Trim().ToString() + "', target='_blank');</script>";

    }
    protected void lnkBtnShow_Click(object sender, EventArgs e)
    {
        DataSet bookList;
        //string txtBookSearch =this.txtBookSearch.Text.ToString();

        string BookID = "0";
        string BookName = "";
        //string txtSearch = this.txtSearch.Text.ToString();

        //if (txtBookSearch.Contains(','))
        //{

        //    string[] txtSrcArray = txtBookSearch.Split(',');
        //    BookName = txtSrcArray[0];
        //    BookID = txtSrcArray[1];
        //}
        //else
        //{
        //    if (IsNumber(txtBookSearch))
        //    {
        //        BookID = txtBookSearch;
        //    }
        //    else
        //    {
        //        BookName = txtBookSearch;
        //    }

        //}

        //bookList = LIB_BookManager.LoadLIB_BookPageRpt("SearchAll_BooksByBookName", txtBookSearch);
        int category =Convert.ToInt32(this.ddlCategory.SelectedItem.Value);
        int subcategory = Convert.ToInt32(this.ddlSubCategory.SelectedItem.Value);
        bookList = LIB_BookManager.SearchAll_BooksCat_SubCategory("SearchAll_BooksCat_SubCategory", category, subcategory);
        //bookList = LIB_BookManager.SearchAll_BooksByBookName("SearchAll_BooksByBookName", BookName, BookID);
       
        DataTable tbl1 = bookList.Tables[0];
        this.gvLIB_Book.DataSource = bookList.Tables[0];
        this.gvLIB_Book.DataBind();
        if (tbl1 == null)
            return;
        Session["tblCategorySubCategory"] = tbl1;
    }
    static bool IsNumber(string value)
    {
        // Return true if this is a number.
        int number1;
        return int.TryParse(value, out number1);
    }
}