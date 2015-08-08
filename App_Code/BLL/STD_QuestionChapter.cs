using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_QuestionChapter
{
    public STD_QuestionChapter()
    {
    }


    public STD_QuestionChapter
        (
int  question_ChapterID,
int  questionID,
int  chapterID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.Question_ChapterID = question_ChapterID;
this.QuestionID = questionID;
this.ChapterID = chapterID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  Question_ChapterID
    {
        get ; 
        set  ;
    }

    public int  QuestionID
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

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdateDate
    {
        get ; 
        set  ;
    }

}

