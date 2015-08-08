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


public partial class IssueBook_ByBarcod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AuthorIDLoad();
        }
    }
   

    
    protected void lnkBtnShow_Click(object sender, EventArgs e)
    {
       
        Session.Remove("tblIssueBook");
        Session.Remove("tblReceiveBook");
        this.gvLIB_ReceiveBook.DataSource = null;
        this.gvLIB_ReceiveBook.DataBind();

        DataSet bookList;
        string txtBookSearch =this.txtBookSearch.Text.ToString();
        bookList = LIB_BookManager.IssueBook_ByBarcod("IssueBook_ByBarcod", txtBookSearch);
        if (bookList == null)
            return;
        if (bookList.Tables[0].Rows == null)
            return;
        DataTable tbl1 = bookList.Tables[0];
        if (tbl1 == null)
            return;
        Session["tblIssueBook"] = tbl1;
        this.gvLIB_Book.DataSource = (DataTable)Session["tblIssueBook"];
        this.gvLIB_Book.DataBind();      
    }

    protected void lnkBtnReceive_Click(object sender, EventArgs e)
    {
        Session.Remove("tblIssueBook");
        Session.Remove("tblReceiveBook");
        this.gvLIB_Book.DataSource = null;
        this.gvLIB_Book.DataBind();

        DataSet bookList1;
        string txtBookCode = this.txtBookSearch.Text.ToString();
        bookList1 = LIB_BookManager.ReceiveBook_ByBarcod("ReceiveBook_ByBarcod", txtBookCode);
        DataTable tbl1 = bookList1.Tables[0];
        if (tbl1 == null)
            return;
        Session["tblReceiveBook"] = tbl1;
        this.gvLIB_ReceiveBook.DataSource = (DataTable)Session["tblReceiveBook"];
        this.gvLIB_ReceiveBook.DataBind();

    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        Session.Remove("tblIssueBook");
        Session.Remove("tblReceiveBook");

        LinkButton linkButton = new LinkButton();
        linkButton = (LinkButton)sender;
        bool result = LIB_BookIssueManager.DeleteLIB_BookIssue(Convert.ToInt32(linkButton.CommandArgument));
        if (result)
        {
            this.txtMsg.Text = "Received Successfully!";
        }
        lnkBtnReceive_Click(null, null);
        //LIB_BookIssueManager.LoadLIB_BookIssuePage(gvLIB_BookIssue, rptPager, 1, ddlPageSize);
    }
}