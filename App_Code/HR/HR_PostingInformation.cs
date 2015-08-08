using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_PostingInformation
{
    public HR_PostingInformation()
    {
    }


    public HR_PostingInformation
        (
int  postingInformationID,
string  employeeID,
string  department,
string  designation,
string  jobLocation,
string  supervisor,
DateTime  joningDate,
string  status,
DateTime  findingDate,
DateTime  postingDate,
string  jobResponsibily,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.PostingInformationID = postingInformationID;
this.EmployeeID = employeeID;
this.Department = department;
this.Designation = designation;
this.JobLocation = jobLocation;
this.Supervisor = supervisor;
this.JoningDate = joningDate;
this.Status = status;
this.FindingDate = findingDate;
this.PostingDate = postingDate;
this.JobResponsibily = jobResponsibily;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  PostingInformationID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  Department
    {
        get ; 
        set  ;
    }

    public string  Designation
    {
        get ; 
        set  ;
    }

    public string  JobLocation
    {
        get ; 
        set  ;
    }

    public string  Supervisor
    {
        get ; 
        set  ;
    }

    public DateTime  JoningDate
    {
        get ; 
        set  ;
    }

    public string  Status
    {
        get ; 
        set  ;
    }

    public DateTime  FindingDate
    {
        get ; 
        set  ;
    }

    public DateTime  PostingDate
    {
        get ; 
        set  ;
    }

    public string  JobResponsibily
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

