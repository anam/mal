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
 public partial class AdminSTD_ComprehensionQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_ComprehensionQuestionData();
         		QuestionIDLoad();
		ComprehensionIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_ComprehensionQuestionData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_ComprehensionQuestion sTD_ComprehensionQuestion = new STD_ComprehensionQuestion ();
//	sTD_ComprehensionQuestion.ComprehensionQuestionID=  int.Parse(ddlComprehensionQuestionID.SelectedValue);
	sTD_ComprehensionQuestion.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_ComprehensionQuestion.ComprehensionID=  int.Parse(ddlComprehensionID.SelectedValue);
	sTD_ComprehensionQuestion.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ComprehensionQuestion.AddedDate=  DateTime.Now;
	sTD_ComprehensionQuestion.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ComprehensionQuestion.UpdateDate = DateTime.Now; 
	int resutl =STD_ComprehensionQuestionManager.InsertSTD_ComprehensionQuestion(sTD_ComprehensionQuestion);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ComprehensionQuestion.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_ComprehensionQuestion sTD_ComprehensionQuestion = new STD_ComprehensionQuestion ();
	sTD_ComprehensionQuestion.ComprehensionQuestionID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_ComprehensionQuestion.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_ComprehensionQuestion.ComprehensionID=  int.Parse(ddlComprehensionID.SelectedValue);
	sTD_ComprehensionQuestion.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ComprehensionQuestion.AddedDate=  DateTime.Now;
	sTD_ComprehensionQuestion.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_ComprehensionQuestion.UpdateDate = DateTime.Now; 
	bool  resutl =STD_ComprehensionQuestionManager.UpdateSTD_ComprehensionQuestion(sTD_ComprehensionQuestion);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_ComprehensionQuestion.aspx");
	}
	private void showSTD_ComprehensionQuestionData()
	{
	 	STD_ComprehensionQuestion sTD_ComprehensionQuestion  = new STD_ComprehensionQuestion ();
	 	sTD_ComprehensionQuestion = STD_ComprehensionQuestionManager.GetSTD_ComprehensionQuestionByComprehensionQuestionID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlQuestionID.SelectedValue  =sTD_ComprehensionQuestion.QuestionID.ToString();
	 	ddlComprehensionID.SelectedValue  =sTD_ComprehensionQuestion.ComprehensionID.ToString();
	 	
	}
	
	private void QuestionIDLoad()
	{
		try {
		DataSet ds = STD_QuestionManager.GetDropDownListAllSTD_Question();
		ddlQuestionID.DataValueField = "QuestionID";
		ddlQuestionID.DataTextField = "QuestionName";
		ddlQuestionID.DataSource = ds.Tables[0];
		ddlQuestionID.DataBind();
		ddlQuestionID.Items.Insert(0, new ListItem("Select Question >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
	private void ComprehensionIDLoad()
	{
		try {
		DataSet ds = STD_ComprehensionManager.GetDropDownListAllSTD_Comprehension();
		ddlComprehensionID.DataValueField = "ComprehensionID";
		ddlComprehensionID.DataTextField = "ComprehensionName";
		ddlComprehensionID.DataSource = ds.Tables[0];
		ddlComprehensionID.DataBind();
		ddlComprehensionID.Items.Insert(0, new ListItem("Select Comprehension >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

