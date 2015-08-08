using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_EmployeeOverTimePackage
{
    public HR_EmployeeOverTimePackage()
    {
    }


    public HR_EmployeeOverTimePackage
        (
int overTimeID,
string employeeID,
int overTimePackageID,
decimal overTimeTakaPerHour,
bool overTimeFlag,
string dayMonth,
DateTime overTimeDate,
string addedBy,
DateTime addedDate,
string modifiedBy,
DateTime modifiedDate

        )
    {
        this.OverTimeID = overTimeID;
        this.EmployeeID = employeeID;
        this.OverTimePackageID = overTimePackageID;
        this.OverTimeTakaPerHour = overTimeTakaPerHour;
        this.OverTimeFlag = overTimeFlag;
        this.DayMonth = dayMonth;
        this.OverTimeDate = overTimeDate;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;

    }

    public int OverTimeID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public int OverTimePackageID
    {
        get;
        set;
    }

    public decimal OverTimeTakaPerHour
    {
        get;
        set;
    }

    public bool OverTimeFlag
    {
        get;
        set;
    }

    public string DayMonth
    {
        get;
        set;
    }

    public DateTime OverTimeDate
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

