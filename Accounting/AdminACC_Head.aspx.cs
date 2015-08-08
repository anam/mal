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
 public partial class AdminACC_Head : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_HeadData();
         		AccountIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_HeadData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_Head aCC_Head = new ACC_Head ();
//	aCC_Head.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_Head.HeadName=  txtHeadName.Text;
	aCC_Head.HeadCode=  txtHeadCode.Text;
	aCC_Head.AccountID=  int.Parse(ddlAccountID.SelectedValue);
	aCC_Head.AddedBy=  Profile.card_id;
	aCC_Head.AddedDate=  DateTime.Now;
	aCC_Head.UpdatedBy=  Profile.card_id;
	aCC_Head.UpdateDate=  DateTime.Now;
	aCC_Head.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_HeadManager.InsertACC_Head(aCC_Head);
	Response.Redirect("AdminDisplayACC_Head.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_Head aCC_Head = new ACC_Head ();
	aCC_Head.HeadID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_Head.HeadName=  txtHeadName.Text;
	aCC_Head.HeadCode=  txtHeadCode.Text;
	aCC_Head.AccountID=  int.Parse(ddlAccountID.SelectedValue);
	aCC_Head.AddedBy=  Profile.card_id;
	aCC_Head.AddedDate=  DateTime.Now;
	aCC_Head.UpdatedBy=  Profile.card_id;
	aCC_Head.UpdateDate=  DateTime.Now;
	aCC_Head.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_HeadManager.UpdateACC_Head(aCC_Head);
	Response.Redirect("AdminDisplayACC_Head.aspx");
	}
	private void showACC_HeadData()
	{
	 	ACC_Head aCC_Head  = new ACC_Head ();
	 	aCC_Head = ACC_HeadManager.GetACC_HeadByHeadID(Int32.Parse(Request.QueryString["ID"]));
	 	txtHeadName.Text =aCC_Head.HeadName.ToString();
	 	txtHeadCode.Text =aCC_Head.HeadCode.ToString();
	 	ddlAccountID.SelectedValue  =aCC_Head.AccountID.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_Head.RowStatusID.ToString();
	}
	
	private void AccountIDLoad()
	{
		try {
		DataSet ds = ACC_AccountManager.GetDropDownListAllACC_Account();
		ddlAccountID.DataValueField = "AccountID";
		ddlAccountID.DataTextField = "AccountName";
		ddlAccountID.DataSource = ds.Tables[0];
		ddlAccountID.DataBind();
		ddlAccountID.Items.Insert(0, new ListItem("Select Account >>", "0"));
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

