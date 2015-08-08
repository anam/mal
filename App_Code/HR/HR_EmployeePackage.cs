using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EmployeePackage
{
    public HR_EmployeePackage()
    {
    }


    public HR_EmployeePackage
        (
int  employeePackageID,
string  packageName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.EmployeePackageID = employeePackageID;
this.PackageName = packageName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  EmployeePackageID
    {
        get ; 
        set  ;
    }

    public string  PackageName
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

