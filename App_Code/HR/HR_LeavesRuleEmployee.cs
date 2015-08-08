using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_LeavesRuleEmployee
{
    public HR_LeavesRuleEmployee()
    {
    }


    public HR_LeavesRuleEmployee
        (
int  leavesRuleEmployeeID,
string  employeeID,
int  leaveRuleID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.LeavesRuleEmployeeID = leavesRuleEmployeeID;
this.EmployeeID = employeeID;
this.LeaveRuleID = leaveRuleID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  LeavesRuleEmployeeID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  LeaveRuleID
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

