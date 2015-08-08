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
 public partial class AdminCOMN_Religion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_ReligionData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_ReligionData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_Religion cOMN_Religion = new COMN_Religion ();
//	cOMN_Religion.ReligionID=  int.Parse(ddlReligionID.SelectedValue);
	cOMN_Religion.ReligionName=  txtReligionName.Text;
	cOMN_Religion.AddedBy=  Profile.card_id;
	cOMN_Religion.AddedDate=  DateTime.Now;
	cOMN_Religion.ModifiedBy=  Profile.card_id;
	cOMN_Religion.ModifiedDate=  DateTime.Now;
	int resutl =COMN_ReligionManager.InsertCOMN_Religion(cOMN_Religion);
    Response.Redirect("AdminDisplayCOMN_Religion.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_Religion cOMN_Religion = new COMN_Religion ();
	cOMN_Religion.ReligionID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_Religion.ReligionName=  txtReligionName.Text;
	cOMN_Religion.AddedBy=  Profile.card_id;
	cOMN_Religion.AddedDate=  DateTime.Now;
	cOMN_Religion.ModifiedBy=  Profile.card_id;
	cOMN_Religion.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_ReligionManager.UpdateCOMN_Religion(cOMN_Religion);
    Response.Redirect("AdminDisplayCOMN_Religion.aspx");
	}
	private void showCOMN_ReligionData()
	{
	 	COMN_Religion cOMN_Religion  = new COMN_Religion ();
	 	cOMN_Religion = COMN_ReligionManager.GetCOMN_ReligionByReligionID(Int32.Parse(Request.QueryString["ID"]));
	 	txtReligionName.Text =cOMN_Religion.ReligionName.ToString();
	}
	
}

