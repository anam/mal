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
 public partial class AdminQuiz_Comprehension : System.Web.UI.Page
 {

    // List<Quiz_TrueFalse> listTrueFalse = new List<Quiz_TrueFalse>();
    // List<int> delTrueFalseIDs = new List<int>();
    //public static List<Quiz_TrueFalse> listDrCr = new List<Quiz_TrueFalse>();

    //private static List<Quiz_FillInTheBlanks> fillInTheBlanks = new List<Quiz_FillInTheBlanks>();
    //static List<int> delFillInTheBlankIDs = new List<int>();

    //private static List<Quiz_MultipleQuestion> multipleQuestions = new List<Quiz_MultipleQuestion>();
    //static List<int> delMultipleQuestionIDs = new List<int>();

    //public List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
    //static List<int> delFillInTheBlankDetailsIDs = new List<int>();

    //public List<Quiz_MultipleQuestionDetails> multipleQuestionDetails = new List<Quiz_MultipleQuestionDetails>();
    //static List<int> delMultipleQuestionDetailsIDs = new List<int>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["listTrueFalse"] = null;
            Session["delTrueFalseIDs"] = null;
            Session["listDrCr"] = null;
            Session["fillInTheBlanks"] = null;
            Session["delFillInTheBlankIDs"] = null;
            Session["multipleQuestions"] = null;
            Session["delMultipleQuestionIDs"] = null;
            Session["fillInTheBlanksDetails"] = null;
            Session["delFillInTheBlankDetailsIDs"] = null;
            Session["multipleQuestionDetails"] = null;
            Session["delMultipleQuestionDetailsIDs"] = null;

            _loadCourse();
            _loadSubject(0);
            ChapterIDLoad(0, 0);

            if (Request.QueryString["ID"] != null)
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                //btnAdd.Visible = false;
                showQuiz_ComprehensionData();
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

    private void ChapterIDLoad(int courseID, int subjectID)
    {
        try
        {
            if (courseID > 0 && subjectID > 0)
            {
                DataSet ds = Quiz_ChapterManager.GetDropDownListAllQuiz_Chapter(courseID, subjectID);
                ddlChapterID.DataValueField = "ChapterID";
                ddlChapterID.DataTextField = "ChapterName";
                ddlChapterID.DataSource = ds.Tables[0];
                ddlChapterID.DataBind();
            }
            ddlChapterID.Items.Insert(0, new ListItem("...Select Chapter...", "0"));
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    protected void ddlCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _loadSubject(Convert.ToInt32(ddlCourseID.SelectedValue));
    }

    protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int courseID = Convert.ToInt32(ddlCourseID.SelectedValue);
        int subjectID = Convert.ToInt32(ddlSubjectID.SelectedValue);
        ChapterIDLoad(courseID, subjectID);
    }

	private void showQuiz_ComprehensionData()
	{
        try
        {
             List<Quiz_TrueFalse> listTrueFalse = new List<Quiz_TrueFalse>();
            
            int comprehensionID = Convert.ToInt32(Request.QueryString["ID"].ToString());

            Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension();
            quiz_Comprehension = Quiz_ComprehensionManager.GetQuiz_ComprehensionByComprehensionID(comprehensionID);
            ddlCourseID.SelectedValue = quiz_Comprehension.CourseID.ToString();
            _loadSubject(quiz_Comprehension.CourseID);

            

            ddlSubjectID.SelectedValue = quiz_Comprehension.SubjectID.ToString();

            ChapterIDLoad(quiz_Comprehension.CourseID, quiz_Comprehension.SubjectID);

            ddlChapterID.SelectedValue = quiz_Comprehension.ChapterID.ToString();
            fckDesc.Value= quiz_Comprehension.Comprehension.ToString();

            #region Display TrueFalse Questions
            DataSet ds = Quiz_TrueFalseManager.GetQuiz_TrueFalseByComprehensionID(comprehensionID);
            listTrueFalse.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Quiz_TrueFalse trueFalse = new Quiz_TrueFalse();
                trueFalse.TrueFalseID = Convert.ToInt32(dr["TrueFalseID"].ToString());
                trueFalse.ComprehensionID = Convert.ToInt32(dr["ComprehensionID"].ToString());
                trueFalse.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                trueFalse.SubjectID = Convert.ToInt32(dr["SubjectID"].ToString());
                trueFalse.ChapterID = Convert.ToInt32(dr["ChapterID"].ToString());
                trueFalse.QuestionTitle = dr["QuestionTitle"].ToString();
                trueFalse.IsDrCr = Convert.ToBoolean(dr["IsDrCr"].ToString());
                trueFalse.IsTrue = Convert.ToBoolean(dr["IsTrue"].ToString());
                trueFalse.AddedBy = dr["AddedBy"].ToString();
                trueFalse.AddedDate = Convert.ToDateTime(dr["AddedDate"].ToString());
                trueFalse.ModifiedBy = dr["ModifiedBy"].ToString();
                trueFalse.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());

                listTrueFalse.Add(trueFalse);
            }
            
            Session["listTrueFalse"] = listTrueFalse;

            gvQuiz_TrueFalse.DataSource = Session["listTrueFalse"];
            gvQuiz_TrueFalse.DataBind();
            #endregion

            #region Display DrCr Questions

            List<Quiz_TrueFalse> listDrCr = new List<Quiz_TrueFalse>();

            ds = new DataSet();
            ds = Quiz_TrueFalseManager.GetQuiz_DrCrByComprehensionID(comprehensionID);

            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Quiz_TrueFalse drcr = new Quiz_TrueFalse();
                drcr.TrueFalseID = Convert.ToInt32(dr["TrueFalseID"].ToString());
                drcr.ComprehensionID = Convert.ToInt32(dr["ComprehensionID"].ToString());
                drcr.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                drcr.SubjectID = Convert.ToInt32(dr["SubjectID"].ToString());
                drcr.ChapterID = Convert.ToInt32(dr["ChapterID"].ToString());
                drcr.QuestionTitle = dr["QuestionTitle"].ToString();
                drcr.IsDrCr = Convert.ToBoolean(dr["IsDrCr"].ToString());
                drcr.IsTrue = Convert.ToBoolean(dr["IsTrue"].ToString());
                drcr.AddedBy = dr["AddedBy"].ToString();
                drcr.AddedDate = Convert.ToDateTime(dr["AddedDate"].ToString());
                drcr.ModifiedBy = dr["ModifiedBy"].ToString();
                drcr.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());

                listDrCr.Add(drcr);
            }

            Session["listDrCr"] = listDrCr;


            gvQuiz_gvDrCr.DataSource = Session["listDrCr"];
            gvQuiz_gvDrCr.DataBind();
            #endregion

            #region Display Fill in The BlankQuestions

            List<Quiz_FillInTheBlanks> fillInTheBlanks = new List<Quiz_FillInTheBlanks>();

            DataSet dsFillInTheBlanks = Quiz_FillInTheBlanksManager.GetQuiz_FillInTheBlanksByComprehensionID(comprehensionID);
            foreach (DataRow dr in dsFillInTheBlanks.Tables[0].Rows)
            {
                Quiz_FillInTheBlanks fillInTheBlank = new Quiz_FillInTheBlanks();
                fillInTheBlank.FillInTheBlanksID = Convert.ToInt32(dr["FillInTheBlanksID"].ToString());
                fillInTheBlank.ComprehensionID = Convert.ToInt32(dr["ComprehensionID"].ToString());
                fillInTheBlank.Question = dr["Question"].ToString();
                fillInTheBlank.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                fillInTheBlank.SubjectID = Convert.ToInt32(dr["SubjectID"].ToString());
                fillInTheBlank.ChapterID = Convert.ToInt32(dr["ChapterID"].ToString());
                fillInTheBlank.AddedBy=dr["AddedBy"].ToString();
                fillInTheBlank.AddedDate = Convert.ToDateTime(dr["AddedDate"].ToString());
                fillInTheBlank.ModifiedBy = dr["ModifiedBy"].ToString();
                fillInTheBlank.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());

                fillInTheBlanks.Add(fillInTheBlank);
            }

            Session["fillInTheBlanks"] = fillInTheBlanks;

            gvQuiz_FillInTheBlanks.DataSource = Session["fillInTheBlanks"];
            gvQuiz_FillInTheBlanks.DataBind();

            
            #endregion

            #region Display Multiple Choice Questions
           
            List<Quiz_MultipleQuestion> multipleQuestions = new List<Quiz_MultipleQuestion>();

            DataSet dsMultipleQuestions = Quiz_MultipleQuestionManager.GetQuiz_MultipleQuestionByComprehensionID(comprehensionID);

            foreach (DataRow dr in dsMultipleQuestions.Tables[0].Rows)
            {
                Quiz_MultipleQuestion multipleQuestion = new Quiz_MultipleQuestion();
                multipleQuestion.MultipleQustionID = Convert.ToInt32(dr["MultipleQustionID"].ToString());
                multipleQuestion.ComprehensionID = Convert.ToInt32(dr["ComprehensionID"].ToString());
                multipleQuestion.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                multipleQuestion.SubjectID = Convert.ToInt32(dr["SubjectID"].ToString());
                multipleQuestion.ChapterID = Convert.ToInt32(dr["ChapterID"].ToString());
                multipleQuestion.MultipleQuestionName = dr["MultipleQuestionName"].ToString();
                multipleQuestion.AddedBy = dr["AddedBy"].ToString();
                multipleQuestion.AddedDate = Convert.ToDateTime(dr["AddedDate"].ToString());
                multipleQuestion.ModifiedBy = dr["ModifiedBy"].ToString();
                multipleQuestion.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());

                multipleQuestions.Add(multipleQuestion);
            }

            Session["multipleQuestions"] = multipleQuestions;

            gvQuiz_MultipleQuestion.DataSource = Session["multipleQuestions"];
            gvQuiz_MultipleQuestion.DataBind();            
            #endregion

            
        }
        catch (Exception ex)
        {
        }
	}
	
    protected void lbDeleteTruFalse_Click(object sender, EventArgs e)
	{
        List<Quiz_TrueFalse> listTrueFalse = new List<Quiz_TrueFalse>();
        listTrueFalse = (List<Quiz_TrueFalse>)Session["listTrueFalse"];
        
        List<int> delTrueFalseIDs = new List<int>();

        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;
        
        int index = Convert.ToInt32(linkButton.CommandArgument);
        listTrueFalse.RemoveAt(index);

        GridViewRow row = (GridViewRow)linkButton.NamingContainer;
        int trueFalseID = Convert.ToInt32(((HiddenField)row.FindControl("hfTureFalseID")).Value);

        if (trueFalseID > 0)
        {
            if (Session["delTrueFalseIDs"] == null)
            {
                delTrueFalseIDs.Add(trueFalseID);
                Session["delTrueFalseIDs"] = delTrueFalseIDs;
            }
            else
                ((List<int>)Session["delTrueFalseIDs"]).Add(trueFalseID);
        }

        Session["listTrueFalse"] = listTrueFalse;

        gvQuiz_TrueFalse.DataSource = Session["listTrueFalse"];
        gvQuiz_TrueFalse.DataBind();
  	}

    protected void lbDeleteDrCr_Click(object sender, EventArgs e)
    {
        List<Quiz_TrueFalse> listDrCr = new List<Quiz_TrueFalse>();

        listDrCr = (List<Quiz_TrueFalse>)Session["listDrCr"];

        List<int> delTrueFalseIDs = new List<int>();

        ImageButton linkButton = new ImageButton();
        linkButton = (ImageButton)sender;

        int index = Convert.ToInt32(linkButton.CommandArgument);
        listDrCr.RemoveAt(index);

        GridViewRow row = (GridViewRow)linkButton.NamingContainer;
        int trueFalseID = Convert.ToInt32(((HiddenField)row.FindControl("hfDrCrID")).Value);

        if (trueFalseID > 0)
        {
            if (Session["delTrueFalseIDs"] == null)
            {
                delTrueFalseIDs.Add(trueFalseID);
                Session["delTrueFalseIDs"] = delTrueFalseIDs;
            }
            else
                ((List<int>)Session["delTrueFalseIDs"]).Add(trueFalseID);
        }

        Session["listDrCr"] = listDrCr;

        gvQuiz_gvDrCr.DataSource = listDrCr;
        gvQuiz_gvDrCr.DataBind();
    }
     
    protected void btnTrueFalseAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["listTrueFalse"] == null)
            {
                List<Quiz_TrueFalse> listTrueFalse = new List<Quiz_TrueFalse>();

                Quiz_TrueFalse truefalse = new Quiz_TrueFalse();

                truefalse.QuestionTitle = txtTrueFalseQuestionTitle.Text;
                truefalse.IsTrue = radTrueFalse.SelectedValue == "True" ? true : false;
                truefalse.IsDrCr = false;

                // before that we have to generate the comprehention id
                truefalse.ComprehensionID = 1;

                listTrueFalse.Add(truefalse);

                Session["listTrueFalse"] = listTrueFalse;

                gvQuiz_TrueFalse.DataSource = Session["listTrueFalse"];
                gvQuiz_TrueFalse.DataBind();

                txtTrueFalseQuestionTitle.Text = string.Empty;

                radTrueFalse.SelectedIndex = -1;
            }
            else
            {
                Quiz_TrueFalse truefalse = new Quiz_TrueFalse();

                truefalse.QuestionTitle = txtTrueFalseQuestionTitle.Text;
                truefalse.IsTrue = radTrueFalse.SelectedValue == "True" ? true : false;
                truefalse.IsDrCr = false;

                // before that we have to generate the comprehention id
                truefalse.ComprehensionID = 1;

                
                ((List<Quiz_TrueFalse>)Session["listTrueFalse"]).Add(truefalse);

                gvQuiz_TrueFalse.DataSource = Session["listTrueFalse"];
                gvQuiz_TrueFalse.DataBind();

                txtTrueFalseQuestionTitle.Text = string.Empty;

                radTrueFalse.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
        }
    }
     
    protected void btnDrCrAddMore_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["listDrCr"] == null)
            {
                List<Quiz_TrueFalse> listDrCr = new List<Quiz_TrueFalse>();

                Quiz_TrueFalse drcr = new Quiz_TrueFalse();

                drcr.QuestionTitle = txtDrCrQuestion.Text;
                drcr.IsTrue = radDrCr.SelectedValue == "True" ? true : false;
                drcr.IsDrCr = true;

                // before that we have to generate the comprehention id
                drcr.ComprehensionID = 1;

                listDrCr.Add(drcr);

                Session["listDrCr"] = listDrCr;

                gvQuiz_gvDrCr.DataSource = Session["listDrCr"];
                gvQuiz_gvDrCr.DataBind();

                txtTrueFalseQuestionTitle.Text = string.Empty;
                radDrCr.SelectedIndex = -1;
            }

            else
            {
                Quiz_TrueFalse drcr = new Quiz_TrueFalse();

                drcr.QuestionTitle = txtDrCrQuestion.Text;
                drcr.IsTrue = radDrCr.SelectedValue == "True" ? true : false;
                drcr.IsDrCr = true;

                // before that we have to generate the comprehention id
                drcr.ComprehensionID = 1;

                ((List<Quiz_TrueFalse>)Session["listDrCr"]).Add(drcr);

               

                gvQuiz_gvDrCr.DataSource = Session["listDrCr"];
                gvQuiz_gvDrCr.DataBind();

                txtTrueFalseQuestionTitle.Text = string.Empty;
                radDrCr.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnMoreMultipleQuestionAns_Click(object sender, EventArgs e)
    {
        try
        {

            List<Quiz_MultipleQuestionDetails> multipleQuestionDetails = new List<Quiz_MultipleQuestionDetails>();

            Button btnMoreMultipleQuestionAns = (Button)sender;
            GridViewRow row = (GridViewRow)btnMoreMultipleQuestionAns.NamingContainer;

            GridView gvQuiz_MultipleQuestionDetails = (GridView)row.FindControl("gvQuiz_MultipleQuestionDetails");

            foreach (GridViewRow dtlRow in gvQuiz_MultipleQuestionDetails.Rows)
            {
                TextBox txtQuestionTitle = (TextBox)dtlRow.FindControl("txtQuestionTitle");
                Quiz_MultipleQuestionDetails multipleQuestionDetail = new Quiz_MultipleQuestionDetails();
                multipleQuestionDetail.MultipleQustionID = 0;
                multipleQuestionDetail.MultipleQuestionDetailsID = 0;
                multipleQuestionDetail.QuestionTitle = txtQuestionTitle.Text;

                multipleQuestionDetails.Add(multipleQuestionDetail);
            }

            //Session["multipleQuestionDetails"] = multipleQuestionDetails;

            multipleQuestionDetails.Add(new Quiz_MultipleQuestionDetails());
            gvQuiz_MultipleQuestionDetails.DataSource = multipleQuestionDetails;
            gvQuiz_MultipleQuestionDetails.DataBind();

        }
        catch (Exception ex)
        {
        }
    }

    protected void lbDeleteFillInTheBlanksQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_TrueFalse> listTrueFalse = new List<Quiz_TrueFalse>();

            listTrueFalse = (List<Quiz_TrueFalse>)Session["listTrueFalse"];

            ImageButton linkButton = new ImageButton();
            linkButton = (ImageButton)sender;


            int index = Convert.ToInt32(linkButton.CommandArgument);

            listTrueFalse.RemoveAt(index);

            gvQuiz_TrueFalse.DataSource = listTrueFalse;
            gvQuiz_TrueFalse.DataBind();

        }
        catch (Exception ex)
        {
        }
    }

    protected void btnMoreFillInTheBlanksDetails_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();

            Button btnMoreFillInTheBlanksDetails = (Button)sender;
            GridViewRow row = (GridViewRow)btnMoreFillInTheBlanksDetails.NamingContainer;

            GridView gvQuiz_FillInTheBlanksDetails = (GridView)row.FindControl("gvQuiz_FillInTheBlanksDetails");

            foreach (GridViewRow dtlRow in gvQuiz_FillInTheBlanksDetails.Rows)
            {
                TextBox txtAnswer = (TextBox)dtlRow.FindControl("txtAnswer");
                Quiz_FillInTheBlanksDetails fillInTheBlanksDetail = new Quiz_FillInTheBlanksDetails();
                fillInTheBlanksDetail.FillInTheBlanksID = 0;
                fillInTheBlanksDetail.FillInTheBlanksDetailsID = 0;
                fillInTheBlanksDetail.Answer = txtAnswer.Text;

                fillInTheBlanksDetails.Add(fillInTheBlanksDetail);
            }

            //Session["fillInTheBlanksDetails"] = fillInTheBlanksDetails;

            fillInTheBlanksDetails.Add(new Quiz_FillInTheBlanksDetails(0, 0, 0, "", "", DateTime.Now, "", DateTime.Now));
            gvQuiz_FillInTheBlanksDetails.DataSource = fillInTheBlanksDetails;
            gvQuiz_FillInTheBlanksDetails.DataBind();

        }
        catch (Exception ex)
        {
        }
    }

    protected void btnDeletefillInTheBlank_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_FillInTheBlanks> fillInTheBlanks = new List<Quiz_FillInTheBlanks>();

            fillInTheBlanks = (List<Quiz_FillInTheBlanks>)Session["fillInTheBlanks"];

            List<int> delFillInTheBlankIDs = new List<int>();

            ImageButton btnDeletefillInTheBlank = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnDeletefillInTheBlank.NamingContainer;
            HiddenField hfFillInTheBlankID = (HiddenField)row.FindControl("hfFillInTheBlankID");
            int index = Convert.ToInt32(btnDeletefillInTheBlank.CommandArgument);

            fillInTheBlanks.RemoveAt(index);
            int fillInTheBlankID = Convert.ToInt32(hfFillInTheBlankID.Value);
            if (fillInTheBlankID > 0)
            {
                if (Session["delFillInTheBlankIDs"] == null)
                {
                    delFillInTheBlankIDs.Add(fillInTheBlankID);
                    Session["delFillInTheBlankIDs"] = delFillInTheBlankIDs;
                }
                else
                    ((List<int>)Session["delFillInTheBlankIDs"]).Add(fillInTheBlankID);
            }

            Session["fillInTheBlanks"] = fillInTheBlanks;

            gvQuiz_FillInTheBlanks.DataSource = fillInTheBlanks;
            gvQuiz_FillInTheBlanks.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnDeleteFillInTheBlankDetails_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
            List<int> delFillInTheBlankDetailsIDs = new List<int>();

            ImageButton btnDelete = new ImageButton();
            btnDelete = (ImageButton)sender;

            GridView gvQuiz_FillInTheBlanksDetails =(GridView) ((GridViewRow)btnDelete.NamingContainer).NamingContainer;

            fillInTheBlanksDetails.Clear();
            foreach (GridViewRow dtlRow in gvQuiz_FillInTheBlanksDetails.Rows)
            {
                HiddenField hfFillInTheBlankDtlID =(HiddenField) dtlRow.FindControl("hfFillInTheBlankDtlID");
                TextBox txtAnswer = (TextBox)dtlRow.FindControl("txtAnswer");
                Quiz_FillInTheBlanksDetails fillInTheBlanksDetail = new Quiz_FillInTheBlanksDetails();
                fillInTheBlanksDetail.FillInTheBlanksID = 0;
                fillInTheBlanksDetail.FillInTheBlanksDetailsID = Convert.ToInt32(hfFillInTheBlankDtlID.Value);
                fillInTheBlanksDetail.Answer = txtAnswer.Text;

                fillInTheBlanksDetails.Add(fillInTheBlanksDetail);
            }

            int index = Convert.ToInt32(btnDelete.CommandArgument);
            fillInTheBlanksDetails.RemoveAt(index);

            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            int fillInTheBlankDtlID = Convert.ToInt32(((HiddenField)row.FindControl("hfFillInTheBlankDtlID")).Value);
            if (fillInTheBlankDtlID > 0)
            {
                if (Session["delFillInTheBlankDetailsIDs"] == null)
                {
                    delFillInTheBlankDetailsIDs.Add(fillInTheBlankDtlID);

                    Session["delFillInTheBlankDetailsIDs"] = delFillInTheBlankDetailsIDs;
                }
                else
                    ((List<int>)Session["delFillInTheBlankDetailsIDs"]).Add(fillInTheBlankDtlID);
            }

            Session["fillInTheBlanksDetails"] = fillInTheBlanksDetails;

            gvQuiz_FillInTheBlanksDetails.DataSource = Session["fillInTheBlanksDetails"];
            gvQuiz_FillInTheBlanksDetails.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnDeleteMultipleQuestion_Click(object sender, EventArgs e)
    {
        try
        {
             List<Quiz_MultipleQuestion> multipleQuestions = new List<Quiz_MultipleQuestion>();
             multipleQuestions = (List<Quiz_MultipleQuestion>)Session["multipleQuestions"];

             List<int> delMultipleQuestionIDs = new List<int>();

            ImageButton btnDeleteMultipleQuestion = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btnDeleteMultipleQuestion.NamingContainer;
            HiddenField hfMultipleQuestionID = (HiddenField)row.FindControl("hfMultipleQuestionID");
            int index = Convert.ToInt32(btnDeleteMultipleQuestion.CommandArgument);

            multipleQuestions.RemoveAt(index);
            int multipleQuestionID = Convert.ToInt32(hfMultipleQuestionID.Value);
            if (multipleQuestionID > 0)
            {
                if (Session["delMultipleQuestionIDs"] == null)
                {
                    delMultipleQuestionIDs.Add(multipleQuestionID);
                    Session["delMultipleQuestionIDs"] = delMultipleQuestionIDs;
                }
                else
                    ((List<int>)Session["delMultipleQuestionIDs"]).Add(multipleQuestionID);
            }
            Session["multipleQuestions"] = multipleQuestions;

            gvQuiz_MultipleQuestion.DataSource = Session["multipleQuestions"];
            gvQuiz_MultipleQuestion.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnDeleteMultipleQuestionDetails_Click(object sender, EventArgs e)
    {
        try
        {
            List<Quiz_MultipleQuestionDetails> multipleQuestionDetails = new List<Quiz_MultipleQuestionDetails>();
            List<int> delMultipleQuestionDetailsIDs = new List<int>();

            ImageButton btnDelete = new ImageButton();
            btnDelete = (ImageButton)sender;
            GridView gvQuiz_MultipleQuestionDetails = (GridView)((GridViewRow)btnDelete.NamingContainer).NamingContainer;
            
            foreach (GridViewRow dtlRow in gvQuiz_MultipleQuestionDetails.Rows)
            {
                TextBox txtQuestionTitle = (TextBox)dtlRow.FindControl("txtQuestionTitle");
                Label lblAnswer = (Label)dtlRow.FindControl("lblAnswer");
                HiddenField hfMultipleQuestionDetailsID = (HiddenField)dtlRow.FindControl("hfMultipleQuestionDetailsID");

                Quiz_MultipleQuestionDetails multipleQuestionDetail = new Quiz_MultipleQuestionDetails();
                multipleQuestionDetail.MultipleQuestionDetailsID = Convert.ToInt32(hfMultipleQuestionDetailsID.Value);
                multipleQuestionDetail.MultipleQustionID = 0;
                multipleQuestionDetail.QuestionTitle = txtQuestionTitle.Text;
                multipleQuestionDetail.IsAnswer = bool.Parse(lblAnswer.Text);

                multipleQuestionDetails.Add(multipleQuestionDetail);
            }

            int index = Convert.ToInt32(btnDelete.CommandArgument);
            multipleQuestionDetails.RemoveAt(index);

            Session["multipleQuestionDetails"] = multipleQuestionDetails;

            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            int multipleQuestionDetailsID = Convert.ToInt32(((HiddenField)row.FindControl("hfMultipleQuestionDetailsID")).Value);
            if (multipleQuestionDetailsID > 0)
            {
                if (Session["delMultipleQuestionDetailsIDs"] == null)
                {
                    delMultipleQuestionDetailsIDs.Add(multipleQuestionDetailsID);
                    Session["delMultipleQuestionDetailsIDs"] = delMultipleQuestionDetailsIDs;
                }
                else
                    ((List<int>)Session["delMultipleQuestionDetailsIDs"]).Add(multipleQuestionDetailsID);
            }

            gvQuiz_MultipleQuestionDetails.DataSource = Session["multipleQuestionDetails"];
            gvQuiz_MultipleQuestionDetails.DataBind();

            //upMultipleQuestion.Update();
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_MultipleQuestionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }

    protected void gvQuiz_TrueFalse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";


            //  BulletedList bl =             (BulletedList)e.Row.FindControl("bltTerritories");
        }
    }
   
    protected void gvQuiz_gvDrCr_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAnsewer = (Label)e.Row.FindControl("lblAnswer");

            RadioButtonList chkAnswer = (RadioButtonList)e.Row.FindControl("radIsAnswer");

            chkAnswer.SelectedValue = lblAnsewer.Text == "True" ? "True" : "False";
        }
    }

    protected void gvQuiz_FillInTheBlanksQuestionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvQuiz_MultipleQuestion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvQuiz_MultipleQuestionDetails = (GridView)e.Row.FindControl("gvQuiz_MultipleQuestionDetails");
            HiddenField hfMultipleQuestionID = (HiddenField)e.Row.FindControl("hfMultipleQuestionID");
            int multipleQuestionID = Convert.ToInt32(hfMultipleQuestionID.Value);
            List<Quiz_MultipleQuestionDetails> multipleQuestionDetails = new List<Quiz_MultipleQuestionDetails>();
            if (multipleQuestionID > 0)
            {
                //Session["multipleQuestionDetails"] = Quiz_MultipleQuestionDetailsManager.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(multipleQuestionID);
                gvQuiz_MultipleQuestionDetails.DataSource = Quiz_MultipleQuestionDetailsManager.GetAllQuiz_MultipleQuestionDetailsByMultipleQustionID(multipleQuestionID);
            }
            else
            {
                multipleQuestionDetails.Add(new Quiz_MultipleQuestionDetails(0, 0, "", true, "", DateTime.Now, "", DateTime.Now));
                //Session["multipleQuestionDetails"] = multipleQuestionDetails;
                gvQuiz_MultipleQuestionDetails.DataSource = multipleQuestionDetails;
            }
            gvQuiz_MultipleQuestionDetails.DataBind();
        }
    }

    protected void gvMultipleQUestionsAnswer_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btnMoreFillInTheBlanksQuestion_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["fillInTheBlanks"] == null)
            {
                List<Quiz_FillInTheBlanks> fillInTheBlanks = new List<Quiz_FillInTheBlanks>();

                Quiz_FillInTheBlanks quiz_FillInTheBlank = new Quiz_FillInTheBlanks();
                quiz_FillInTheBlank.FillInTheBlanksID = 0;
                fillInTheBlanks.Add(quiz_FillInTheBlank);

                Session["fillInTheBlanks"] = fillInTheBlanks;
                gvQuiz_FillInTheBlanks.DataSource = Session["fillInTheBlanks"];

                gvQuiz_FillInTheBlanks.DataBind();
            }
            else
            {
               
                Quiz_FillInTheBlanks quiz_FillInTheBlank = new Quiz_FillInTheBlanks();
                quiz_FillInTheBlank.FillInTheBlanksID = 0;
                ((List<Quiz_FillInTheBlanks>)Session["fillInTheBlanks"]).Add(quiz_FillInTheBlank);

               
                gvQuiz_FillInTheBlanks.DataSource = Session["fillInTheBlanks"];

                gvQuiz_FillInTheBlanks.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvQuiz_FillInTheBlanks_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<Quiz_FillInTheBlanksDetails> fillInTheBlanksDetails = new List<Quiz_FillInTheBlanksDetails>();
            GridView gvQuiz_FillInTheBlanksDetails = (GridView)e.Row.FindControl("gvQuiz_FillInTheBlanksDetails");
            HiddenField hfFillInTheBlankID = (HiddenField)e.Row.FindControl("hfFillInTheBlankID");
            int fillInTheBlankID = Convert.ToInt32(hfFillInTheBlankID.Value);

            if (fillInTheBlankID > 0)
            {
                //Session["fillInTheBlanksDetails"] = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(fillInTheBlankID);
                gvQuiz_FillInTheBlanksDetails.DataSource = Quiz_FillInTheBlanksDetailsManager.GetQuiz_FillInTheBlanksByFillInTheBlanksID(fillInTheBlankID);
            }
            else
            {
                fillInTheBlanksDetails.Add(new Quiz_FillInTheBlanksDetails(0, 0, 0, "", "", DateTime.Now, "", DateTime.Now));
                //Session["fillInTheBlanksDetails"] = fillInTheBlanksDetails;
                gvQuiz_FillInTheBlanksDetails.DataSource = fillInTheBlanksDetails;
            }
            gvQuiz_FillInTheBlanksDetails.DataBind();
        }

    }

    protected void btnMoreMultipleQuestions_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["multipleQuestions"] == null)
            {
                List<Quiz_MultipleQuestion> multipleQuestions = new List<Quiz_MultipleQuestion>();
                Quiz_MultipleQuestion multiplequestion = new Quiz_MultipleQuestion();
                multiplequestion.MultipleQustionID = 0;
                multipleQuestions.Add(multiplequestion);
                Session["multipleQuestions"] = multipleQuestions;
                gvQuiz_MultipleQuestion.DataSource = Session["multipleQuestions"];
                gvQuiz_MultipleQuestion.DataBind();
            }
            else
            {
                Quiz_MultipleQuestion multiplequestion = new Quiz_MultipleQuestion();
                multiplequestion.MultipleQustionID = 0;
               
                ((List<Quiz_MultipleQuestion>)Session["multipleQuestions"]).Add(multiplequestion);
                
                gvQuiz_MultipleQuestion.DataSource = Session["multipleQuestions"];
                gvQuiz_MultipleQuestion.DataBind();
            }

            //Session["ListMultipleQuestionDetails"] = multipleQuestionDetails;
            //multipleQuestionDetails = null;
            //gvQuiz_MultipleQuestionDetails.DataSource = null;
            //gvQuiz_MultipleQuestionDetails.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
     
    protected void btnSaveComprehention_Click(object sender, EventArgs e)
    {
        try
        {
            string userID = Profile.card_id ;

            int comprehensionID = 0;
            Quiz_Comprehension quiz_Comprehension = new Quiz_Comprehension();
            #region "Save Comprehention Basic Data"
            if (Request.QueryString["ID"] != null)
            {
                comprehensionID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                quiz_Comprehension = Quiz_ComprehensionManager.GetQuiz_ComprehensionByComprehensionID(comprehensionID);
                quiz_Comprehension.CourseID = int.Parse(ddlCourseID.SelectedValue);
                quiz_Comprehension.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                quiz_Comprehension.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                quiz_Comprehension.Comprehension = fckDesc.Value;
                quiz_Comprehension.ModifiedBy = userID;
                quiz_Comprehension.ModifiedDate = DateTime.Now;

                Quiz_ComprehensionManager.UpdateQuiz_Comprehension(quiz_Comprehension);
            }
            else
            {
                quiz_Comprehension.ComprehensionID = 0;
                quiz_Comprehension.CourseID = int.Parse(ddlCourseID.SelectedValue);
                quiz_Comprehension.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                quiz_Comprehension.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                quiz_Comprehension.Comprehension = fckDesc.Value;
                quiz_Comprehension.AddedBy = userID;
                quiz_Comprehension.AddedDate = DateTime.Now;
                quiz_Comprehension.ModifiedBy = userID;
                quiz_Comprehension.ModifiedDate = DateTime.Now;

                comprehensionID = Quiz_ComprehensionManager.InsertQuiz_Comprehension(quiz_Comprehension);
            }
            #endregion

            #region "Save true and falsess"

            for (int tI = 0; tI < gvQuiz_TrueFalse.Rows.Count; tI++)
            {
                Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
                HiddenField hfTureFalseID = (HiddenField)gvQuiz_TrueFalse.Rows[tI].FindControl("hfTureFalseID");
                int trueFalseID = Convert.ToInt32(hfTureFalseID.Value);
                TextBox txtQuestionTitle = (TextBox)gvQuiz_TrueFalse.Rows[tI].FindControl("txtQuestionTitle");
                RadioButtonList radIsAnswer = (RadioButtonList)gvQuiz_TrueFalse.Rows[tI].FindControl("radIsAnswer");

                if (txtQuestionTitle.Text != "")
                {
                    quiz_TrueFalse.TrueFalseID = trueFalseID;
                    quiz_TrueFalse.ComprehensionID = comprehensionID;
                    quiz_TrueFalse.CourseID = int.Parse(ddlCourseID.SelectedValue);
                    quiz_TrueFalse.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                    quiz_TrueFalse.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                    quiz_TrueFalse.QuestionTitle = txtQuestionTitle.Text;
                    quiz_TrueFalse.IsDrCr = false;
                    quiz_TrueFalse.IsTrue = radIsAnswer.SelectedValue == "True" ? true : false;
                    quiz_TrueFalse.AddedBy = userID;
                    quiz_TrueFalse.AddedDate = DateTime.Now;
                    quiz_TrueFalse.ModifiedBy = userID;
                    quiz_TrueFalse.ModifiedDate = DateTime.Now;

                    if (trueFalseID > 0)
                        Quiz_TrueFalseManager.UpdateQuiz_TrueFalse(quiz_TrueFalse);
                    else
                        trueFalseID = Quiz_TrueFalseManager.InsertQuiz_TrueFalse(quiz_TrueFalse);
                }
            }

            gvQuiz_TrueFalse.DataSource = string.Empty.ToList();
            gvQuiz_TrueFalse.DataBind();

            #endregion

            #region "Save dr cr "
            for (int dI = 0; dI < gvQuiz_gvDrCr.Rows.Count; dI++)
            {
                Quiz_TrueFalse quiz_TrueFalse = new Quiz_TrueFalse();
                HiddenField hfDrCrID = (HiddenField)gvQuiz_gvDrCr.Rows[dI].FindControl("hfDrCrID");
                int trueFalseID = Convert.ToInt32(hfDrCrID.Value);
                TextBox txtQuestionTitle = (TextBox)gvQuiz_gvDrCr.Rows[dI].FindControl("txtQuestionTitle");
                RadioButtonList radIsAnswer = (RadioButtonList)gvQuiz_gvDrCr.Rows[dI].FindControl("radIsAnswer");

                if (txtQuestionTitle.Text != "")
                {
                    quiz_TrueFalse.TrueFalseID = trueFalseID;
                    quiz_TrueFalse.ComprehensionID = comprehensionID;
                    quiz_TrueFalse.CourseID = int.Parse(ddlCourseID.SelectedValue);
                    quiz_TrueFalse.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                    quiz_TrueFalse.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                    quiz_TrueFalse.QuestionTitle = txtQuestionTitle.Text;
                    quiz_TrueFalse.IsDrCr = true;
                    quiz_TrueFalse.IsTrue = radIsAnswer.SelectedValue == "True" ? true : false;
                    quiz_TrueFalse.AddedBy = userID;
                    quiz_TrueFalse.AddedDate = DateTime.Now;
                    quiz_TrueFalse.ModifiedBy = userID;
                    quiz_TrueFalse.ModifiedDate = DateTime.Now;

                    if (trueFalseID > 0)
                        Quiz_TrueFalseManager.UpdateQuiz_TrueFalse(quiz_TrueFalse);
                    else
                        trueFalseID = Quiz_TrueFalseManager.InsertQuiz_TrueFalse(quiz_TrueFalse);
                }

            }

            gvQuiz_gvDrCr.DataSource = string.Empty.ToList();
            gvQuiz_gvDrCr.DataBind();

            #endregion

            #region Delete True/False and Dr/Cr Questions

            List<int> delTrueFalseIDs = new List<int>();
            if (Session["delTrueFalseIDs"] != null)
            {
                delTrueFalseIDs = (List<int>)Session["delTrueFalseIDs"];

                foreach (int id in delTrueFalseIDs)
                {
                    Quiz_TrueFalseManager.DeleteQuiz_TrueFalse(id);
                }

            }

           
            #endregion

            #region "Save fill in the blanks"
            for (int i = 0; i < gvQuiz_FillInTheBlanks.Rows.Count; i++)
            {
                Quiz_FillInTheBlanks fillInTheBlanks = new Quiz_FillInTheBlanks();
                HiddenField hfFillInTheBlankID = (HiddenField)gvQuiz_FillInTheBlanks.Rows[i].FindControl("hfFillInTheBlankID");
                int fillInTheBlankID = Convert.ToInt32(hfFillInTheBlankID.Value);
                TextBox txtFilInTheBlanksQuestion = (TextBox)gvQuiz_FillInTheBlanks.Rows[i].FindControl("txtFilInTheBlanksQuestion");

                if (txtFilInTheBlanksQuestion.Text != "")
                {
                    fillInTheBlanks.FillInTheBlanksID = fillInTheBlankID;
                    fillInTheBlanks.Question = txtFilInTheBlanksQuestion.Text;
                    fillInTheBlanks.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                    fillInTheBlanks.CourseID = int.Parse(ddlCourseID.SelectedValue);
                    fillInTheBlanks.ComprehensionID = comprehensionID;
                    fillInTheBlanks.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                    fillInTheBlanks.AddedBy = userID;
                    fillInTheBlanks.AddedDate = DateTime.Now;
                    fillInTheBlanks.ModifiedBy = userID;
                    fillInTheBlanks.ModifiedDate = DateTime.Now;

                    if (fillInTheBlankID > 0)
                        Quiz_FillInTheBlanksManager.UpdateQuiz_FillInTheBlanks(fillInTheBlanks);
                    else
                        fillInTheBlankID = Quiz_FillInTheBlanksManager.InsertQuiz_FillInTheBlanks(fillInTheBlanks);
                    #region Fill In The Blanks Details
                    if (fillInTheBlankID > 0)
                    {
                        GridView gvQuiz_FillInTheBlanksDetails = (GridView)gvQuiz_FillInTheBlanks.Rows[i].FindControl("gvQuiz_FillInTheBlanksDetails");

                        for (int j = 0; j < gvQuiz_FillInTheBlanksDetails.Rows.Count; j++)
                        {
                            HiddenField hfFillInTheBlankDtlID = (HiddenField)gvQuiz_FillInTheBlanksDetails.Rows[j].FindControl("hfFillInTheBlankDtlID");
                            int fillInTheBlanksDetailsID = Convert.ToInt32(hfFillInTheBlankDtlID.Value);
                            Label lblSerial = (Label)gvQuiz_FillInTheBlanksDetails.Rows[j].FindControl("lblSerial");
                            TextBox txtAnswer = ((TextBox)gvQuiz_FillInTheBlanksDetails.Rows[j].FindControl("txtAnswer"));

                            if (txtAnswer.Text != "")
                            {
                                Quiz_FillInTheBlanksDetails fillInTheBlanksDtl = new Quiz_FillInTheBlanksDetails();

                                fillInTheBlanksDtl.FillInTheBlanksDetailsID = fillInTheBlanksDetailsID;
                                fillInTheBlanksDtl.FillInTheBlanksID = fillInTheBlankID;
                                fillInTheBlanksDtl.QuestionSl = int.Parse(lblSerial.Text);
                                fillInTheBlanksDtl.Answer = txtAnswer.Text;
                                fillInTheBlanksDtl.AddedBy = userID;
                                fillInTheBlanksDtl.AddedDate = DateTime.Now;
                                fillInTheBlanksDtl.ModifiedBy = userID;
                                fillInTheBlanksDtl.ModifiedDate = DateTime.Now;

                                if (fillInTheBlanksDetailsID > 0)
                                    Quiz_FillInTheBlanksDetailsManager.UpdateQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
                                else
                                    fillInTheBlanksDetailsID = Quiz_FillInTheBlanksDetailsManager.InsertQuiz_FillInTheBlanksDetails(fillInTheBlanksDtl);
                            }
                        }

                        gvQuiz_FillInTheBlanksDetails.DataSource = string.Empty.ToList();
                        gvQuiz_FillInTheBlanksDetails.DataBind();
                    }
                }

            }

            gvQuiz_FillInTheBlanks.DataSource = string.Empty.ToList();
            gvQuiz_FillInTheBlanks.DataBind();
                    #endregion
            List<int> delFillInTheBlankIDs = new List<int>();
            if (Session["delFillInTheBlankIDs"] != null)
            {
                delFillInTheBlankIDs = (List<int>)Session["delFillInTheBlankIDs"];

                foreach (int id in delFillInTheBlankIDs)
                {
                    Quiz_FillInTheBlanksManager.DeleteQuiz_FillInTheBlanks(id);
                }

            }


            List<int> delFillInTheBlankDetailsIDs = new List<int>();
            if (Session["delFillInTheBlankDetailsIDs"] != null)
            {
                delFillInTheBlankDetailsIDs = (List<int>)Session["delFillInTheBlankDetailsIDs"];

                foreach (int id in delFillInTheBlankDetailsIDs)
                {
                    Quiz_FillInTheBlanksDetailsManager.DeleteQuiz_FillInTheBlanksDetails(id);
                }

            }

            
            #endregion

            #region "Save multiple questions"
            for (int mI = 0; mI < gvQuiz_MultipleQuestion.Rows.Count; mI++)
            {

                TextBox txtMultipleQuestionName = (TextBox)gvQuiz_MultipleQuestion.Rows[mI].FindControl("txtMultipleQuestionName");
                HiddenField hfMultipleQuestionID = (HiddenField)gvQuiz_MultipleQuestion.Rows[mI].FindControl("hfMultipleQuestionID");
                int multipleQuestionID = Convert.ToInt32(hfMultipleQuestionID.Value);

                if (txtMultipleQuestionName.Text != "")
                {
                    Quiz_MultipleQuestion quiz_MultipleQuestion = new Quiz_MultipleQuestion();
                    quiz_MultipleQuestion.MultipleQustionID = multipleQuestionID;
                    quiz_MultipleQuestion.ComprehensionID = comprehensionID;
                    quiz_MultipleQuestion.CourseID = int.Parse(ddlCourseID.SelectedValue);
                    quiz_MultipleQuestion.SubjectID = int.Parse(ddlSubjectID.SelectedValue);
                    quiz_MultipleQuestion.ChapterID = int.Parse(ddlChapterID.SelectedValue);
                    quiz_MultipleQuestion.MultipleQuestionName = txtMultipleQuestionName.Text;
                    quiz_MultipleQuestion.AddedBy = userID;
                    quiz_MultipleQuestion.AddedDate = DateTime.Now;
                    quiz_MultipleQuestion.ModifiedBy = userID;
                    quiz_MultipleQuestion.ModifiedDate = DateTime.Now;

                    if (multipleQuestionID > 0)
                        Quiz_MultipleQuestionManager.UpdateQuiz_MultipleQuestion(quiz_MultipleQuestion);
                    else
                        multipleQuestionID = Quiz_MultipleQuestionManager.InsertQuiz_MultipleQuestion(quiz_MultipleQuestion);

                    GridView gvQuiz_MultipleQuestionDetails = (GridView)gvQuiz_MultipleQuestion.Rows[mI].FindControl("gvQuiz_MultipleQuestionDetails");

                    for (int mDi = 0; mDi < gvQuiz_MultipleQuestionDetails.Rows.Count; mDi++)
                    {
                        Label lblSerial = ((Label)gvQuiz_MultipleQuestionDetails.Rows[mDi].FindControl("lblSerial"));
                        HiddenField hfMultipleQuestionDetailsID = (HiddenField)gvQuiz_MultipleQuestionDetails.Rows[mDi].FindControl("hfMultipleQuestionDetailsID");
                        int multipleQuestionDetailsID = Convert.ToInt32(hfMultipleQuestionDetailsID.Value);
                        TextBox txtQuestionTitle = (TextBox)gvQuiz_MultipleQuestionDetails.Rows[mDi].FindControl("txtQuestionTitle");
                        Label lblAnswer = (Label)gvQuiz_MultipleQuestionDetails.Rows[mDi].FindControl("lblAnswer");
                        RadioButtonList chkAnswer = (RadioButtonList)gvQuiz_MultipleQuestionDetails.Rows[mDi].FindControl("radIsAnswer");

                        if (txtQuestionTitle.Text != "")
                        {
                            Quiz_MultipleQuestionDetails quiz_MultipleQuestionDetails = new Quiz_MultipleQuestionDetails();
                            quiz_MultipleQuestionDetails.MultipleQuestionDetailsID = multipleQuestionDetailsID;
                            quiz_MultipleQuestionDetails.MultipleQustionID = multipleQuestionID;
                            quiz_MultipleQuestionDetails.QuestionTitle = txtQuestionTitle.Text;
                            quiz_MultipleQuestionDetails.IsAnswer = chkAnswer.SelectedValue == "True" ? true : false;
                            quiz_MultipleQuestionDetails.AddedBy = userID;
                            quiz_MultipleQuestionDetails.AddedDate = DateTime.Now;
                            quiz_MultipleQuestionDetails.ModifiedBy = userID;
                            quiz_MultipleQuestionDetails.ModifiedDate = DateTime.Now;

                            if (multipleQuestionDetailsID > 0)
                                Quiz_MultipleQuestionDetailsManager.UpdateQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);
                            else
                                multipleQuestionDetailsID = Quiz_MultipleQuestionDetailsManager.InsertQuiz_MultipleQuestionDetails(quiz_MultipleQuestionDetails);
                        }
                    }

                    gvQuiz_MultipleQuestionDetails.DataSource = string.Empty.ToList();
                    gvQuiz_MultipleQuestionDetails.DataBind();
                }
            }

            gvQuiz_MultipleQuestion.DataSource = string.Empty.ToList();
            gvQuiz_MultipleQuestion.DataBind();

            List<int> delMultipleQuestionIDs = new List<int>();
            if (Session["delMultipleQuestionIDs"] != null)
            {
                delMultipleQuestionIDs = (List<int>)Session["delMultipleQuestionIDs"];

                foreach (int id in delMultipleQuestionIDs)
                {
                    Quiz_MultipleQuestionManager.DeleteQuiz_MultipleQuestion(id);
                }

            }

            List<int> delMultipleQuestionDetailsIDs = new List<int>();
            if (Session["delMultipleQuestionDetailsIDs"] != null)
            {
                delMultipleQuestionDetailsIDs = (List<int>)Session["delMultipleQuestionDetailsIDs"];

                foreach (int id in delMultipleQuestionDetailsIDs)
                {
                    Quiz_MultipleQuestionDetailsManager.DeleteQuiz_MultipleQuestionDetails(id);
                }

            }

           
            #endregion

            Response.Redirect("~/quiz/AdminDisplayQuiz_Comprehension.aspx", false);
        }
        catch (Exception ex)
        {
        }
    }
   
}


