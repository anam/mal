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
 public partial class AdminSTD_ReaultSystem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ReaultSystemData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ReaultSystemData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ReaultSystem sTD_ReaultSystem = new STD_ReaultSystem ();
//	sTD_ReaultSystem.ReaultSystemID=  int.Parse(ddlReaultSystemID.SelectedValue);
	sTD_ReaultSystem.ReaultSystemName=  txtReaultSystemName.Text;
	sTD_ReaultSystem.AddedBy=  Profile.card_id;
	sTD_ReaultSystem.AddedDate=  DateTime.Now;
	sTD_ReaultSystem.ModifiedBy=  Profile.card_id;
	sTD_ReaultSystem.ModifiedDate=  DateTime.Now;
	int resutl =STD_ReaultSystemManager.InsertSTD_ReaultSystem(sTD_ReaultSystem);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ReaultSystem.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ReaultSystem sTD_ReaultSystem = new STD_ReaultSystem ();
	sTD_ReaultSystem.ReaultSystemID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ReaultSystem.ReaultSystemName=  txtReaultSystemName.Text;
	sTD_ReaultSystem.AddedBy=  Profile.card_id;
	sTD_ReaultSystem.AddedDate=  DateTime.Now;
	sTD_ReaultSystem.ModifiedBy=  Profile.card_id;
	sTD_ReaultSystem.ModifiedDate=  DateTime.Now;
	bool  resutl =STD_ReaultSystemManager.UpdateSTD_ReaultSystem(sTD_ReaultSystem);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ReaultSystem.aspx");
	}
	private void showSTD_ReaultSystemData()
	{
	 	STD_ReaultSystem sTD_ReaultSystem  = new STD_ReaultSystem ();
	 	sTD_ReaultSystem = STD_ReaultSystemManager.GetSTD_ReaultSystemByReaultSystemID(Int32.Parse(Request.QueryString["ID"]));
	 	txtReaultSystemName.Text =sTD_ReaultSystem.ReaultSystemName.ToString();
	}
	
}

