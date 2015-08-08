using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_RetirementsRuleEmployee
{
    public HR_RetirementsRuleEmployee()
    {
    }


    public HR_RetirementsRuleEmployee
        (
int  retirementRulesID,
string  employeeID,
string  retirementRulesName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.RetirementRulesID = retirementRulesID;
this.EmployeeID = employeeID;
this.RetirementRulesName = retirementRulesName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  RetirementRulesID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  RetirementRulesName
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

