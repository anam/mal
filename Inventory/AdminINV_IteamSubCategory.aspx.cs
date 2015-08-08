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
 public partial class AdminINV_IteamSubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadINV_IteamSubCategoryData();
         		IteamCategoryIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showINV_IteamSubCategoryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory ();
//	iNV_IteamSubCategory.IteamSubCategoryID=  int.Parse(ddlIteamSubCategoryID.SelectedValue);
	iNV_IteamSubCategory.IteamSubCategoryName=  txtIteamSubCategoryName.Text;
	iNV_IteamSubCategory.IteamCategoryID=  int.Parse(ddlIteamCategoryID.SelectedValue);
	iNV_IteamSubCategory.AddedBy=  Profile.card_id;
	iNV_IteamSubCategory.AddedDate=  DateTime.Now;
	iNV_IteamSubCategory.UpdatedBy=  Profile.card_id;
	iNV_IteamSubCategory.UpdatedDate=   DateTime.Now;
	int resutl =INV_IteamSubCategoryManager.InsertINV_IteamSubCategory(iNV_IteamSubCategory);
    }catch(Exception ex){}Response.Redirect("AdminDisplayINV_IteamSubCategory.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	INV_IteamSubCategory iNV_IteamSubCategory = new INV_IteamSubCategory ();
	iNV_IteamSubCategory.IteamSubCategoryID=  int.Parse(Request.QueryString["ID"].ToString());
	iNV_IteamSubCategory.IteamSubCategoryName=  txtIteamSubCategoryName.Text;
	iNV_IteamSubCategory.IteamCategoryID=  int.Parse(ddlIteamCategoryID.SelectedValue);
	iNV_IteamSubCategory.AddedBy=  Profile.card_id;
	iNV_IteamSubCategory.AddedDate=  DateTime.Now;
	iNV_IteamSubCategory.UpdatedBy=  Profile.card_id;
	iNV_IteamSubCategory.UpdatedDate=   DateTime.Now;
	bool  resutl =INV_IteamSubCategoryManager.UpdateINV_IteamSubCategory(iNV_IteamSubCategory);
	}catch(Exception ex){}Response.Redirect("AdminDisplayINV_IteamSubCategory.aspx");
	}
	private void showINV_IteamSubCategoryData()
	{
	 	INV_IteamSubCategory iNV_IteamSubCategory  = new INV_IteamSubCategory ();
	 	iNV_IteamSubCategory = INV_IteamSubCategoryManager.GetINV_IteamSubCategoryByIteamSubCategoryID(Int32.Parse(Request.QueryString["ID"]));
	 	txtIteamSubCategoryName.Text =iNV_IteamSubCategory.IteamSubCategoryName.ToString();
	 	ddlIteamCategoryID.SelectedValue  =iNV_IteamSubCategory.IteamCategoryID.ToString();
	 	string txtUpdatedBy_Text =iNV_IteamSubCategory.UpdatedBy.ToString();
	 	string txtUpdatedDate_Text =iNV_IteamSubCategory.UpdatedDate.ToString();
	}
	
	private void IteamCategoryIDLoad()
	{
		try {
		DataSet ds = INV_IteamCategoryManager.GetDropDownListAllINV_IteamCategory();
		ddlIteamCategoryID.DataValueField = "IteamCategoryID";
		ddlIteamCategoryID.DataTextField = "IteamCategoryName";
		ddlIteamCategoryID.DataSource = ds.Tables[0];
		ddlIteamCategoryID.DataBind();
		ddlIteamCategoryID.Items.Insert(0, new ListItem("Select ItemCategory >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

