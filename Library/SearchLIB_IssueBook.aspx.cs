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
        string BookName = "%%";

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
        bookList = LIB_BookManager.SearchAll_IssueBooksByBookName("SearchAll_IssueBooksByBookName", BookName, BookID);
        //DataSet bookList = LIB_BookManager.LoadLIB_BookIssueRptDateWise("GetAll_LIB_BookIssueRptDateWise", fromDate, toDate);
       
        DataTable tbl1 = bookList.Tables[0];
        this.gvLIB_Book.DataSource = bookList.Tables[0];
        this.gvLIB_Book.DataBind();
        if (tbl1 == null)
            return;
        Session["tblAuthorWiseBook"] = tbl1;
    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = LIB_BookIssueManager.DeleteLIB_BookIssue(Convert.ToInt32(linkButton.CommandArgument));
        if (result)
        {
            this.txtMsg.Text="Received Successfully!";
        }
        lnkBtnShow_Click(null, null);
        //LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, 1, ddlPageSize);
    }
    static bool IsNumber(string value)
    {
        // Return true if this is a number.
        int number1;
        return int.TryParse(value, out number1);
    }
}