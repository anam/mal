using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryIncrementPackage
{
    public HR_SalaryIncrementPackage()
    {
    }


    public HR_SalaryIncrementPackage
        (
int  salaryIncrementPackageID,
string  salaryIncrementPackageName,
string  salaryIncrementFormula,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SalaryIncrementPackageID = salaryIncrementPackageID;
this.SalaryIncrementPackageName = salaryIncrementPackageName;
this.SalaryIncrementFormula = salaryIncrementFormula;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SalaryIncrementPackageID
    {
        get ; 
        set  ;
    }

    public string  SalaryIncrementPackageName
    {
        get ; 
        set  ;
    }

    public string  SalaryIncrementFormula
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

