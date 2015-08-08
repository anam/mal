using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_ShiftingWorkingDays
{
    public HR_ShiftingWorkingDays()
    {
    }


    public HR_ShiftingWorkingDays
        (
int  shiftingWorkingDaysID,
string  shiftingWorkingDaysName,
string  shiftStartTime,
string  shiftEndTime,
string  description,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.ShiftingWorkingDaysID = shiftingWorkingDaysID;
this.ShiftingWorkingDaysName = shiftingWorkingDaysName;
this.ShiftStartTime = shiftStartTime;
this.ShiftEndTime = shiftEndTime;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  ShiftingWorkingDaysID
    {
        get ; 
        set  ;
    }

    public string  ShiftingWorkingDaysName
    {
        get ; 
        set  ;
    }

    public string  ShiftStartTime
    {
        get ; 
        set  ;
    }

    public string  ShiftEndTime
    {
        get ; 
        set  ;
    }

    public string  Description
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

    public string  ModifiedBy
    {
        get ; 
        set  ;
    }

    public DateTime  ModifiedDate
    {
        get ; 
        set  ;
    }

}

