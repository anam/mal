using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Benefit
{
    public HR_Benefit()
    {
    }


    public HR_Benefit(
        int benefitPackageID,
        string employeeID,
        string benefitPackageName,
        int bonus,
        string rules,
        string addedBy,
        DateTime addedDate,
        string modifiedBy,
        DateTime modifiedDate
        )
    {
        this.BenefitPackageID = benefitPackageID;
        this.EmployeeID = employeeID;
        this.BenefitPackageName = benefitPackageName;
        this.Bonus = bonus;
        this.Rules = rules;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int BenefitPackageID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public string BenefitPackageName
    {
        get;
        set;
    }

    public int Bonus
    {
        get;
        set;
    }

    public string Rules
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

