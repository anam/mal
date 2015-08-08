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
 public partial class AdminSTD_Campus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_CampusData();
         		CityIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_CampusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Campus sTD_Campus = new STD_Campus ();
//	sTD_Campus.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	sTD_Campus.CampusName=  txtCampusName.Text;
	sTD_Campus.Address=  txtAddress.Text;
	sTD_Campus.Description=  txtDescription.Text;
	sTD_Campus.CityID=  int.Parse(ddlCityID.SelectedValue);
	sTD_Campus.AddedBy=  Profile.card_id;
	sTD_Campus.AddedDate=  DateTime.Now;
	sTD_Campus.UpdatedBy=  Profile.card_id;
	sTD_Campus.UpdateDate = DateTime.Now; 
	int resutl =STD_CampusManager.InsertSTD_Campus(sTD_Campus);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Campus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Campus sTD_Campus = new STD_Campus ();
	sTD_Campus.CampusID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Campus.CampusName=  txtCampusName.Text;
	sTD_Campus.Address=  txtAddress.Text;
	sTD_Campus.Description=  txtDescription.Text;
	sTD_Campus.CityID=  int.Parse(ddlCityID.SelectedValue);
	sTD_Campus.AddedBy=  Profile.card_id;
	sTD_Campus.AddedDate=  DateTime.Now;
	sTD_Campus.UpdatedBy=  Profile.card_id;
	sTD_Campus.UpdateDate = DateTime.Now; 
	bool  resutl =STD_CampusManager.UpdateSTD_Campus(sTD_Campus);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Campus.aspx");
	}
	private void showSTD_CampusData()
	{
	 	STD_Campus sTD_Campus  = new STD_Campus ();
	 	sTD_Campus = STD_CampusManager.GetSTD_CampusByCampusID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCampusName.Text =sTD_Campus.CampusName.ToString();
	 	txtAddress.Text =sTD_Campus.Address.ToString();
	 	txtDescription.Text =sTD_Campus.Description.ToString();
	 	ddlCityID.SelectedValue  =sTD_Campus.CityID.ToString();
	}
	
	private void CityIDLoad()
	{
		try {
		DataSet ds = STD_CityManager.GetDropDownListAllSTD_City();
		ddlCityID.DataValueField = "CityID";
		ddlCityID.DataTextField = "CityName";
		ddlCityID.DataSource = ds.Tables[0];
		ddlCityID.DataBind();
		ddlCityID.Items.Insert(0, new ListItem("Select City >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

