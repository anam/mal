using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class HR_OthersDocuments
{
    public HR_OthersDocuments()
    {
    }


    public HR_OthersDocuments
        (
int  othersDocumentsID,
string  employeeID,
string  documentsType,
string  documentName,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate

        )

    {
this.OthersDocumentsID = othersDocumentsID;
this.EmployeeID = employeeID;
this.DocumentsType = documentsType;
this.DocumentName = documentName;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;

    }

    public int  OthersDocumentsID
    {
        get ; 
        set  ;
    }

    public string  EmployeeID
    {
        get ; 
        set  ;
    }

    public string  DocumentsType
    {
        get ; 
        set  ;
    }

    public string  DocumentName
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

