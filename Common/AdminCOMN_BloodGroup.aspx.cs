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
 public partial class AdminCOMN_BloodGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_BloodGroupData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);                
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_BloodGroupData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_BloodGroup cOMN_BloodGroup = new COMN_BloodGroup ();
//	cOMN_BloodGroup.BloodGroupID=  int.Parse(ddlBloodGroupID.SelectedValue);
	cOMN_BloodGroup.BloodGroupName=  txtBloodGroupName.Text;
	cOMN_BloodGroup.AddedBy=  Profile.card_id;
	cOMN_BloodGroup.AddedDate=  DateTime.Now;
	cOMN_BloodGroup.ModifiedBy=  Profile.card_id;
	cOMN_BloodGroup.ModifiedDate=  DateTime.Now;
	int resutl =COMN_BloodGroupManager.InsertCOMN_BloodGroup(cOMN_BloodGroup);
    Response.Redirect("AdminDisplayCOMN_BloodGroup.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_BloodGroup cOMN_BloodGroup = new COMN_BloodGroup ();
	cOMN_BloodGroup.BloodGroupID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_BloodGroup.BloodGroupName=  txtBloodGroupName.Text;
	cOMN_BloodGroup.AddedBy=  Profile.card_id;
	cOMN_BloodGroup.AddedDate=  DateTime.Now;
	cOMN_BloodGroup.ModifiedBy=  Profile.card_id;
	cOMN_BloodGroup.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_BloodGroupManager.UpdateCOMN_BloodGroup(cOMN_BloodGroup);
    Response.Redirect("AdminDisplayCOMN_BloodGroup.aspx");
	}
	private void showCOMN_BloodGroupData()
	{
	 	COMN_BloodGroup cOMN_BloodGroup  = new COMN_BloodGroup ();
	 	cOMN_BloodGroup = COMN_BloodGroupManager.GetCOMN_BloodGroupByBloodGroupID(Int32.Parse(Request.QueryString["ID"]));
	 	txtBloodGroupName.Text =cOMN_BloodGroup.BloodGroupName.ToString();
	}
	
}

