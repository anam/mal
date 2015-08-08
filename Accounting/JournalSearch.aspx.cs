using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_JournalSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        bool result = ACC_JournalMasterManager.DeleteACC_JournalMaster(Convert.ToInt32(linkButton.CommandArgument));
        btnSearch_OnClick(this, new EventArgs());
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();
        DataSet journalMaster = new DataSet();

        if (Request.QueryString["JournalMasterID"] != null)
        {
            startDate = txtFromDate.Text != "" ? DateTime.Parse(txtFromDate.Text) : DateTime.Parse("1/1/1753");
            endDate = txtTo.Text != "" ? DateTime.Parse(txtTo.Text) : DateTime.Parse("12/31/9999");  
          
            journalMaster = ACC_JournalMasterManager.SearchACC_AccountJournalMaster(Convert.ToInt32(Request.QueryString["JournalMasterID"]), startDate, endDate);
        }
        else
        {
            int journalmasterID = 0;
            startDate = txtFromDate.Text != "" ? DateTime.Parse(txtFromDate.Text) : DateTime.Parse("1/1/1753");
            endDate = txtTo.Text != "" ? DateTime.Parse(txtTo.Text) : DateTime.Parse("12/31/9999");
            journalmasterID = txtJournalMaster.Text != "" ? Convert.ToInt32(txtJournalMaster.Text) : 0;
            journalMaster = ACC_JournalMasterManager.SearchACC_AccountJournalMaster(journalmasterID, startDate, endDate);
        }

        if (journalMaster != null)
        {
            gvACC_JournalMaster.DataSource = journalMaster;
            gvACC_JournalMaster.DataBind();
        }
    }
    protected void JournalMaster_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvACC_Journal = (GridView)e.Row.FindControl("gvACC_Journal");
            Label lblJournalID = (Label)e.Row.FindControl("lblJournalID");
            DataSet journals = ACC_JournalManager.GetACC_JournalsByJournalMasterID(Convert.ToInt32(lblJournalID.Text));
            gvACC_Journal.DataSource = journals;
            gvACC_Journal.DataBind();
        }
    }
   
}