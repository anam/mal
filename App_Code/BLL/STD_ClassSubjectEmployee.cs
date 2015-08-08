using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_ClassSubjectEmployee
{
    public STD_ClassSubjectEmployee()
    {
    }


    public STD_ClassSubjectEmployee
        (
int  classSubjectEmployeeID,
string  classSubjectEmployeeName,
string  employeeID,
int  classSubjectID,
string  addedBy,
DateTime  addedDate,
string  updatedBy,
DateTime  updateDate

        )

    {
this.ClassSubjectEmployeeID = classSubjectEmployeeID;
this.ClassSubjectEmployeeName = classSubjectEmployeeName;
this.EmployeeID = employeeID;
this.ClassSubjectID = classSubjectID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.UpdatedBy = updatedBy;
this.UpdateDate = updateDate;

    }

    public int  ClassSubjectEmployeeID
    {
        get ; 
        set  ;
    }

    public string  ClassSubjectEmployeeName
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public int  ClassSubjectID
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

