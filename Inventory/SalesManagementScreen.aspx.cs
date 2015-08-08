using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using RPT_LIB;

public partial class Inventory_SalesManagementScreen : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            //txtMRRNo.Text = "MR" + Convert.ToDateTime(txtMRRDate.Text).ToString("MM") + "-" + GetNewMRRNo();
            CreateSessionTable();
            StoreIDLoad();
            CampusIDLoad();
            lnkbtnList_Click1(null, null);
        }
    }
    private void CampusIDLoad()
    {
        try
        {
            //DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
            //ddlCampus.DataValueField = "CampusID";
            //ddlCampus.DataTextField = "CampusName";
            //ddlCampus.DataSource = ds.Tables[0];
            //ddlCampus.DataBind();
            //ddlCampus.Items.Insert(0, new ListItem("Select Campus >>", "0"));
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
    private void CreateSessionTable()
    {
        Session.Remove("itemSales");
        DataTable itemSales = new DataTable();
        //tbl1.Columns.Add("INVOICENO", Type.GetType("System.String"));
        itemSales.Columns.Add("SIRCODE", Type.GetType("System.String"));
        itemSales.Columns.Add("ITEMDESC", Type.GetType("System.String"));
        itemSales.Columns.Add("TAGID", Type.GetType("System.String"));
        itemSales.Columns.Add("WARRENTY", Type.GetType("System.Int32"));
        itemSales.Columns.Add("QUANTITY", Type.GetType("System.Double"));
        itemSales.Columns.Add("UNITPRICE", Type.GetType("System.Double"));
        itemSales.Columns.Add("TOTALPRICE", Type.GetType("System.Double"));

        Session["itemSales"] = itemSales;
    }
    protected void GetNewInvoise()
    {
        // DataSet ds1 = INV_MRRInfoManager.GetAllINV_MRRInfos1("PMT_TASK_RPT", this.txtIssueDate.Text.ToString());
        DataSet dsIssueNo = INV_MRRInfoManager.GetAllINV_InvoiseNo(this.txtDate.Text.ToString());
        this.txtInvoice.Text = dsIssueNo.Tables[0].Rows[0]["invo"].ToString();
    }
    protected void lnkbtnList_Click1(object sender, EventArgs e)
    {
        string comcod = "1101";
        //string search = txtItemSearch.Text.Trim();

        DataSet ds2 = INV_MRRInfoManager.GetAllINV_Items("GetAllINV_Iteams");
        if (ds2 == null)
        {
            lblMsg.Text = "No Data Found";
            return;
        }
        this.ddlItemDesc.DataTextField = "Description";
        this.ddlItemDesc.DataValueField = "IteamID";
        this.ddlItemDesc.DataSource = ds2.Tables[0];
        this.ddlItemDesc.DataBind();
        //this.ddlItemList_SelectedIndexChanged(null, null);
        txtQty.Text = "";
        txtTagID.Text = "";
        this.ddlItemDesc_SelectedIndexChanged(null, null);
    }

    protected void btnAddToTable_Click(object sender, EventArgs e)
    {

        if (this.txtWarrenty.Text == "" || this.txtQty.Text == "" || this.txtUnitPrice.Text == "" || this.txtTagID.Text == "")
        {
            lblMsg.Text = "Input Correctly";
            return;

        }
        lblMsg.Text = "";


        //string invoice =this.txtInvoice.Text.Trim();
        string sircode = this.ddlItemDesc.SelectedValue;
        string itemdesc = ddlItemDesc.SelectedItem.Text.ToString();//13, ddlItemDesc.SelectedItem.Text.Length - 13).Trim();
        string ItemTag = this.txtTagID.Text;
        Int32 warrenty = Int32.Parse(this.txtWarrenty.Text);
        double Qty = Convert.ToDouble("0" + this.txtQty.Text.Trim());
        double UnitPrice = Convert.ToDouble("0" + this.txtUnitPrice.Text.Trim());
        double totalprice = Qty * UnitPrice;
        txtTotalPrice.Text = totalprice.ToString();

        DataTable tbl1 = (DataTable)Session["itemSales"];
        DataRow[] dr = tbl1.Select("TAGID='" + ItemTag + "' and SIRCODE='" + sircode + "'");
        if (dr.Length == 1)
        {
            dr[0]["WARRENTY"] = warrenty;
            dr[0]["QUANTITY"] = Qty;
            dr[0]["UNITPRICE"] = UnitPrice;
            dr[0]["TOTALPRICE"] = totalprice;

        }
        else
        {
            DataRow dr1 = tbl1.NewRow();
            // dr1["INVOICENO"] = invoice;
            dr1["SIRCODE"] = sircode;
            dr1["ITEMDESC"] = itemdesc;
            dr1["TAGID"] = ItemTag;
            dr1["WARRENTY"] = warrenty;
            dr1["QUANTITY"] = Qty;
            dr1["UNITPRICE"] = UnitPrice;
            dr1["TOTALPRICE"] = totalprice;
            tbl1.Rows.Add(dr1);
        }
        Session["itemSales"] = tbl1;
        this.gvSales_DataBind();
        this.gvSales.Visible = true;

        this.txtTagID.Text = "";
        this.txtWarrenty.Text = "";
        this.txtQty.Text = "";
        this.txtUnitPrice.Text = "";
        this.txtAddress.Text = "";
        this.txtTotalPrice.Text = "";

    }

    private void gvSales_DataBind()
    {
        DataTable tbl = (DataTable)Session["itemSales"];
        this.gvSales.DataSource = tbl;
        this.gvSales.DataBind();

        if (tbl == null)
            return;

        if (tbl.Rows.Count > 0)
        {
            ((Label)this.gvSales.FooterRow.FindControl("gvlblTotal")).Text =
                    Convert.ToDouble((Convert.IsDBNull(tbl.Compute("sum(TOTALPRICE)", "")) ? 0.00 :
                    tbl.Compute("sum(TOTALPRICE)", ""))).ToString("#,##0.00;(#,##0.00); ");
        }
    }

    protected void ddlItemDesc_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtQty.Text = "";
        txtUnitPrice.Text = "";
        txtWarrenty.Text = "";
        txtTagID.Text = "";
        txtTotalPrice.Text = "";
        txtTagID.Focus();
    }

    protected void btnSalesUpdate_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["itemSales"];
        //string comcod = "1101";
        for (int i = 0; i < this.gvSales.Rows.Count; i++)
        {
            string warrenty = ((TextBox)gvSales.Rows[i].FindControl("gvtxtWarrenty")).Text.Trim();
            string quantity = ((TextBox)gvSales.Rows[i].FindControl("gvtxtQty")).Text.Trim();
            string UPrice = ((TextBox)gvSales.Rows[i].FindControl("gvtxtPrice")).Text.Trim();
            gvSales.EditIndex = -1;

            dt.Rows[i].BeginEdit();
            dt.Rows[i]["WARRENTY"] = Convert.ToDouble(warrenty);
            dt.Rows[i]["QUANTITY"] = Convert.ToDouble(quantity);
            dt.Rows[i]["UNITPRICE"] = Convert.ToDouble(UPrice);
            dt.Rows[i]["TOTALPRICE"] = Convert.ToDouble(quantity) * Convert.ToDouble(UPrice);
            dt.Rows[i].EndEdit();
            dt.AcceptChanges();
        }
        Session["itemSales"] = dt;

        this.gvSales_DataBind();
    }

    protected void btnFinalUpdate_Click(object sender, EventArgs e)
    {
        GetNewInvoise();
        string Invoice = this.txtInvoice.Text.ToString();
        string InvDate = this.txtDate.Text.ToString();
        INV_Store store = INV_StoreManager.GetINV_StoreByStoreID(Convert.ToInt32(this.ddlStoreID.SelectedValue));
        string invCampus = store.CampusID.ToString(); //this.ddlCampus.SelectedValue.ToString();
        string remarks = this.txtAddress.Text;
        DataTable dt = (DataTable)Session["itemSales"];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string invoiceno = Invoice;
            string SIRCODE = dt.Rows[i]["SIRCODE"].ToString().Trim();
            string TAGID = dt.Rows[i]["TAGID"].ToString().Trim();
            string WARRENTY = dt.Rows[i]["WARRENTY"].ToString().Trim();
            string QUANTITY = dt.Rows[i]["QUANTITY"].ToString().Trim();
            string UNITPRICE = dt.Rows[i]["UNITPRICE"].ToString().Trim();

            int result = INV_SaleManager.InsertINV_SaleInsert("InsertINV_SaleInsert", Invoice, SIRCODE, TAGID, WARRENTY, QUANTITY, UNITPRICE, InvDate, invCampus, remarks);
            if (result != null)
            {
                lblMsg.Text = "Update Successfull";
            }
            else
            {
                lblMsg.Text = "Upadte Faild";
            }
        }
        //txtDate.Enabled = true;
        //this.btnFinalUpdate.Enabled = false;
        ((LinkButton)this.gvSales.FooterRow.FindControl("btnFinalUpdate")).Enabled = false;
        // this.btnSubmit.Enabled = false;
        //this.btnPrint.Enabled = true;
    }

    protected void ddlItemDesc_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            txtAvaQtyCheck.Text = "";
            INV_Store store = INV_StoreManager.GetINV_StoreByStoreID(Convert.ToInt32(this.ddlStoreID.SelectedValue));

            DataSet AvlQty = INV_IssueManager.GetAllINV_IssuesCheckAvlqty(Convert.ToInt32(this.ddlItemDesc.SelectedValue), store.CampusID, Convert.ToInt32(this.ddlStoreID.SelectedValue));  //(this.txtIssueDate.Text.ToString());

            if (AvlQty == null)
                return;
            this.txtAvaQtyCheck.Text = AvlQty.Tables[0].Rows[0]["avlqty"].ToString();
            if (Decimal.Parse(this.txtAvaQtyCheck.Text) <= 0)
            {
                //txtAvaQtyCheck.Text = "Not Avail Able";
                lblMsg.Text = "The Item is not avail able!";
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private string TotalPrice()
    {
        string invoice = this.txtInvoice.Text; //"IN" + Convert.ToDateTime(txtDate.Text).ToString("yyyyMM") + txtInvoice.Text.Substring(5, 4);

        DataSet ds = INV_SaleManager.GetAllINV_TakaInWord(invoice); //ps.PrTotalPrice(invoice);
        DataTable dt = ds.Tables[0];
        Double Price = double.Parse(dt.Rows[0]["total"].ToString());
        return ConvertNumToText(Convert.ToInt32(Math.Round(Price)));
    }

    private string ConvertNumToText(Int32 nn)
    {
        int numdigit;
        int[] n = new int[12];
        string[] digits = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Ffourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tee = { "", "", "Twentee", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        Int32 num = nn;
        numdigit = 0;
        string str = "";
        do
        {
            n[numdigit] = num % 10;
            numdigit++;
            num = num / 10;

        } while (num > 0);
        numdigit--;
        for (; numdigit >= 0; numdigit--)
        {  //Crore
            if (numdigit == 8)
                str = str + tee[n[numdigit]] + " ";
            else if (numdigit == 7 && n[8] == 1)
                str = str + teens[n[numdigit]] + " Crore" + " ";
            else if (numdigit == 7)
                str = str + digits[n[numdigit]] + " Crore" + " ";
            //Lac
            else if (numdigit == 6)
                str = str + tee[n[numdigit]] + " ";
            else if (numdigit == 5 && n[6] == 1)
                str = str + teens[n[numdigit]] + " Lac" + " ";
            else if (numdigit == 5 && n[5] == 0 && n[6] == 0)//*****If 5th & 6th digit ziro
                str = str + digits[n[numdigit]] + " ";
            else if (numdigit == 5)
                str = str + digits[n[numdigit]] + " Lac" + " ";
            //Thousand
            else if (numdigit == 4)
                str = str + tee[n[numdigit]] + " ";

            else if (numdigit == 3 && n[4] == 1)
                str = str + teens[n[numdigit]] + " Thousand" + " ";

            else if (numdigit == 3 && n[4] == 0 && n[3] == 0) //if 4th & 5th digits zero
                str = str + digits[n[numdigit]] + " ";
            else if (numdigit == 3)
                str = str + digits[n[numdigit]] + " Thousand" + " ";
            else if (numdigit == 2 && n[numdigit] == 0)
                str = str + digits[n[numdigit]] + " ";

            else if (numdigit == 2)
                str = str + digits[n[numdigit]] + " Hundread" + " ";
            else if (numdigit == 1)
                str = str + tee[n[numdigit]] + " ";
            else if (numdigit == 0 && n[numdigit + 1] == 1)
                str = str + teens[n[numdigit]] + " ";
            else if (numdigit == 0)
                str = str + digits[n[numdigit]] + " ";

            else
                str = str + digits[n[numdigit]] + " ";

        }
        return str.Replace("  ", " ");
    }

    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        DataTable item = (DataTable)Session["itemSales"];
        //RptIssue objRptIssue = new RptIssue();
        ReportDocument objInvoice = null;// new RPT_LIB.INV_RPT.SalesInvoice();
        TextObject SalesDate = objInvoice.ReportDefinition.ReportObjects["txtDate"] as TextObject;
        SalesDate.Text = this.txtDate.Text;
        TextObject invoiceno = objInvoice.ReportDefinition.ReportObjects["txtInvoice"] as TextObject;
        invoiceno.Text = this.txtInvoice.Text; //"IN" + Convert.ToDateTime(txtDate.Text).ToString("yyyyMM") + txtInvoice.Text.Substring(5, 4);
        //TextObject CustId = objInvoive.ReportDefinition.ReportObjects["txtCustID"] as TextObject;
        //CustId.Text = this.txtCustID.Text;
        TextObject CustName = objInvoice.ReportDefinition.ReportObjects["txtName"] as TextObject;
        CustName.Text = this.txtAddress.Text;
        //TextObject CustAdd = objInvoive.ReportDefinition.ReportObjects["txtAddress"] as TextObject;
        //CustAdd.Text = this.txtAddress.Text;
        //TextObject CustPhone = objInvoive.ReportDefinition.ReportObjects["txtPhone"] as TextObject;
        //CustPhone.Text = this.txtPhone.Text;
        TextObject GrandTotal = objInvoice.ReportDefinition.ReportObjects["txtTotal"] as TextObject;
        GrandTotal.Text = TotalPrice() + " and Ziro Ziro Paisa.";
        TextObject comadd = objInvoice.ReportDefinition.ReportObjects["txtcomn"] as TextObject;
        comadd.Text = "CUC";

        objInvoice.SetDataSource(item);
        Session["Report1"] = objInvoice;
        this.lblPrint.Text = @"<script>window.open('RptViewer.aspx?PrintOpt=" +
                            this.ddlAdobe.SelectedValue.Trim().ToString() + "', target='_blank');</script>";
    }
}