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
 public partial class AdminSTD_ContactType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ContactTypeData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ContactTypeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ContactType sTD_ContactType = new STD_ContactType ();
//	sTD_ContactType.ContactTypeID=  int.Parse(ddlContactTypeID.SelectedValue);
	sTD_ContactType.ContactTypeName=  txtContactTypeName.Text;
	sTD_ContactType.AddedBy=  Profile.card_id;
	sTD_ContactType.AddedDate=  DateTime.Now;
	sTD_ContactType.ModifiedBy=  Profile.card_id;
	sTD_ContactType.ModifiedDate=  DateTime.Now;
	int resutl =STD_ContactTypeManager.InsertSTD_ContactType(sTD_ContactType);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ContactType.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ContactType sTD_ContactType = new STD_ContactType ();
	sTD_ContactType.ContactTypeID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ContactType.ContactTypeName=  txtContactTypeName.Text;
	sTD_ContactType.AddedBy=  Profile.card_id;
	sTD_ContactType.AddedDate=  DateTime.Now;
	sTD_ContactType.ModifiedBy=  Profile.card_id;
	sTD_ContactType.ModifiedDate=  DateTime.Now;
	bool  resutl =STD_ContactTypeManager.UpdateSTD_ContactType(sTD_ContactType);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ContactType.aspx");
	}
	private void showSTD_ContactTypeData()
	{
	 	STD_ContactType sTD_ContactType  = new STD_ContactType ();
	 	sTD_ContactType = STD_ContactTypeManager.GetSTD_ContactTypeByContactTypeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtContactTypeName.Text =sTD_ContactType.ContactTypeName.ToString();
	}
	
}

