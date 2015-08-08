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
 public partial class AdminACC_HeadUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadACC_HeadUserData();
         		HeadIDLoad();
               // HeadIDLoad();
		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showACC_HeadUserData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	ACC_HeadUser aCC_HeadUser = new ACC_HeadUser ();
//	aCC_HeadUser.HeadUserID=  int.Parse(ddlHeadUserID.SelectedValue);
	aCC_HeadUser.HeadUserName=  txtHeadUserName.Text;
	aCC_HeadUser.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_HeadUser.UserID=  ddlUserID.SelectedValue;
	aCC_HeadUser.AddedBy=  Profile.card_id;
	aCC_HeadUser.AddedDate=  DateTime.Now;
	aCC_HeadUser.UpdatedBy=  Profile.card_id;
	aCC_HeadUser.UpdateDate=  DateTime.Now;
	aCC_HeadUser.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =ACC_HeadUserManager.InsertACC_HeadUser(aCC_HeadUser);
	Response.Redirect("AdminDisplayACC_HeadUser.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	ACC_HeadUser aCC_HeadUser = new ACC_HeadUser ();
	aCC_HeadUser.HeadUserID=  int.Parse(Request.QueryString["ID"].ToString());
	aCC_HeadUser.HeadUserName=  txtHeadUserName.Text;
	aCC_HeadUser.HeadID=  int.Parse(ddlHeadID.SelectedValue);
	aCC_HeadUser.UserID=  ddlUserID.SelectedValue;
	aCC_HeadUser.AddedBy=  Profile.card_id;
	aCC_HeadUser.AddedDate=  DateTime.Now;
	aCC_HeadUser.UpdatedBy=  Profile.card_id;
	aCC_HeadUser.UpdateDate=  DateTime.Now;
	aCC_HeadUser.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =ACC_HeadUserManager.UpdateACC_HeadUser(aCC_HeadUser);
	Response.Redirect("AdminDisplayACC_HeadUser.aspx");
	}
	private void showACC_HeadUserData()
	{
	 	ACC_HeadUser aCC_HeadUser  = new ACC_HeadUser ();
	 	aCC_HeadUser = ACC_HeadUserManager.GetACC_HeadUserByHeadUserID(Int32.Parse(Request.QueryString["ID"]));
	 	txtHeadUserName.Text =aCC_HeadUser.HeadUserName.ToString();
	 	ddlHeadID.SelectedValue  =aCC_HeadUser.HeadID.ToString();
	 	ddlUserID.SelectedValue  =aCC_HeadUser.UserID.ToString();
	 	ddlRowStatusID.SelectedValue  =aCC_HeadUser.RowStatusID.ToString();
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

