using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Year
{
    public HR_Year()
    {
    }


    public HR_Year
        (
int  yearID,
DateTime  yearStart,
DateTime  yearEnd,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.YearID = yearID;
this.YearStart = yearStart;
this.YearEnd = yearEnd;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  YearID
    {
        get ; 
        set  ;
    }

    public DateTime  YearStart
    {
        get ; 
        set  ;
    }

    public DateTime  YearEnd
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

