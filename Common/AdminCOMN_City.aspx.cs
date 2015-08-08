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
 public partial class AdminCOMN_City : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_CityData();
         		CountryIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_CityData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_City cOMN_City = new COMN_City ();
//	cOMN_City.CityID=  int.Parse(ddlCityID.SelectedValue);
	cOMN_City.CityName=  txtCityName.Text;
	cOMN_City.Description=  txtDescription.Text;
	cOMN_City.CountryID=  int.Parse(ddlCountryID.SelectedValue);
	cOMN_City.AddedBy=  Profile.card_id;
	cOMN_City.AddedDate=  DateTime.Now;
	cOMN_City.UpdatedBy=  Profile.card_id;
    cOMN_City.UpdateDate = DateTime.Now;
	int resutl =COMN_CityManager.InsertCOMN_City(cOMN_City);
    Response.Redirect("AdminDisplayCOMN_City.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_City cOMN_City = new COMN_City ();
	cOMN_City.CityID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_City.CityName=  txtCityName.Text;
	cOMN_City.Description=  txtDescription.Text;
	cOMN_City.CountryID=  int.Parse(ddlCountryID.SelectedValue);
	cOMN_City.AddedBy=  Profile.card_id;
	cOMN_City.AddedDate=  DateTime.Now;
	cOMN_City.UpdatedBy=  Profile.card_id;
    cOMN_City.UpdateDate = DateTime.Now;
	bool  resutl =COMN_CityManager.UpdateCOMN_City(cOMN_City);
	Response.Redirect("AdminDisplayCOMN_City.aspx");
	}
	private void showCOMN_CityData()
	{
	 	COMN_City cOMN_City  = new COMN_City ();
	 	cOMN_City = COMN_CityManager.GetCOMN_CityByCityID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCityName.Text =cOMN_City.CityName.ToString();
	 	txtDescription.Text =cOMN_City.Description.ToString();
	 	ddlCountryID.SelectedValue  =cOMN_City.CountryID.ToString();
	}
	
	private void CountryIDLoad()
	{
		try {
		DataSet ds = COMN_CountryManager.GetDropDownListAllCOMN_Country();
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

