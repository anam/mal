using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EmployeeSalaryRules
{
    public HR_EmployeeSalaryRules()
    {
    }


    public HR_EmployeeSalaryRules
        (
int employeeSalaryPackageRulesID,
string employeeID,
int packageRulesID,
string addedBy,
DateTime addedDate,
string updatedBy,
DateTime updatedDate

        )
    {
        this.EmployeeSalaryPackageRulesID = employeeSalaryPackageRulesID;
        this.EmployeeID = employeeID;
        this.PackageRulesID = packageRulesID;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.UpdatedBy = updatedBy;
        this.UpdatedDate = updatedDate;

    }

    public int EmployeeSalaryPackageRulesID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public int PackageRulesID
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

    public string UpdatedBy
    {
        get;
        set;
    }

    public DateTime UpdatedDate
    {
        get;
        set;
    }

}

