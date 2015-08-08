using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_QuestionAnswer
{
    public STD_QuestionAnswer()
    {
    }


    public STD_QuestionAnswer
        (
int  questionAnswerID,
int  questionID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
bool  isCorrectQuestionAnswer,
string  description

        )

    {
this.QuestionAnswerID = questionAnswerID;
this.QuestionID = questionID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.IsCorrectQuestionAnswer = isCorrectQuestionAnswer;
this.Description = description;

    }

    public int  QuestionAnswerID
    {
        get ; 
        set  ;
    }

    public int  QuestionID
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

    public bool  IsCorrectQuestionAnswer
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

}

