using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryAdjustment
{
    public HR_SalaryAdjustment()
    {
    }


    public HR_SalaryAdjustment
        (
int  salaryAdjustmentID,
string  employeeID,
DateTime  adjustmentDate,
string  additionalBenifitName,
decimal  amount

        )

    {
this.SalaryAdjustmentID = salaryAdjustmentID;
this.EmployeeID = employeeID;
this.AdjustmentDate = adjustmentDate;
this.AdditionalBenifitName = additionalBenifitName;
this.Amount = amount;

    }

    public int  SalaryAdjustmentID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public DateTime  AdjustmentDate
    {
        get ; 
        set  ;
    }

    public string  AdditionalBenifitName
    {
        get ; 
        set  ;
    }

    public decimal  Amount
    {
        get ; 
        set  ;
    }

}

