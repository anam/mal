using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_JobResponsibility
{
    public HR_JobResponsibility()
    {
    }


    public HR_JobResponsibility
        (
int  jobResponsibilityID,
string  jobResponsibilityName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.JobResponsibilityID = jobResponsibilityID;
this.JobResponsibilityName = jobResponsibilityName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  JobResponsibilityID
    {
        get ; 
        set  ;
    }

    public string  JobResponsibilityName
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

