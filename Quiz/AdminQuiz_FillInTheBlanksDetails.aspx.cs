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
 public partial class AdminQuiz_FillInTheBlanksDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 //           loadQuiz_FillInTheBlanksDetailsData();
         		FillInTheBlanksIDLoad();

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showQuiz_FillInTheBlanksDetailsData();
                }
        }
    }
	protected void btnAdd_Click(object sender, EventArgs e)
		{
	Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails = new Quiz_FillInTheBlanksDetails ();
//	quiz_FillInTheBlanksDetails.FillInTheBlanksDetailsID=  int.Parse(ddlFillInTheBlanksDetailsID.SelectedValue);
	quiz_FillInTheBlanksDetails.FillInTheBlanksID=  int.Parse(ddlFillInTheBlanksID.SelectedValue);
	quiz_FillInTheBlanksDetails.QuestionSl=  int.Parse(txtQuestionSl.Text);
	quiz_FillInTheBlanksDetails.Answer=  txtAnswer.Text;
	quiz_FillInTheBlanksDetails.AddedBy=  Profile.card_id;
	quiz_FillInTheBlanksDetails.AddedDate=  DateTime.Now;
	quiz_FillInTheBlanksDetails.ModifiedBy=  Profile.card_id;
	quiz_FillInTheBlanksDetails.ModifiedDate=  DateTime.Now;
	int resutl =Quiz_FillInTheBlanksDetailsManager.InsertQuiz_FillInTheBlanksDetails(quiz_FillInTheBlanksDetails);
	Response.Redirect("AdminDisplayQuiz_FillInTheBlanksDetails.aspx");
	}
	protected void btnUpdate_Click(object sender, EventArgs e)
		{
	Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails = new Quiz_FillInTheBlanksDetails ();
	quiz_FillInTheBlanksDetails.FillInTheBlanksDetailsID=  int.Parse(Request.QueryString["ID"].ToString());
	quiz_FillInTheBlanksDetails.FillInTheBlanksID=  int.Parse(ddlFillInTheBlanksID.SelectedValue);
	quiz_FillInTheBlanksDetails.QuestionSl=  int.Parse(txtQuestionSl.Text);
	quiz_FillInTheBlanksDetails.Answer=  txtAnswer.Text;
	quiz_FillInTheBlanksDetails.AddedBy=  Profile.card_id;
	quiz_FillInTheBlanksDetails.AddedDate=  DateTime.Now;
	quiz_FillInTheBlanksDetails.ModifiedBy=  Profile.card_id;
	quiz_FillInTheBlanksDetails.ModifiedDate=  DateTime.Now;
	bool  resutl =Quiz_FillInTheBlanksDetailsManager.UpdateQuiz_FillInTheBlanksDetails(quiz_FillInTheBlanksDetails);
	Response.Redirect("AdminDisplayQuiz_FillInTheBlanksDetails.aspx");
	}
	private void showQuiz_FillInTheBlanksDetailsData()
	{
	 	Quiz_FillInTheBlanksDetails quiz_FillInTheBlanksDetails  = new Quiz_FillInTheBlanksDetails ();
	 	quiz_FillInTheBlanksDetails = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksDetailsByFillInTheBlanksDetailsID(Int32.Parse(Request.QueryString["ID"]));
	 	ddlFillInTheBlanksID.SelectedValue  =quiz_FillInTheBlanksDetails.FillInTheBlanksID.ToString();
	 	txtQuestionSl.Text =quiz_FillInTheBlanksDetails.QuestionSl.ToString();
	 	txtAnswer.Text =quiz_FillInTheBlanksDetails.Answer.ToString();
	}
	
	private void FillInTheBlanksIDLoad()
	{
		try {
		DataSet ds = Quiz_FillInTheBlanksManager.GetDropDownListAllQuiz_FillInTheBlanks();
		ddlFillInTheBlanksID.DataValueField = "FillInTheBlanksID";
		ddlFillInTheBlanksID.DataTextField = "FillInTheBlanksName";
		ddlFillInTheBlanksID.DataSource = ds.Tables[0];
		ddlFillInTheBlanksID.DataBind();
		ddlFillInTheBlanksID.Items.Insert(0, new ListItem("Select FillInTheBlanks >>", "0"));
		}
		catch (Exception ex) {
		ex.Message.ToString();
		}
	 }
}

