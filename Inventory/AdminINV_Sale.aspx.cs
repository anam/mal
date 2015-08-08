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
 public partial class AdminINV_Sale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadINV_SaleData();
         		CampusIDLoad();
		IteamIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showINV_SaleData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	INV_Sale iNV_Sale = new INV_Sale ();
//	iNV_Sale.SaleID=  int.Parse(ddlSaleID.SelectedValue);
	iNV_Sale.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	iNV_Sale.InvoiceNo=  txtInvoiceNo.Text;
	iNV_Sale.IteamID=  int.Parse(ddlIteamID.SelectedValue);
	iNV_Sale.Quantity=  decimal.Parse(txtQuantity.Text);
	iNV_Sale.Warrenty=  int.Parse(txtWarrenty.Text);
	iNV_Sale.UnitPrice=  decimal.Parse(txtUnitPrice.Text);
	iNV_Sale.SaleDate=   DateTime.Parse(txtSaleDate.Text);
	iNV_Sale.Remark=  txtRemark.Text;
	iNV_Sale.AddedBy=  Profile.card_id;
	iNV_Sale.AddedDate=  DateTime.Now;
	iNV_Sale.UpdatedBy=  Profile.card_id;
	iNV_Sale.UpdatedDate=   DateTime.Now;
	int resutl =INV_SaleManager.InsertINV_Sale(iNV_Sale);
    }catch(Exception ex){}Response.Redirect("AdminDisplayINV_Sale.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	INV_Sale iNV_Sale = new INV_Sale ();
	iNV_Sale.SaleID=  int.Parse(Request.QueryString["ID"].ToString());
	iNV_Sale.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	iNV_Sale.InvoiceNo=  txtInvoiceNo.Text;
	iNV_Sale.IteamID=  int.Parse(ddlIteamID.SelectedValue);
	iNV_Sale.Quantity=  decimal.Parse(txtQuantity.Text);
	iNV_Sale.Warrenty=  int.Parse(txtWarrenty.Text);
	iNV_Sale.UnitPrice=  decimal.Parse(txtUnitPrice.Text);
	iNV_Sale.SaleDate=   DateTime.Parse(txtSaleDate.Text);
	iNV_Sale.Remark=  txtRemark.Text;
	iNV_Sale.AddedBy=  Profile.card_id;
	iNV_Sale.AddedDate=  DateTime.Now;
	iNV_Sale.UpdatedBy=  Profile.card_id;
	iNV_Sale.UpdatedDate=   DateTime.Now;
	bool  resutl =INV_SaleManager.UpdateINV_Sale(iNV_Sale);
	}catch(Exception ex){}Response.Redirect("AdminDisplayINV_Sale.aspx");
	}
	private void showINV_SaleData()
	{
	 	INV_Sale iNV_Sale  = new INV_Sale ();
	 	iNV_Sale = INV_SaleManager.GetINV_SaleBySaleID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlCampusID.SelectedValue  =iNV_Sale.CampusID.ToString();
	 	txtInvoiceNo.Text =iNV_Sale.InvoiceNo.ToString();
	 	ddlIteamID.SelectedValue  =iNV_Sale.IteamID.ToString();
	 	txtQuantity.Text =iNV_Sale.Quantity.ToString();
	 	txtWarrenty.Text =iNV_Sale.Warrenty.ToString();
	 	txtUnitPrice.Text =iNV_Sale.UnitPrice.ToString();
	 	txtSaleDate.Text =iNV_Sale.SaleDate.ToString();
	 	txtRemark.Text =iNV_Sale.Remark.ToString();
	 	string txtUpdatedBy_Text =iNV_Sale.UpdatedBy.ToString();
	 	string txtUpdatedDate_Text =iNV_Sale.UpdatedDate.ToString();
	}
	
	private void CampusIDLoad()
	{
		try {
            DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
		ddlCampusID.DataValueField = "CampusID";
		ddlCampusID.DataTextField = "CampusName";
		ddlCampusID.DataSource = ds.Tables[0];
		ddlCampusID.DataBind();
		ddlCampusID.Items.Insert(0, new ListItem("Select Campus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void IteamIDLoad()
	{
		try {
		DataSet ds = INV_IteamManager.GetDropDownListAllINV_Iteam();
		ddlIteamID.DataValueField = "IteamID";
		ddlIteamID.DataTextField = "IteamName";
		ddlIteamID.DataSource = ds.Tables[0];
		ddlIteamID.DataBind();
		ddlIteamID.Items.Insert(0, new ListItem("Select Iteam >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

