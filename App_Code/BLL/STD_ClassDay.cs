using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassDay
{
    public STD_ClassDay()
    {
    }


    public STD_ClassDay
        (
int  classDayID,
string  classDayName,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ClassDayID = classDayID;
this.ClassDayName = classDayName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ClassDayID
    {
        get ; 
        set  ;
    }

    public string  ClassDayName
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

    public string  UpdatedBy
    {
        get ; 
        set  ;
    }

    public DateTime  UpdateDate
    {
        get ; 
        set  ;
    }

}

