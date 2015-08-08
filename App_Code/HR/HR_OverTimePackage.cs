using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_OverTimePackage
{
    public HR_OverTimePackage()
    {
    }


    public HR_OverTimePackage
        (
int  overTimePackageID,
string  overTimePackageName,
string  overTimeFormula,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.OverTimePackageID = overTimePackageID;
this.OverTimePackageName = overTimePackageName;
this.OverTimeFormula = overTimeFormula;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  OverTimePackageID
    {
        get ; 
        set  ;
    }

    public string  OverTimePackageName
    {
        get ; 
        set  ;
    }

    public string  OverTimeFormula
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

