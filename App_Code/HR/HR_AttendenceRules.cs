using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_AttendenceRules
{
    public HR_AttendenceRules()
    {
    }


    public HR_AttendenceRules
        (
int  attendenceRulesID,
string  employeeID,
string  rules,
int  time,
string  unit,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.AttendenceRulesID = attendenceRulesID;
this.EmployeeID = employeeID;
this.Rules = rules;
this.Time = time;
this.Unit = unit;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  AttendenceRulesID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  Rules
    {
        get ; 
        set  ;
    }

    public int  Time
    {
        get ; 
        set  ;
    }

    public string  Unit
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

