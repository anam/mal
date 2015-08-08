using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Course
{
    public STD_Course()
    {
    }


    public STD_Course
        (
int  courseID,
string  courseName,
string  description,
string  duration,
decimal  cost,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.CourseID = courseID;
this.CourseName = courseName;
this.Description = description;
this.Duration = duration;
this.Cost = cost;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  CourseID
    {
        get ; 
        set  ;
    }

    public string  CourseName
    {
        get ; 
        set  ;
    }

    public string  Description
    {
        get ; 
        set  ;
    }

    public string  Duration
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

