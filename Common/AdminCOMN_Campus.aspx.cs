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
 public partial class AdminCOMN_Campus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadCOMN_CampusData();
         		CityIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showCOMN_CampusData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	COMN_Campus cOMN_Campus = new COMN_Campus ();
//	cOMN_Campus.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	cOMN_Campus.CampusName=  txtCampusName.Text;
	cOMN_Campus.Address=  txtAddress.Text;
	cOMN_Campus.Description=  txtDescription.Text;
	cOMN_Campus.CityID=  int.Parse(ddlCityID.SelectedValue);
	cOMN_Campus.AddedBy=  Profile.card_id;
	cOMN_Campus.AddedDate=  DateTime.Now;
	cOMN_Campus.UpdatedBy=  Profile.card_id;
    cOMN_Campus.UpdateDate = DateTime.Now;
	int resutl =COMN_CampusManager.InsertCOMN_Campus(cOMN_Campus);
    Response.Redirect("AdminDisplayCOMN_Campus.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	COMN_Campus cOMN_Campus = new COMN_Campus ();
	cOMN_Campus.CampusID=  int.Parse(Request.QueryString["ID"].ToString());
	cOMN_Campus.CampusName=  txtCampusName.Text;
	cOMN_Campus.Address=  txtAddress.Text;
	cOMN_Campus.Description=  txtDescription.Text;
	cOMN_Campus.CityID=  int.Parse(ddlCityID.SelectedValue);
	cOMN_Campus.AddedBy=  Profile.card_id;
	cOMN_Campus.AddedDate=  DateTime.Now;
	cOMN_Campus.UpdatedBy=  Profile.card_id;
    cOMN_Campus.UpdateDate = DateTime.Now;
	bool  resutl =COMN_CampusManager.UpdateCOMN_Campus(cOMN_Campus);
	Response.Redirect("AdminDisplayCOMN_Campus.aspx");
	}
	private void showCOMN_CampusData()
	{
	 	COMN_Campus cOMN_Campus  = new COMN_Campus ();
	 	cOMN_Campus = COMN_CampusManager.GetCOMN_CampusByCampusID(Int32.Parse(Request.QueryString["ID"]));
	 	txtCampusName.Text =cOMN_Campus.CampusName.ToString();
	 	txtAddress.Text =cOMN_Campus.Address.ToString();
	 	txtDescription.Text =cOMN_Campus.Description.ToString();
	 	ddlCityID.SelectedValue  =cOMN_Campus.CityID.ToString();
	}
	
	private void CityIDLoad()
	{
		try {
		DataSet ds = COMN_CityManager.GetDropDownListAllCOMN_City();
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

