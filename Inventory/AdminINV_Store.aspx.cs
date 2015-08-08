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
 public partial class AdminINV_Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadINV_StoreData();
         		CampusIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showINV_StoreData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	INV_Store iNV_Store = new INV_Store ();
//	iNV_Store.StoreID=  int.Parse(ddlStoreID.SelectedValue);
	iNV_Store.StoreName=  txtStoreName.Text;
	iNV_Store.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	iNV_Store.Description=  txtDescription.Text;
	iNV_Store.AddedBy=  Profile.card_id;
	iNV_Store.AddedDate=  DateTime.Now;
	iNV_Store.UpdatedBy=  Profile.card_id;
	iNV_Store.UpdatedDate=   DateTime.Now;
	int resutl =INV_StoreManager.InsertINV_Store(iNV_Store);
    }catch(Exception ex){}Response.Redirect("AdminDisplayINV_Store.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	INV_Store iNV_Store = new INV_Store ();
	iNV_Store.StoreID=  int.Parse(Request.QueryString["ID"].ToString());
	iNV_Store.StoreName=  txtStoreName.Text;
	iNV_Store.CampusID=  int.Parse(ddlCampusID.SelectedValue);
	iNV_Store.Description=  txtDescription.Text;
	iNV_Store.AddedBy=  Profile.card_id;
	iNV_Store.AddedDate=  DateTime.Now;
	iNV_Store.UpdatedBy=  Profile.card_id;
	iNV_Store.UpdatedDate=   DateTime.Now;
	bool  resutl =INV_StoreManager.UpdateINV_Store(iNV_Store);
	}catch(Exception ex){}Response.Redirect("AdminDisplayINV_Store.aspx");
	}
	private void showINV_StoreData()
	{
	 	INV_Store iNV_Store  = new INV_Store ();
	 	iNV_Store = INV_StoreManager.GetINV_StoreByStoreID(Int32.Parse(Request.QueryString["ID"]));
	 	txtStoreName.Text =iNV_Store.StoreName.ToString();
	 	ddlCampusID.SelectedValue  =iNV_Store.CampusID.ToString();
	 	txtDescription.Text =iNV_Store.Description.ToString();
	 	string txtUpdatedBy_Text =iNV_Store.UpdatedBy.ToString();
	 	string txtUpdatedDate_Text =iNV_Store.UpdatedDate.ToString();
	}
	
	private void CampusIDLoad()
	{
		try {
            DataSet ds = COMN_CampusManager.GetDropDownListAllCOMN_Campus();
		ddlCampusID.DataValueField = "CampusID";
		ddlCampusID.DataTextField = "CampusName";
		ddlCampusID.DataSource = ds.Tables[0];
		ddlCampusID.DataBind();
		ddlCampusID.Items.Insert(0, new ListItem("Select Campus >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

