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
 public partial class AdminSTD_ClassStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassStatusData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassStatusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ClassStatus sTD_ClassStatus = new STD_ClassStatus ();
//	sTD_ClassStatus.ClassStatusID=  int.Parse(ddlClassStatusID.SelectedValue);
	sTD_ClassStatus.ClassStatusName=  txtClassStatusName.Text;
	sTD_ClassStatus.AddedBy=  Profile.card_id;
	sTD_ClassStatus.AddedDate=  DateTime.Now;
	sTD_ClassStatus.UpdatedBy=  Profile.card_id;
	sTD_ClassStatus.UpdateDate = DateTime.Now; 
	int resutl =STD_ClassStatusManager.InsertSTD_ClassStatus(sTD_ClassStatus);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassStatus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ClassStatus sTD_ClassStatus = new STD_ClassStatus ();
	sTD_ClassStatus.ClassStatusID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassStatus.ClassStatusName=  txtClassStatusName.Text;
	sTD_ClassStatus.AddedBy=  Profile.card_id;
	sTD_ClassStatus.AddedDate=  DateTime.Now;
	sTD_ClassStatus.UpdatedBy=  Profile.card_id;
	sTD_ClassStatus.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ClassStatusManager.UpdateSTD_ClassStatus(sTD_ClassStatus);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassStatus.aspx");
	}
	private void showSTD_ClassStatusData()
	{
	 	STD_ClassStatus sTD_ClassStatus  = new STD_ClassStatus ();
	 	sTD_ClassStatus = STD_ClassStatusManager.GetSTD_ClassStatusByClassStatusID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassStatusName.Text =sTD_ClassStatus.ClassStatusName.ToString();
	}
	
}

