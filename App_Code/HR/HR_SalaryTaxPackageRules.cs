using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryTaxPackageRules
{
    public HR_SalaryTaxPackageRules()
    {
    }


    public HR_SalaryTaxPackageRules
        (
int  salaryTaxPackageRulesID,
string  employeeID,
int  salaryTaxPackageID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SalaryTaxPackageRulesID = salaryTaxPackageRulesID;
this.EmployeeID = employeeID;
this.SalaryTaxPackageID = salaryTaxPackageID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SalaryTaxPackageRulesID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  SalaryTaxPackageID
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

