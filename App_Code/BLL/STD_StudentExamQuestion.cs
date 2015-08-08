using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class StudentExamQuestion
{
    public StudentExamQuestion()
    {
    }

    public StudentExamQuestion
        (
        int studentExamQuestionID, 
        int questionID, 
        int questionTypeID, 
        string studentID, 
        int examID, 
        string addedBy, 
        DateTime addedDate, 
        string modifiedBy, 
        DateTime modifiedDate
        )
    {
        this.StudentExamQuestionID = studentExamQuestionID;
        this.QuestionID = questionID;
        this.QuestionTypeID = questionTypeID;
        this.StudentID = studentID;
        this.ExamID = examID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }


    private int _studentExamQuestionID;
    public int StudentExamQuestionID
    {
        get { return _studentExamQuestionID; }
        set { _studentExamQuestionID = value; }
    }

    private int _questionID;
    public int QuestionID
    {
        get { return _questionID; }
        set { _questionID = value; }
    }

    private int _questionTypeID;
    public int QuestionTypeID
    {
        get { return _questionTypeID; }
        set { _questionTypeID = value; }
    }

    private string _studentID;
    public string StudentID
    {
        get { return _studentID; }
        set { _studentID = value; }
    }

    private int _examID;
    public int ExamID
    {
        get { return _examID; }
        set { _examID = value; }
    }

    private string _addedBy;
    public string AddedBy
    {
        get { return _addedBy; }
        set { _addedBy = value; }
    }

    private DateTime _addedDate;
    public DateTime AddedDate
    {
        get { return _addedDate; }
        set { _addedDate = value; }
    }

    private string _modifiedBy;
    public string ModifiedBy
    {
        get { return _modifiedBy; }
        set { _modifiedBy = value; }
    }

    private DateTime _modifiedDate;
    public DateTime ModifiedDate
    {
        get { return _modifiedDate; }
        set { _modifiedDate = value; }
    }
}
