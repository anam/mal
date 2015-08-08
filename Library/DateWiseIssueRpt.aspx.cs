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


public partial class DateWiseIssueRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            
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
        
        string fromDate=this.txtFromDate.Text.ToString();
        string toDate = this.txtToDate.Text.ToString();
        //DataSet bookList = LIB_BookManager.LoadLIB_BookPageRpt("GetAll_BooksByAuthorID","");
        DataSet bookList = LIB_BookManager.LoadLIB_BookIssueRptDateWise("GetAll_LIB_BookIssueRptDateWise", fromDate, toDate);
       
        DataTable tbl1 = bookList.Tables[0];
        this.gvLIB_Book.DataSource = bookList.Tables[0];
        this.gvLIB_Book.DataBind();
        if (tbl1 == null)
            return;
        Session["tblAuthorWiseBook"] = tbl1;
    }
}