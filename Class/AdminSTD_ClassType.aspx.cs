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
 public partial class AdminSTD_ClassType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassTypeData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassTypeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ClassType sTD_ClassType = new STD_ClassType ();
//	sTD_ClassType.ClassTypeID=  int.Parse(ddlClassTypeID.SelectedValue);
	sTD_ClassType.ClassTypeName=  txtClassTypeName.Text;
	sTD_ClassType.AddedBy=  Profile.card_id;
	sTD_ClassType.AddedDate=  DateTime.Now;
	sTD_ClassType.UpdatedBy=  Profile.card_id;
	sTD_ClassType.UpdateDate = DateTime.Now; 
	int resutl =STD_ClassTypeManager.InsertSTD_ClassType(sTD_ClassType);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassType.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
	{
	    STD_ClassType sTD_ClassType = new STD_ClassType ();
	    sTD_ClassType.ClassTypeID=  int.Parse(Request.QueryString["ID"].ToString());
	    sTD_ClassType.ClassTypeName=  txtClassTypeName.Text;
	    sTD_ClassType.AddedBy=  Profile.card_id;
	    sTD_ClassType.AddedDate=  DateTime.Now;
	    sTD_ClassType.UpdatedBy=  Profile.card_id;
	    sTD_ClassType.UpdateDate = DateTime.Now; 
	    bool  resutl =STD_ClassTypeManager.UpdateSTD_ClassType(sTD_ClassType);
	    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassType.aspx");
	}
	private void showSTD_ClassTypeData()
	{
	 	STD_ClassType sTD_ClassType  = new STD_ClassType ();
	 	sTD_ClassType = STD_ClassTypeManager.GetSTD_ClassTypeByClassTypeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassTypeName.Text =sTD_ClassType.ClassTypeName.ToString();
	}
	
}

