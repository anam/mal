using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_LunchRule
{
    public HR_LunchRule()
    {
    }


    public HR_LunchRule
        (
            int lunchRuleID,
            string employeeID,
            DateTime lunchTimeStart,
            DateTime lunchTimeEnd,
            int lunchFlexibleTimeMins,
            int lunchTimeAllowed,
            bool lunchFlag,
            string addedBy,
            DateTime addedDate,
            string modifiedBy,
            DateTime modifiedDate
        )
    {
        this.LunchRuleID = lunchRuleID;
        this.EmployeeID = employeeID;
        this.LunchTimeStart = lunchTimeStart;
        this.LunchTimeEnd = lunchTimeEnd;
        this.LunchFlexibleTimeMins = lunchFlexibleTimeMins;
        this.LunchTimeAllowed = lunchTimeAllowed;
        this.LunchFlag = lunchFlag;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int LunchRuleID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public DateTime LunchTimeStart
    {
        get;
        set;
    }

    public DateTime LunchTimeEnd
    {
        get;
        set;
    }


    public int LunchFlexibleTimeMins
    {
        get;
        set;
    }

    public int LunchTimeAllowed
    {
        get;
        set;
    }

    public bool LunchFlag
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

