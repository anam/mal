using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_BenifitPackage
{
    public HR_BenifitPackage()
    {

    }


    public HR_BenifitPackage
        (
        int benifitPackageID,
        string benifitPackageName,
        int benifitTimesYear,
        string bebifitFormula,
        bool isGrossBenifit,
        string addedBy,
        DateTime addedDate,
        string modifiedBy,
        DateTime modifiedDate

        )
    {
        this.BenifitPackageID = benifitPackageID;
        this.BenifitPackageName = benifitPackageName;
        this.BenifitTimesYear = benifitTimesYear;
        this.BebifitFormula = bebifitFormula;
        this.IsGrossBenifit = isGrossBenifit;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int BenifitPackageID
    {
        get;
        set;
    }

    public string BenifitPackageName
    {
        get;
        set;
    }

    public int BenifitTimesYear
    {
        get;
        set;
    }

    public string BebifitFormula
    {
        get;
        set;
    }

    public bool IsGrossBenifit
    {
        get;
        set;
    }

    public string AddedBy
    {
        get;
        set;
    }
    public DateTime AddedDate
    {
        get;
        set;
    }

    public string ModifiedBy
    {
        get;
        set;
    }
    public DateTime ModifiedDate
    {
        get;
        set;
    }

}

