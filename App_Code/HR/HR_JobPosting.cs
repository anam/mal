using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_JobPosting
{
    public HR_JobPosting()
    {
    }


    public HR_JobPosting
        (
int  jobPostingID,
string  employeeID,
int  departmentID,
int  designationID,
DateTime  joinDate,
DateTime  endDate,
string  postingStatus,
string  jobLocation,
string  supervisorID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.JobPostingID = jobPostingID;
this.EmployeeID = employeeID;
this.DepartmentID = departmentID;
this.DesignationID = designationID;
this.JoinDate = joinDate;
this.EndDate = endDate;
this.PostingStatus = postingStatus;
this.JobLocation = jobLocation;
this.SupervisorID = supervisorID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  JobPostingID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  DepartmentID
    {
        get ; 
        set  ;
    }

    public int  DesignationID
    {
        get ; 
        set  ;
    }

    public DateTime  JoinDate
    {
        get ; 
        set  ;
    }

    public DateTime  EndDate
    {
        get ; 
        set  ;
    }

    public string  PostingStatus
    {
        get ; 
        set  ;
    }

    public string  JobLocation
    {
        get ; 
        set  ;
    }

    public string  SupervisorID
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

