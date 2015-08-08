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
 public partial class AdminSTD_QuestionChapter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_QuestionChapterData();
         		QuestionIDLoad();
		ChapterIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_QuestionChapterData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_QuestionChapter sTD_QuestionChapter = new STD_QuestionChapter ();
//	sTD_QuestionChapter.Question_ChapterID=  int.Parse(ddlQuestion_ChapterID.SelectedValue);
	sTD_QuestionChapter.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_QuestionChapter.ChapterID=  int.Parse(ddlChapterID.SelectedValue);
	sTD_QuestionChapter.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionChapter.AddedDate=  DateTime.Now;
	sTD_QuestionChapter.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionChapter.UpdateDate = DateTime.Now; 
	int resutl =STD_QuestionChapterManager.InsertSTD_QuestionChapter(sTD_QuestionChapter);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_QuestionChapter.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_QuestionChapter sTD_QuestionChapter = new STD_QuestionChapter ();
	sTD_QuestionChapter.Question_ChapterID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_QuestionChapter.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_QuestionChapter.ChapterID=  int.Parse(ddlChapterID.SelectedValue);
	sTD_QuestionChapter.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionChapter.AddedDate=  DateTime.Now;
	sTD_QuestionChapter.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionChapter.UpdateDate = DateTime.Now; 
	bool  resutl =STD_QuestionChapterManager.UpdateSTD_QuestionChapter(sTD_QuestionChapter);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_QuestionChapter.aspx");
	}
	private void showSTD_QuestionChapterData()
	{
	 	STD_QuestionChapter sTD_QuestionChapter  = new STD_QuestionChapter ();
	 	sTD_QuestionChapter = STD_QuestionChapterManager.GetSTD_QuestionChapterByQuestion_ChapterID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlQuestionID.SelectedValue  =sTD_QuestionChapter.QuestionID.ToString();
	 	ddlChapterID.SelectedValue  =sTD_QuestionChapter.ChapterID.ToString();
	 	string txtUpdatedBy_Text =sTD_QuestionChapter.UpdatedBy.ToString();
	 	string txtUpdateDate_Text =sTD_QuestionChapter.UpdateDate.ToString();
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
	private void ChapterIDLoad()
	{
		try {
		DataSet ds = STD_ChapterManager.GetDropDownListAllSTD_Chapter();
		ddlChapterID.DataValueField = "ChapterID";
		ddlChapterID.DataTextField = "ChapterName";
		ddlChapterID.DataSource = ds.Tables[0];
		ddlChapterID.DataBind();
		ddlChapterID.Items.Insert(0, new ListItem("Select Chapter >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

