using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ComprehensionQuestion
{
    public STD_ComprehensionQuestion()
    {
    }


    public STD_ComprehensionQuestion
        (
int  comprehensionQuestionID,
int  questionID,
int  comprehensionID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ComprehensionQuestionID = comprehensionQuestionID;
this.QuestionID = questionID;
this.ComprehensionID = comprehensionID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ComprehensionQuestionID
    {
        get ; 
        set  ;
    }

    public int  QuestionID
    {
        get ; 
        set  ;
    }

    public int  ComprehensionID
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

