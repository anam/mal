using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_TrueFalse
{
    public Quiz_TrueFalse()
    {
    }


    public Quiz_TrueFalse
        (
            int  trueFalseID,
            int  comprehensionID,
            int  courseID,
            int  subjectID,
            int  chapterID,
            string  questionTitle,
            bool  isDrCr,
            bool  isTrue,
            string  addedBy,
            DateTime  addedDate,
            string  modifiedBy,
            DateTime  modifiedDate

        )

        {
            this.TrueFalseID = trueFalseID;
            this.ComprehensionID = comprehensionID;
            this.CourseID = courseID;
            this.SubjectID = subjectID;
            this.ChapterID = chapterID;
            this.QuestionTitle = questionTitle;
            this.IsDrCr = isDrCr;
            this.IsTrue = isTrue;
            this.AddedBy = addedBy;
            this.AddedDate = addedDate;
            this.ModifiedBy = modifiedBy;
            this.ModifiedDate = modifiedDate;

        }

    public int  TrueFalseID
    {
        get ; 
        set  ;
    }

    public int  ComprehensionID
    {
        get ; 
        set  ;
    }

    public int  CourseID
    {
        get ; 
        set  ;
    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

    public int  ChapterID
    {
        get ; 
        set  ;
    }

    public string  QuestionTitle
    {
        get ; 
        set  ;
    }

    public bool  IsDrCr
    {
        get ; 
        set  ;
    }

    public bool  IsTrue
    {
        get ; 
        set  ;
    }

    public bool IsFalse
    {
        get;
        set;
    }


    public string  AddedBy
    {
        get ; 
        set  ;
    }

    public DateTime  AddedDate
    {
        get ; 
        set  ;
    }

    public string  ModifiedBy
    {
        get ; 
        set  ;
    }

    public DateTime ModifiedDate
    {
        get;
        set;
    }

    #region Custom Property
    public int Serial { get; set; }
    public string stAnswer { get; set; }
    #endregion

}

