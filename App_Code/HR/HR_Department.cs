using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Department
{
    public HR_Department()
    {
    }


    public HR_Department
        (
int  departmentID,
string  departmentName,
string  jobLocation,
string  description,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.DepartmentID = departmentID;
this.DepartmentName = departmentName;
this.JobLocation = jobLocation;
this.Description = description;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  DepartmentID
    {
        get ; 
        set  ;
    }

    public string  DepartmentName
    {
        get ; 
        set  ;
    }

    public string  JobLocation
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

