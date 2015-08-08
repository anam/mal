using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_SalaryPackage
{
    public HR_SalaryPackage()
    {
    }


    public HR_SalaryPackage
        (
int  salaryPackageID,
string  salaryPackageName,
int  departmentID,
string  rank,
decimal  ratio,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.SalaryPackageID = salaryPackageID;
this.SalaryPackageName = salaryPackageName;
this.DepartmentID = departmentID;
this.Rank = rank;
this.Ratio = ratio;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  SalaryPackageID
    {
        get ; 
        set  ;
    }

    public string  SalaryPackageName
    {
        get ; 
        set  ;
    }

    public int  DepartmentID
    {
        get ; 
        set  ;
    }

    public string  Rank
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

}

