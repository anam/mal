using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryIncrementPackageRules
{
    public HR_SalaryIncrementPackageRules()
    {
    }


    public HR_SalaryIncrementPackageRules
        (
int  salaryIncrementPackageRulesID,
string  employeeID,
int  salaryIncrementPackageID,
int  year,
int  month,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SalaryIncrementPackageRulesID = salaryIncrementPackageRulesID;
this.EmployeeID = employeeID;
this.SalaryIncrementPackageID = salaryIncrementPackageID;
this.Year = year;
this.Month = month;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SalaryIncrementPackageRulesID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  SalaryIncrementPackageID
    {
        get ; 
        set  ;
    }

    public int  Year
    {
        get ; 
        set  ;
    }

    public int  Month
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

