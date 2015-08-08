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


public partial class Inventory_INV_MRR_Rpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.MRRInfoMasterIDLoad();
        }
    }

    private void MRRInfoMasterIDLoad()
    {
        try
        {
            DataSet ds = INV_MRRInfoMasterManager.GetDropDownListAllINV_MRRInfoMaster();
            ddlMRRInfoMasterID.DataValueField = "MRRInfoMasterID";
            ddlMRRInfoMasterID.DataTextField = "MRRCode";
            ddlMRRInfoMasterID.DataSource = ds.Tables[0];
            ddlMRRInfoMasterID.DataBind();
            ddlMRRInfoMasterID.Items.Insert(0, new ListItem("Select MRRCode >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void gvReceive_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       // INV_MRRInfoManager.LoadINV_MRRInfoPage(gvINV_MRRInfo, rptPager, 1, ddlPageSize);
        Session.Remove("tblMRRInfo");
        string MRRInfoID=this.ddlMRRInfoMasterID.SelectedValue.ToString();
        try
        {
            DataSet ds = INV_MRRInfoManager.GetAllINV_MRRInfosByMRRID(MRRInfoID);
            gvINV_MRRInfo.DataSource = ds.Tables[0];
            gvINV_MRRInfo.DataBind();

            Session["tblMRRInfo"] = ds.Tables[0];
        }
        catch(Exception ex)
        {
        }
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        //Session.Remove("tblMRRInfo");
        //Session["tblBenefit"] = ds2.Tables[0];

        DataTable dt = (DataTable)Session["tblMRRInfo"];

        //ReportDocument rptMRR = new rptMRRInfo();
        //TextObject rptCname = rptMRR.ReportDefinition.ReportObjects["txtComName"] as TextObject;
        //rptCname.Text = "CUC";

        ReportDocument rptMRR = new RPT_LIB.INV_RPT.rptMRRInfo();
        TextObject rptCname = rptMRR.ReportDefinition.ReportObjects["txtComName"] as TextObject;
        rptCname.Text = "CUC";


        rptMRR.SetDataSource(dt);
        Session["Report1"] = rptMRR;
        lbljavascript.Text = @"<script>window.open('../RptViewer.aspx?PrintOpt=" +
                            this.DDPrintOpt.SelectedValue.Trim().ToString() + "', target='_blank');</script>";

    }
}