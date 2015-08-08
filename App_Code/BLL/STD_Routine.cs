using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Routine
{
    public STD_Routine()
    {
    }


    public STD_Routine
        (
int  routineID,
string  routineName,
DateTime  startDate,
DateTime  endDate,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.RoutineID = routineID;
this.RoutineName = routineName;
this.StartDate = startDate;
this.EndDate = endDate;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  RoutineID
    {
        get ; 
        set  ;
    }

    public string  RoutineName
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

