using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_CalenderHolidays
{
    public HR_CalenderHolidays()
    {
    }


    public HR_CalenderHolidays
        (
int  holyDayID,
string  holyDayName,
DateTime  startDate,
DateTime  endDate,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.HolyDayID = holyDayID;
this.HolyDayName = holyDayName;
this.StartDate = startDate;
this.EndDate = endDate;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  HolyDayID
    {
        get ; 
        set  ;
    }

    public string  HolyDayName
    {
        get ; 
        set  ;
    }

    public DateTime  StartDate
    {
        get ; 
        set  ;
    }

    public DateTime  EndDate
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

