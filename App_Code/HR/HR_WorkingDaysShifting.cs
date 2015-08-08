using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_WorkingDaysShifting
{
    public HR_WorkingDaysShifting()
    {
    }


    public HR_WorkingDaysShifting
        (
            int workingDaysID,
            string employeeID,
            bool saturday,
            bool sunday,
            bool monday,
            bool tuesday,
            bool wednesday,
            bool thrusday,
            bool friday,
            DateTime shiftStartTime,
            DateTime shiftEndTime,
            string description,
            string addedBy,
            DateTime addedDate,
            string modifiedBy,
            DateTime modifiedDate
        )
    {
        this.WorkingDaysID = workingDaysID;
        this.EmployeeID = employeeID;
        this.Saturday = saturday;
        this.Sunday = sunday;
        this.Monday = monday;
        this.Tuesday = tuesday;
        this.Wednesday = wednesday;
        this.Thrusday = thrusday;
        this.Friday = friday;
        this.ShiftStartTime = shiftStartTime;
        this.ShiftEndTime = shiftEndTime;
        this.Description = description;
        this.AddedBy = addedBy;
        this.AddedDate = addedDate;
        this.ModifiedBy = modifiedBy;
        this.ModifiedDate = modifiedDate;
    }

    public int WorkingDaysID
    {
        get;
        set;
    }

    public string EmployeeID
    {
        get;
        set;
    }

    public bool Saturday
    {
        get;
        set;
    }

    public bool Sunday
    {
        get;
        set;
    }

    public bool Monday
    {
        get;
        set;
    }

    public bool Tuesday
    {
        get;
        set;
    }

    public bool Wednesday
    {
        get;
        set;
    }

    public bool Thrusday
    {
        get;
        set;
    }

    public bool Friday
    {
        get;
        set;
    }

    public DateTime ShiftStartTime
    {
        get;
        set;
    }

    public DateTime ShiftEndTime
    {
        get;
        set;
    }

    public string Description
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

