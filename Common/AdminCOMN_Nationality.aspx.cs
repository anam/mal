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
 public partial class AdminCOMN_Nationality : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_NationalityData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_NationalityData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_Nationality cOMN_Nationality = new COMN_Nationality ();
//	cOMN_Nationality.NationalityID=  int.Parse(ddlNationalityID.SelectedValue);
	cOMN_Nationality.NationalityName=  txtNationalityName.Text;
	cOMN_Nationality.AddedBy=  Profile.card_id;
	cOMN_Nationality.AddedDate=  DateTime.Now;
	cOMN_Nationality.ModifiedBy=  Profile.card_id;
	cOMN_Nationality.ModifiedDate=  DateTime.Now;
	int resutl =COMN_NationalityManager.InsertCOMN_Nationality(cOMN_Nationality);
    Response.Redirect("AdminDisplayCOMN_Nationality.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_Nationality cOMN_Nationality = new COMN_Nationality ();
	cOMN_Nationality.NationalityID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_Nationality.NationalityName=  txtNationalityName.Text;
	cOMN_Nationality.AddedBy=  Profile.card_id;
	cOMN_Nationality.AddedDate=  DateTime.Now;
	cOMN_Nationality.ModifiedBy=  Profile.card_id;
	cOMN_Nationality.ModifiedDate=  DateTime.Now;
	bool  resutl =COMN_NationalityManager.UpdateCOMN_Nationality(cOMN_Nationality);
	Response.Redirect("AdminDisplayCOMN_Nationality.aspx");
	}
	private void showCOMN_NationalityData()
	{
	 	COMN_Nationality cOMN_Nationality  = new COMN_Nationality ();
	 	cOMN_Nationality = COMN_NationalityManager.GetCOMN_NationalityByNationalityID(Int32.Parse(Request.QueryString["ID"]));
	 	txtNationalityName.Text =cOMN_Nationality.NationalityName.ToString();
	}
	
}

