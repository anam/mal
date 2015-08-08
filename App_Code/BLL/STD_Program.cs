using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Program
{
    public STD_Program()
    {
    }


    public STD_Program
        (
int  programID,
string  programName,
int  courseID,
string  description,
decimal  duration,
decimal  cost,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ProgramID = programID;
this.ProgramName = programName;
this.CourseID = courseID;
this.Description = description;
this.Duration = duration;
this.Cost = cost;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ProgramID
    {
        get ; 
        set  ;
    }

    public string  ProgramName
    {
        get ; 
        set  ;
    }

    public int  CourseID
    {
        get ; 
        set  ;
    }


    
    public string  Description
    {
        get ; 
        set  ;
    }

    public decimal  Duration
    {
        get ; 
        set  ;
    }

    public decimal  Cost
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

