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
 public partial class AdminCOMN_ReaultSystem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_ReaultSystemData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_ReaultSystemData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_ReaultSystem cOMN_ReaultSystem = new COMN_ReaultSystem ();
//	cOMN_ReaultSystem.ReaultSystemID=  int.Parse(ddlReaultSystemID.SelectedValue);
	cOMN_ReaultSystem.ReaultSystemName=  txtReaultSystemName.Text;
	cOMN_ReaultSystem.AddedBy=  Profile.card_id;
	cOMN_ReaultSystem.AddedDate=  DateTime.Now;
	cOMN_ReaultSystem.ModifiedBy=  Profile.card_id;
	cOMN_ReaultSystem.ModifiedDate=  DateTime.Now;
	int resutl =COMN_ReaultSystemManager.InsertCOMN_ReaultSystem(cOMN_ReaultSystem);
	Response.Redirect("AdminCOMN_ReaultSystemDisplay.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_ReaultSystem cOMN_ReaultSystem = new COMN_ReaultSystem ();
	cOMN_ReaultSystem.ReaultSystemID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_ReaultSystem.ReaultSystemName=  txtReaultSystemName.Text;
	cOMN_ReaultSystem.AddedBy=  Profile.card_id;
	cOMN_ReaultSystem.AddedDate=  DateTime.Now;
	cOMN_ReaultSystem.ModifiedBy=  Profile.card_id;
	cOMN_ReaultSystem.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_ReaultSystemManager.UpdateCOMN_ReaultSystem(cOMN_ReaultSystem);
	Response.Redirect("AdminDisplayCOMN_ReaultSystem.aspx");
	}
	private void showCOMN_ReaultSystemData()
	{
	 	COMN_ReaultSystem cOMN_ReaultSystem  = new COMN_ReaultSystem ();
	 	cOMN_ReaultSystem = COMN_ReaultSystemManager.GetCOMN_ReaultSystemByReaultSystemID(Int32.Parse(Request.QueryString["ID"]));
	 	txtReaultSystemName.Text =cOMN_ReaultSystem.ReaultSystemName.ToString();
	}
	
}

