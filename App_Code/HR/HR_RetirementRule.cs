using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_RetirementRule
{
    public HR_RetirementRule()
    {
    }


    public HR_RetirementRule
        (
int  retirementRuleID,
string  retirementRuleName,
int  yearOfApplicable,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.RetirementRuleID = retirementRuleID;
this.RetirementRuleName = retirementRuleName;
this.YearOfApplicable = yearOfApplicable;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  RetirementRuleID
    {
        get ; 
        set  ;
    }

    public string  RetirementRuleName
    {
        get ; 
        set  ;
    }

    public int  YearOfApplicable
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

