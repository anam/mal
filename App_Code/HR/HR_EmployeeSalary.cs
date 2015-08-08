using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EmployeeSalary
{
    public HR_EmployeeSalary()
    {
    }


    public HR_EmployeeSalary (
                        int employeeSalaryID,
                        string employeeID,
                        bool isGross,
                        decimal basicAmount,
                        decimal grossAmount,
                        bool isActive,
                        string addedBy,
                        DateTime addedDate,
                        string modifiedBy,
                        DateTime modifiedDate
        )
    {
        this.EmployeeSalaryID = employeeSalaryID;
        this.EmployeeID = employeeID;
        this.IsGross = isGross;
        this.BasicAmount = basicAmount;
        this.GrossAmount = grossAmount;
        this.IsActive = isActive;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;

    }

    public int EmployeeSalaryID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public bool IsGross
    {
        get;
        set;
    }

    public decimal BasicAmount
    {
        get;
        set;
    }

    public decimal GrossAmount
    {
        get;
        set;
    }

    public bool IsActive
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

