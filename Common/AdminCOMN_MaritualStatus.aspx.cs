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
 public partial class AdminCOMN_MaritualStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_MaritualStatusData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_MaritualStatusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_MaritualStatus cOMN_MaritualStatus = new COMN_MaritualStatus ();
//	cOMN_MaritualStatus.MaritualStatusID=  int.Parse(ddlMaritualStatusID.SelectedValue);
	cOMN_MaritualStatus.MaritualStatusName=  txtMaritualStatusName.Text;
	cOMN_MaritualStatus.AddedBy=  Profile.card_id;
	cOMN_MaritualStatus.AddedDate=  DateTime.Now;
	cOMN_MaritualStatus.ModifiedBy=  Profile.card_id;
	cOMN_MaritualStatus.ModifiedDate=  DateTime.Now;
	int resutl =COMN_MaritualStatusManager.InsertCOMN_MaritualStatus(cOMN_MaritualStatus);
    Response.Redirect("AdminDisplayCOMN_MaritalStatus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_MaritualStatus cOMN_MaritualStatus = new COMN_MaritualStatus ();
	cOMN_MaritualStatus.MaritualStatusID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_MaritualStatus.MaritualStatusName=  txtMaritualStatusName.Text;
	cOMN_MaritualStatus.AddedBy=  Profile.card_id;
	cOMN_MaritualStatus.AddedDate=  DateTime.Now;
	cOMN_MaritualStatus.ModifiedBy=  Profile.card_id;
	cOMN_MaritualStatus.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_MaritualStatusManager.UpdateCOMN_MaritualStatus(cOMN_MaritualStatus);
    Response.Redirect("AdminDisplayCOMN_MaritalStatus.aspx");
	}
	private void showCOMN_MaritualStatusData()
	{
	 	COMN_MaritualStatus cOMN_MaritualStatus  = new COMN_MaritualStatus ();
	 	cOMN_MaritualStatus = COMN_MaritualStatusManager.GetCOMN_MaritualStatusByMaritualStatusID(Int32.Parse(Request.QueryString["ID"]));
        if (cOMN_MaritualStatus != null)
        {
            txtMaritualStatusName.Text = cOMN_MaritualStatus.MaritualStatusName.ToString();
        }
	}
	
}

