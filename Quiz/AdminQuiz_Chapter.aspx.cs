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
 public partial class AdminQuiz_Chapter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
    {
 ////           loadQuiz_ChapterData();
        _loadCourse();
        _loadSubject(0);

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    showQuiz_ChapterData();
                }
        }
    }

    private void _loadCourse()
    {
        try
        {
            DataSet ds = STD_CourseManager.GetDropDownListAllSTD_Course();
            ddlCourseID.DataValueField = "CourseID";
            ddlCourseID.DataTextField = "CourseName";
            ddlCourseID.DataSource = ds;
            ddlCourseID.DataBind();
            ddlCourseID.Items.Insert(0, new ListItem("...Select Course...", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void _loadSubject(int courseID)
    {
        try
        {
            DataSet ds = STD_SubjectManager.GetDropDownListAllSTD_SubjectGeneral(courseID);
            ddlSubjectID.DataValueField = "SubjectID";
            ddlSubjectID.DataTextField = "SubjectName";
            ddlSubjectID.DataSource = ds;
            ddlSubjectID.DataBind();
            ddlSubjectID.Items.Insert(0, new ListItem("...Select Subject...", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _loadSubject(Convert.ToInt32(ddlCourseID.SelectedValue));
    }

	protected void btnAdd_Click(object sender, EventArgs e)
    {
        Quiz_Chapter quiz_Chapter = new Quiz_Chapter ();
        //	quiz_Chapter.ChapterID=  int.Parse(ddlChapterID.SelectedValue);
	    quiz_Chapter.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	    quiz_Chapter.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	    quiz_Chapter.ChapterName=  txtChapterName.Text;
	    quiz_Chapter.AddedBy=  Profile.card_id;
	    quiz_Chapter.AddedDate=  DateTime.Now;
	    quiz_Chapter.ModifiedBy=  Profile.card_id;
	    quiz_Chapter.ModifiedDate=  DateTime.Now;
	    int resutl =Quiz_ChapterManager.InsertQuiz_Chapter(quiz_Chapter);
	    Response.Redirect("AdminDisplayQuiz_Chapter.aspx");
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
    {
	    Quiz_Chapter quiz_Chapter = new Quiz_Chapter ();
	    quiz_Chapter.ChapterID=  int.Parse(Request.QueryString["ID"].ToString());
	    quiz_Chapter.SubjectID=  int.Parse(ddlSubjectID.SelectedValue);
	    quiz_Chapter.CourseID=  int.Parse(ddlCourseID.SelectedValue);
	    quiz_Chapter.ChapterName=  txtChapterName.Text;
	    quiz_Chapter.AddedBy=  Profile.card_id;
	    quiz_Chapter.AddedDate=  DateTime.Now;
	    quiz_Chapter.ModifiedBy=  Profile.card_id;
	    quiz_Chapter.ModifiedDate=  DateTime.Now;
	    bool  resutl =Quiz_ChapterManager.UpdateQuiz_Chapter(quiz_Chapter);
	    Response.Redirect("AdminDisplayQuiz_Chapter.aspx");
	}
	private void showQuiz_ChapterData()
	{
        try
        {
            Quiz_Chapter quiz_Chapter = new Quiz_Chapter();
            quiz_Chapter = Quiz_ChapterManager.GetQuiz_ChapterByChapterID(Int32.Parse(Request.QueryString["ID"]));            
            ddlCourseID.SelectedValue = quiz_Chapter.CourseID.ToString();
            _loadSubject(quiz_Chapter.CourseID);
            ddlSubjectID.SelectedValue = quiz_Chapter.SubjectID.ToString();
            txtChapterName.Text = quiz_Chapter.ChapterName.ToString();
        }
        catch (Exception ex)
        {
        }
	}
}

