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

public partial class INV_MRR_RptDateWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtFromDate.Text = DateTime.Today.AddDays(-7).ToString("dd-MMM-yyyy");
            this.txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            //this.MRRInfoMasterIDLoad();
        }
    }

    //private void MRRInfoMasterIDLoad()
    //{
    //    try
    //    {
    //        DataSet ds = INV_MRRInfoMasterManager.GetDropDownListAllINV_MRRInfoMaster();
    //        ddlMRRInfoMasterID.DataValueField = "MRRInfoMasterID";
    //        ddlMRRInfoMasterID.DataTextField = "MRRCode";
    //        ddlMRRInfoMasterID.DataSource = ds.Tables[0];
    //        ddlMRRInfoMasterID.DataBind();
    //        ddlMRRInfoMasterID.Items.Insert(0, new ListItem("Select MRRCode >>", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.Message.ToString();
    //    }
    //}

    protected void gvReceive_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, 1, ddlPageSize);
        Session.Remove("tblMRRInfoDateWise");
        //string MRRInfoID=this.ddlMRRInfoMasterID.SelectedValue.ToString();
        string txtFromDate=this.txtFromDate.Text.ToString();
        string txtToDate = this.txtToDate.Text.ToString();
        try
        {
            //DataSet ds = INV_MRRInfoManager.GetAllINV_MRRInfosByMRRID(txtToDate);
            DataSet ds = INV_MRRInfoManager.GetAllINV_MRRReportsDateWise("GetAllINV_MRRReportsDateWise", txtFromDate, txtToDate);
            gvINV_MRRInfo.DataSource = ds.Tables[0];
            gvINV_MRRInfo.DataBind();

            Session["tblMRRInfoDateWise"] = ds.Tables[0];
        }
        catch(Exception ex)
        {
        }
    }

    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        //Session.Remove("tblMRRInfo");
        //Session["tblBenefit"] = ds2.Tables[0];

        DataTable dt = (DataTable)Session["tblMRRInfoDateWise"];
        ReportDocument rptMRR = new RPT_LIB.INV_RPT.rptMRRInfo();
        TextObject rptCname = rptMRR.ReportDefinition.ReportObjects["txtComName"] as TextObject;
        rptCname.Text = "CUC";

        //TextObject rptpactdesc = rptsale.ReportDefinition.ReportObjects["ProjectName"] as TextObject;
        //rptpactdesc.Text = "Project Name: " + this.lblProjectName.Text;

        rptMRR.SetDataSource(dt);
        Session["Report1"] = rptMRR;
        lbljavascript.Text = @"<script>window.open('../RptViewer.aspx?PrintOpt=" +
                            this.DDPrintOpt.SelectedValue.Trim().ToString() + "', target='_blank');</script>";

    }
}