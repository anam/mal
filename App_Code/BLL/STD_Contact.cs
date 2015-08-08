using System;
using System.Data;
using System.Configuration;
using System.Linq;

public class STD_Contact
{
    public STD_Contact()
    {
    }


    public STD_Contact
        (
int  contactID,
string  studentID,
string  name,
string  cellNo,
string  occupation,
string  officeTel,
string  officeAddress,
int  contactTypeID,
string  addedBy,
DateTime  addedDate,
string  modifiedBy,
DateTime  modifiedDate,
        int rowStatusID

        )

    {
this.ContactID = contactID;
this.StudentID = studentID;
this.Name = name;
this.CellNo = cellNo;
this.Occupation = occupation;
this.OfficeTel = officeTel;
this.OfficeAddress = officeAddress;
this.ContactTypeID = contactTypeID;
this.AddedBy = addedBy;
this.AddedDate = addedDate;
this.ModifiedBy = modifiedBy;
this.ModifiedDate = modifiedDate;
this.RowStatusID = rowStatusID;

    }

    public int  ContactID
    {
        get ; 
        set  ;
    }

    public string  StudentID
    {
        get ; 
        set  ;
    }

    public string  Name
    {
        get ; 
        set  ;
    }

    public string  CellNo
    {
        get ; 
        set  ;
    }

    public string  Occupation
    {
        get ; 
        set  ;
    }

    public string  OfficeTel
    {
        get ; 
        set  ;
    }

    public string  OfficeAddress
    {
        get ; 
        set  ;
    }

    public int  ContactTypeID
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

    public int RowStatusID
    {
        get;
        set;
    }

    public string StudentName
    {
        get;
        set;
    }

    public string ContactTypeName
    {
        get
        {
            if (ContactTypeID > 0)
                return STD_ContactTypeManager.GetSTD_ContactTypeByContactTypeID(ContactTypeID).ContactTypeName;
            return string.Empty;
        }
    }
}

