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
 public partial class AdminCOMN_RowStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_RowStatusData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_RowStatusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_RowStatus cOMN_RowStatus = new COMN_RowStatus ();
//	cOMN_RowStatus.RowStatusID=  int.Parse(ddlRowStatusID.SelectedValue);
	cOMN_RowStatus.RowStatusName=  txtRowStatusName.Text;
	cOMN_RowStatus.AddedBy=  Profile.card_id;
	cOMN_RowStatus.AddedDate=  DateTime.Now;
	cOMN_RowStatus.UpdatedBy=  Profile.card_id;
	cOMN_RowStatus.UpdateDate=  DateTime.Now;
	int resutl =COMN_RowStatusManager.InsertCOMN_RowStatus(cOMN_RowStatus);
	Response.Redirect("AdminDisplayCOMN_RowStatus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_RowStatus cOMN_RowStatus = new COMN_RowStatus ();
	cOMN_RowStatus.RowStatusID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_RowStatus.RowStatusName=  txtRowStatusName.Text;
	cOMN_RowStatus.AddedBy=  Profile.card_id;
	cOMN_RowStatus.AddedDate=  DateTime.Now;
	cOMN_RowStatus.UpdatedBy=  Profile.card_id;
	cOMN_RowStatus.UpdateDate=  DateTime.Now;
	bool  resutl =COMN_RowStatusManager.UpdateCOMN_RowStatus(cOMN_RowStatus);
	Response.Redirect("AdminDisplayCOMN_RowStatus.aspx");
	}
	private void showCOMN_RowStatusData()
	{
	 	COMN_RowStatus cOMN_RowStatus  = new COMN_RowStatus ();
	 	cOMN_RowStatus = COMN_RowStatusManager.GetCOMN_RowStatusByRowStatusID(Int32.Parse(Request.QueryString["ID"]));
	 	txtRowStatusName.Text =cOMN_RowStatus.RowStatusName.ToString();
	}
	
}

