using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_MultipleQuestionDetails
{
    public Quiz_MultipleQuestionDetails()
    {
    }


    public Quiz_MultipleQuestionDetails
        (
int  multipleQuestionDetailsID,
int  multipleQustionID,
string  questionTitle,
bool  isAnswer,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.MultipleQuestionDetailsID = multipleQuestionDetailsID;
this.MultipleQustionID = multipleQustionID;
this.QuestionTitle = questionTitle;
this.IsAnswer = isAnswer;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  MultipleQuestionDetailsID
    {
        get ; 
        set  ;
    }

    public int  MultipleQustionID
    {
        get ; 
        set  ;
    }

    public string  QuestionTitle
    {
        get ; 
        set  ;
    }

    public bool  IsAnswer
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

