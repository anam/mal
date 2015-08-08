using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_EducationGroup
{
    public STD_EducationGroup()
    {
    }


    public STD_EducationGroup
        (
int  educationGroupID,
string  educationGroupName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.EducationGroupID = educationGroupID;
this.EducationGroupName = educationGroupName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  EducationGroupID
    {
        get ; 
        set  ;
    }

    public string  EducationGroupName
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

