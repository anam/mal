using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_ExamQuestionDetails
{
    public Quiz_ExamQuestionDetails()
    {
    }


    public Quiz_ExamQuestionDetails
        (
int  examQuestionDetailsID,
int  examID,
int  questionType,
int  questionNo,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ExamQuestionDetailsID = examQuestionDetailsID;
this.ExamID = examID;
this.QuestionType = questionType;
this.QuestionNo = questionNo;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ExamQuestionDetailsID
    {
        get ; 
        set  ;
    }

    public int  ExamID
    {
        get ; 
        set  ;
    }

    public int  QuestionType
    {
        get ; 
        set  ;
    }

    public int  QuestionNo
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

}

