using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_LunchTimeRule
{
    public HR_LunchTimeRule()
    {
    }


    public HR_LunchTimeRule
        (
int  lunchTimeRuleID,
string  lunchTimeRuleName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.LunchTimeRuleID = lunchTimeRuleID;
this.LunchTimeRuleName = lunchTimeRuleName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  LunchTimeRuleID
    {
        get ; 
        set  ;
    }

    public string  LunchTimeRuleName
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

