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
 public partial class AdminSTD_Question : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_QuestionData();
         		QuestionTypeIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_QuestionData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_Question sTD_Question = new STD_Question ();
//	sTD_Question.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_Question.QuestionTypeID=  int.Parse(ddlQuestionTypeID.SelectedValue);
	sTD_Question.Description=  txtDescription.Text;
	sTD_Question.Mark=  int.Parse(txtMark.Text);
	sTD_Question.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Question.AddedDate=  DateTime.Now;
	sTD_Question.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Question.UpdateDate = DateTime.Now; 
	int resutl =STD_QuestionManager.InsertSTD_Question(sTD_Question);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Question.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_Question sTD_Question = new STD_Question ();
	sTD_Question.QuestionID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_Question.QuestionTypeID=  int.Parse(ddlQuestionTypeID.SelectedValue);
	sTD_Question.Description=  txtDescription.Text;
	sTD_Question.Mark=  int.Parse(txtMark.Text);
	sTD_Question.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Question.AddedDate=  DateTime.Now;
	sTD_Question.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_Question.UpdateDate = DateTime.Now; 
	bool  resutl =STD_QuestionManager.UpdateSTD_Question(sTD_Question);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_Question.aspx");
	}
	private void showSTD_QuestionData()
	{
	 	STD_Question sTD_Question  = new STD_Question ();
	 	sTD_Question = STD_QuestionManager.GetSTD_QuestionByQuestionID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlQuestionTypeID.SelectedValue  =sTD_Question.QuestionTypeID.ToString();
	 	txtDescription.Text =sTD_Question.Description.ToString();
	 	txtMark.Text =sTD_Question.Mark.ToString();
	 	string txtUpdatedBy_Text =sTD_Question.UpdatedBy.ToString();
	 	string txtUpdateDate_Text =sTD_Question.UpdateDate.ToString();
	}
	
	private void QuestionTypeIDLoad()
	{
		try {
		DataSet ds = STD_QuestionTypeManager.GetDropDownListAllSTD_QuestionType();
		ddlQuestionTypeID.DataValueField = "QuestionTypeID";
		ddlQuestionTypeID.DataTextField = "QuestionTypeName";
		ddlQuestionTypeID.DataSource = ds.Tables[0];
		ddlQuestionTypeID.DataBind();
		ddlQuestionTypeID.Items.Insert(0, new ListItem("Select QuestionType >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

