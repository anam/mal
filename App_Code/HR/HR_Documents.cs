using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_Documents
{
    public HR_Documents()
    {
    }


    public HR_Documents
        (
int  documentsID,
string  employeeID,
string  cvDocs,
string  jobAgreement,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.DocumentsID = documentsID;
this.EmployeeID = employeeID;
this.CvDocs = cvDocs;
this.JobAgreement = jobAgreement;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  DocumentsID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  CvDocs
    {
        get ; 
        set  ;
    }

    public string  JobAgreement
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

