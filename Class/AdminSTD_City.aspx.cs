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
 public partial class AdminSTD_City : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_CityData();
         		CountryIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_CityData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_City sTD_City = new STD_City ();
//	sTD_City.CityID=  int.Parse(ddlCityID.SelectedValue);
	sTD_City.CityName=  txtCityName.Text;
	sTD_City.Description=  txtDescription.Text;
	sTD_City.CountryID=  int.Parse(ddlCountryID.SelectedValue);
	sTD_City.AddedBy=  Profile.card_id;
	sTD_City.AddedDate=  DateTime.Now;
	sTD_City.UpdatedBy=  Profile.card_id;
	sTD_City.UpdateDate = DateTime.Now; 
	int resutl =STD_CityManager.InsertSTD_City(sTD_City);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_City.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_City sTD_City = new STD_City ();
	sTD_City.CityID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_City.CityName=  txtCityName.Text;
	sTD_City.Description=  txtDescription.Text;
	sTD_City.CountryID=  int.Parse(ddlCountryID.SelectedValue);
	sTD_City.AddedBy=  Profile.card_id;
	sTD_City.AddedDate=  DateTime.Now;
	sTD_City.UpdatedBy=  Profile.card_id;
	sTD_City.UpdateDate = DateTime.Now; 
	bool  resutl =STD_CityManager.UpdateSTD_City(sTD_City);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_City.aspx");
	}
	private void showSTD_CityData()
	{
	 	STD_City sTD_City  = new STD_City ();
	 	sTD_City = STD_CityManager.GetSTD_CityByCityID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCityName.Text =sTD_City.CityName.ToString();
	 	txtDescription.Text =sTD_City.Description.ToString();
	 	ddlCountryID.SelectedValue  =sTD_City.CountryID.ToString();
	}
	
	private void CountryIDLoad()
	{
		try {
		DataSet ds = STD_CountryManager.GetDropDownListAllSTD_Country();
		ddlCountryID.DataValueField = "CountryID";
		ddlCountryID.DataTextField = "CountryName";
		ddlCountryID.DataSource = ds.Tables[0];
		ddlCountryID.DataBind();
		ddlCountryID.Items.Insert(0, new ListItem("Select Country >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

