using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_LeaveRule
{
    public HR_LeaveRule()
    {
    }


    public HR_LeaveRule
        (
int  leaveRuleID,
string  leaveRuleName,
int  day,
string  status,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.LeaveRuleID = leaveRuleID;
this.LeaveRuleName = leaveRuleName;
this.Day = day;
this.Status = status;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  LeaveRuleID
    {
        get ; 
        set  ;
    }

    public string  LeaveRuleName
    {
        get ; 
        set  ;
    }

    public int  Day
    {
        get ; 
        set  ;
    }

    public string  Status
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

