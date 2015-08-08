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
 public partial class AdminSTD_BoardUniversity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_BoardUniversityData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_BoardUniversityData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_BoardUniversity sTD_BoardUniversity = new STD_BoardUniversity ();
//	sTD_BoardUniversity.BoardUniversityID=  int.Parse(ddlBoardUniversityID.SelectedValue);
	sTD_BoardUniversity.BoardUniversityName=  txtBoardUniversityName.Text;
	sTD_BoardUniversity.AddedBy=  Profile.card_id;
	sTD_BoardUniversity.AddedDate=  DateTime.Now;
	sTD_BoardUniversity.ModifiedBy=  Profile.card_id;
	sTD_BoardUniversity.ModifiedDate=  DateTime.Now;
	int resutl =STD_BoardUniversityManager.InsertSTD_BoardUniversity(sTD_BoardUniversity);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_BoardUniversity.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_BoardUniversity sTD_BoardUniversity = new STD_BoardUniversity ();
	sTD_BoardUniversity.BoardUniversityID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_BoardUniversity.BoardUniversityName=  txtBoardUniversityName.Text;
	sTD_BoardUniversity.AddedBy=  Profile.card_id;
	sTD_BoardUniversity.AddedDate=  DateTime.Now;
	sTD_BoardUniversity.ModifiedBy=  Profile.card_id;
	sTD_BoardUniversity.ModifiedDate=  DateTime.Now;
	bool  resutl =STD_BoardUniversityManager.UpdateSTD_BoardUniversity(sTD_BoardUniversity);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_BoardUniversity.aspx");
	}
	private void showSTD_BoardUniversityData()
	{
	 	STD_BoardUniversity sTD_BoardUniversity  = new STD_BoardUniversity ();
	 	sTD_BoardUniversity = STD_BoardUniversityManager.GetSTD_BoardUniversityByBoardUniversityID(Int32.Parse(Request.QueryString["ID"]));
	 	txtBoardUniversityName.Text =sTD_BoardUniversity.BoardUniversityName.ToString();
	}
	
}

