using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class Quiz_FillInTheBlanksDetails
{
    public Quiz_FillInTheBlanksDetails()
    {
    }


    public Quiz_FillInTheBlanksDetails
        (
int  fillInTheBlanksDetailsID,
int  fillInTheBlanksID,
int  questionSl,
string  answer,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.FillInTheBlanksDetailsID = fillInTheBlanksDetailsID;
this.FillInTheBlanksID = fillInTheBlanksID;
this.QuestionSl = questionSl;
this.Answer = answer;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  FillInTheBlanksDetailsID
    {
        get ; 
        set  ;
    }

    public int  FillInTheBlanksID
    {
        get ; 
        set  ;
    }

    public int  QuestionSl
    {
        get ; 
        set  ;
    }

    public string  Answer
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

