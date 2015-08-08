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
 public partial class AdminSTD_Country : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_CountryData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_CountryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Country sTD_Country = new STD_Country ();
//	sTD_Country.CountryID=  int.Parse(ddlCountryID.SelectedValue);
	sTD_Country.CountryName=  txtCountryName.Text;
	sTD_Country.Description=  txtDescription.Text;
	sTD_Country.AddedBy=  Profile.card_id;
	sTD_Country.AddedDate=  DateTime.Now;
	sTD_Country.UpdatedBy=  Profile.card_id;
	sTD_Country.UpdateDate = DateTime.Now; 
	int resutl =STD_CountryManager.InsertSTD_Country(sTD_Country);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Country.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Country sTD_Country = new STD_Country ();
	sTD_Country.CountryID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Country.CountryName=  txtCountryName.Text;
	sTD_Country.Description=  txtDescription.Text;
	sTD_Country.AddedBy=  Profile.card_id;
	sTD_Country.AddedDate=  DateTime.Now;
	sTD_Country.UpdatedBy=  Profile.card_id;
	sTD_Country.UpdateDate = DateTime.Now; 
	bool  resutl =STD_CountryManager.UpdateSTD_Country(sTD_Country);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Country.aspx");
	}
	private void showSTD_CountryData()
	{
	 	STD_Country sTD_Country  = new STD_Country ();
	 	sTD_Country = STD_CountryManager.GetSTD_CountryByCountryID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCountryName.Text =sTD_Country.CountryName.ToString();
	 	txtDescription.Text =sTD_Country.Description.ToString();
	}
	
}

