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
 public partial class AdminSTD_EducationGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_EducationGroupData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_EducationGroupData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_EducationGroup sTD_EducationGroup = new STD_EducationGroup ();
//	sTD_EducationGroup.EducationGroupID=  int.Parse(ddlEducationGroupID.SelectedValue);
	sTD_EducationGroup.EducationGroupName=  txtEducationGroupName.Text;
	sTD_EducationGroup.AddedBy=  Profile.card_id;
	sTD_EducationGroup.AddedDate=  DateTime.Now;
	sTD_EducationGroup.ModifiedBy=  Profile.card_id;
	sTD_EducationGroup.ModifiedDate=  DateTime.Now;
	int resutl =STD_EducationGroupManager.InsertSTD_EducationGroup(sTD_EducationGroup);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_EducationGroup.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_EducationGroup sTD_EducationGroup = new STD_EducationGroup ();
	sTD_EducationGroup.EducationGroupID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_EducationGroup.EducationGroupName=  txtEducationGroupName.Text;
	sTD_EducationGroup.AddedBy=  Profile.card_id;
	sTD_EducationGroup.AddedDate=  DateTime.Now;
	sTD_EducationGroup.ModifiedBy=  Profile.card_id;
	sTD_EducationGroup.ModifiedDate=  DateTime.Now;
	bool  resutl =STD_EducationGroupManager.UpdateSTD_EducationGroup(sTD_EducationGroup);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_EducationGroup.aspx");
	}
	private void showSTD_EducationGroupData()
	{
	 	STD_EducationGroup sTD_EducationGroup  = new STD_EducationGroup ();
	 	sTD_EducationGroup = STD_EducationGroupManager.GetSTD_EducationGroupByEducationGroupID(Int32.Parse(Request.QueryString["ID"]));
	 	txtEducationGroupName.Text =sTD_EducationGroup.EducationGroupName.ToString();
	}
	
}

