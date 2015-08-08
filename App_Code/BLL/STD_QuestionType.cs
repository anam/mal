using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_QuestionType
{
    public STD_QuestionType()
    {
    }


    public STD_QuestionType
        (
int  questionTypeID,
string  questionTypeName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.QuestionTypeID = questionTypeID;
this.QuestionTypeName = questionTypeName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  QuestionTypeID
    {
        get ; 
        set  ;
    }

    public string  QuestionTypeName
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

