using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_MultipleQuestion
{
    public Quiz_MultipleQuestion()
    {
    }


    public Quiz_MultipleQuestion
        (
int  multipleQustionID,
int  comprehensionID,
int  courseID,
int  subjectID,
int  chapterID,
string  multipleQuestionName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.MultipleQustionID = multipleQustionID;
this.ComprehensionID = comprehensionID;
this.CourseID = courseID;
this.SubjectID = subjectID;
this.ChapterID = chapterID;
this.MultipleQuestionName = multipleQuestionName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  MultipleQustionID
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

    public string  MultipleQuestionName
    {
        get ; 
        set  ;
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

    public DateTime  ModifiedDate
    {
        get ; 
        set  ;
    }

    #region Custom Property
    public int Serial { get; set; }
    public string stAnswer { get; set; }
    public string AnswerString { get; set; }
    #endregion
}

