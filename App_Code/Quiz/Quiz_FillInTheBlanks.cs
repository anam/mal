using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_FillInTheBlanks
{
    public Quiz_FillInTheBlanks()
    {
    }


    public Quiz_FillInTheBlanks
        (
int  fillInTheBlanksID,
int  comprehensionID,
string  question,
int  courseID,
int  subjectID,
int  chapterID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.FillInTheBlanksID = fillInTheBlanksID;
this.ComprehensionID = comprehensionID;
this.Question = question;
this.CourseID = courseID;
this.SubjectID = subjectID;
this.ChapterID = chapterID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  FillInTheBlanksID
    {
        get ; 
        set  ;
    }

    public int  ComprehensionID
    {
        get ; 
        set  ;
    }

    public string  Question
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

