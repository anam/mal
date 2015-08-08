using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Package
{
    public HR_Package()
    {
    }


    public HR_Package
        (
int  packageID,
string  packageName,
int  packageValue

        )

    {
this.PackageID = packageID;
this.PackageName = packageName;
this.PackageValue = packageValue;

    }

    public int  PackageID
    {
        get ; 
        set  ;
    }

    public string  PackageName
    {
        get ; 
        set  ;
    }

    public int  PackageValue
    {
        get ; 
        set  ;
    }

}

