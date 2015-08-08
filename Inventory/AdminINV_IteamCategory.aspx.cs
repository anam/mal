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
 public partial class AdminINV_IteamCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadINV_IteamCategoryData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showINV_IteamCategoryData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	INV_IteamCategory iNV_IteamCategory = new INV_IteamCategory ();
//	iNV_IteamCategory.IteamCategoryID=  int.Parse(ddlIteamCategoryID.SelectedValue);
	iNV_IteamCategory.IteamCategoryName=  txtIteamCategoryName.Text;
	iNV_IteamCategory.AddedBy=  Profile.card_id;
	iNV_IteamCategory.AddedDate=  DateTime.Now;
	iNV_IteamCategory.UpdatedBy=  Profile.card_id;
	iNV_IteamCategory.UpdatedDate=   DateTime.Now;
	int resutl =INV_IteamCategoryManager.InsertINV_IteamCategory(iNV_IteamCategory);
    }catch(Exception ex){}Response.Redirect("AdminDisplayINV_IteamCategory.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	INV_IteamCategory iNV_IteamCategory = new INV_IteamCategory ();
	iNV_IteamCategory.IteamCategoryID=  int.Parse(Request.QueryString["ID"].ToString());
	iNV_IteamCategory.IteamCategoryName=  txtIteamCategoryName.Text;
	iNV_IteamCategory.AddedBy=  Profile.card_id;
	iNV_IteamCategory.AddedDate=  DateTime.Now;
	iNV_IteamCategory.UpdatedBy=  Profile.card_id;
	iNV_IteamCategory.UpdatedDate=   DateTime.Now;
	bool  resutl =INV_IteamCategoryManager.UpdateINV_IteamCategory(iNV_IteamCategory);
	}catch(Exception ex){}Response.Redirect("AdminDisplayINV_IteamCategory.aspx");
	}
	private void showINV_IteamCategoryData()
	{
	 	INV_IteamCategory iNV_IteamCategory  = new INV_IteamCategory ();
	 	iNV_IteamCategory = INV_IteamCategoryManager.GetINV_IteamCategoryByIteamCategoryID(Int32.Parse(Request.QueryString["ID"]));
	 	txtIteamCategoryName.Text =iNV_IteamCategory.IteamCategoryName.ToString();
	 	string txtUpdatedBy_Text =iNV_IteamCategory.UpdatedBy.ToString();
	 	string txtUpdatedDate_Text =iNV_IteamCategory.UpdatedDate.ToString();
	}
	
}

