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
 

public partial class AdminDisplaySTD_Fees : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadGrid(); 
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadGrid();
        loadBounchedDataset();
    }

    private void loadGrid()
    {
        if (txtStudentID.Text == "")
        {
            STD_FeesManager.GetAllSTD_FeesList_NotPaid(gvSTD_Fees, rptPagerFeesMaster, 1, ddlPageSizeFeesMaster);
            //gvSTD_Fees.DataSource = processDataSet(STD_FeesManager.GetAllSTD_FeesList_NotPaid());
            //gvSTD_Fees.DataBind();

            divPaggingFeesMaster.Visible = true;
        }
        else
        {
            gvSTD_Fees.DataSource = STD_FeesManager.processDataSet(STD_FeesManager.GetSTD_FeesListByStudentCode(txtStudentID.Text));
            gvSTD_Fees.DataBind();

            divPaggingFeesMaster.Visible = false;
        }
    }

    protected void PageSizeFeesMaster_Changed(object sender, EventArgs e)
    {
        STD_FeesManager.GetAllSTD_FeesList_NotPaid(gvSTD_Fees, rptPagerFeesMaster, 1, ddlPageSizeFeesMaster);
    }
    protected void PageFeesMaster_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        STD_FeesManager.GetAllSTD_FeesList_NotPaid(gvSTD_Fees, rptPagerFeesMaster, pageIndex, ddlPageSizeFeesMaster);
    }

    protected void PageSize_Changed(object sender, EventArgs e)
    {
        pnPaging.Visible = true;
        ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, 1, ddlPageSize, 8);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        pnPaging.Visible = true;
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, pageIndex, ddlPageSize, 8);
    }

    protected void gvACC_Check_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hlinkProcess = (HyperLink)e.Row.FindControl("hlinkProcess");
            Label lblRemarks = (Label)e.Row.FindControl("lblRemarks");
            

            HiddenField hfCheckID = (HiddenField)e.Row.FindControl("hfCheckID");
            

            hlinkProcess.NavigateUrl = "~/Accounting/JournalDoubleEntryCommon.aspx?DrOrCr=Cr&BasicAccountID=1&SubBasicAccountID=27&AccountID=43&UserTypeID=1&StudentCode=11002010&Amount=" + lblRemarks.Text + "&UserTypeIDMoney=2&CheckID=" + hfCheckID.Value;

        }
    }

    protected void loadBounchedDataset()
    {
        try
        {
            if (txtStudentID.Text!="")
            {
                pnPaging.Visible = false;

                string WhoUser = txtStudentID.Text;

                WhoUser =  STD_StudentManager.GetHR_StudnetByStudentCode(WhoUser).StudentID;


                gvACC_Check.DataSource = ACC_CheckManager.SearchACC_Checks("", WhoUser, "", 0, "", 8);
                gvACC_Check.DataBind();
            }
            else
            {
                pnPaging.Visible = true;
                ACC_CheckManager.LoadACC_CheckPageByRowStatusID(gvACC_Check, rptPager, 1, ddlPageSize, 8);
                if (gvACC_Check.Rows.Count == 0)
                    pnPaging.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
}

