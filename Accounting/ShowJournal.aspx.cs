using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_ShowJournal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                DataSet journals = ACC_JournalManager.GetACC_JournalsByJournalMasterID(id);
                gvACC_Journal.DataSource = journals;
                gvACC_Journal.DataBind();
            }
        }
    }
    protected void gvACC_Journal_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal sumdebit=0, sumcredit=0;
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            Label lblDebit = (Label)e.Row.FindControl("lblDebit");
            Label lblCredit = (Label)e.Row.FindControl("lblCredit");

            sumdebit= Convert.ToDecimal(Session["sumdebit"])+Convert.ToDecimal(lblDebit.Text);
            sumcredit=Convert.ToDecimal(Session["sumcredit"])+Convert.ToDecimal(lblCredit.Text);

            Session["sumdebit"]=sumdebit;
            Session["sumCredit"]=sumcredit;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
           
            Label lblTotalCredit = (Label)e.Row.FindControl("lblTotalCredit");
            Label lblTotalDebit = (Label)e.Row.FindControl("lblTotalDebit");

            lblTotalDebit.Text = Session["sumdebit"].ToString() != null ? Session["sumdebit"].ToString() : "";
            lblTotalCredit.Text = Session["sumCredit"].ToString() != null ? Session["sumCredit"].ToString() : "";
            Session["sumdebit"] = null;
            Session["sumCredit"] = null;
        }
    }
}