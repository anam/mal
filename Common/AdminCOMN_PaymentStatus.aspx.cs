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
 public partial class AdminCOMN_PaymentStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_PaymentStatusData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_PaymentStatusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_PaymentStatus cOMN_PaymentStatus = new COMN_PaymentStatus ();
//	cOMN_PaymentStatus.PaymentStatusID=  int.Parse(ddlPaymentStatusID.SelectedValue);
	cOMN_PaymentStatus.PaymentStatusName=  txtPaymentStatusName.Text;
	cOMN_PaymentStatus.AddedBy=  Profile.card_id;
	cOMN_PaymentStatus.AddedDate=  DateTime.Now;
	cOMN_PaymentStatus.UpdatedBy=  Profile.card_id;
	cOMN_PaymentStatus.UpdateDate=  DateTime.Now;
	cOMN_PaymentStatus.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =COMN_PaymentStatusManager.InsertCOMN_PaymentStatus(cOMN_PaymentStatus);
	Response.Redirect("AdminDisplayCOMN_PaymentStatus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_PaymentStatus cOMN_PaymentStatus = new COMN_PaymentStatus ();
	cOMN_PaymentStatus.PaymentStatusID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_PaymentStatus.PaymentStatusName=  txtPaymentStatusName.Text;
	cOMN_PaymentStatus.AddedBy=  Profile.card_id;
	cOMN_PaymentStatus.AddedDate=  DateTime.Now;
	cOMN_PaymentStatus.UpdatedBy=  Profile.card_id;
	cOMN_PaymentStatus.UpdateDate=  DateTime.Now;
	cOMN_PaymentStatus.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =COMN_PaymentStatusManager.UpdateCOMN_PaymentStatus(cOMN_PaymentStatus);
	Response.Redirect("AdminDisplayCOMN_PaymentStatus.aspx");
	}
	private void showCOMN_PaymentStatusData()
	{
	 	COMN_PaymentStatus cOMN_PaymentStatus  = new COMN_PaymentStatus ();
	 	cOMN_PaymentStatus = COMN_PaymentStatusManager.GetCOMN_PaymentStatusByPaymentStatusID(Int32.Parse(Request.QueryString["ID"]));
	 	txtPaymentStatusName.Text =cOMN_PaymentStatus.PaymentStatusName.ToString();
	 	ddlRowStatusID.SelectedValue  =cOMN_PaymentStatus.RowStatusID.ToString();
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

