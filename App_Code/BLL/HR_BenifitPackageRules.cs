using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_BenifitPackageRules
{
    public HR_BenifitPackageRules()
    {
    }

    public HR_BenifitPackageRules(int benifitPackageRulesID, string employeeID, int benifitPackageID)
    {
        this.BenifitPackageRulesID = benifitPackageRulesID;
        this.BenifitPackageID = benifitPackageID;
        this.EmployeeID = employeeID;
    }

    public int BenifitPackageRulesID
    {
        get;
        set;
    }


    public int BenifitPackageID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }
}

