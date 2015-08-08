using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ProvidentfundAmount
{
    public HR_ProvidentfundAmount()
    {
    }


    public HR_ProvidentfundAmount
        (
int  providentfundAmountID,
string  employeeID,
decimal  employeeContributionAmount,
decimal  companyContributionAmount,
DateTime  payrollDate,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ProvidentfundAmountID = providentfundAmountID;
this.EmployeeID = employeeID;
this.EmployeeContributionAmount = employeeContributionAmount;
this.CompanyContributionAmount = companyContributionAmount;
this.PayrollDate = payrollDate;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ProvidentfundAmountID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public decimal  EmployeeContributionAmount
    {
        get ; 
        set  ;
    }

    public decimal  CompanyContributionAmount
    {
        get ; 
        set  ;
    }

    public DateTime  PayrollDate
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

