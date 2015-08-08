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
 public partial class AdminCOMN_Country : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_CountryData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_CountryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_Country cOMN_Country = new COMN_Country ();
//	cOMN_Country.CountryID=  int.Parse(ddlCountryID.SelectedValue);
	cOMN_Country.CountryName=  txtCountryName.Text;
	cOMN_Country.Description=  txtDescription.Text;
	cOMN_Country.AddedBy=  Profile.card_id;
	cOMN_Country.AddedDate=  DateTime.Now;
	cOMN_Country.UpdatedBy=  Profile.card_id;
    cOMN_Country.UpdateDate = DateTime.Now;
	int resutl =COMN_CountryManager.InsertCOMN_Country(cOMN_Country);
    Response.Redirect("AdminDisplayCOMN_Country.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_Country cOMN_Country = new COMN_Country ();
	cOMN_Country.CountryID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_Country.CountryName=  txtCountryName.Text;
	cOMN_Country.Description=  txtDescription.Text;
	cOMN_Country.AddedBy=  Profile.card_id;
	cOMN_Country.AddedDate=  DateTime.Now;
	cOMN_Country.UpdatedBy=  Profile.card_id;
    cOMN_Country.UpdateDate = DateTime.Now;
	bool  resutl =COMN_CountryManager.UpdateCOMN_Country(cOMN_Country);
	Response.Redirect("AdminDisplayCOMN_Country.aspx");
	}
	private void showCOMN_CountryData()
	{
	 	COMN_Country cOMN_Country  = new COMN_Country ();
	 	cOMN_Country = COMN_CountryManager.GetCOMN_CountryByCountryID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCountryName.Text =cOMN_Country.CountryName.ToString();
	 	txtDescription.Text =cOMN_Country.Description.ToString();
	}
	
}

