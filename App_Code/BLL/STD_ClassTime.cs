using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassTime
{
    public STD_ClassTime()
    {
    }


    public STD_ClassTime
        (
int  classTimeID,
string  classTimeName,
decimal  duration,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate,
int  order,
int  classTimeGroupID,
string  startTime,
string  endTime,
string  extraField1,
string  extraField2,
string  extraField3,
string  extraField4,
string  extraField5,
int  rowStatusID

        )

    {
this.ClassTimeID = classTimeID;
this.ClassTimeName = classTimeName;
this.Duration = duration;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;
this.Order = order;
this.ClassTimeGroupID = classTimeGroupID;
this.StartTime = startTime;
this.EndTime = endTime;
this.ExtraField1 = extraField1;
this.ExtraField2 = extraField2;
this.ExtraField3 = extraField3;
this.ExtraField4 = extraField4;
this.ExtraField5 = extraField5;
this.RowStatusID = rowStatusID;

    }

    public int  ClassTimeID
    {
        get ; 
        set  ;
    }

    public string  ClassTimeName
    {
        get ; 
        set  ;
    }

    public decimal  Duration
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

    public int  Order
    {
        get ; 
        set  ;
    }

    public int  ClassTimeGroupID
    {
        get ; 
        set  ;
    }

    public string  StartTime
    {
        get ; 
        set  ;
    }

    public string  EndTime
    {
        get ; 
        set  ;
    }

    public string  ExtraField1
    {
        get ; 
        set  ;
    }

    public string  ExtraField2
    {
        get ; 
        set  ;
    }

    public string  ExtraField3
    {
        get ; 
        set  ;
    }

    public string  ExtraField4
    {
        get ; 
        set  ;
    }

    public string  ExtraField5
    {
        get ; 
        set  ;
    }

    public int  RowStatusID
    {
        get ; 
        set  ;
    }

    public bool IsEnabled
    {
        get;
        set;
    }

    public string CaseForDisabled
    {
        get;
        set;
    }
    public string ClassTimeGroupName
    {
        get;
        set;
    }

}

