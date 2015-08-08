using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class InvItemIssue : System.Web.UI.Page
{

    public static string StrIssueNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtIssueDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            //txtIssueNo.Text = "IS" + Convert.ToDateTime(txtIssueDate.Text).ToString("MM") + "-" + NewIssueNo();
            CreateTable();
            StoreIDLoad();
            CampusIDLoad();
        }
    }
    private void CampusIDLoad()
    {
        try
        {
            DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
            ddlCampus.DataValueField = "CampusID";
            ddlCampus.DataTextField = "CampusName";
            ddlCampus.DataSource = ds.Tables[0];
            ddlCampus.DataBind();
            ddlCampus.Items.Insert(0, new ListItem("Select Campus >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void StoreIDLoad()
    {
        try
        {
            DataSet ds = INV_StoreManager.GetDropDownListAllINV_Store();
            ddlStoreFromID.DataValueField = "StoreID";
            ddlStoreFromID.DataTextField = "StoreName";
            ddlStoreFromID.DataSource = ds.Tables[0];
            ddlStoreFromID.DataBind();
            ddlStoreFromID.Items.Insert(0, new ListItem("Select Store >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    private void CreateTable()
    {
        Session.Remove("IssueItem");
        DataTable dtl = new DataTable();
        dtl.Columns.Add("issueno", Type.GetType("System.String"));
        dtl.Columns.Add("itemcode", Type.GetType("System.String"));
        dtl.Columns.Add("itemdesc", Type.GetType("System.String"));
        dtl.Columns.Add("tagid", Type.GetType("System.String"));
        dtl.Columns.Add("qty", Type.GetType("System.Double"));
        Session["IssueItem"] = dtl;
    }

    protected void lnkbtnFind_Click(object sender, EventArgs e)
    {
        string comcod = "1101";
        string search = txtFind.Text.Trim();

        DataSet ds2 = INV_MRRInfoManager.GetAllINV_Items("GetAllINV_Iteams");
        if (ds2 == null)
        {
            lblMessage.Text = "No Data Found";
            return;
        }
        this.ddlItemList.DataTextField = "Description";
        this.ddlItemList.DataValueField = "IteamID";
        this.ddlItemList.DataSource = ds2.Tables[0];
        this.ddlItemList.DataBind();
        //this.ddlItemList_SelectedIndexChanged(null, null);
        txtQty.Text = "";
        txtTagID.Text = "";
    }

    protected void lnkbtnSubmitItem_Click(object sender, EventArgs e)
    {
        if (txtTagID.Text == "")
        {
            txtTagID.Focus();
            lblFinalMessage.Text = "Enetr TagID";
            return;
        }
        lblFinalMessage.Text = "";
        if (txtQty.Text == "")
        {
            txtQty.Focus();
            lblFinalMessage.Text = "Enter Quantity";
            return;
        }
        lblFinalMessage.Text = "";

        string issueno =  txtIssueNo.Text;
        string itemcod = ddlItemList.SelectedValue;
        string itemdesc = this.ddlItemList.SelectedItem.Text.ToString();//.Substring(13, ddlItemList.SelectedItem.ToString().Length - 13);
        string tagid = this.txtTagID.Text;
        string itemqty = txtQty.Text;

        DataTable dt2 = (DataTable)Session["IssueItem"];

        //DataRow[] dr1 = dt2.Select("tagid='" + tagid + "' and itemcode='" + itemcod + "'");
        //if (dr1.Length == 1)
        //{

        //    dr1[0]["qty"] = itemqty;

        //}
        //else
        //{

            DataRow dr = dt2.NewRow();
            dr["itemcode"] = itemcod;
            dr["issueno"] = issueno;
            dr["itemdesc"] = itemdesc;
            dr["tagid"] = tagid;
            dr["qty"] = itemqty;
            dt2.Rows.Add(dr);
        //}

        Session["IssueItem"] = dt2;

        gvIssue_DataBind();
        gvIssue.Visible = true;


    }
    private void gvIssue_DataBind()
    {

        DataTable tbl = (DataTable)Session["IssueItem"];
        gvIssue.DataSource = tbl;
        gvIssue.DataBind();
        if (tbl == null)
            return;

        if (tbl.Rows.Count > 0)
        {
            ((Label)this.gvIssue.FooterRow.FindControl("gvlblTotalQty")).Text =
                    Convert.ToDouble((Convert.IsDBNull(tbl.Compute("sum(qty)", "")) ? 0.00 :
                    tbl.Compute("sum(qty)", ""))).ToString("#,##0.00;(#,##0.00); ");

        }
    }

    protected void GetNewISSNo()
    {
       // DataSet ds1 = INV_MRRInfoManager.GetAllINV_MRRInfos1("PMT_TASK_RPT", this.txtIssueDate.Text.ToString());
        DataSet dsIssueNo = INV_MRRInfoManager.GetAllINV_IssueNo(this.txtIssueDate.Text.ToString());
        this.txtIssueNo.Text = dsIssueNo.Tables[0].Rows[0]["issno"].ToString();
    }

    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        //DataTable issue = (DataTable)Session["Issueitem"];
        //RptIssue objRptIssue = new RptIssue();
        ////string nn=
        //TextObject comnam = objRptIssue.ReportDefinition.ReportObjects["txtcomn"] as TextObject;
        //comnam.Text = claientinf.comn;//clientinf.cinf(); //ddlProductList.SelectedValue.ToString();
        //TextObject Procode = objRptIssue.ReportDefinition.ReportObjects["txtProCode"] as TextObject;
        //Procode.Text = ddlProductList.SelectedValue.ToString();
        //TextObject ProDesc = objRptIssue.ReportDefinition.ReportObjects["txtProDesc"] as TextObject;
        //ProDesc.Text = ddlProductList.SelectedItem.ToString().Substring(13, ddlProductList.SelectedItem.ToString().Length - 13);
        //TextObject ProQty = objRptIssue.ReportDefinition.ReportObjects["txtProQty"] as TextObject;
        //ProQty.Text = txtProductQty.Text;

        //TextObject issueno = objRptIssue.ReportDefinition.ReportObjects["txtIssueNo"] as TextObject;
        //issueno.Text = StrIssueNo;
        //TextObject issuedate = objRptIssue.ReportDefinition.ReportObjects["txtIssueDate"] as TextObject;
        //issuedate.Text = txtIssueDate.Text;
        //TextObject storeid = objRptIssue.ReportDefinition.ReportObjects["txtStoreID"] as TextObject;
        //storeid.Text = ddlStoreFromID.Text;

        //objRptIssue.SetDataSource(issue);
        //Session["Report1"] = objRptIssue;
        //lblPrint.Text = @"<script>window.open('RptViewer.aspx?PrintOpt=" +
        //                    this.DDPrintOpt.SelectedValue.Trim().ToString() + "', target='_blank');</script>";

    }
    protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.txtTagID.Text = "";
        //string sirncode = ddlItemList.SelectedValue;
        //DataSet ds3 = pii.GetTagid(sirncode);
        //if (ds3 == null)
        //    return;

        //txtTagID.Text = ds3.Tables[0].Rows[0][0].ToString();
        txtQty.Text = "";
        txtTagID.Text = "";
        txtTagID.Focus();

    }
    protected void btnIssueUpdate_Click(object sender, EventArgs e)
    {
        DataTable dt2 = (DataTable)Session["IssueItem"];

        for (int i = 0; i < this.gvIssue.Rows.Count; i++)
        {
            string qty = ((TextBox)gvIssue.Rows[i].FindControl("gvtxtQty")).Text.Trim();

            dt2.Rows[i].BeginEdit();
            dt2.Rows[i]["Qty"] = Convert.ToDouble(qty);
            dt2.Rows[i].EndEdit();
            dt2.AcceptChanges();
        }

        Session["IssueItem"] = dt2;
        this.gvIssue.EditIndex = -1;
        this.gvIssue_DataBind();

    }
    protected void LinkFinalUpdate_Click(object sender, EventArgs e)
    {
        this.GetNewISSNo();// Save Issue info in ISSUE table
        //---------------------------
        if (ddlStoreFromID.Text == "Select Store" || txtIssueNo.Text == "" )
        {
            lblMessage.Text = "Enter Infomation Currectly";
            return;
        }
        lblMessage.Text = "";

        string comcod = "1101";
        string issueno = this.txtIssueNo.Text;
        string storeid = this.ddlStoreFromID.SelectedValue;
        string procod = this.txtRemark.Text;
        //Int32 proqty = 0; // Convert.ToInt32(txtProductQty.Text);
        string proqty = "0";
        string issuedate = txtIssueDate.Text.Trim();
        string CampusId = this.ddlCampus.SelectedValue.ToString();

        int IssueID = INV_MRRInfoManager.InsertIssueMaster("INV_InsertIssueMaster", issueno, storeid, procod, proqty, issuedate, CampusId);
        string IssueMasterId = IssueID.ToString();
        //----------------------------
        //string comcod = "1101";
        DataTable dt = (DataTable)Session["Issueitem"];
        string issdate1 = txtIssueDate.Text.Trim();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //string issueno = dt.Rows[i]["issueno"].ToString().Trim();
            string itemcod = dt.Rows[i]["itemcode"].ToString().Trim();
            string itemqty = dt.Rows[i]["qty"].ToString().Trim();
            string tagid = dt.Rows[i]["tagid"].ToString().Trim();

            int result = INV_MRRInfoManager.InsertIssueDetails("InsertINV_IssueDetail", CampusId, IssueMasterId, storeid, issueno, itemcod, tagid, itemqty, issdate1);
            if (result !=null)
                lblFinalMessage.Text = "Saved Successfully";
            else
                lblFinalMessage.Text = "Saving Failed";
        }

        //this.PanelItem.Visible = false;
        //this.LinkNew.Enabled = true;
        //this.ddlProductList.Enabled = true;
        this.txtIssueDate.Enabled = true;
        lnkbtnFind.Enabled = false;
        //this.LinkFinalUpdate.Enabled = false;
        ((LinkButton)this.gvIssue.FooterRow.FindControl("LinkFinalUpdate")).Enabled = false;
        this.lnkbtnSubmitItem.Enabled = false;

    }
    protected void gvIssue_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.gvIssue.EditIndex = -1;
        this.gvIssue_DataBind();
    }
    protected void gvIssue_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["IssueItem"];
        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        Session["IssueItem"] = dt;
        this.gvIssue_DataBind();
    }
    protected void gvIssue_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}