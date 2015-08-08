using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_RoutineTime
{
    public STD_RoutineTime()
    {
    }


    public STD_RoutineTime
        (
int  routineTimeID,
string  routineTimeName,
int  roomID,
int  subjectID,
string  employeeID,
int  classID,
int  classDayID,
int  classTimeID,
int  routineID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.RoutineTimeID = routineTimeID;
this.RoutineTimeName = routineTimeName;
this.RoomID = roomID;
this.SubjectID = subjectID;
this.EmployeeID = employeeID;
this.ClassID = classID;
this.ClassDayID = classDayID;
this.ClassTimeID = classTimeID;
this.RoutineID = routineID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  RoutineTimeID
    {
        get ; 
        set  ;
    }

    public string  RoutineTimeName
    {
        get ; 
        set  ;
    }

    public int  RoomID
    {
        get ; 
        set  ;
    }

    public int  SubjectID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  ClassID
    {
        get ; 
        set  ;
    }

    public int  ClassDayID
    {
        get ; 
        set  ;
    }

    public int  ClassTimeID
    {
        get ; 
        set  ;
    }

    public int  RoutineID
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

    public string RoomName
    {
        get;
        set;
    }

    public string SubjectName
    {
        get;
        set;
    }

    public string EmployeeName
    {
        get;
        set;
    }

    public int ClassName
    {
        get;
        set;
    }

    public int ClassDayName
    {
        get;
        set;
    }

    public int ClassTimeName
    {
        get;
        set;
    }

    public int RoutineName
    {
        get;
        set;
    }

    public bool IsMarked
    {
        get;
        set;
    }

}

