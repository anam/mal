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


public partial class SearchLIB_Book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AuthorIDLoad();
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

    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        DataTable bookListDT = (DataTable)Session["tblAuthorWiseBook"];
        ReportDocument rptAuthorWiseBook = new RPT_LIB.LIB_RPT.rptAuthorWiseBook();
        TextObject rptCname = rptAuthorWiseBook.ReportDefinition.ReportObjects["txtComName"] as TextObject;
        rptCname.Text = "CUC";
        rptAuthorWiseBook.SetDataSource(bookListDT);
        Session["Report1"] = rptAuthorWiseBook;
        lbljavascript.Text = @"<script>window.open('../RptViewer.aspx?PrintOpt=" +
                            this.DDPrintOpt.SelectedValue.Trim().ToString() + "', target='_blank');</script>";

    }
    protected void lnkBtnShow_Click(object sender, EventArgs e)
    {
        DataSet bookList;
        string txtBookSearch =this.txtBookSearch.Text.ToString();

        string BookID = "0";
        string BookName = "";
        //string txtSearch = this.txtSearch.Text.ToString();

        if (txtBookSearch.Contains(','))
        {

            string[] txtSrcArray = txtBookSearch.Split(',');
            BookName = txtSrcArray[0];
            BookID = txtSrcArray[1];
        }
        else
        {
            if (IsNumber(txtBookSearch))
            {
                BookID = txtBookSearch;
            }
            else
            {
                BookName = txtBookSearch;
            }

        }

       // bookList = LIB_BookManager.LoadLIB_BookPageRpt("SearchAll_BooksByBookName", txtBookSearch);
        bookList = LIB_BookManager.SearchAll_BooksByBookName("SearchAll_BooksByBookName", BookName, BookID);
       
        DataTable tbl1 = bookList.Tables[0];
        this.gvLIB_Book.DataSource = bookList.Tables[0];
        this.gvLIB_Book.DataBind();
        if (tbl1 == null)
            return;
        Session["tblAuthorWiseBook"] = tbl1;
    }
    static bool IsNumber(string value)
    {
        // Return true if this is a number.
        int number1;
        return int.TryParse(value, out number1);
    }
}