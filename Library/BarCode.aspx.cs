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


public partial class BarCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
   
        }
    }   
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        DataTable tbl3 = new DataTable();
        tbl3.Columns.Add("barcod", Type.GetType("System.String"));
        int i;
        string barcod = "";
        int code = Convert.ToInt32(this.txtBookCode.Text+"0");
        int qty = Convert.ToInt32(this.txtQty.Text);
        while(qty > 0)
        { 
            code = code + 1;
            for ( i = 1; qty >= i; i++)
            {
                DataRow dr1 = tbl3.NewRow();
                 dr1["barcod"] = code;
                 tbl3.Rows.Add(dr1);
                 break;
            }
            qty--;          
        }

        DataTable dtBarcod = (DataTable)tbl3;       
        ReportDocument rptAuthorWiseBook = new RPT_LIB.LIB_RPT.Barcod();
        rptAuthorWiseBook.SetDataSource(dtBarcod);
        Session["Report1"] = rptAuthorWiseBook;
        lbljavascript.Text = @"<script>window.open('../RptViewer.aspx?PrintOpt=" +
                            this.DDPrintOpt.SelectedValue.Trim().ToString() + "', target='_blank');</script>";

    }
    protected void lnkBtnShow_Click(object sender, EventArgs e)
    {
        
        //string fromDate=this.txtFromDate.Text.ToString();
        //string toDate = this.txtToDate.Text.ToString();
       
        //DataSet bookList = LIB_BookManager.LoadLIB_BookIssueRptDateWise("GetAll_LIB_BookIssueRptDateWise", fromDate, toDate);
       
        //DataTable tbl1 = bookList.Tables[0];
        //this.gvLIB_Book.DataSource = bookList.Tables[0];
        //this.gvLIB_Book.DataBind();
        //if (tbl1 == null)
        //    return;
        //Session["tblAuthorWiseBook"] = tbl1;
    }
}