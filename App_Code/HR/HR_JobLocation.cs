using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_JobLocation
{
    public HR_JobLocation()
    {
    }


    public HR_JobLocation
        (
int  jobLocationID,
string  jobLocationName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.JobLocationID = jobLocationID;
this.JobLocationName = jobLocationName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  JobLocationID
    {
        get ; 
        set  ;
    }

    public string  JobLocationName
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

