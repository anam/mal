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
 public partial class AdminSTD_ClassDay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ClassDayData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ClassDayData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ClassDay sTD_ClassDay = new STD_ClassDay ();
//	sTD_ClassDay.ClassDayID=  int.Parse(ddlClassDayID.SelectedValue);
	sTD_ClassDay.ClassDayName=  txtClassDayName.Text;
	sTD_ClassDay.AddedBy=  Profile.card_id;
	sTD_ClassDay.AddedDate=  DateTime.Now;
	sTD_ClassDay.UpdatedBy=  Profile.card_id;
	sTD_ClassDay.UpdateDate = DateTime.Now; 
	int resutl =STD_ClassDayManager.InsertSTD_ClassDay(sTD_ClassDay);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassDay.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ClassDay sTD_ClassDay = new STD_ClassDay ();
	sTD_ClassDay.ClassDayID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ClassDay.ClassDayName=  txtClassDayName.Text;
	sTD_ClassDay.AddedBy=  Profile.card_id;
	sTD_ClassDay.AddedDate=  DateTime.Now;
	sTD_ClassDay.UpdatedBy=  Profile.card_id;
	sTD_ClassDay.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ClassDayManager.UpdateSTD_ClassDay(sTD_ClassDay);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ClassDay.aspx");
	}
	private void showSTD_ClassDayData()
	{
	 	STD_ClassDay sTD_ClassDay  = new STD_ClassDay ();
	 	sTD_ClassDay = STD_ClassDayManager.GetSTD_ClassDayByClassDayID(Int32.Parse(Request.QueryString["ID"]));
	 	txtClassDayName.Text =sTD_ClassDay.ClassDayName.ToString();
	}
	
}

