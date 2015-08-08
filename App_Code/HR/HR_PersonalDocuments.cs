using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_PersonalDocuments
{
    public HR_PersonalDocuments()
    {
    }


    public HR_PersonalDocuments
        (
int  personalDocumentsID,
string  employeeID,
string  fileName,
string  fileLocationUrl,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.PersonalDocumentsID = personalDocumentsID;
this.EmployeeID = employeeID;
this.FileName = fileName;
this.FileLocationUrl = fileLocationUrl;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  PersonalDocumentsID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  FileName
    {
        get ; 
        set  ;
    }

    public string  FileLocationUrl
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

