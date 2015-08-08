using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_JobExperience
{
    public HR_JobExperience()
    {
    }


    public HR_JobExperience
        (
int  jobExperienceID,
string userID,
string  organization,
string  position,
string natureofWork,
DateTime  yearStart,
DateTime  yearEnd,
string  reasonForLeaving,
string  contactPerson,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.JobExperienceID = jobExperienceID;
this.userID = userID;
this.Organization = organization;
this.Position = position;
this.NatureofWork = natureofWork;
this.YearStart = yearStart;
this.YearEnd = yearEnd;
this.ReasonForLeaving = reasonForLeaving;
this.ContactPerson = contactPerson;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public string EmployeeID
    {
        get;
        set;
    }


    public int  JobExperienceID
    {
        get ; 
        set  ;
    }

    public string userID
    {
        get ; 
        set  ;
    }

    public string  Organization
    {
        get ; 
        set  ;
    }

    public string  Position
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

    public string  ReasonForLeaving
    {
        get ; 
        set  ;
    }

    public string  ContactPerson
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


    public string NatureofWork
    { 
        get;
        set;
    }

    
}

