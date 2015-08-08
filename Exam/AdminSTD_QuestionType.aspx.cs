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
 public partial class AdminSTD_QuestionType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_QuestionTypeData();
         
            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_QuestionTypeData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_QuestionType sTD_QuestionType = new STD_QuestionType ();
//	sTD_QuestionType.QuestionTypeID=  int.Parse(ddlQuestionTypeID.SelectedValue);
	sTD_QuestionType.QuestionTypeName=  txtQuestionTypeName.Text;
	sTD_QuestionType.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionType.AddedDate=  DateTime.Now;
	sTD_QuestionType.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionType.UpdateDate = DateTime.Now; 
	int resutl =STD_QuestionTypeManager.InsertSTD_QuestionType(sTD_QuestionType);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_QuestionType.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_QuestionType sTD_QuestionType = new STD_QuestionType ();
	sTD_QuestionType.QuestionTypeID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_QuestionType.QuestionTypeName=  txtQuestionTypeName.Text;
	sTD_QuestionType.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionType.AddedDate=  DateTime.Now;
	sTD_QuestionType.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionType.UpdateDate = DateTime.Now; 
	bool  resutl =STD_QuestionTypeManager.UpdateSTD_QuestionType(sTD_QuestionType);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_QuestionType.aspx");
	}
	private void showSTD_QuestionTypeData()
	{
	 	STD_QuestionType sTD_QuestionType  = new STD_QuestionType ();
	 	sTD_QuestionType = STD_QuestionTypeManager.GetSTD_QuestionTypeByQuestionTypeID(Int32.Parse(Request.QueryString["ID"]));
	 	txtQuestionTypeName.Text =sTD_QuestionType.QuestionTypeName.ToString();
	 	string txtUpdatedBy_Text =sTD_QuestionType.UpdatedBy.ToString();
	 	string txtUpdateDate_Text =sTD_QuestionType.UpdateDate.ToString();
	}
	
}

