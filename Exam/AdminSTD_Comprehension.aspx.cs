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
 public partial class AdminSTD_Comprehension : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ComprehensionData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ComprehensionData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Comprehension sTD_Comprehension = new STD_Comprehension ();
//	sTD_Comprehension.ComprehensionID=  int.Parse(ddlComprehensionID.SelectedValue);
	sTD_Comprehension.ComprehensionName=  txtComprehensionName.Text;
	sTD_Comprehension.Description=  txtDescription.Text;
	sTD_Comprehension.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Comprehension.AddedDate=  DateTime.Now;
	sTD_Comprehension.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Comprehension.UpdateDate = DateTime.Now; 
	int resutl =STD_ComprehensionManager.InsertSTD_Comprehension(sTD_Comprehension);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Comprehension.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Comprehension sTD_Comprehension = new STD_Comprehension ();
	sTD_Comprehension.ComprehensionID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Comprehension.ComprehensionName=  txtComprehensionName.Text;
	sTD_Comprehension.Description=  txtDescription.Text;
	sTD_Comprehension.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Comprehension.AddedDate=  DateTime.Now;
	sTD_Comprehension.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Comprehension.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ComprehensionManager.UpdateSTD_Comprehension(sTD_Comprehension);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Comprehension.aspx");
	}
	private void showSTD_ComprehensionData()
	{
	 	STD_Comprehension sTD_Comprehension  = new STD_Comprehension ();
	 	sTD_Comprehension = STD_ComprehensionManager.GetSTD_ComprehensionByComprehensionID(Int32.Parse(Request.QueryString["ID"]));
	 	txtComprehensionName.Text =sTD_Comprehension.ComprehensionName.ToString();
	 	txtDescription.Text =sTD_Comprehension.Description.ToString();
	}
	
}

