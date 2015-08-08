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
 public partial class AdminACC_VoucherIteam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_VoucherIteamData();
         		VoucherIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_VoucherIteamData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam ();
//	aCC_VoucherIteam.VoucherIteamID=  int.Parse(ddlVoucherIteamID.SelectedValue);
	aCC_VoucherIteam.VoucherIteamName=  txtVoucherIteamName.Text;
	aCC_VoucherIteam.VoucherID=  int.Parse(ddlVoucherID.SelectedValue);
	aCC_VoucherIteam.IteamCode=  txtIteamCode.Text;
	aCC_VoucherIteam.Description=  txtDescription.Text;
	aCC_VoucherIteam.UnitPrice=  decimal.Parse(txtUnitPrice.Text);
	aCC_VoucherIteam.Quantity=  decimal.Parse(txtQuantity.Text);
	aCC_VoucherIteam.AddedBy=  Profile.card_id;
	aCC_VoucherIteam.AddedDate=  DateTime.Now;
	aCC_VoucherIteam.UpdatedBy=  Profile.card_id;
	aCC_VoucherIteam.UpdateDate=  DateTime.Now;
	aCC_VoucherIteam.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_VoucherIteamManager.InsertACC_VoucherIteam(aCC_VoucherIteam);
	Response.Redirect("AdminDisplayACC_VoucherIteam.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_VoucherIteam aCC_VoucherIteam = new ACC_VoucherIteam ();
	aCC_VoucherIteam.VoucherIteamID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_VoucherIteam.VoucherIteamName=  txtVoucherIteamName.Text;
	aCC_VoucherIteam.VoucherID=  int.Parse(ddlVoucherID.SelectedValue);
	aCC_VoucherIteam.IteamCode=  txtIteamCode.Text;
	aCC_VoucherIteam.Description=  txtDescription.Text;
	aCC_VoucherIteam.UnitPrice=  decimal.Parse(txtUnitPrice.Text);
	aCC_VoucherIteam.Quantity=  decimal.Parse(txtQuantity.Text);
	aCC_VoucherIteam.AddedBy=  Profile.card_id;
	aCC_VoucherIteam.AddedDate=  DateTime.Now;
	aCC_VoucherIteam.UpdatedBy=  Profile.card_id;
	aCC_VoucherIteam.UpdateDate=  DateTime.Now;
	aCC_VoucherIteam.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_VoucherIteamManager.UpdateACC_VoucherIteam(aCC_VoucherIteam);
	Response.Redirect("AdminDisplayACC_VoucherIteam.aspx");
	}
	private void showACC_VoucherIteamData()
	{
	 	ACC_VoucherIteam aCC_VoucherIteam  = new ACC_VoucherIteam ();
	 	aCC_VoucherIteam = ACC_VoucherIteamManager.GetACC_VoucherIteamByVoucherIteamID(Int32.Parse(Request.QueryString["ID"]));
	 	txtVoucherIteamName.Text =aCC_VoucherIteam.VoucherIteamName.ToString();
	 	ddlVoucherID.SelectedValue  =aCC_VoucherIteam.VoucherID.ToString();
	 	txtIteamCode.Text =aCC_VoucherIteam.IteamCode.ToString();
	 	txtDescription.Text =aCC_VoucherIteam.Description.ToString();
	 	txtUnitPrice.Text =aCC_VoucherIteam.UnitPrice.ToString();
	 	txtQuantity.Text =aCC_VoucherIteam.Quantity.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_VoucherIteam.RowStatusID.ToString();
	}
	
	private void VoucherIDLoad()
	{
		try {
		DataSet ds = ACC_VoucherManager.GetDropDownListAllACC_Voucher();
		ddlVoucherID.DataValueField = "VoucherID";
		ddlVoucherID.DataTextField = "VoucherName";
		ddlVoucherID.DataSource = ds.Tables[0];
		ddlVoucherID.DataBind();
		ddlVoucherID.Items.Insert(0, new ListItem("Select Voucher >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void RowStatusIDLoad()
	{
		try {
		DataSet ds = COMN_RowStatusManager.GetDropDownListAllCOMN_RowStatus();
		ddlRowStatusID.DataValueField = "RowStatusID";
		ddlRowStatusID.DataTextField = "RowStatusName";
		ddlRowStatusID.DataSource = ds.Tables[0];
		ddlRowStatusID.DataBind();
		ddlRowStatusID.Items.Insert(0, new ListItem("Select RowStatus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

