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
 public partial class AdminSTD_FeesType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_FeesTypeData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_FeesTypeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_FeesType sTD_FeesType = new STD_FeesType ();
//	sTD_FeesType.FeesTypeID=  int.Parse(ddlFeesTypeID.SelectedValue);
	sTD_FeesType.FeesTypeName=  txtFeesTypeName.Text;
	sTD_FeesType.AddedBy=  Profile.card_id;
	sTD_FeesType.AddedDate=  DateTime.Now;
	sTD_FeesType.UpdatedBy=  Profile.card_id;
	sTD_FeesType.UpdateDate=  DateTime.Now;
	sTD_FeesType.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_FeesTypeManager.InsertSTD_FeesType(sTD_FeesType);
	Response.Redirect("AdminDisplaySTD_FeesType.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_FeesType sTD_FeesType = new STD_FeesType ();
	sTD_FeesType.FeesTypeID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_FeesType.FeesTypeName=  txtFeesTypeName.Text;
	sTD_FeesType.AddedBy=  Profile.card_id;
	sTD_FeesType.AddedDate=  DateTime.Now;
	sTD_FeesType.UpdatedBy=  Profile.card_id;
	sTD_FeesType.UpdateDate=  DateTime.Now;
	sTD_FeesType.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_FeesTypeManager.UpdateSTD_FeesType(sTD_FeesType);
	Response.Redirect("AdminDisplaySTD_FeesType.aspx");
	}
	private void showSTD_FeesTypeData()
	{
	 	STD_FeesType sTD_FeesType  = new STD_FeesType ();
	 	sTD_FeesType = STD_FeesTypeManager.GetSTD_FeesTypeByFeesTypeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtFeesTypeName.Text =sTD_FeesType.FeesTypeName.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_FeesType.RowStatusID.ToString();
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

