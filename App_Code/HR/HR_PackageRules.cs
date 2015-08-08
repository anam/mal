using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_PackageRules
{
    public HR_PackageRules()
    {
    }


    public HR_PackageRules
        (
int  packageRulesID,
string  packageRulesName,
int  packageID,
int  rulesValue,
string  rulesOperator,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updatedDate

        )

    {
this.PackageRulesID = packageRulesID;
this.PackageRulesName = packageRulesName;
this.PackageID = packageID;
this.RulesValue = rulesValue;
this.RulesOperator = rulesOperator;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdatedDate = updatedDate;

    }

    public int  PackageRulesID
    {
        get ; 
        set  ;
    }

    public string  PackageRulesName
    {
        get ; 
        set  ;
    }

    public int  PackageID
    {
        get ; 
        set  ;
    }

    public int  RulesValue
    {
        get ; 
        set  ;
    }

    public string  RulesOperator
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

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdatedDate
    {
        get ; 
        set  ;
    }

}

