using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryIncrement
{
    public HR_SalaryIncrement()
    {
    }


    public HR_SalaryIncrement
        (
int  salaryIncrementID,
string  salaryIncrementName,
int  perYearNoTimes,
decimal  ratio,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate,
string  employeeID

        )

    {
this.SalaryIncrementID = salaryIncrementID;
this.SalaryIncrementName = salaryIncrementName;
this.PerYearNoTimes = perYearNoTimes;
this.Ratio = ratio;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;
this.EmployeeID = employeeID;

    }

    public int  SalaryIncrementID
    {
        get ; 
        set  ;
    }

    public string  SalaryIncrementName
    {
        get ; 
        set  ;
    }

    public int  PerYearNoTimes
    {
        get ; 
        set  ;
    }

    public decimal  Ratio
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

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

}

