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
 public partial class AdminACC_OpeningBalance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_OpeningBalanceData();
         		HeadIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_OpeningBalanceData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_OpeningBalance aCC_OpeningBalance = new ACC_OpeningBalance ();
//	aCC_OpeningBalance.OpeningBalanceID=  int.Parse(ddlOpeningBalanceID.SelectedValue);
	aCC_OpeningBalance.OpeningBalanceName=  txtOpeningBalanceName.Text;
	aCC_OpeningBalance.Amount=  decimal.Parse(txtAmount.Text);
	aCC_OpeningBalance.IsUsed=  bool.Parse( radIsUsed.SelectedValue);
	aCC_OpeningBalance.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_OpeningBalance.AddedBy=  Profile.card_id;
	aCC_OpeningBalance.AddedDate=  DateTime.Now;
	aCC_OpeningBalance.UpdatedBy=  Profile.card_id;
	aCC_OpeningBalance.UpdateDate=  DateTime.Now;
	aCC_OpeningBalance.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_OpeningBalanceManager.InsertACC_OpeningBalance(aCC_OpeningBalance);
	Response.Redirect("AdminDisplayACC_OpeningBalance.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_OpeningBalance aCC_OpeningBalance = new ACC_OpeningBalance ();
	aCC_OpeningBalance.OpeningBalanceID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_OpeningBalance.OpeningBalanceName=  txtOpeningBalanceName.Text;
	aCC_OpeningBalance.Amount=  decimal.Parse(txtAmount.Text);
	aCC_OpeningBalance.IsUsed=  bool.Parse( radIsUsed.SelectedValue);
	aCC_OpeningBalance.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_OpeningBalance.AddedBy=  Profile.card_id;
	aCC_OpeningBalance.AddedDate=  DateTime.Now;
	aCC_OpeningBalance.UpdatedBy=  Profile.card_id;
	aCC_OpeningBalance.UpdateDate=  DateTime.Now;
	aCC_OpeningBalance.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_OpeningBalanceManager.UpdateACC_OpeningBalance(aCC_OpeningBalance);
	Response.Redirect("AdminDisplayACC_OpeningBalance.aspx");
	}
	private void showACC_OpeningBalanceData()
	{
	 	ACC_OpeningBalance aCC_OpeningBalance  = new ACC_OpeningBalance ();
	 	aCC_OpeningBalance = ACC_OpeningBalanceManager.GetACC_OpeningBalanceByOpeningBalanceID(Int32.Parse(Request.QueryString["ID"]));
	 	txtOpeningBalanceName.Text =aCC_OpeningBalance.OpeningBalanceName.ToString();
	 	txtAmount.Text =aCC_OpeningBalance.Amount.ToString();
	 	 radIsUsed.SelectedValue  =aCC_OpeningBalance.IsUsed.ToString();
	 	ddlHeadID.SelectedValue  =aCC_OpeningBalance.HeadID.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_OpeningBalance.RowStatusID.ToString();
	}
	
	private void HeadIDLoad()
	{
		try {
		DataSet ds = ACC_HeadManager.GetDropDownListAllACC_Head();
		ddlHeadID.DataValueField = "HeadID";
		ddlHeadID.DataTextField = "HeadName";
		ddlHeadID.DataSource = ds.Tables[0];
		ddlHeadID.DataBind();
		ddlHeadID.Items.Insert(0, new ListItem("Select Head >>", "0"));
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

