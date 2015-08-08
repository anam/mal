using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminINV_ItemIssueEntryScreen : System.Web.UI.Page
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
            lnkbtnFind_Click(null, null);
            if (Request.QueryString["ID"] != null)
            {
                ShowData(sender, e);
                btnUpdate.Visible = true;
                lnkbtnSubmitItem.Visible = false;                
            }            
        }
    }

    private void ShowData(object sender, EventArgs e)
    {
        try
        {
            int iNVIssueID = Convert.ToInt32(Request.QueryString["ID"]);
            INV_Issue issue = INV_IssueManager.GetINV_IssueByIssueID(iNVIssueID);
            if (issue != null)
            {
                INV_IssueMaster issueMaster = null;
                if (issue.IssueMasterID != null)
                {
                    issueMaster = INV_IssueMasterManager.GetINV_IssueMasterByIssueMasterID(issue.IssueMasterID);
                    if (issueMaster != null)
                    {
                        hdnIssueMasterID.Value = issueMaster.IssueMasterID.ToString();
                        txtRemark.Text = issueMaster.IssueMasterName;
                        txtRemark.ReadOnly = true;
                        txtIssueDate.Text = issueMaster.IssueDate.ToString("dd MMM yyyy");
                        txtIssueDate.ReadOnly = true;
                    }
                }
                hdnIssueID.Value = issue.IssueID.ToString();
                txtIssueNo.Text = issue.IssueNo;
                txtIssueNo.ReadOnly = true;
                //txtIssueDate.Text = issue.IssueDate.ToString("dd MMM yyyy");
                txtTagID.Text = issue.TagID;
                txtTagID.ReadOnly = true;
                string[] qntArray = issue.Quantity.ToString().Split('.');
                txtQty.Text = qntArray.Length >0 ? qntArray[0] :"0";
                hdnTotalQnty.Value = txtQty.Text;
                ddlCampus.SelectedValue = issue.CampusID.ToString();
                ddlStoreFromID.SelectedValue = issue.StoreID.ToString();
                ddlStoreFromID.Enabled = false;
                ddlStoreFromID_OnSelectedIndexChanged(sender, e);
                ddlItemList.SelectedValue = issue.ItemID.ToString();
                ddlItemList.Enabled = false;
                ddlItemList_SelectedIndexChanged1(sender, e);
            }
        }
        catch (Exception ex)
        {
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
        dtl.Columns.Add("storeID", Type.GetType("System.String"));
        dtl.Columns.Add("itemcode", Type.GetType("System.String"));
        dtl.Columns.Add("itemdesc", Type.GetType("System.String"));
        dtl.Columns.Add("tagid", Type.GetType("System.String"));
        dtl.Columns.Add("qty", Type.GetType("System.Double"));
        Session["IssueItem"] = dtl;
    }

    protected void lnkbtnFind_Click(object sender, EventArgs e)
    {
        string comcod = "1101";
        //string search = txtFind.Text.Trim();

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
        //txtQty.Text = "";
        //txtTagID.Text = "";
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
            hdnTotalQnty.Value = Convert.ToDouble((Convert.IsDBNull(tbl.Compute("sum(qty)", "")) ? 0.00 :
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

    protected void ddlStoreFromID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlStoreFromID.SelectedValue) > 0)
        {
            INV_Store store = INV_StoreManager.GetINV_StoreByStoreID(Convert.ToInt32(ddlStoreFromID.SelectedValue));
            if (store != null)
            {
                if (store.CampusID != null)
                {
                    COMN_Campus campus = COMN_CampusManager.GetCOMN_CampusByCampusID(store.CampusID);
                    if (campus != null)
                    {
                        lblCampusName.Text = campus.CampusName;
                    }
                }
            }
        }
        else
        {
            lblCampusName.Text = string.Empty;
        }
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
        if (ddlStoreFromID.Text == "Select Store" || txtIssueNo.Text == "")
        {
            lblMessage.Text = "Enter Infomation Currectly";
            return;
        }
        lblMessage.Text = "";

        string comcod = "1101";
        string issueno = this.txtIssueNo.Text;
        string storeid = this.ddlStoreFromID.SelectedValue;
        string masterName = this.txtRemark.Text;
        string proqty = "0";
        if (hdnTotalQnty.Value != string.Empty)
        {
            proqty = hdnTotalQnty.Value;
        }
        
        string issuedate = txtIssueDate.Text.Trim();
        string CampusId = this.ddlCampus.SelectedValue.ToString();

        int IssueMasID = INV_MRRInfoManager.InsertIssueMaster("INV_InsertIssueMaster", issueno, storeid, masterName, proqty, issuedate, CampusId);
        string IssueMasterId = IssueMasID.ToString();
        //----------------------------
        //string comcod = "1101";
        DataTable dt = (DataTable)Session["Issueitem"];
        string issdate1 = txtIssueDate.Text.Trim();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //string issueno = dt.Rows[i]["issueno"].ToString().Trim();
            //string itemcod = dt.Rows[i]["itemcode"].ToString().Trim();
            //string itemqty = dt.Rows[i]["qty"].ToString().Trim();
            //string tagid = dt.Rows[i]["tagid"].ToString().Trim();

            INV_Issue issue = new INV_Issue();
            issue.IssueMasterID = IssueMasID;
            issue.IssueNo = dt.Rows[i]["issueNo"].ToString().Trim();
            issue.StoreID = Convert.ToInt32( dt.Rows[i]["storeID"].ToString().Trim());
            issue.ItemID = Convert.ToInt32(dt.Rows[i]["itemcode"].ToString().Trim());
            issue.Quantity  = Convert.ToDecimal( dt.Rows[i]["qty"].ToString().Trim());
            issue.TagID = dt.Rows[i]["tagid"].ToString().Trim();
            issue.IssueDate =Convert.ToDateTime( issuedate);
            issue.ProductionCode = "0";
            issue.AddedBy = Profile.card_id;
            issue.AddedDate = DateTime.Now;

            //int result = INV_MRRInfoManager.InsertIssueDetails("InsertINV_IssueDetail", CampusId, IssueMasterId, storeid, issueno, itemcod, tagid, itemqty, issdate1);
            int result = INV_IssueManager.InsertINV_Issue(issue);
            if (result != null)
                lblFinalMessage.Text = "Saved Successfully";
            else
                lblFinalMessage.Text = "Saving Failed";
        }

        this.txtIssueDate.Enabled = true;
        ((LinkButton)this.gvIssue.FooterRow.FindControl("LinkFinalUpdate")).Enabled = false;
        this.lnkbtnSubmitItem.Enabled = false;

    }

    protected void btnUpdate_OnClick(object sender, EventArgs e)
    {
        lblMessage.Text = "";       
        INV_Issue issue = new INV_Issue();
        issue.IssueMasterID = Convert.ToInt32(hdnIssueMasterID.Value);
        issue.IssueID = Convert.ToInt32(hdnIssueID.Value);

        issue.IssueNo = txtIssueNo.Text.Trim();
        issue.StoreID = Convert.ToInt32(ddlStoreFromID.SelectedValue);

        issue.ItemID = Convert.ToInt32(ddlItemList.SelectedValue);

        issue.Quantity = Convert.ToDecimal(txtQty.Text.Trim());

        issue.TagID = txtTagID.Text.Trim();
        issue.IssueDate = Convert.ToDateTime(txtIssueDate.Text.Trim());
        issue.ProductionCode = "0";
        //string userID = Profile.card_id;
        issue.UpdatedBy = Profile.card_id;
        issue.UpdatedDate = DateTime.Now;

        INV_IssueMaster issueMaster = new INV_IssueMaster();
        if (hdnIssueMasterID.Value != string.Empty)
        {
            issueMaster = INV_IssueMasterManager.GetINV_IssueMasterByIssueMasterID(Convert.ToInt32(hdnIssueMasterID.Value));
            if (issueMaster != null)
            {
                issueMaster.Quantity = issueMaster.Quantity - ((Convert.ToDecimal(hdnTotalQnty.Value)) - Convert.ToDecimal(txtQty.Text.Trim()));
                issueMaster.UpdatedBy = Profile.card_id;
                issueMaster.UpdatedDate = DateTime.Now;
                INV_IssueMasterManager.UpdateINV_IssueMaster(issueMaster);
            }
        }
        
        bool result = INV_IssueManager.UpdateINV_Issue(issue);
        if (result == true)
        {
            lblFinalMessage.Text = "Updated Successfully";
        }
        else
        {
            lblFinalMessage.Text = "Updating Failed";
        }
        Response.Redirect("AdminDisplayINV_Issue.aspx");
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
        //string test = this.txtAvaQtyCheck.Text;
        //if (test == "")
        //    return;

        if (Decimal.Parse(this.txtAvaQtyCheck.Text) <= 0)
        {
            this.lblMessage.Text = "The Item is not avail able!";
            return;
        }
        if (Decimal.Parse(this.txtAvaQtyCheck.Text) < Decimal.Parse(this.txtQty.Text))
        {
            this.lblMessage.Text = "Not avail able quantity";
            return;
        }

        lblFinalMessage.Text = "";
        this.GetNewISSNo(); // Save Issue info in ISSUE table
        string issueno = txtIssueNo.Text;
        string storeID = ddlStoreFromID.SelectedValue;
        string itemcod = ddlItemList.SelectedValue;
        string itemdesc = this.ddlItemList.SelectedItem.Text.ToString(); //.Substring(13, ddlItemList.SelectedItem.ToString().Length - 13);
        string tagid = this.txtTagID.Text;
        string itemqty = txtQty.Text;

        DataTable dt2 = (DataTable)Session["IssueItem"];
        DataRow[] dr1 = null;
        //if (dt2 != null)
        //{
            dr1 = dt2.Select("tagid='" + tagid + "' and itemcode='" + itemcod + "'");
        //}
        //else
        //{
        //    dt2 = new DataTable();
        //}
        //if (dr1 != null)
        //{
            if (dr1.Length == 1)
            {
                dr1[0]["qty"] = itemqty;
            }
        //}
        else
        {
            DataRow dr = dt2.NewRow();
            dr["issueno"] = issueno;
            dr["storeID"] = storeID;
            dr["itemcode"] = itemcod;
            dr["itemdesc"] = itemdesc;
            dr["tagid"] = tagid;
            dr["qty"] = itemqty;
            dt2.Rows.Add(dr);
        }

        Session["IssueItem"] = dt2;

        gvIssue_DataBind();
        gvIssue.Visible = true;

        this.txtTagID.Text = "";
        //this.txtRemark.Text = "";
        this.txtQty.Text = "";
    }

    protected void ddlItemList_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            txtAvaQtyCheck.Text = "";
            DataSet AvlQty = new DataSet();
            if (Convert.ToInt32(ddlStoreFromID.SelectedValue) > 0)
            {
                INV_Store store = INV_StoreManager.GetINV_StoreByStoreID(Convert.ToInt32(ddlStoreFromID.SelectedValue));
                if (store != null)
                {
                    AvlQty = INV_IssueManager.GetAllINV_IssuesCheckAvlqty(Convert.ToInt32(this.ddlItemList.SelectedValue), store.CampusID, Convert.ToInt32(this.ddlStoreFromID.SelectedValue));  //(this.txtIssueDate.Text.ToString());
                }
            }
           

            if (AvlQty == null)
                return;
            this.txtAvaQtyCheck.Text = AvlQty.Tables[0].Rows[0]["avlqty"].ToString();
            lblOnHand.Text = "On hand";
            if (Decimal.Parse(this.txtAvaQtyCheck.Text) <= 0)
            {
                //txtAvaQtyCheck.Text = "Not Avail Able";
                lblMessage.Text = "The Item is not available!";
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}