using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class InvItemReceve : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtMRRDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
           // txtMRRNo.Text = "MR" + Convert.ToDateTime(txtMRRDate.Text).ToString("MM") + "-" + GetNewMRRNo();
            createtable();
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
            ddlStoreID.DataValueField = "StoreID";
            ddlStoreID.DataTextField = "StoreName";
            ddlStoreID.DataSource = ds.Tables[0];
            ddlStoreID.DataBind();
            ddlStoreID.Items.Insert(0, new ListItem("Select Store >>", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void createtable()
    {
        DataTable tbl1 = new DataTable();

        tbl1.Columns.Add("sircode", Type.GetType("System.String"));
        tbl1.Columns.Add("sirdesc1", Type.GetType("System.String"));
        tbl1.Columns.Add("sirunit", Type.GetType("System.String"));
        tbl1.Columns.Add("tagid", Type.GetType("System.String"));
        tbl1.Columns.Add("mrrqty", Type.GetType("System.Double"));
        tbl1.Columns.Add("mrrrat", Type.GetType("System.Double"));
        tbl1.Columns.Add("mrramt", Type.GetType("System.Double"));
        tbl1.Columns.Add("salrat", Type.GetType("System.Double"));
        tbl1.Columns.Add("salamt", Type.GetType("System.Double"));
        Session["tblgvReceive"] = tbl1;
    }
    protected void GetNewMRRNo()
    {
        DataSet ds1 = INV_MRRInfoManager.GetAllINV_MRRInfos1("PMT_TASK_RPT", this.txtMRRDate.Text.ToString());
        this.txtMRRNo.Text = ds1.Tables[0].Rows[0]["MRNO"].ToString();
    }
    protected void lbtnItem_Click(object sender, EventArgs e)
    {
        DataSet ds2 = INV_MRRInfoManager.GetAllINV_Items("GetAllINV_Iteams");
        this.ddlItemDesc.DataTextField = "Description";
        this.ddlItemDesc.DataValueField = "IteamID";
        this.ddlItemDesc.DataSource = ds2.Tables[0];
        this.ddlItemDesc.DataBind();
    }
    protected void lnkBtnAdd_Click(object sender, EventArgs e)
    {

        if (txtTag.Text == "" || txtQty.Text == "" || txtSalesRate.Text == "" || txtMRRRate.Text == "")
        {
            lblMessage.Text = "Incorrect Input";

            return;
        }
        lblMessage.Text = "";

        this.gvReceive_UpdateSession();

        string m_sircode = this.ddlItemDesc.SelectedValue.ToString();
        string m_sirdesc1 = this.ddlItemDesc.SelectedItem.Text.Trim();
        string m_sirunit = this.lblUnit.Text.Trim();
        string m_tagid = this.txtTag.Text.Trim();
        double m_mrrqty = Convert.ToDouble("0" + this.txtQty.Text.Trim());
        double m_mrrrat = Convert.ToDouble("0" + this.txtMRRRate.Text.Trim());
        double m_salrat = Convert.ToDouble("0" + this.txtSalesRate.Text.Trim());
        double m_mrramt = m_mrrqty * m_mrrrat;
        double m_salamt = m_mrrqty * m_salrat;

        DataTable tbl1 = (DataTable)Session["tblgvReceive"];

        //DataRow[] dr = tbl1.Select("tagid='" + m_tagid + "' and sircode='" + m_sircode + "'");
        //if (dr.Length == 1)
        //{

        //    dr[0]["mrrqty"] = m_mrrqty;
        //    dr[0]["mrrrat"] = m_mrrrat;
        //    dr[0]["salrat"] = m_salrat;
        //    dr[0]["mrramt"] = m_mrramt;
        //    dr[0]["salamt"] = m_salamt;
        //}
        //else
        //{
            DataRow dr1 = tbl1.NewRow();
            dr1["sircode"] = m_sircode;
            dr1["sirdesc1"] = m_sirdesc1;
            dr1["sirunit"] = m_sirunit;
            dr1["tagid"] = m_tagid;
            dr1["mrrqty"] = m_mrrqty;
            dr1["mrrrat"] = m_mrrrat;
            dr1["salrat"] = m_salrat;
            dr1["mrramt"] = m_mrramt;
            dr1["salamt"] = m_salamt;
            tbl1.Rows.Add(dr1);
        //}

        Session["tblgvReceive"] = tbl1;
        this.gvReceive_DataBind();
    }

    protected void gvReceive_DataBind()
    {
        DataTable tbl1 = (DataTable)Session["tblgvReceive"];

        this.gvReceive.DataSource = tbl1;
        this.gvReceive.DataBind();
        if (tbl1 == null)
            return;

        if (tbl1.Rows.Count > 0)
        {
            ((Label)this.gvReceive.FooterRow.FindControl("lblgvReceiveMRRTotalAmt")).Text =
                    Convert.ToDouble((Convert.IsDBNull(tbl1.Compute("sum(mrramt)", "")) ? 0.00 :
                    tbl1.Compute("sum(mrramt)", ""))).ToString("#,##0.00;(#,##0.00); ");

            ((Label)this.gvReceive.FooterRow.FindControl("lblgvReceiveSalesTotalAmt")).Text =
                    Convert.ToDouble((Convert.IsDBNull(tbl1.Compute("sum(salamt)", "")) ? 0.00 :
                    tbl1.Compute("sum(salamt)", ""))).ToString("#,##0.00;(#,##0.00); ");
        }
    }

    protected void gvReceive_UpdateSession()
    {
        DataTable tbl1 = (DataTable)Session["tblgvReceive"];

        for (int i = 0; i < this.gvReceive.Rows.Count; i++)
        {
            string m_sircode = ((Label)this.gvReceive.Rows[i].FindControl("lblgvReceiveItemCode")).Text.Trim();
            string m_tagid = ((TextBox)this.gvReceive.Rows[i].FindControl("txtgvReceiveTagNo")).Text.Trim();
            double m_mrrqty = Convert.ToDouble("0" + ((TextBox)this.gvReceive.Rows[i].FindControl("txtgvReceiveQty")).Text.Trim().Replace(",", ""));
            double m_mrrrat = Convert.ToDouble("0" + ((TextBox)this.gvReceive.Rows[i].FindControl("txtgvReceiveMRRRate")).Text.Trim().Replace(",", ""));
            double m_salrat = Convert.ToDouble("0" + ((TextBox)this.gvReceive.Rows[i].FindControl("txtgvReceiveSalesRate")).Text.Trim().Replace(",", ""));
            double m_mrramt = m_mrrqty * m_mrrrat;
            double m_salamt = m_mrrqty * m_salrat;
            DataRow[] dr1 = tbl1.Select("sircode='" + m_sircode + "' and tagid = '" + m_tagid + "'");
            if (dr1.Length <= 1)
            {
                int RowIndex = this.gvReceive.PageIndex * this.gvReceive.PageSize + i;

                tbl1.Rows[RowIndex]["tagid"] = m_tagid;
                tbl1.Rows[RowIndex]["mrrqty"] = m_mrrqty;
                tbl1.Rows[RowIndex]["mrrrat"] = m_mrrrat;
                tbl1.Rows[RowIndex]["salrat"] = m_salrat;
                tbl1.Rows[RowIndex]["mrramt"] = m_mrramt;
                tbl1.Rows[RowIndex]["salamt"] = m_salamt;

            }

        }
        Session["tblgvReceive"] = tbl1;
    }

    protected void ddlItemDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMRRRate.Text = "";
        txtQty.Text = "";
        txtTag.Text = "";
        txtSalesRate.Text = "";
        txtTag.Focus();
    }

    protected void LbtngvReceiveCalTotal_Click(object sender, EventArgs e)
    {
        this.gvReceive_UpdateSession();
        this.gvReceive_DataBind();

    }

    protected void lnkbtnFinal_Click(object sender, EventArgs e)
    {

        this.GetNewMRRNo();
        //string comcod = "1101";
        string mrrdate = txtMRRDate.Text;
        string mrrno = this.txtMRRNo.Text;//"MR" + Convert.ToDateTime(txtMRRDate.Text).ToString("yyyyMM") + txtMRRNo.Text.Substring(5, 6);
        string storeid = this.ddlStoreID.SelectedValue.ToString();
        //string Campusid = this.ddlCampus.SelectedValue.ToString();
        string CampusID = this.ddlCampus.SelectedValue.ToString();
        int mrrMasterIDint = INV_MRRInfoManager.FinalUpdateMrrMaster("INV_InsertMRRMaster", mrrno, storeid, mrrdate, CampusID);

        string mrrMasterID = mrrMasterIDint.ToString();
       // string CampusID = this.ddlCampus.SelectedValue.ToString();
        if (mrrMasterID ==null)
        {
            lblMessage.Text = "Update Faild";
            return;
        }
        DataTable tblF = (DataTable)Session["tblgvReceive"];
        for (int i = 0; i < tblF.Rows.Count; i++)
        {
            string sircode = tblF.Rows[i]["sircode"].ToString().Trim();
            string sirdesc1 = tblF.Rows[i]["sirdesc1"].ToString().Trim();
            string sirunit = tblF.Rows[i]["sirunit"].ToString().Trim();
            string tagid = tblF.Rows[i]["tagid"].ToString().Trim();
            string mrrqty = tblF.Rows[i]["mrrqty"].ToString().Trim();
            string mrrrat = tblF.Rows[i]["mrrrat"].ToString().Trim();
            string salrat = tblF.Rows[i]["salrat"].ToString().Trim();
            string mrramt = tblF.Rows[i]["mrramt"].ToString().Trim();
            string salamt = tblF.Rows[i]["salamt"].ToString().Trim();


            int result = INV_MRRInfoManager.FinalUpdateMRRDetails("INV_InsertMRRDetails", mrrno, mrrMasterID,CampusID, sircode, tagid, mrrqty, mrramt, salamt, mrrdate, storeid);
            if (result !=null)
            {
                lblMessage.Text = "Update Successfull";
            }
            else
            {
                lblMessage.Text = "Update Faild";
            }
        }

        ((LinkButton)this.gvReceive.FooterRow.FindControl("lnkbtnFinal")).Enabled = false;
        this.lnkBtnAdd.Enabled = false;
      

    }
    protected void gvReceive_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gvReceive_UpdateSession();
        this.gvReceive.PageIndex = e.NewPageIndex;
        this.gvReceive_DataBind();
    }
    protected void gvReceive_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}