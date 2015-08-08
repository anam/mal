using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryTaxPackage
{
    public HR_SalaryTaxPackage()
    {
    }


    public HR_SalaryTaxPackage
        (
int  salaryTaxPackagePackageID,
string  salaryTaxPackagePackageName,
string  salaryTaxPackageFormula,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SalaryTaxPackagePackageID = salaryTaxPackagePackageID;
this.SalaryTaxPackagePackageName = salaryTaxPackagePackageName;
this.SalaryTaxPackageFormula = salaryTaxPackageFormula;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SalaryTaxPackagePackageID
    {
        get ; 
        set  ;
    }

    public string  SalaryTaxPackagePackageName
    {
        get ; 
        set  ;
    }

    public string  SalaryTaxPackageFormula
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

