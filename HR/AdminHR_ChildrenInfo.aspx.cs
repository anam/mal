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
 public partial class AdminHR_ChildrenInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showHR_ChildrenInfoData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo ();
//	hR_ChildrenInfo.ChildrenInfoID=  int.Parse(ddlChildrenInfoID.SelectedValue);
    hR_ChildrenInfo.EmployeeID = Profile.card_id;
	hR_ChildrenInfo.ChildrenInfoName=  txtChildrenInfoName.Text;
	hR_ChildrenInfo.ChildrenDateOfBirth=  txtChildrenDateOfBirth.Text;
    hR_ChildrenInfo.Sex = ddlSex.SelectedValue;
	hR_ChildrenInfo.AddedBy=  Profile.card_id;
	hR_ChildrenInfo.AddedDate=  DateTime.Now;
	hR_ChildrenInfo.ModifiedBy=  Profile.card_id;
	hR_ChildrenInfo.ModifiedDate=  DateTime.Now;
	int resutl =HR_ChildrenInfoManager.InsertHR_ChildrenInfo(hR_ChildrenInfo);
	Response.Redirect("AdminDisplayHR_ChildrenInfo.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	HR_ChildrenInfo hR_ChildrenInfo = new HR_ChildrenInfo ();
	hR_ChildrenInfo.ChildrenInfoID=  int.Parse(Request.QueryString["ID"].ToString());
    hR_ChildrenInfo.EmployeeID = Profile.card_id;
	hR_ChildrenInfo.ChildrenInfoName=  txtChildrenInfoName.Text;
	hR_ChildrenInfo.ChildrenDateOfBirth=  txtChildrenDateOfBirth.Text;
    hR_ChildrenInfo.Sex = ddlSex.SelectedValue;
	hR_ChildrenInfo.AddedBy=  Profile.card_id;
	hR_ChildrenInfo.AddedDate=  DateTime.Now;
	hR_ChildrenInfo.ModifiedBy=  Profile.card_id;
	hR_ChildrenInfo.ModifiedDate=  DateTime.Now;
	bool  resutl =HR_ChildrenInfoManager.UpdateHR_ChildrenInfo(hR_ChildrenInfo);
	Response.Redirect("AdminDisplayHR_ChildrenInfo.aspx");
	}
	private void showHR_ChildrenInfoData()
	{
	 	HR_ChildrenInfo hR_ChildrenInfo  = new HR_ChildrenInfo ();
	 	hR_ChildrenInfo = HR_ChildrenInfoManager.GetHR_ChildrenInfoByChildrenInfoID(Int32.Parse(Request.QueryString["ID"]));
	 	
	 	txtChildrenInfoName.Text =hR_ChildrenInfo.ChildrenInfoName.ToString();
	 	txtChildrenDateOfBirth.Text =hR_ChildrenInfo.ChildrenDateOfBirth.ToString();
        ddlSex.SelectedValue = hR_ChildrenInfo.Sex.ToString();
	}
	
	
}

