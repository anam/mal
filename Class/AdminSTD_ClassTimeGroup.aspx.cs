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
 public partial class AdminSTD_ClassTimeGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassTimeGroupData();
         		RowStatusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassTimeGroupData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	STD_ClassTimeGroup sTD_ClassTimeGroup = new STD_ClassTimeGroup ();
//	sTD_ClassTimeGroup.ClassTimeGroupID=  int.Parse(ddlClassTimeGroupID.SelectedValue);
    sTD_ClassTimeGroup.ClassTimeGroupName = txtClassTimeGroupName.Text + "-" + txtExtraField3.Text;
	sTD_ClassTimeGroup.StartTime=  txtStartTime.Text;
	sTD_ClassTimeGroup.EndTime=  txtEndTime.Text;
	sTD_ClassTimeGroup.ExtraField1=  txtExtraField1.Text;
	sTD_ClassTimeGroup.ExtraField2=  txtExtraField2.Text;
	sTD_ClassTimeGroup.ExtraField3=  txtExtraField3.Text;
	sTD_ClassTimeGroup.ExtraField4=  txtExtraField4.Text;
	sTD_ClassTimeGroup.ExtraField5=  txtExtraField5.Text;
	sTD_ClassTimeGroup.AddedBy=  Profile.card_id;
	sTD_ClassTimeGroup.AddedDate=  DateTime.Now;
	sTD_ClassTimeGroup.UpdatedBy=  Profile.card_id;
	sTD_ClassTimeGroup.UpdateDate=  DateTime.Now;
	sTD_ClassTimeGroup.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	int resutl =STD_ClassTimeGroupManager.InsertSTD_ClassTimeGroup(sTD_ClassTimeGroup);
	Response.Redirect("AdminDisplaySTD_ClassTimeGroup.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	STD_ClassTimeGroup sTD_ClassTimeGroup = new STD_ClassTimeGroup ();
	sTD_ClassTimeGroup.ClassTimeGroupID=  int.Parse(Request.QueryString["ID"].ToString());
    sTD_ClassTimeGroup.ClassTimeGroupName = txtClassTimeGroupName.Text + "-" + txtExtraField3.Text;
	sTD_ClassTimeGroup.StartTime=  txtStartTime.Text;
	sTD_ClassTimeGroup.EndTime=  txtEndTime.Text;
	sTD_ClassTimeGroup.ExtraField1=  txtExtraField1.Text;
	sTD_ClassTimeGroup.ExtraField2=  txtExtraField2.Text;
	sTD_ClassTimeGroup.ExtraField3=  txtExtraField3.Text;
	sTD_ClassTimeGroup.ExtraField4=  txtExtraField4.Text;
	sTD_ClassTimeGroup.ExtraField5=  txtExtraField5.Text;
	sTD_ClassTimeGroup.AddedBy=  Profile.card_id;
	sTD_ClassTimeGroup.AddedDate=  DateTime.Now;
	sTD_ClassTimeGroup.UpdatedBy=  Profile.card_id;
	sTD_ClassTimeGroup.UpdateDate=  DateTime.Now;
	sTD_ClassTimeGroup.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	bool  resutl =STD_ClassTimeGroupManager.UpdateSTD_ClassTimeGroup(sTD_ClassTimeGroup);
	Response.Redirect("AdminDisplaySTD_ClassTimeGroup.aspx");
	}
	private void showSTD_ClassTimeGroupData()
	{
	 	STD_ClassTimeGroup sTD_ClassTimeGroup  = new STD_ClassTimeGroup ();
	 	sTD_ClassTimeGroup = STD_ClassTimeGroupManager.GetSTD_ClassTimeGroupByClassTimeGroupID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassTimeGroupName.Text =sTD_ClassTimeGroup.ClassTimeGroupName.ToString().Split('-')[0];
	 	txtStartTime.Text =sTD_ClassTimeGroup.StartTime.ToString();
	 	txtEndTime.Text =sTD_ClassTimeGroup.EndTime.ToString();
	 	txtExtraField1.Text =sTD_ClassTimeGroup.ExtraField1.ToString();
	 	txtExtraField2.Text =sTD_ClassTimeGroup.ExtraField2.ToString();
        txtExtraField3.Text = sTD_ClassTimeGroup.ClassTimeGroupName.ToString().Split('-')[1];
	 	txtExtraField4.Text =sTD_ClassTimeGroup.ExtraField4.ToString();
	 	txtExtraField5.Text =sTD_ClassTimeGroup.ExtraField5.ToString();
	 	ddlRowStatusID.SelectedValue  =sTD_ClassTimeGroup.RowStatusID.ToString();
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

