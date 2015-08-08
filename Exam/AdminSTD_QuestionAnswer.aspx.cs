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
 public partial class AdminSTD_QuestionAnswer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadSTD_QuestionAnswerData();
         		QuestionIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showSTD_QuestionAnswerData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e){try
		{
	STD_QuestionAnswer sTD_QuestionAnswer = new STD_QuestionAnswer ();
//	sTD_QuestionAnswer.QuestionAnswerID=  int.Parse(ddlQuestionAnswerID.SelectedValue);
	sTD_QuestionAnswer.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_QuestionAnswer.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionAnswer.AddedDate=  DateTime.Now;
	sTD_QuestionAnswer.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionAnswer.UpdateDate = DateTime.Now; 
	sTD_QuestionAnswer.IsCorrectQuestionAnswer=  bool.Parse( radIsCorrectQuestionAnswer.SelectedValue);
	sTD_QuestionAnswer.Description=  txtDescription.Text;
	int resutl =STD_QuestionAnswerManager.InsertSTD_QuestionAnswer(sTD_QuestionAnswer);
    }catch(Exception ex){}Response.Redirect("AdminDisplaySTD_QuestionAnswer.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e){try
		{
	STD_QuestionAnswer sTD_QuestionAnswer = new STD_QuestionAnswer ();
	sTD_QuestionAnswer.QuestionAnswerID=  int.Parse(Request.QueryString["ID"].ToString());
	sTD_QuestionAnswer.QuestionID=  int.Parse(ddlQuestionID.SelectedValue);
	sTD_QuestionAnswer.AddedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionAnswer.AddedDate=  DateTime.Now;
	sTD_QuestionAnswer.UpdatedBy=  "530038e1-cf38-4ddb-84a4-99b6974b4f9d";
	sTD_QuestionAnswer.UpdateDate = DateTime.Now; 
	sTD_QuestionAnswer.IsCorrectQuestionAnswer=  bool.Parse( radIsCorrectQuestionAnswer.SelectedValue);
	sTD_QuestionAnswer.Description=  txtDescription.Text;
	bool  resutl =STD_QuestionAnswerManager.UpdateSTD_QuestionAnswer(sTD_QuestionAnswer);
	}catch(Exception ex){}Response.Redirect("AdminDisplaySTD_QuestionAnswer.aspx");
	}
	private void showSTD_QuestionAnswerData()
	{
	 	STD_QuestionAnswer sTD_QuestionAnswer  = new STD_QuestionAnswer ();
	 	sTD_QuestionAnswer = STD_QuestionAnswerManager.GetSTD_QuestionAnswerByQuestionAnswerID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlQuestionID.SelectedValue  =sTD_QuestionAnswer.QuestionID.ToString();
	 	string txtUpdatedBy_Text =sTD_QuestionAnswer.UpdatedBy.ToString();
	 	string txtUpdateDate_Text =sTD_QuestionAnswer.UpdateDate.ToString();
	 	 radIsCorrectQuestionAnswer.SelectedValue  =sTD_QuestionAnswer.IsCorrectQuestionAnswer.ToString();
	 	txtDescription.Text =sTD_QuestionAnswer.Description.ToString();
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
}

