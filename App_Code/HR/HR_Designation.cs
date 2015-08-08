using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Designation
{
    public HR_Designation()
    {
    }


    public HR_Designation
        (
int  designationID,
string  designationName,
int  departmentID,
string  supervisor,
string  jobResponsibility,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.DesignationID = designationID;
this.DesignationName = designationName;
this.DepartmentID = departmentID;
this.Supervisor = supervisor;
this.JobResponsibility = jobResponsibility;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  DesignationID
    {
        get ; 
        set  ;
    }

    public string  DesignationName
    {
        get ; 
        set  ;
    }

    public int  DepartmentID
    {
        get ; 
        set  ;
    }

    public string  Supervisor
    {
        get ; 
        set  ;
    }

    public string  JobResponsibility
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

