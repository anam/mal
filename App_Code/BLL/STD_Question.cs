using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Question
{
    public STD_Question()
    {
    }


    public STD_Question
        (
int  questionID,
int  questionTypeID,
string  description,
int  mark,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.QuestionID = questionID;
this.QuestionTypeID = questionTypeID;
this.Description = description;
this.Mark = mark;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  QuestionID
    {
        get ; 
        set  ;
    }

    public int  QuestionTypeID
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public int  Mark
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

